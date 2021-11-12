using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Project> Projects { get; set; }

        public Client()
        {
            Projects = new List<Project>();
        }
    }
}
