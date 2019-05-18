using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CefSharp.WinForms;
using CefSharp;

namespace PSeminar
{
    public class Map
    {
        private static string _apiKey;
        private static Main _main;

        public Map(string apiKey)
        {
            _apiKey = apiKey;
            _main = Application.OpenForms["Main"] as Main;

            // Init 'Chromium Embedded Framework'
            var settings = new CefSettings();
            if (Cef.IsInitialized == false)
                Cef.Initialize(settings);

            AutoLoadTrack();
        }

        private void AutoLoadTrack()
        {
            var executingPathString = AppDomain.CurrentDomain.BaseDirectory;
            var executingPath = new DirectoryInfo(executingPathString);

            var files = executingPath.GetFiles("*.gpx");
            if (!files.Any())
            {
                _main.SetStatus("Keine Trackdatei gefunden!");
                return;
            }

            var file = files.FirstOrDefault();
            ParseTrack(file);
        }


        public void ParseTrack(FileInfo file)
        {
            if (file == null) throw new ArgumentNullException(nameof(file));

            var serializer = new XmlSerializer(typeof(RootElement));

            RootElement gpx;
            using (var reader = new FileStream(file.FullName, FileMode.Open))
            {
                gpx = (RootElement)serializer.Deserialize(reader);
            }

            SendMapsRequest(gpx.Track.TrackSegment.Waypoints);

            var main = Application.OpenForms["Main"] as Main;
            main?.SetGpx(gpx);
        }

        private static void SendMapsRequest(IReadOnlyList<Waypoints> waypoints)
        {
            var htmlPath = AppDomain.CurrentDomain.BaseDirectory + "map.html";
            var sw = new StreamWriter(htmlPath, false, Encoding.GetEncoding(437));

            var centerLongitude = waypoints[0].Longitude;
            var centerLatitude = waypoints[0].Latitude;

            // Ab hier schreiben wir ein neues HTML Dokument, welches uns die Karte anzeigt
            sw.WriteLine("<!DOCTYPE html>");
            sw.WriteLine("<html>");
            sw.WriteLine("<head>");
            sw.WriteLine("<meta charset=\"utf-8\">");
            sw.WriteLine("<meta name=\"viewport\" content=\"initial - scale = 1.0, user - scalable = no\">");
            sw.WriteLine("<style>");
            sw.WriteLine("html, body, #map{");
            sw.WriteLine("margin :0;");
            sw.WriteLine("padding: 0;");
            sw.WriteLine("height: 100%");
            sw.WriteLine("}");
            sw.WriteLine("</style>");
            sw.WriteLine("</head>");
            sw.WriteLine("<body>");
            sw.WriteLine("<div id=\"map\"></div>");

            sw.WriteLine("<script>");
            sw.WriteLine("function initMap() {");
            sw.WriteLine("var map = new google.maps.Map(document.getElementById('map'), {");
            sw.WriteLine("center: { lat: " + centerLatitude + ", lng: " + centerLongitude + "},");
            sw.WriteLine("zoom: 14,");
            sw.WriteLine("mapTypeId: 'satellite',");
            sw.WriteLine("});");

            sw.WriteLine("var trackCoordinates = [");
            for (var i = 0; i < waypoints.Count; i++)
            {
                // Trackfehler
                if (i + 1 > 110 && i + 1 < 120) continue;

                sw.WriteLine("{lat: " + waypoints[i].Latitude + ", lng: " + waypoints[i].Longitude + "},");
            }
            sw.WriteLine("];");

            sw.WriteLine("var trackPath = new google.maps.Polyline({");
            sw.WriteLine("path: trackCoordinates,");
            sw.WriteLine("geodesic: true,");
            sw.WriteLine("strokeColor: '#FF0000',");
            sw.WriteLine("strokeOpacity: 1.0,");
            sw.WriteLine("strokeWeight: 2");
            sw.WriteLine("});");

            // Spezielle Marker wie Gipsbruch, Start & Ziel, später auch noch Rastplätze etc.
            sw.WriteLine("var markerGips = new google.maps.Marker(" + "{");
            sw.WriteLine("position: { lat: " + waypoints[77].Latitude + ", lng: " + waypoints[77].Longitude + "},");
            sw.WriteLine("map: map,");
            sw.WriteLine("label: 'G',");
            sw.WriteLine("});");

            sw.WriteLine("var markerStartZiel = new google.maps.Marker(" + "{");
            sw.WriteLine("position: { lat: " + waypoints[500].Latitude + ", lng: " + waypoints[500].Longitude + "},");
            sw.WriteLine("map: map,");
            sw.WriteLine("label: 'S/Z',");
            sw.WriteLine("});");

            sw.WriteLine("trackPath.setMap(map);");
            sw.WriteLine("}");

            #region Ups
            //// Gesonderter Index um den Punkten eine korrekte Nummerierung zu geben
            //int wpNumber = 1;
            //for (int i = 0; i < waypoints.Count; i++)
            //{
            //    // Punkte die versehentlich oder falsch gesetzt wurden;
            //    if (i == 0 || i == 2 || i == 33 || i == 34 || i == 35)
            //    {
            //        //_logger.Log(LogLevel.Debug, "Ignoriere Wegpunkt der versehentlich/falsch gesetzt wurde!");
            //        continue;
            //    }

            //    // Erstellt für jeden Wegpunkt einen neuen Punkt auf der Karte
            //    sw.WriteLine($"var marker{i.ToString()} = new google.maps.Marker(" + "{");
            //    sw.WriteLine("position: { lat: " + waypoints[i].Latitude + ", lng: " + waypoints[i].Longitude + "},");
            //    sw.WriteLine("map: map,");


            //    // Bei besonderen Punkten wird zusätzlich noch ein Titel eingefügt der angezeigt werden kann
            //    // Wenn der Mauszeiger drüber fährt.
            //    switch (i)
            //    {
            //        default:
            //            sw.WriteLine($"label: '{wpNumber.ToString()}',");
            //            break;
            //    }


            //    sw.WriteLine("});");

            //    //_logger.Log(LogLevel.Debug, "Wegpunkt auf Karte eingetragen");

            //    wpNumber++;
            //}

            //sw.WriteLine("}");
            #endregion


            sw.WriteLine("</script>");
            sw.WriteLine($"<script src=\"https://maps.googleapis.com/maps/api/js?key={_apiKey}&callback=initMap\"");
            sw.WriteLine("async defer></script>");
            sw.WriteLine("</body>");
            sw.WriteLine("</html>");
            sw.Close();


            // Initiiert einen WebBrowser und fügt ihn als Hintergrundelement hinzu (benötigt um die Karte zu bewegen)
            var chromeBrowser = new ChromiumWebBrowser("file://" + htmlPath)
            {
                Dock = DockStyle.Fill,
            };

            _main?.Controls.Add(chromeBrowser);
        }
    }
}