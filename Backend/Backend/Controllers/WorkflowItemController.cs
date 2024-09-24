using Backend.DTOs;
using Backend.Logics;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkflowItemController : ControllerBase
    {
        private IWorkflowItemLogic _logic;

        public WorkflowItemController(IWorkflowItemLogic logic)
        {
            _logic = logic;
        }

        [HttpGet("wf/{taskitemid}")]
        [Authorize]
        public WorkflowItem GetWorkflowByTaskItem(string taskitemid)
        {
            return _logic.GetWorkflowByTaskItem(taskitemid);
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<WorkflowItem> GetWorkflowItems()
        {
            return _logic.Read();
        }

        [HttpGet("{id}")]
        [Authorize]
        public WorkflowItem GetWorkflowItem(string id)
        {
            return _logic.Read(id);
        }

        [HttpPost]
        [Authorize]
        public async Task CreateWorkflowItemAsync([FromBody] CreateWorkflowItemDto createDto)
        {
            await _logic.CreateAsync(createDto);
        }

        [HttpPost("mul/")]
        [Authorize]
        public async Task<ActionResult> CreateWorkflowItemsAsync([FromBody] IEnumerable<CreateWorkflowItemDto> createDto)
        {
            foreach (var item in createDto)
            {
                await _logic.CreateAsync(item);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public void DeleteWorkflowItem(string id)
        {
            
            _logic.Delete(id);
        }

        [HttpPut]
        [Authorize]
        public void UpdateWorkflowItem([FromBody] WorkflowItem workflowItem)
        {
            _logic.Update(workflowItem);
        }

        [HttpPut("mul/")]
        [Authorize]
        public async Task<ActionResult> UpdateWorkflowItemsAsync([FromBody] IEnumerable<WorkflowItem> workflowItems)
        {
            foreach(var item in workflowItems)
            {
                await _logic.UpdateAsync(item);
            }

            return Ok();
        }
    }
}
