using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AviTracker.Web.Models;
using AviTracker.Web.Repositories;

namespace MvcApplication1.Api
{
    public class TaskController : ApiController
    {
        private readonly IProjectTasksRepository _projectTasksRepository;

        public TaskController(IProjectTasksRepository projectTasksRepository)
        {
            _projectTasksRepository = projectTasksRepository;
        }

        // GET api/Task
        public IEnumerable<ProjectTask> GetProjectTasks(int projectId)
        {
            return _projectTasksRepository.GetAll();
        }

        // GET api/Task/5
        public ProjectTask GetProjectTask(int projectId, int taskId)
        {
            ProjectTask projecttask = _projectTasksRepository.Find(taskId);
            if (projecttask == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return projecttask;
        }

        // PUT api/Task/5
        public HttpResponseMessage PutProjectTask(int projectId, int id, ProjectTask projectTask)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != projectTask.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            _projectTasksRepository.Update(projectTask, id);

            try
            {
                _projectTasksRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Task
        public HttpResponseMessage PostProjectTask(int projectId, ProjectTask projectTask)
        {
            if (ModelState.IsValid)
            {
                _projectTasksRepository.Add(projectTask, true);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, projectTask);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = projectTask.Id}));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Task/5
        public HttpResponseMessage DeleteProjectTask(int projectid, int id)
        {
            ProjectTask projecttask = _projectTasksRepository.Delete(id);
            if (projecttask == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                _projectTasksRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, projecttask);
        }

        protected override void Dispose(bool disposing)
        {
            _projectTasksRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}