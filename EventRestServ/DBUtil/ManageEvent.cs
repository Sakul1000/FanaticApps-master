using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventRestServ.DBUtil
{
    public class ManageEvent
    {
        private const String connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HotelDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public IList<Event> GetAllEvent()
        {
            IList<Event> retList = new List<Event>();

            //forbinelse til database 
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                //sql kald
                using (SqlCommand cmd = new SqlCommand("select * from Event", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Event g = new Event();
                        g.EventNr = reader.GetInt32(0);
                        g.Name = reader.GetName(i: 1);
                        g.Adresse = reader.GetString(i: 2);
                        retList.Add(g);
                    }
                }
            }

            return retList;
        }

        public Event GetEventFromId(int EventNo)
        {
            Event g = new Event();

            //forbinelse til database 
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                //sql kald
                using (SqlCommand cmd = new SqlCommand("select * from Event where Event_No = @Event_No", conn))
                {
                    cmd.Parameters.AddWithValue("@Event_No", EventNo);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        g.EventNr = reader.GetInt32(0);
                        g.Name = reader.GetName(i: 1);
                        g.Adresse = reader.GetString(i: 2);

                    }
                }
            }

            return g;

        }
        public bool CreateEvent(Event Event)
        {
            Event createEvent = new Event();
            bool success;

            //forbinelse til database 
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                //sql kald
                using (SqlCommand cmd = new SqlCommand("insert into Event values ( @Event_No, @Name, @Address)", conn))
                {
                    cmd.Parameters.AddWithValue("@Event_No", Event.EventNr);
                    cmd.Parameters.AddWithValue("@Name", Event.Name);
                    cmd.Parameters.AddWithValue("@Address", Event.Adresse);
                    int rows = cmd.ExecuteNonQuery();
                    success = rows == 1;

                }
            }

            return success;

        }
        public bool UpdateEvent(Event Event, int EventNr)

        {
            Event updateEvent = new Event();
            bool success;

            //forbinelse til database 
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                //sql kald
                using (SqlCommand cmd = new SqlCommand("update Event set Event_No = @Event_No, Name = @Name, Address = @Address where Event_No = @Event_No", conn))
                {
                    cmd.Parameters.AddWithValue("@Event_No", EventNr);
                    cmd.Parameters.AddWithValue("@Name", Event.Name);
                    cmd.Parameters.AddWithValue("@Address", Event.Adresse);
                    int rows = cmd.ExecuteNonQuery();
                    success = rows == 1;

                }
            }

            return success;

        }
        public Event DeleteEvent(int EventNr)
        {

            bool success;

            //forbinelse til database 
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                //sql kald
                using (SqlCommand cmd = new SqlCommand("delete from Event where Event_No = @Event_No, ", conn))
                {
                    cmd.Parameters.AddWithValue("@Event_No", EventNr);
                    int rows = cmd.ExecuteNonQuery();
                    success = rows == 1;

                }
            }

            return GetEventFromId(EventNr);

        }
    }
}
