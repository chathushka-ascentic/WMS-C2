using Ascentic.WorkFlow.MVCClient.HTTPServices;
using Ascentic.WorkFlow.MVCClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ascentic.WorkFlow.MVCClient.Controllers
{
    public class ManagerController : Controller
    {
        TaskService taskService = new TaskService();

        public async Task<ActionResult> ToDoIndex()
        {
            try
            {
                IEnumerable<TaskModel> taskModels = await taskService.Get();
                if (taskModels != null)
                {
                    ViewBag.ToDoCount = taskModels.Where(t => t.Status == "To Do").Count();
                    ViewBag.InProgressCount = taskModels.Where(t => t.Status == "In Progress").Count();
                    ViewBag.DoneCount = taskModels.Where(t => t.Status == "Done").Count();
                    ViewBag.DelayedCount = taskModels.Where(t => t.Status != "Done" && t.AgreedCompletionDate < DateTime.Now.Date).Count();
                    return View(taskModels.Where(t => t.Status == "To Do").OrderBy(t => t.AgreedCompletionDate));
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["ExceptionText"] = "Error Occured, Please Contact the Administrator";
                return RedirectToAction("Index", "Exception");
            }
        }

        public async Task<ActionResult> InProgressIndex()
        {
            try
            {
                IEnumerable<TaskModel> taskModels = await taskService.Get();
                if (taskModels != null)
                {
                    ViewBag.ToDoCount = taskModels.Where(t => t.Status == "To Do").Count();
                    ViewBag.InProgressCount = taskModels.Where(t => t.Status == "In Progress").Count();
                    ViewBag.DoneCount = taskModels.Where(t => t.Status == "Done").Count();
                    ViewBag.DelayedCount = taskModels.Where(t => t.Status != "Done" && t.AgreedCompletionDate < DateTime.Now.Date).Count();
                    return View(taskModels.Where(t => t.Status == "In Progress").OrderBy(t => t.AgreedCompletionDate));
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["ExceptionText"] = "Error Occured, Please Contact the Administrator";
                return RedirectToAction("Index", "Exception");
            }
        }

        public async Task<ActionResult> DoneIndex()
        {
            try
            {
                IEnumerable<TaskModel> taskModels = await taskService.Get();
                if (taskModels != null)
                {
                    ViewBag.ToDoCount = taskModels.Where(t => t.Status == "To Do").Count();
                    ViewBag.InProgressCount = taskModels.Where(t => t.Status == "In Progress").Count();
                    ViewBag.DoneCount = taskModels.Where(t => t.Status == "Done").Count();
                    ViewBag.DelayedCount = taskModels.Where(t => t.Status != "Done" && t.AgreedCompletionDate < DateTime.Now.Date).Count();
                    return View(taskModels.Where(t => t.Status == "Done"));
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["ExceptionText"] = "Error Occured, Please Contact the Administrator";
                return RedirectToAction("Index", "Exception");
            }
        }

        public async Task<ActionResult> DelayedIndex()
        {
            try
            {
                IEnumerable<TaskModel> taskModels = await taskService.Get();
                if (taskModels != null)
                {
                    ViewBag.ToDoCount = taskModels.Where(t => t.Status == "To Do").Count();
                    ViewBag.InProgressCount = taskModels.Where(t => t.Status == "In Progress").Count();
                    ViewBag.DoneCount = taskModels.Where(t => t.Status == "Done").Count();
                    ViewBag.DelayedCount = taskModels.Where(t => t.Status != "Done" && t.AgreedCompletionDate < DateTime.Now.Date).Count();
                    return View(taskModels.Where(t => t.Status != "Done" && t.AgreedCompletionDate < DateTime.Now.Date));
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["ExceptionText"] = "Error Occured, Please Contact the Administrator";
                return RedirectToAction("Index", "Exception");
            }
        }

        public ActionResult CreateTask()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateTask(TaskModel taskToCreate)
        {
            try
            {
                if (taskToCreate != null)
                {
                    taskToCreate.AssignedBy = Session["LoggedUserEmail"].ToString();
                    taskToCreate.Status = "To Do";
                    taskToCreate.CreatedDate = DateTime.Now;

                    await taskService.Post(taskToCreate);
                    return RedirectToAction("ToDoIndex");
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["ExceptionText"] = "Error Occured, Please Contact the Administrator";
                return RedirectToAction("Index", "Exception");
            }
        }

        public async Task<ActionResult> EditTask(int id)
        {
            try
            {
                TaskModel taskToEdit = await taskService.GetById(id);
                if (taskToEdit != null)
                {
                    return View(taskToEdit);
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["ExceptionText"] = "Error Occured, Please Contact the Administrator";
                return RedirectToAction("Index", "Exception");
            }
        }

        [HttpPost]
        public async Task<ActionResult> EditTask(TaskModel taskToEdit)
        {
            try
            {
                if (taskToEdit != null)
                {
                    await taskService.Update(taskToEdit);
                    return RedirectToAction("ToDoIndex");
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["ExceptionText"] = "Error Occured, Please Contact the Administrator";
                return RedirectToAction("Index", "Exception");
            }
        }

        public async Task<ActionResult> DeleteTask(int id)
        {
            try
            {
                await taskService.Delete(id); ;
                return RedirectToAction("ToDoIndex");
            }
            catch (Exception ex)
            {
                TempData["ExceptionText"] = "Error Occured, Please Contact the Administrator";
                return RedirectToAction("Index", "Exception");
            }
        }
    }
}
