using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AviTracker.Web.Models;
using AviTracker.Web.Repositories;

namespace AviTracker.Web.Api
{
    public class ProjectController : ApiController
    {
        private readonly IClientRepository _clientRepository;
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository, IClientRepository clientRepository)
        {
            _projectRepository = projectRepository;
            _clientRepository = clientRepository;
        }

        // GET api/Project
        public IEnumerable<Project> GetProjects(int clientId)
        {
            List<Project> projects = _projectRepository.Query().Where(x => x.Client.ClientId == clientId).ToList();
            return projects;
        }

        // GET api/Project/5
        public Project GetProject(int clientId, int id)
        {
            Project project = _projectRepository.Find(id);
            if (project == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return project;
        }

        // PUT api/Project/5
        public HttpResponseMessage PutProject(int id, Project project)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != project.ProjectId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            _projectRepository.Update(project, id);

            try
            {
                _projectRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Project
        public HttpResponseMessage PostProject(int clientId, Project project)
        {
            if (ModelState.IsValid)
            {
                Client client = _clientRepository.Find(clientId);
                client.Projects.Add(project);
                _clientRepository.Save();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, project);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = project.ProjectId}));
                return response;
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // DELETE api/Project/5
        public HttpResponseMessage DeleteProject(int clientId, int id)
        {
            Project project = _projectRepository.Delete(id);
            if (project == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                _projectRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, project);
        }

        protected override void Dispose(bool disposing)
        {
            _projectRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}