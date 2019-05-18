using System.Collections.Generic;
using System.Xml.Serialization;

namespace PSeminar
{
    // Ausgabe-Stufe für den Debug Logger
    public enum LogLevel
    {
        Fehler,
        Erfolg,
        Debug,
    }

    #region !! NICHT BEARBEITEN/LÖSCHEN !! WICHTIGE ELEMENTE ZUM AUSLESEN DER TRACKDATEI !!

    [XmlRoot(ElementName = "link", Namespace = "http://www.topografix.com/GPX/1/1")]
    public class Link
    {
        [XmlElement(ElementName = "text", Namespace = "http://www.topografix.com/GPX/1/1")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
    }

    [XmlRoot(ElementName = "metadata", Namespace = "http://www.topografix.com/GPX/1/1")]
    public class Metadata
    {
        [XmlElement(ElementName = "link", Namespace = "http://www.topografix.com/GPX/1/1")]
        public Link Link { get; set; }
        [XmlElement(ElementName = "time", Namespace = "http://www.topografix.com/GPX/1/1")]
        public string Time { get; set; }
    }

    [XmlRoot(ElementName = "TrackExtension", Namespace = "http://www.garmin.com/xmlschemas/GpxExtensions/v3")]
    public class TrackExtension
    {
        [XmlElement(ElementName = "DisplayColor", Namespace = "http://www.garmin.com/xmlschemas/GpxExtensions/v3")]
        public string DisplayColor { get; set; }
    }

    [XmlRoot(ElementName = "TrackStatsExtension", Namespace = "http://www.garmin.com/xmlschemas/TrackStatsExtension/v1")]
    public class TrackStatsExtension
    {
        [XmlElement(ElementName = "Distance", Namespace = "http://www.garmin.com/xmlschemas/TrackStatsExtension/v1")]
        public string Distance { get; set; }
        [XmlElement(ElementName = "TotalElapsedTime", Namespace = "http://www.garmin.com/xmlschemas/TrackStatsExtension/v1")]
        public string TotalElapsedTime { get; set; }
        [XmlElement(ElementName = "MovingTime", Namespace = "http://www.garmin.com/xmlschemas/TrackStatsExtension/v1")]
        public string MovingTime { get; set; }
        [XmlElement(ElementName = "StoppedTime", Namespace = "http://www.garmin.com/xmlschemas/TrackStatsExtension/v1")]
        public string StoppedTime { get; set; }
        [XmlElement(ElementName = "MovingSpeed", Namespace = "http://www.garmin.com/xmlschemas/TrackStatsExtension/v1")]
        public string MovingSpeed { get; set; }
        [XmlElement(ElementName = "MaxSpeed", Namespace = "http://www.garmin.com/xmlschemas/TrackStatsExtension/v1")]
        public string MaxSpeed { get; set; }
        [XmlElement(ElementName = "MaxElevation", Namespace = "http://www.garmin.com/xmlschemas/TrackStatsExtension/v1")]
        public string MaxElevation { get; set; }
        [XmlElement(ElementName = "MinElevation", Namespace = "http://www.garmin.com/xmlschemas/TrackStatsExtension/v1")]
        public string MinElevation { get; set; }
        [XmlElement(ElementName = "Ascent", Namespace = "http://www.garmin.com/xmlschemas/TrackStatsExtension/v1")]
        public string Ascent { get; set; }
        [XmlElement(ElementName = "Descent", Namespace = "http://www.garmin.com/xmlschemas/TrackStatsExtension/v1")]
        public string Descent { get; set; }
        [XmlElement(ElementName = "AvgAscentRate", Namespace = "http://www.garmin.com/xmlschemas/TrackStatsExtension/v1")]
        public string AvgAscentRate { get; set; }
        [XmlElement(ElementName = "MaxAscentRate", Namespace = "http://www.garmin.com/xmlschemas/TrackStatsExtension/v1")]
        public string MaxAscentRate { get; set; }
        [XmlElement(ElementName = "AvgDescentRate", Namespace = "http://www.garmin.com/xmlschemas/TrackStatsExtension/v1")]
        public string AvgDescentRate { get; set; }
        [XmlElement(ElementName = "MaxDescentRate", Namespace = "http://www.garmin.com/xmlschemas/TrackStatsExtension/v1")]
        public string MaxDescentRate { get; set; }
    }

    [XmlRoot(ElementName = "extensions", Namespace = "http://www.topografix.com/GPX/1/1")]
    public class Extensions
    {
        [XmlElement(ElementName = "TrackExtension", Namespace = "http://www.garmin.com/xmlschemas/GpxExtensions/v3")]
        public TrackExtension TrackExtension { get; set; }
        [XmlElement(ElementName = "TrackStatsExtension", Namespace = "http://www.garmin.com/xmlschemas/TrackStatsExtension/v1")]
        public TrackStatsExtension TrackStatsExtension { get; set; }
    }

    [XmlRoot(ElementName = "trkpt", Namespace = "http://www.topografix.com/GPX/1/1")]
    public class Waypoints
    {
        [XmlElement(ElementName = "ele", Namespace = "http://www.topografix.com/GPX/1/1")]
        public string Elevation { get; set; }
        [XmlElement(ElementName = "time", Namespace = "http://www.topografix.com/GPX/1/1")]
        public string Time { get; set; }
        [XmlAttribute(AttributeName = "lat")]
        public string Latitude { get; set; }
        [XmlAttribute(AttributeName = "lon")]
        public string Longitude { get; set; }
    }

    [XmlRoot(ElementName = "trkseg", Namespace = "http://www.topografix.com/GPX/1/1")]
    public class TrackSegment
    {
        [XmlElement(ElementName = "trkpt", Namespace = "http://www.topografix.com/GPX/1/1")]
        public List<Waypoints> Waypoints { get; set; }
    }

    [XmlRoot(ElementName = "trk", Namespace = "http://www.topografix.com/GPX/1/1")]
    public class Track
    {
        [XmlElement(ElementName = "name", Namespace = "http://www.topografix.com/GPX/1/1")]
        public string Name { get; set; }
        [XmlElement(ElementName = "extensions", Namespace = "http://www.topografix.com/GPX/1/1")]
        public Extensions Extensions { get; set; }
        [XmlElement(ElementName = "trkseg", Namespace = "http://www.topografix.com/GPX/1/1")]
        public TrackSegment TrackSegment { get; set; }
    }

    [XmlRoot(ElementName = "gpx", Namespace = "http://www.topografix.com/GPX/1/1")]
    public class RootElement
    {
        [XmlElement(ElementName = "metadata", Namespace = "http://www.topografix.com/GPX/1/1")]
        public Metadata Metadata { get; set; }
        [XmlElement(ElementName = "trk", Namespace = "http://www.topografix.com/GPX/1/1")]
        public Track Track { get; set; }
        [XmlAttribute(AttributeName = "creator")]
        public string Creator { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
    }
#endregion
}