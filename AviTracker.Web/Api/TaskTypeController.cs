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
    public class TaskTypeController : ApiController
    {
        private readonly ITaskTypeRepository _taskTypeRepository;

        public TaskTypeController(ITaskTypeRepository taskTypeRepository)
        {
            _taskTypeRepository = taskTypeRepository;
        }

        // GET api/TaskType
        public IEnumerable<TaskType> GetTaskTypes()
        {
            return _taskTypeRepository.GetAll().ToList();
        }

        // GET api/TaskType/5
        public TaskType GetTaskType(int id)
        {
            TaskType tasktype = _taskTypeRepository.Find(id);
            if (tasktype == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return tasktype;
        }

        // PUT api/TaskType/5
        public HttpResponseMessage PutTaskType(int id, TaskType tasktype)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != tasktype.TaskTypeId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            _taskTypeRepository.Update(tasktype, id);

            try
            {
                _taskTypeRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/TaskType
        public HttpResponseMessage PostTaskType(TaskType tasktype)
        {
            if (ModelState.IsValid)
            {
                tasktype = _taskTypeRepository.Add(tasktype, true);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, tasktype);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = tasktype.TaskTypeId}));
                return response;
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // DELETE api/TaskType/5
        public HttpResponseMessage DeleteTaskType(int id)
        {
            TaskType tasktype = _taskTypeRepository.Delete(id);
            if (tasktype == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                _taskTypeRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, tasktype);
        }

        protected override void Dispose(bool disposing)
        {
            _taskTypeRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}