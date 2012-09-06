using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GitLab.NET.Projects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GitLab.NET
{
    public class GitLabConnection : IGitLabConnection
    {
        private readonly Token _securityToken;
        private readonly Uri _apihost;


        public GitLabConnection(Uri host, Token authentication)
        {
            _securityToken = authentication;
            _apihost = new Uri(host, "api/v2/");
        }



        public async Task<List<Project>> FetchAllProjects()
        {
            var fetchAllProjectsUri = new Uri(_apihost, "projects");
            fetchAllProjectsUri = new Uri(fetchAllProjectsUri, AuthenticationUriPart);

            var jprojects = await FetchWebData(fetchAllProjectsUri);


            var fetchedProjects = from dynamic jproject in jprojects
                                  select new Project(Int32.Parse(jproject["id"].ToString()))
                                             {
                                                 Name = jproject["name"]
                                             };
             
            return fetchedProjects.ToList();
        }

        public Task<Project> GetProjectById(int id)
        {
            throw new NotImplementedException();
        }


        private async Task<JArray> FetchWebData(Uri url)
        {
            JArray response = null;

            var httpClient = new HttpClient();

            var res = await httpClient.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var responseJson =  await res.Content.ReadAsStringAsync();
                response = JArray.Parse(responseJson);
            }
            return response;
        }



        private string AuthenticationUriPart
        {
            get { return "?private_token=" + _securityToken; }
        }



    }
}
