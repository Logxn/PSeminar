 * IMPORTANT INFORMATION: This is a school project. All comments are in German!
 * Dieser Code ist nur eine Rohfassung. Es wurde hier NICHT explizit auf korrekte Objekt-Orientierung geachtet,
 * da nur wenig Zeit zur Vollendung blieb.
 * Motto-des-Monats: "Hauptsache es funktioniert."
 *
 * Dennoch richtet sich der Code nach allgemeinen .NET Konventionen
 * siehe (https://de.wikibooks.org/wiki/Arbeiten_mit_.NET:_Allgemeines/_Anhang/_Namenskonventionen)
 * Dies wurde durch eine Visual Studio Erweiterung "JetBrains ReSharper" sichergestellt.
 *
 * Projektname: P-Seminar Ickelheim Wanderweg (Q11)
 * Lizenz: GNU General Public License
 * Author: Logan Thompson -> github.com/Logxn/
 * Kontakt: hello@loganthompson.de
 * Letzte Änderung: 18.05.2019 13:28 Uhr
 *
 * Changelog:
 * [Version 1.4]: 
 * - [NEU] Aktueller Track vom 19.04.2019
 * - [NEU - ROHFASSUNG] Diagramm der Trackhöhe
 * - [NEU] Streckendarstellung als Linie und nicht mehr mit Markern
 * - [NEU] Automatisches Laden der Trackdatei
 * - [VERBESSERT] Alle Elemente der Klasse Models.cs wurden korrekt benannt
 * - [VERBESSERT] Graphen werden direkt beim Start des Programms geladen
 * - [ENTFERNT] DEBUG Funktionen
 * - [ENTFERNT] Marker
 *
 * [Version 1.3]: 
 * - [NEU] Informationen und Kommentare
 * - [GEÄNDERT] Aufteilen aller Funktionen in ihre zugehörigen Klassen
 * - [VERBESSERT] Leserlichkeit des Codes
 *
 * [Version 1.2]: 
 * - [NEU] Einbinden einer Karte
 * - [NEU] Setzen von Markern
 * - [NEU] Setzen von Spezialpunkten
 * - [NEU] Allgemine Daten des Tracks (Dauer, Gesamtlänge, etc.) ausgelesen
 *
 * [Version 1.1]: 
 * - [NEU] Integrieren der Google Maps API
 * - [GEÄNDERT] Auslesen der Trackpunkte verschönert (XMLSerializer)
 * - [RELEASE - ENTFERNT] Auslesen der Laufwerke, sowie finden des GPS Geräts
 *
 * [Version 1.0]: 
 * - [NEU] Auslesen aller Laufwerke
 * - [NEU] Finden des GPS Geräts
 * - [NEU] Rohfassung auslesen der Trackpunkte