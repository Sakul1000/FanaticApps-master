using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    internal class Worker
    {
        private const string URI = "http://localhost:51306/api/Events";
        //private const string URI = "";

        public async void Start()
        {
            IList<Event> EventListe = await GetAllEventAsync();
            foreach (Event eve in EventListe)
            {
                Console.WriteLine(eve);
            }
        }

        private async Task<IList<Event>> GetAllEventAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                String content = await client.GetStringAsync(URI);
                IList<Event> clist = JsonConvert.DeserializeObject<IList<Event>>(content);
                return clist;
            }

        }

    }
}