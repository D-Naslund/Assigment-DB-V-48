using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment_DB_V_48
{
    internal class SakilaDataHandler
    {
        Connection Connection = new Connection();

        public SqlDataReader ActorGetFilm(string name, string lastName)
        {
            try
            {
                var connection = Connection.GetConnection();

                using var command1 = new SqlCommand($"SELECT first_name,last_name,film.title FROM actor INNER JOIN film_actor on actor.actor_id = film_actor.actor_id INNER JOIN film on film_actor.film_id = film.film_id WHERE first_name LIKE '{name}' AND Last_name LIKE '{lastName}%' ", connection);

                //Has to be left open or "rec" cant be read for elsewhere
                connection.Open();
                var rec = command1.ExecuteReader();
                return rec;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Code 1");
                return null;
            }
        }
    }
}
