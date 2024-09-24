using Backend.DTOs;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class WorkflowItemRepository : IWorkflowItemRepository
    {
        private readonly AppDbContext _context;

        public WorkflowItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CreateWorkflowItemDto createDto)
        {
            WorkflowItem wf = new WorkflowItem()
            {
                Name = createDto.Name,
                IsActive = createDto.IsActive,
                Order = createDto.Order,
                TaskItemId = createDto.TaskItemId,
                IsDeletable = true,
            };

            var old = await _context.WorkflowItems.FirstOrDefaultAsync(x => x.Id == wf.Id);
            if (old != null) throw new ArgumentException("There's already a WorkflowItem with this id: " + wf.Id);
            
            _context.WorkflowItems.Add(wf);
            await _context.SaveChangesAsync();
        }

        public void Create(WorkflowItem workflowItem)
        {
            var old = _context.WorkflowItems.FirstOrDefault(t => t.Id == workflowItem.Id);
            if (old != null)
            {
                throw new ArgumentException("There's already a WorkflowItem with this id: " + workflowItem.Id);
            }

            if (workflowItem.Order <= 0)
            {
                throw new ArgumentException("Order cannot be or less than zero.");
            }

            var sameOrder = _context.WorkflowItems
                .Where(x => x.TaskItemId == workflowItem.TaskItemId 
                && x.Order == workflowItem.Order)
                .FirstOrDefault(); 
            if (sameOrder != null)
            {
                throw new ArgumentException("There cannot be more items with the same Order: " + workflowItem.Order);
            }

            

            _context.WorkflowItems.Add(workflowItem);
            _context.SaveChanges();
        }

        public IEnumerable<WorkflowItem> Read()
        {
            return _context.WorkflowItems;
        }

        public WorkflowItem Read(string id)
        {
            var workflowItem = _context.WorkflowItems.FirstOrDefault(t => t.Id == id);
            if (workflowItem == null)
            {
                throw new ArgumentException("There's no WorkflowItem with this id: " + id);
            }
            return workflowItem;
        }

        public void Delete(string id)
        {
            var workflowItem = _context.WorkflowItems.FirstOrDefault(t => t.Id == id);
            if (workflowItem == null)
            {
                throw new ArgumentException("There's no WorkflowItem with this id: " + id);
            }

            _context.WorkflowItems.Remove(workflowItem);
            _context.SaveChanges();
        }

        //public void Update(WorkflowItem workflowItem)
        //{
        //    ;
        //    var old = _context.WorkflowItems.FirstOrDefault(t => t.Id == workflowItem.Id);
        //    if (old == null)
        //    {
        //        throw new ArgumentException("There's no WorkflowItem with this id: " + workflowItem.Id);
        //    }

        //    //var sameOrder = _context.WorkflowItems
        //    //    .Where(x => x.TaskItemId == workflowItem.TaskItemId
        //    //    && x.Order == workflowItem.Order)
        //    //    .FirstOrDefault();
        //    //if (sameOrder != null)
        //    //{
        //    //    throw new ArgumentException("There cannot be more items with the same Order: " + workflowItem.Order);
        //    //}
        //    //Ha egy order egyezés van, akkor az összes ordert ami nagyobb-egyenlő mint az új eggyel megnöveljük, ezzel elkerülve az ütközést

        //    old.Name = workflowItem.Name;
        //    old.Order = workflowItem.Order;
        //    old.IsActive = workflowItem.IsActive;
            
        //    _context.SaveChanges();
        //}

        public async Task UpdateAsync(WorkflowItem item)
        {
            var old = await _context.WorkflowItems.FirstOrDefaultAsync(t => t.Id == item.Id);
            if (old == null)
            {
                throw new ArgumentException("There's no WorkflowItem with this id: " + item.Id);
            }
            old.Name = item.Name;
            old.Order = item.Order;
            old.IsActive = item.IsActive;
            
            await _context.SaveChangesAsync();
        }
    }
}
