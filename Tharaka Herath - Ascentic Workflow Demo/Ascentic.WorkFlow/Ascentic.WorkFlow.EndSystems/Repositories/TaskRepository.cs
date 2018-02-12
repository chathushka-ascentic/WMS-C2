using Ascentic.WorkFlow.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ascentic.WorkFlow.Contracts.DTOs;
using System.Linq.Expressions;
using AutoMapper;
using Ascentic.WorkFlow.EndSystems.Common;
using Ascentic.WorkFlow.EndSystems.Entities;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Ascentic.WorkFlow.EndSystems.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public TaskRepository() { }

        /// <summary>
        /// Create a new task.
        /// </summary>
        /// <param name="taskToCreate"></param>
        /// <returns></returns>
        public async Task<int> Create(TaskDto taskToCreate)
        {
            try
            {
                if (taskToCreate != null)
                {
                    Entities.Task taskEntityToCreate = Mapper.Map<Entities.Task>(taskToCreate);
                    using (var context = new WorkFlowContext())
                    {
                        context.Task.Add(taskEntityToCreate);
                        return await context.SaveChangesAsync();
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retrieve a task if taskId is specified. If taskId is null then retrieve all the tasks.
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TaskDto>> Retrieve(int? taskId)
        {
            try
            {
                using (var context = new WorkFlowContext())
                {
                    IEnumerable<Entities.Task> taskEntities = taskId.HasValue
                        ? await context.Task.Where(t => t.TaskId == taskId && t.IsDeleted == false).ToListAsync()
                        : await context.Task.Where(t => t.IsDeleted == false).ToListAsync();
                    if (taskEntities.Count() > 0)
                    {
                        IEnumerable<TaskDto> taskDtos = Mapper.Map<IEnumerable<TaskDto>>(taskEntities);
                        return taskDtos;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retrieve tasks for particular executive
        /// </summary>
        /// <param name="assignee"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TaskDto>> RetrieveByAssignee(string assignee)
        {
            try
            {
                using (var context = new WorkFlowContext())
                {
                    IEnumerable<Entities.Task> taskEntities = await context.Task.Where(t => t.Assignee == assignee && t.IsDeleted == false).ToListAsync();
                    if (taskEntities.Count() > 0)
                    {
                        IEnumerable<TaskDto> taskDtos = Mapper.Map<IEnumerable<TaskDto>>(taskEntities);
                        return taskDtos;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update a task.
        /// </summary>
        /// <param name="taskToUpdate"></param>
        /// <returns></returns>
        public async Task<int> Update(int taskId, TaskDto taskToUpdate)
        {
            try
            {
                using (var context = new WorkFlowContext())
                {
                    Entities.Task taskToUpdateFromDb = await context.Task.FindAsync(taskId);
                    if (taskToUpdateFromDb != null)
                    {
                        taskToUpdateFromDb.Description = taskToUpdate.Description;
                        taskToUpdateFromDb.Assignee = taskToUpdate.Assignee;
                        taskToUpdateFromDb.AssignedBy = taskToUpdate.AssignedBy;
                        taskToUpdateFromDb.Status = taskToUpdate.Status;
                        taskToUpdateFromDb.AgreedCompletionDate = taskToUpdate.AgreedCompletionDate;

                        return await context.SaveChangesAsync();
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update the status of a task to In Progress or Done.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="taskToUpdate"></param>
        /// <returns></returns>
        public async Task<int> UpdateStatus(int taskId, TaskDto taskToUpdate)
        {
            try
            {
                if (taskToUpdate.Status != "Done")
                {
                    Entities.Task taskToDelete = new Entities.Task() { TaskId = taskId, Status = taskToUpdate.Status };
                    using (var context = new WorkFlowContext())
                    {
                        context.Task.Attach(taskToDelete);
                        context.Entry(taskToDelete).Property(t => t.Status).IsModified = true;
                        return await context.SaveChangesAsync();
                    }
                }
                else
                {
                    using (var context = new WorkFlowContext())
                    {
                        Entities.Task taskToUpdateFromDb = await context.Task.FindAsync(taskId);
                        if (taskToUpdateFromDb != null)
                        {
                            taskToUpdateFromDb.Status = taskToUpdate.Status;
                            taskToUpdateFromDb.ActualCompletionDate = taskToUpdate.ActualCompletionDate;

                            return await context.SaveChangesAsync();
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete a task.
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public async Task<int> Delete(int taskId)
        {
            try
            {
                Entities.Task taskToDelete = new Entities.Task() { TaskId = taskId, IsDeleted = true };
                using (var context = new WorkFlowContext())
                {
                    context.Task.Attach(taskToDelete);
                    context.Entry(taskToDelete).Property(t => t.IsDeleted).IsModified = true;
                    return await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
