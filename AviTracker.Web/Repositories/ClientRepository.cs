using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AviTracker.Web.Models;

namespace AviTracker.Web.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        
        public Client Add(Client entity, bool persist)
        {
            Context.Clients.Add(entity);
            if (persist) Save();
            return entity;
        }


    }
}