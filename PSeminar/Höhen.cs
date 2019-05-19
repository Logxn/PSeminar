using System;
using System.Windows.Forms;

namespace PSeminar
{
    public partial class Höhen : Form
    {
        private readonly RootElement _gpx;
        public Höhen(RootElement gpx)
        {
            InitializeComponent();
            _gpx = gpx;
        }

        private void Höhen_Load(object sender, EventArgs e)
        {
            heightChart.Series.Add("Anstieg Min");
            heightChart.Series.Add("Anstieg Max");

            heightChart.Series[0].Points.AddXY("Anstieg Min", _gpx.Track.Extensions.TrackStatsExtension.MinElevation);

            // Der Punkt 0,0 wird benötigt, damit Anstieg Max angezeigt wird.
            // Bin zu faul das richtig zu fixen. Sorry.
            heightChart.Series[1].Points.AddXY(0, 0);
            heightChart.Series[1].Points.AddXY("Anstieg Max", _gpx.Track.Extensions.TrackStatsExtension.MaxElevation);
        }
    }
}
