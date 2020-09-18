using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using X_Forms.PersonenDb.Services;
using Newtonsoft.Json;
using System.IO;
using Xamarin.Forms;

//vgl. AndroidDatabaseService.cs
[assembly: Dependency(typeof(X_Forms.Droid.Services.AndroidJsonService))]
namespace X_Forms.Droid.Services
{
    public class AndroidJsonService : IJsonService
    {
        //Pfad zum Abspeichern des Json-Datei
        private static string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "jsonText.txt");

        public T LoadJson<T>()
        {
            //Prüfung, ob Datei existiert
            if (!File.Exists(path))
                //Wenn nein, dann wird die Datei erstellt
                File.Create(path).Dispose();

            //Auslesen des Dateiinhalts (String in Json-Format)
            string jsonString = File.ReadAllText(path);

            //Umwandlung des Json-Strings in Datentyp T (<-- generischer Typ-platzhalter) sowie Rückgabe des Werts
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public void SaveJson(object data)
        {
            //Umwandlung eines objects in einen Json-String
            string jsonString = JsonConvert.SerializeObject(data);

            //Erstellen/Überschreiben der Datei mit Json-String
            File.WriteAllText(path, jsonString);
        }
    }
}