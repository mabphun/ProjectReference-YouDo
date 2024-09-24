using Backend.DTOs;
using Backend.Models;

namespace Backend.Logics
{
    public interface IWorkflowItemLogic
    {
        Task CreateAsync(CreateWorkflowItemDto createDto);
        void Create(WorkflowItem workflowItem);
        void Delete(string id);
        IEnumerable<WorkflowItem> Read();
        WorkflowItem Read(string id);
        void Update(WorkflowItem workflowItem);
        Task UpdateAsync(WorkflowItem workflowItem);
        //Custom
        WorkflowItem GetWorkflowByTaskItem(string taskitemid);
    }
}