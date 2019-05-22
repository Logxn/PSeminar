using System;
using System.Windows.Forms;
using System.IO;
using PSeminar.Config;

namespace PSeminar
{
    public partial class Main : Form
    {
        private static string _googleMapsApiKey;
        private static Map _map;
        private static RootElement _gpx;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
            var configManger = new ConfigManager();
            _googleMapsApiKey = configManger.LoadConfig().GoogleApiKey;
            if (string.IsNullOrWhiteSpace((_googleMapsApiKey)))
            {
                MessageBox.Show(@"Fehler: Es wurde kein API-Key für Google Maps in die Einstellungsdatei eingetragen! Das Programm schließt sich nun.",
                    @"Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Environment.Exit(1);
            }

            _map = new Map(_googleMapsApiKey);
        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            var result = fileDialog.ShowDialog();

            if (result != DialogResult.OK) return;
            if (!fileDialog.CheckFileExists) return;
            if (!fileDialog.CheckPathExists) return;

            var file = new FileInfo(fileDialog.FileName);
            _map.ParseTrack(file);
        }

        public void SetGpx(RootElement gpx)
        {
            _gpx = gpx;
        }

        public void SetStatus(string content)
        {
            statusLabel.Text = content;
        }

        private void HöhenverlaufMenu_Click(object sender, EventArgs e)
        {
            if (_gpx == null) return;

            var höhenVerlauf = new HöhenVerlauf(_gpx);
            höhenVerlauf.Show();
        }

        private void HöhenMenu_Click(object sender, EventArgs e)
        {
            if (_gpx == null) return;

            var höhen = new Höhen(_gpx);
            höhen.Show();
        }

        private void WegbeschaffenheitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_map.IsNickelTrack()) return;

            var wegbeschaffenheit = new Wegbeschaffenheit();
            wegbeschaffenheit.Show();
        }
    }
}
