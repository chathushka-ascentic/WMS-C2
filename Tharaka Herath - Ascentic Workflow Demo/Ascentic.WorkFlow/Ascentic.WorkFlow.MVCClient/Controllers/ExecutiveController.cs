using Ascentic.WorkFlow.MVCClient.HTTPServices;
using Ascentic.WorkFlow.MVCClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ascentic.WorkFlow.MVCClient.Controllers
{
    public class ExecutiveController : Controller
    {
        TaskService taskService = new TaskService();

        public async Task<ActionResult> ToDoIndex()
        {
            try
            {
                IEnumerable<TaskModel> taskModels = await taskService.GetByAssignee(Session["LoggedUserEmail"].ToString());
                if (taskModels != null)
                {
                    ViewBag.ToDoCount = taskModels.Where(t => t.Status == "To Do").Count();
                    ViewBag.InProgressCount = taskModels.Where(t => t.Status == "In Progress").Count();
                    ViewBag.DoneCount = taskModels.Where(t => t.Status == "Done").Count();
                    ViewBag.DelayedCount = taskModels.Where(t => t.Status != "Done" && t.AgreedCompletionDate < DateTime.Now.Date).Count();
                    return View(taskModels.Where(t => t.Status == "To Do").OrderBy(t => t.AgreedCompletionDate));
                }
                return View(taskModels);
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
                IEnumerable<TaskModel> taskModels = await taskService.GetByAssignee(Session["LoggedUserEmail"].ToString());
                if (taskModels != null)
                {
                    ViewBag.ToDoCount = taskModels.Where(t => t.Status == "To Do").Count();
                    ViewBag.InProgressCount = taskModels.Where(t => t.Status == "In Progress").Count();
                    ViewBag.DoneCount = taskModels.Where(t => t.Status == "Done").Count();
                    ViewBag.DelayedCount = taskModels.Where(t => t.Status != "Done" && t.AgreedCompletionDate < DateTime.Now.Date).Count();
                    return View(taskModels.Where(t => t.Status == "In Progress").OrderBy(t => t.AgreedCompletionDate));
                }
                return View(taskModels);
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
                IEnumerable<TaskModel> taskModels = await taskService.GetByAssignee(Session["LoggedUserEmail"].ToString());
                if (taskModels != null)
                {
                    ViewBag.ToDoCount = taskModels.Where(t => t.Status == "To Do").Count();
                    ViewBag.InProgressCount = taskModels.Where(t => t.Status == "In Progress").Count();
                    ViewBag.DoneCount = taskModels.Where(t => t.Status == "Done").Count();
                    ViewBag.DelayedCount = taskModels.Where(t => t.Status != "Done" && t.AgreedCompletionDate < DateTime.Now.Date).Count();
                    return View(taskModels.Where(t => t.Status == "Done"));
                }
                return View(taskModels);
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
                IEnumerable<TaskModel> taskModels = await taskService.GetByAssignee(Session["LoggedUserEmail"].ToString());
                if (taskModels != null)
                {
                    ViewBag.ToDoCount = taskModels.Where(t => t.Status == "To Do").Count();
                    ViewBag.InProgressCount = taskModels.Where(t => t.Status == "In Progress").Count();
                    ViewBag.DoneCount = taskModels.Where(t => t.Status == "Done").Count();
                    ViewBag.DelayedCount = taskModels.Where(t => t.Status != "Done" && t.AgreedCompletionDate < DateTime.Now.Date).Count();
                    return View(taskModels.Where(t => t.Status != "Done" && t.AgreedCompletionDate < DateTime.Now.Date));
                }
                return View(taskModels);
            }
            catch (Exception ex)
            {
                TempData["ExceptionText"] = "Error Occured, Please Contact the Administrator";
                return RedirectToAction("Index", "Exception");
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            try
            {
                TaskModel taskModel = await taskService.GetById(id);
                if (taskModel != null)
                {
                    return View(taskModel);
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["ExceptionText"] = "Error Occured, Please Contact the Administrator";
                return RedirectToAction("Index", "Exception");
            }
        }

        public async Task<ActionResult> SetInProgress(int id)
        {
            try
            {
                TaskModel taskModel = new TaskModel()
                {
                    TaskId = id,
                    Status = "In Progress"
                };
                await taskService.UpdateStatus(taskModel);
                return RedirectToAction("InProgressIndex");
            }
            catch (Exception ex)
            {
                TempData["ExceptionText"] = "Error Occured, Please Contact the Administrator";
                return RedirectToAction("Index", "Exception");
            }
        }

        public async Task<ActionResult> SetDone(int id)
        {
            try
            {
                TaskModel taskModel = new TaskModel()
                {
                    TaskId = id,
                    Status = "Done",
                    ActualCompletionDate = DateTime.Now
                };
                await taskService.UpdateStatus(taskModel);
                return RedirectToAction("DoneIndex");
            }
            catch (Exception ex)
            {
                TempData["ExceptionText"] = "Error Occured, Please Contact the Administrator";
                return RedirectToAction("Index", "Exception");
            }
        }
    }
}