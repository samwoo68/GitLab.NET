



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitLab.NET.Issues;

namespace GitLab.NET.Projects
{
    public class Project
    {
        private List<Issue> _issues;

        public Project(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        /// <summary>
        /// The Name of this Project
        /// </summary>
        public virtual string Name { get; set; }


        /// <summary>
        /// Returns all Issues of this Project
        /// </summary>
        public List<Issue> AllIssues
        {
            get { return new List<Issue>(_issues); }
        }

        public override string ToString()
        {
            return "{" + this.Id + "} " + this.Name;
        }

    }
}
