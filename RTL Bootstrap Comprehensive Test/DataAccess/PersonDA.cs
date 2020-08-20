using Dapper;
using RTL_Bootstrap_Comprehensive_Test.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace RTL_Bootstrap_Comprehensive_Test.DataAccess
{
    public class PersonDA
    {
        public String getConnectionString(String name = "Default")
        {
            return "";
        }

        public List<PersonModel> GetPersons()
        {
            using (IDbConnection cnn = new SQLiteConnection(getConnectionString()))                
            {
                return cnn.Query<PersonModel>("Select * From person").ToList();
            }
        }
    }
}
