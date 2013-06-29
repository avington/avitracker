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
    public class StatusController : ApiController
    {
        private readonly IStatusRepository _statusRepository;

        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }


        // GET api/Status
        public IEnumerable<TaskStatus> GetTaskStatus()
        {
            IEnumerable<TaskStatus> taskStatuses = _statusRepository.GetAll().ToList();
            return taskStatuses;
        }

        // GET api/Status/5
        public TaskStatus GetTaskStatus(int id)
        {
            TaskStatus taskstatus = _statusRepository.Find(id);

            if (taskstatus == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return taskstatus;
        }

        // PUT api/Status/5
        public HttpResponseMessage PutTaskStatus(int id, TaskStatus taskstatus)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != taskstatus.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            _statusRepository.Update(taskstatus, id);

            try
            {
                _statusRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Status
        public HttpResponseMessage PostTaskStatus(TaskStatus taskstatus)
        {
            if (ModelState.IsValid)
            {
                TaskStatus taskStatus = _statusRepository.Add(taskstatus, true);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, taskStatus);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = taskStatus.Id }));
                return response;
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // DELETE api/Status/5
        public HttpResponseMessage DeleteTaskStatus(int id)
        {
            TaskStatus taskstatus = _statusRepository.Delete(id);
            if (taskstatus == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                _statusRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, taskstatus);
        }

        protected override void Dispose(bool disposing)
        {
            _statusRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}