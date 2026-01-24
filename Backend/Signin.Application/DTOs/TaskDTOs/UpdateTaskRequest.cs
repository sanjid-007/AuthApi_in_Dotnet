using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signin.Application.DTOs.TaskDTOs
{
    public class UpdateTaskRequest
    {
        public string Id { get; set;  }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
