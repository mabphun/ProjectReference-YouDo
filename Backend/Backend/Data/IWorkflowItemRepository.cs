using Backend.DTOs;
using Backend.Models;

namespace Backend.Data
{
    public interface IWorkflowItemRepository
    {
        void Create(WorkflowItem workflowItem);
        Task CreateAsync(CreateWorkflowItemDto createDto);
        void Delete(string id);
        IEnumerable<WorkflowItem> Read();
        WorkflowItem Read(string id);
        Task UpdateAsync(WorkflowItem workflowItem);
    }
}
