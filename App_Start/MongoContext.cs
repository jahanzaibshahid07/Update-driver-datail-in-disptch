using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Despatch.App_Start
{
    public class MongoContext
    {
        public IMongoDatabase mongoDatabase;
        public MongoContext()
        {
            var mongoclient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            mongoDatabase = mongoclient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);
        }
    }
}