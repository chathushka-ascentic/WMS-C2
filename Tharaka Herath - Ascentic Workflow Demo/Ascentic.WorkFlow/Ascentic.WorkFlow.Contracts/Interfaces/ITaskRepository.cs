using Ascentic.WorkFlow.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ascentic.WorkFlow.Contracts.Interfaces
{
    public interface ITaskRepository
    {
        Task<int> Create(TaskDto taskToCreate);
        Task<IEnumerable<TaskDto>> Retrieve(int? taskId);
        Task<IEnumerable<TaskDto>> RetrieveByAssignee(string assignee);
        Task<int> Update(int taskId, TaskDto taskToUpdate);
        Task<int> UpdateStatus(int taskId, TaskDto taskToUpdate);
        Task<int> Delete(int taskId);
    }
}
