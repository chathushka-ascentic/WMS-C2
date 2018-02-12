using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascentic.WorkFlow.Contracts.DTOs
{
    public class TaskDto
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public string Assignee { get; set; }
        public string AssignedBy { get; set; }
        public string Status { get; set; }
        public DateTime AgreedCompletionDate { get; set; }
        public DateTime ActualCompletionDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
