using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment_DB_V_48
{
    internal class SakilaGUI
    {
        SakilaDataHandler SakilaDataHandler = new SakilaDataHandler();
        Connection Connection = new Connection();
        public void MenuStart()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("SAKILA DATABASE");
                Console.WriteLine("Enter First name of actor");
                var selectFirstName = Console.ReadLine();

                Console.WriteLine("Enter Last name of actor\n(you can leave this open or enter part of it)");
                var selectLastName = Console.ReadLine();
                if (selectLastName == null)
                    selectLastName = "";

                if (selectFirstName != null)
                {
                    var data = SakilaDataHandler.ActorGetFilm(selectFirstName, selectLastName);
                    if (data == null)
                        continue;
                    ListFilms(data);
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                }
            } while (true);
        }

        public void ListFilms(SqlDataReader data)
        {
            try
            {
                var connection = Connection.GetConnection();
                connection.Open();
                if (data.HasRows)
                {
                    Console.WriteLine("Firstname-Lastname-Films");
                    while (data.Read())
                    {
                        Console.WriteLine($"{data[0]} {data[1]}-{data[2]}");
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Code 2");
            }
        }
    }
}
