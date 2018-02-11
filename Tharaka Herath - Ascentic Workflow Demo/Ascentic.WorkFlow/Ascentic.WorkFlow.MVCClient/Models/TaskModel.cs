using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ascentic.WorkFlow.MVCClient.Models
{
    public class TaskModel
    {
        [Display(Name = "Task Id")]
        public int TaskId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Assignee { get; set; }

        [Display(Name ="Assigned by")]
        public string AssignedBy { get; set; }

        public string Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Agreed Date of Completion")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime AgreedCompletionDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Actual Date of Completion")]
        public DateTime ActualCompletionDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Create Date")]
        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}