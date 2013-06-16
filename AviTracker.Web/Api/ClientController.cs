using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AviTracker.Web.Repositories;
using MvcApplication1.Models;

namespace AviTracker.Web.Api
{
    public class ClientController : ApiController
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        // GET api/Client
        public IEnumerable<Client> Get()
        {
            IEnumerable<Client> clients = _clientRepository.GetAll().ToList();
            return clients;
        }

        // GET api/Client/5
        public Client Get(int id)
        {
            Client client = _clientRepository.Find(id);
            if (client == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return client;
        }

        // PUT api/Client/5
        public HttpResponseMessage Put(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != client.ClientId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            _clientRepository.Update(client);

            try
            {
                _clientRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Client
        public HttpResponseMessage Post(Client client)
        {
            if (ModelState.IsValid)
            {
                _clientRepository.Add(client, true);
                _clientRepository.Save();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, client);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = client.ClientId}));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Client/5
        public HttpResponseMessage DeleteClient(int id)
        {
            Client client = _clientRepository.Delete(id);

            try
            {
                _clientRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, client);
        }

        protected override void Dispose(bool disposing)
        {
            _clientRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}