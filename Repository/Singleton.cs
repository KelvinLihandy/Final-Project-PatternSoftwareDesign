using FinalProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalProjectPSD.Repository
{
    public class Singleton
    {
        private DatabaseJewel db;

        public DatabaseJewel GetDatabase()
        {
            if (db == null)
            {
                db = new DatabaseJewel();
            }
            return db;
        }
    }
}