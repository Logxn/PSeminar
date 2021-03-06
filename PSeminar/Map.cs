﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using CefSharp;
using CefSharp.WinForms;
using PSeminar.ConsoleManaging;

namespace PSeminar
{
    public class Map
    {
        private static string _apiKey;
        private static Main _main;
        private static bool _isNickelTrack;

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
            if (file != null && file.Name.ToLower().Contains("nic"))
            {
                _isNickelTrack = true;
            }
            
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

            var main = Application.OpenForms["Main"] as Main;
            main?.SetGpx(gpx);

            if (file.Name.ToLower().Contains("nic"))
            {
                _isNickelTrack = true;
            }

            SendMapsRequest(gpx.Track.TrackSegment.Waypoints);
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
            sw.WriteLine("scrollwheel: true");
            sw.WriteLine("});");
#if !DEBUG
            // Bierkeller Alternativ Weg
            sw.WriteLine("var alternativeCoordinates = [");
            sw.WriteLine("{lat: 49.474083, lng: 10.448440},");
            sw.WriteLine("{lat: 49.474565, lng: 10.450166},");
            sw.WriteLine("{lat: 49.474660, lng: 10.451220},");
            sw.WriteLine("{lat: 49.474520, lng: 10.451733},");
            sw.WriteLine("{lat: 49.474007, lng: 10.452232},");
            sw.WriteLine("{lat: 49.473594, lng: 10.452602},");
            sw.WriteLine("{lat: 49.473682, lng: 10.455618},");
            sw.WriteLine("{lat: " + waypoints[233].Latitude + ", lng: " + waypoints[233].Longitude + "},");
            sw.WriteLine("]");

            sw.WriteLine("var alternativeTrackPath = new google.maps.Polyline({");
            sw.WriteLine("path: alternativeCoordinates,");
            sw.WriteLine("geodesic: true,");
            sw.WriteLine("strokeColor: '#3E047C',");
            sw.WriteLine("strokeOpacity: 1.0,");
            sw.WriteLine("strokeWeight: 2");
            sw.WriteLine("});");

            sw.WriteLine("var trackCoordinates = [");
            for (var i = 0; i < waypoints.Count; i++)
            {
                // Manuelle Anpassungen nur erforderlich, wenn es sich um UNSERE Trackdatei handelt
                if (_isNickelTrack)
                {
                    // Trackfehler
                    if (i > 109 && i < 119 || i > 86 && i < 114 || i > 200 && i < 233 || i >= 0 && i < 5 || i == 623) continue;

                    if (i == 86)
                    {
                        // Quelle Fix
                        sw.WriteLine("{lat: " + waypoints[i].Latitude + ", lng: " + waypoints[i].Longitude + "},");
                        sw.WriteLine("{lat: 49.466774, lng: 10.435598},");
                        sw.WriteLine("{lat: " + waypoints[i + 1].Latitude + ", lng: " + waypoints[i + 1].Longitude +
                                     "},");

                        // Weg fix laut screenshot
                        sw.WriteLine("{lat: 49.466843, lng: 10.439590},");
                        continue;
                    }

                    if (i == 200)
                    {
                        sw.WriteLine("{lat: " + waypoints[i].Latitude + ", lng: " + waypoints[i].Longitude + "},");
                        sw.WriteLine("{lat: 49.473363, lng: 10.450407},");
                        sw.WriteLine("{lat: 49.473912, lng: 10.449974},");
                        sw.WriteLine("{lat: 49.474129, lng: 10.447914},");
                        sw.WriteLine("{lat: 49.474407, lng: 10.448070},");
                        sw.WriteLine("{lat: 49.475206, lng: 10.450680},");
                        sw.WriteLine("{lat: 49.475468, lng: 10.456369},");
                        sw.WriteLine("{lat: 49.474806, lng: 10.456497},");
                        continue;
                    }
                }
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

            #region Sehenswürdigkeiten
            // Spezielle Marker wie Gipsbruch, Start & Ziel, später auch noch Rastplätze etc.
            sw.WriteLine("var markerGips = new google.maps.Marker(" + "{");
            sw.WriteLine("position: { lat: " + waypoints[77].Latitude + ", lng: " + waypoints[77].Longitude + "},");
            sw.WriteLine("map: map,");
            sw.WriteLine("label: 'G',");
            sw.WriteLine("});");

            sw.WriteLine("var markerStartZiel = new google.maps.Marker(" + "{");
            sw.WriteLine("position: { lat: " + waypoints[623].Latitude + ", lng: " + waypoints[623].Longitude + "},");
            sw.WriteLine("map: map,");
            sw.WriteLine("label: 'S/Z',");
            sw.WriteLine("});");

            sw.WriteLine("var markerQuelle = new google.maps.Marker(" + "{");
            sw.WriteLine("position: { lat: 49.466774, lng: 10.435598},");
            sw.WriteLine("map: map,");
            sw.WriteLine("label: 'Q',");
            sw.WriteLine("});");

            sw.WriteLine("var markerBierkeller = new google.maps.Marker(" + "{");
            sw.WriteLine("position: { lat: 49.473764, lng: 10.449370},");
            sw.WriteLine("map: map,");
            sw.WriteLine("label: 'B',");
            sw.WriteLine("});");
#endregion

            #region Rastplätze
            sw.WriteLine("var markerSeerastplatz = new google.maps.Marker(" + "{");
            sw.WriteLine("position: { lat: " + waypoints[233].Latitude + ", lng: " + waypoints[233].Longitude + "},");
            sw.WriteLine("map: map,");
            sw.WriteLine("icon: {");
            sw.WriteLine("url: \"http://maps.google.com/mapfiles/ms/icons/blue-dot.png\"");
            sw.WriteLine("}");
            sw.WriteLine("});");

            sw.WriteLine("var markerLinken = new google.maps.Marker(" + "{");
            sw.WriteLine("position: { lat: " + waypoints[519].Latitude + ", lng: " + waypoints[519].Longitude + "},");
            sw.WriteLine("map: map,");
            sw.WriteLine("icon: {");
            sw.WriteLine("url: \"http://maps.google.com/mapfiles/ms/icons/blue-dot.png\"");
            sw.WriteLine("}");
            sw.WriteLine("});");

            sw.WriteLine("var markerWalnuss = new google.maps.Marker(" + "{");
            sw.WriteLine("position: { lat: " + waypoints[196].Latitude + ", lng: " + waypoints[196].Longitude + "},");
            sw.WriteLine("map: map,");
            sw.WriteLine("icon: {");
            sw.WriteLine("url: \"http://maps.google.com/mapfiles/ms/icons/blue-dot.png\"");
            sw.WriteLine("}");
            sw.WriteLine("});");
#endregion

            sw.WriteLine("trackPath.setMap(map);");
            sw.WriteLine("alternativeTrackPath.setMap(map)");
            sw.WriteLine("}");
#endif

#if DEBUG
            // Gesonderter Index um den Punkten eine korrekte Nummerierung zu geben
            var logger = new ConsoleHelper();
            var wpNumber = 1;
            for (var i = 0; i < waypoints.Count; i++)
            {
                // Punkte die versehentlich oder falsch gesetzt wurden;
                if (i == 0 || i == 2 || i == 33 || i == 34 || i == 35)
                {
                    //_logger.Log(LogLevel.Debug, "Ignoriere Wegpunkt der versehentlich/falsch gesetzt wurde!");
                    continue;
                }

                // Erstellt für jeden Wegpunkt einen neuen Punkt auf der Karte
                sw.WriteLine($"var marker{i.ToString()} = new google.maps.Marker(" + "{");
                sw.WriteLine("position: { lat: " + waypoints[i].Latitude + ", lng: " + waypoints[i].Longitude + "},");
                sw.WriteLine("map: map,");

                switch (i)
                {
                    default:
                        sw.WriteLine($"label: '{wpNumber.ToString()}',");
                        break;
                }

                sw.WriteLine("});");

                logger.Log(LogLevel.Debug, $"{i} => {waypoints[i].Latitude},{waypoints[i].Longitude}");

                wpNumber++;
            }

            sw.WriteLine("}");
#endif

            sw.WriteLine("</script>");
            sw.WriteLine($"<script src=\"https://maps.googleapis.com/maps/api/js?key={_apiKey}&callback=initMap\"");
            sw.WriteLine("async defer></script>");
            sw.WriteLine("</body>");
            sw.WriteLine("</html>");
            sw.Close();


            // Initiiert einen WebBrowser und fügt ihn als Hintergrundelement hinzu (benötigt um die Karte zu bewegen)
            var chromeBrowser = new ChromiumWebBrowser("file://" + htmlPath)
            {
                Dock = DockStyle.Fill
            };

            _main?.Controls.Add(chromeBrowser);
        }

        public bool IsNickelTrack()
        {
            return _isNickelTrack;
        }
    }
}