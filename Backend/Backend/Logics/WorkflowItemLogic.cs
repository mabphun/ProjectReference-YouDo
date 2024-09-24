using Backend.Data;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Logics
{
    public class WorkflowItemLogic : IWorkflowItemLogic
    {
        private readonly IWorkflowItemRepository _workflowItemRepo;
        private readonly ITaskItemRepository _taskItemRepo;

        public WorkflowItemLogic(IWorkflowItemRepository repo)
        {
            _workflowItemRepo = repo;
        }

        public async Task CreateAsync(CreateWorkflowItemDto createDto)
        {
            await _workflowItemRepo.CreateAsync(createDto);
        }

        public void Create(WorkflowItem workflowItem)
        {
            // Validations can be here
            _workflowItemRepo.Create(workflowItem);
        }

        public IEnumerable<WorkflowItem> Read()
        {
            return _workflowItemRepo.Read();
        }

        public WorkflowItem Read(string id)
        {
            return _workflowItemRepo.Read(id);
        }

        public void Delete(string id)
        {
            _workflowItemRepo.Delete(id);
        }

        public void Update(WorkflowItem workflowItem)
        {
            _workflowItemRepo.UpdateAsync(workflowItem);
        }

        public async Task UpdateAsync(WorkflowItem workflowItem)
        {
            await _workflowItemRepo.UpdateAsync(workflowItem);
        }

        public WorkflowItem GetWorkflowByTaskItem(string taskitemid)
        {
            var item = _workflowItemRepo
                .Read()
                .Where(x=> x.TaskItemId == taskitemid)
                .OrderBy(x => x.Order)
                .Where(x => x.IsActive)
                .FirstOrDefault();
            if (item == null)
            {
                return new WorkflowItem() 
                { 
                    Name = "Error! No active workflow item.",
                    Order = 0,
                    IsActive = true,
                    TaskItemId = taskitemid 
                };
            }
            return item;
        }
    }
}
