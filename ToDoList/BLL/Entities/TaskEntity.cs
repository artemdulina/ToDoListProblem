using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }

        public bool IsCompleted { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }
    }
}
