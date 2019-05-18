﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PSeminar
{
    public partial class TrackData : Form
    {
        private List<Waypoints> _data;

        public TrackData()
        {
            InitializeComponent();
        }

        public TrackData(RootElement gpx)
        {
            InitializeComponent();
            _data = gpx.Track.TrackSegment.Waypoints;
        }

        private void TrackData_Load(object sender, EventArgs e)
        {
            ShowHeight();
        }

        private void ShowHeight()
        {
            for (var i = 0; i < _data.Count; i++)
            {
                heightChart.Series[0].Points.AddXY(i + 1, _data[i].Elevation);
            }
        }
    }
}