using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

   /* EventId = eventId;
EventNavn = eventNavn;
EventTid = eventTid;
EventDato = eventDato;
EventAdresse = eventAdresse;
EventPostnummer = eventPostnummer;
*/
    class RestWorker
    {
        private string URI = "http://localhost:51306/api/Events";

        public async void Start()
        {
            IList<Event> Events = await hentAlleEvents();

            foreach (Event Event in Events)
            {
                Console.WriteLine(Event);
            }

            Event g = new Event(Event_No: "33", name: "Sven", Address: "Hillrød 3400");
            bool erOprettet = await OpretEvents(g);
            Console.WriteLine("En ny Event er oprettet" + erOprettet);

            Event g = new Event(Event_No: "33", name: "Bo", Address: "Hillrød 3400");
            bool erOpdateret = await OpdaterEvents(g);
            Console.WriteLine("En Event er Opdateret" + erOpdateret);

            Event g = new Event(Event_No: "33", name: "Bo", Address: "Hillrød 3400");
            bool erSlettet = await SletEvents(g);
            Console.WriteLine("En Event er Slettet" + erSlettet);


        }



        private async Task<IList> Event>> hentEnEvents()
        {
            List<Event> Event;

            using (HttpClient client = new HttpClient())
            {
                String json = await client.GetStringAsync(URI + nameof(Event Event);
                Event = jsonConvert.DeserializeObject<List<Event>>(json);

            }

            return Event;
        }

        private async Task<bool> OpretEvents(Event Event)
        {
            bool ok = false;

            using (HttpClient client = new HttpClient())
            {
                //laver en body
                String jstring = JsonConvert.SerialzeObject(Event);
                StringContent content = new StringContent(jstring, Encoding.UTF8, mediaType: "application/json");
                HttpResponseMessage result = await client.postAsync(URI, content);

                if (result.IsSuccessSatusCode)
                {
                    string okRes = await result.Content.ReadAsStringAsync();
                    ok = JsonConvert.DerialzeObject<bool>(okRes);

                }
            }


            return ok;
        }


        private async Task<bool> SletEvents(Event Event)
        {
            bool ok = false;

            using (HttpClient client = new HttpClient())
            {
                //laver en body
                String jstring = JsonConvert.SerialzeObject(Event);
                StringContent content = new StringContent(jstring, Encoding.UTF8, mediaType: "application/json");
                HttpResponseMessage result = await client.postAsync(URI, content);

                if (result.IsSuccessSatusCode)
                {
                    string okRes = await result.Content.ReadAsStringAsync();
                    ok = JsonConvert.DerialzeObject<bool>(okRes);

                }
            }


            return ok;
        }

        private async Task<bool> OpdaterEvents(Event Event)
        {
            bool ok = false;

            using (HttpClient client = new HttpClient())
            {
                //laver en body
                String jstring = JsonConvert.SerialzeObject(Event);
                StringContent content = new StringContent(jstring, Encoding.UTF8, mediaType: "application/json");
                HttpResponseMessage result = await client.postAsync(URI, content);

                if (result.IsSuccessSatusCode)
                {
                    string okRes = await result.Content.ReadAsStringAsync();
                    ok = JsonConvert.DerialzeObject<bool>(okRes);

                }
            }


            return ok;
        }

    }
}
