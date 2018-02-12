using Ascentic.WorkFlow.Contracts.DTOs;
using Ascentic.WorkFlow.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ascentic.WorkFlow.API.Controllers
{
    public class TaskController : ApiController
    {
        private ITaskRepository TaskRepository { get; set; }

        public TaskController(ITaskRepository taskRepository)
        {
            if (taskRepository == null)
            {
                throw new ArgumentNullException("taskRepository");
            }

            TaskRepository = taskRepository;
        }

        // GET: api/Task
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                IEnumerable<TaskDto> taskDtos = await TaskRepository.Retrieve(null);
                if (taskDtos != null)
                {
                    return Ok(taskDtos);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Task/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                IEnumerable<TaskDto> taskDtos = await TaskRepository.Retrieve(id);
                if (taskDtos != null)
                {
                    return Ok(taskDtos.SingleOrDefault());
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Task?assignee={assignee}
        public async Task<IHttpActionResult> Get(string assignee)
        {
            try
            {
                IEnumerable<TaskDto> taskDtos = await TaskRepository.RetrieveByAssignee(assignee);
                if (taskDtos != null)
                {
                    return Ok(taskDtos);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Task
        public async Task<IHttpActionResult> Post(TaskDto taskToCreate)
        {
            try
            {
                if (taskToCreate != null)
                {
                    return Ok(await TaskRepository.Create(taskToCreate));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Task/5
        public async Task<IHttpActionResult> Put(int id, TaskDto taskToUpdate)
        {
            try
            {
                if (taskToUpdate != null)
                {
                    return Ok(await TaskRepository.Update(id,taskToUpdate));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Task/5
        [Route("api/Task/UpdateStatus/")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateStatus(TaskDto taskToUpdate)
        {
            try
            {
                if (taskToUpdate != null)
                {
                    return Ok(await TaskRepository.UpdateStatus(taskToUpdate.TaskId, taskToUpdate));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Task/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                return Ok(await TaskRepository.Delete(id));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
