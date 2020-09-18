using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using X_Forms.Uebungen.GoogleBooks.Model;

namespace X_Forms.Uebungen.GoogleBooks.Services
{
    //Service-Klasse zum Zugriff auf GoogleBooks
    public static class BookService
    {
        public static GBook FindBooks(string searchstring)
        {
            string json;

            using (WebClient client = new WebClient())
            {
                //WebClient läd Bücherliste herunter
                json = client.DownloadString($"https://www.googleapis.com/books/v1/volumes?q={searchstring}");
            }

            //Json deserialisiert den String in Model-Objekte
            return JsonConvert.DeserializeObject<GBook>(json);

            //return ObservableCollection<Item>(JsonConvert.DeserializeObject<GBook>(json).Items);
        }
    }
}
