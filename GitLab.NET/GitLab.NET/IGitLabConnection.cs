using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitLab.NET.Projects;

namespace GitLab.NET
{
    public interface IGitLabConnection
    {
        Task<List<Project>> FetchAllProjects();

        Task<Project> GetProjectById(int id);
    }


}
