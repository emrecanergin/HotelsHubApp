﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsHubApp.DataAccess.Concrete.MongoDB
{
    public  class MongoDbSettings
    {
        public string ConnectionString;
        public string Database;

        //Configuration için kullanılacak

        public const string ConnectionStringValue = nameof(ConnectionString);
        public const string DatabaseValue = nameof(Database);
    }
}
