using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Test
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MyServiceImp : IMyService
    {
        private static List<int> ides = new List<int>();
        public Result SorcePerson(Person person)
        {
            if (ides.Count == 0)
                GetIdes();

            if (person.Name.Equals(""))
                return new Result("there aren't Name", "Failed");

            foreach (var item in ides)
            {
                if (item == person.ID)
                    return new Result("The Person is already exist", "Failed");
            }

            string connectionString =
            "Data Source=(local);Initial Catalog=MyWCFDataBasa;"
            + "Integrated Security=true";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = $"INSERT INTO Humons (Id,[Name],[Group],Price)" +
                    $" VALUES('{person.ID}','{person.Name}','{person.Group}','{person.Price}')";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            ides.Add(person.ID);
            return new Result("The Person will be added", "Access");
        }

        private void GetIdes()
        {
            string connectionString =
             "Data Source=(local);Initial Catalog=MyWCFDataBasa;"
             + "Integrated Security=true";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "select Id from Humons";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                List<string> columns = new List<string>();
                while (dataReader.Read())
                {
                    ides.Add(dataReader.GetInt32(0));
                }
                dataReader.Close();
            }
        }
    }
}
