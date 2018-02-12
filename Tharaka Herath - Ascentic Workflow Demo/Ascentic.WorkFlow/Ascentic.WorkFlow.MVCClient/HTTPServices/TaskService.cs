using Ascentic.WorkFlow.MVCClient.HTTPClient;
using Ascentic.WorkFlow.MVCClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Ascentic.WorkFlow.MVCClient.HTTPServices
{
    public class TaskService
    {
        public TaskService() { }

        /// <summary>
        /// Retrieve all the tasks.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TaskModel>> Get()
        {
            try
            {
                using (HttpClient client = HTTPClientFactory.GetClient())
                {
                    var apiResponse = await client.GetAsync("api/Task");
                    if (apiResponse.IsSuccessStatusCode)
                    {
                        return apiResponse.Content.ReadAsAsync<IEnumerable<TaskModel>>().Result;
                    }
                    else if (apiResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                    else
                    {
                        throw new Exception(apiResponse.StatusCode.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retrieve a task by taskId.
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public async Task<TaskModel> GetById(int taskId)
        {
            try
            {
                using (HttpClient client = HTTPClientFactory.GetClient())
                {
                    var apiResponse = await client.GetAsync("api/Task/" + taskId);
                    if (apiResponse.IsSuccessStatusCode)
                    {
                        return apiResponse.Content.ReadAsAsync<TaskModel>().Result;
                    }
                    else if (apiResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                    else
                    {
                        throw new Exception(apiResponse.StatusCode.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retrieve tasks for particular executive.
        /// </summary>
        /// <param name="assignee"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TaskModel>> GetByAssignee(string assignee)
        {
            try
            {
                using (HttpClient client = HTTPClientFactory.GetClient())
                {
                    var apiResponse = await client.GetAsync("api/Task?assignee=" + assignee);
                    if (apiResponse.IsSuccessStatusCode)
                    {
                        return apiResponse.Content.ReadAsAsync<IEnumerable<TaskModel>>().Result;
                    }
                    else if (apiResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                    else
                    {
                        throw new Exception(apiResponse.StatusCode.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Post a new task.
        /// </summary>
        /// <param name="taskToPost"></param>
        /// <returns></returns>
        public async Task<bool> Post(TaskModel taskToPost)
        {
            try
            {
                using (HttpClient client = HTTPClientFactory.GetClient())
                {
                    var apiResponse = await client.PostAsJsonAsync("api/Task/", taskToPost);
                    if (apiResponse.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception(apiResponse.StatusCode.ToString());
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
        public async Task<bool> Update(TaskModel taskToUpdate)
        {
            try
            {
                using (HttpClient client = HTTPClientFactory.GetClient())
                {
                    var apiResponse = await client.PutAsJsonAsync("api/Task/" + taskToUpdate.TaskId, taskToUpdate);
                    if (apiResponse.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception(apiResponse.StatusCode.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update the status of a task specified by TaskId.
        /// </summary>
        /// <param name="taskToUpdate"></param>
        /// <returns></returns>
        public async Task<bool> UpdateStatus(TaskModel taskToUpdate)
        {
            try
            {
                using (HttpClient client = HTTPClientFactory.GetClient())
                {
                    var apiResponse = await client.PutAsJsonAsync("api/Task/UpdateStatus", taskToUpdate);
                    if (apiResponse.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception(apiResponse.StatusCode.ToString());
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
        public async Task<bool> Delete(int taskId)
        {
            try
            {
                using (HttpClient client = HTTPClientFactory.GetClient())
                {
                    var apiResponse = await client.DeleteAsync("api/Task/" + taskId);
                    if (apiResponse.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception(apiResponse.StatusCode.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}