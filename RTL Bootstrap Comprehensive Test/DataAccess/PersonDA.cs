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


        public PersonModel GetPerson(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(getConnectionString()))
            {
                return cnn.Query<PersonModel>("Select * From person WHERE Id = @ID", new { ID = id }).FirstOrDefault();
            }
        }


        public int CreatePerson(PersonModel person)
        {
            using (IDbConnection cnn = new SQLiteConnection(getConnectionString()))
            {
                return cnn.Execute("INSERT INTO PERSON (FirstName,LastName,EmailAddress) VALUES (@FirstName,@LastName,@EmailAddress)", person);
            }
        }




    }
}
