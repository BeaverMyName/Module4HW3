using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartedDate { get; set; }
        public virtual List<EmployeeProject> EmployeeProject { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public Project()
        {
            EmployeeProject = new List<EmployeeProject>();
        }
    }
}
