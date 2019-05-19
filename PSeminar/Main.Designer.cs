namespace PSeminar
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupLegende = new System.Windows.Forms.GroupBox();
            this.labelQuelle = new System.Windows.Forms.Label();
            this.labelGipsbruch = new System.Windows.Forms.Label();
            this.labelStartZiel = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.HöhenverlaufMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.HöhenMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.trackinfosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupLegende.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupLegende
            // 
            this.groupLegende.Controls.Add(this.labelQuelle);
            this.groupLegende.Controls.Add(this.labelGipsbruch);
            this.groupLegende.Controls.Add(this.labelStartZiel);
            this.groupLegende.Location = new System.Drawing.Point(9, 206);
            this.groupLegende.Margin = new System.Windows.Forms.Padding(2);
            this.groupLegende.Name = "groupLegende";
            this.groupLegende.Padding = new System.Windows.Forms.Padding(2);
            this.groupLegende.Size = new System.Drawing.Size(101, 101);
            this.groupLegende.TabIndex = 0;
            this.groupLegende.TabStop = false;
            this.groupLegende.Text = "Legende";
            // 
            // labelQuelle
            // 
            this.labelQuelle.AutoSize = true;
            this.labelQuelle.Location = new System.Drawing.Point(4, 72);
            this.labelQuelle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelQuelle.Name = "labelQuelle";
            this.labelQuelle.Size = new System.Drawing.Size(57, 13);
            this.labelQuelle.TabIndex = 2;
            this.labelQuelle.Text = "Q = Quelle";
            // 
            // labelGipsbruch
            // 
            this.labelGipsbruch.AutoSize = true;
            this.labelGipsbruch.Location = new System.Drawing.Point(4, 47);
            this.labelGipsbruch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGipsbruch.Name = "labelGipsbruch";
            this.labelGipsbruch.Size = new System.Drawing.Size(75, 13);
            this.labelGipsbruch.TabIndex = 1;
            this.labelGipsbruch.Text = "G = Gipsbruch";
            // 
            // labelStartZiel
            // 
            this.labelStartZiel.AutoSize = true;
            this.labelStartZiel.Location = new System.Drawing.Point(4, 22);
            this.labelStartZiel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStartZiel.Name = "labelStartZiel";
            this.labelStartZiel.Size = new System.Drawing.Size(82, 13);
            this.labelStartZiel.TabIndex = 0;
            this.labelStartZiel.Text = "S/Z = Start/Ziel";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpen,
            this.menuGraph,
            this.trackinfosToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(806, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuOpen
            // 
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(56, 20);
            this.menuOpen.Text = "Öffnen";
            this.menuOpen.Click += new System.EventHandler(this.MenuOpen_Click);
            // 
            // menuGraph
            // 
            this.menuGraph.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HöhenverlaufMenu,
            this.HöhenMenu});
            this.menuGraph.Name = "menuGraph";
            this.menuGraph.Size = new System.Drawing.Size(64, 20);
            this.menuGraph.Text = "Graphen";
            // 
            // HöhenverlaufMenu
            // 
            this.HöhenverlaufMenu.Name = "HöhenverlaufMenu";
            this.HöhenverlaufMenu.Size = new System.Drawing.Size(180, 22);
            this.HöhenverlaufMenu.Text = "Höhenverlauf";
            this.HöhenverlaufMenu.Click += new System.EventHandler(this.HöhenverlaufMenu_Click);
            // 
            // fileDialog
            // 
            this.fileDialog.Filter = "GPX-Dateien (*.gpx)|*.gpx|Alle Dateien (*.*)|*.*";
            this.fileDialog.InitialDirectory = "C:\\";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 496);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(806, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(35, 17);
            this.statusLabel.Text = "Idle...";
            // 
            // HöhenMenu
            // 
            this.HöhenMenu.Name = "HöhenMenu";
            this.HöhenMenu.Size = new System.Drawing.Size(180, 22);
            this.HöhenMenu.Text = "Höhen";
            this.HöhenMenu.Click += new System.EventHandler(this.HöhenMenu_Click);
            // 
            // trackinfosToolStripMenuItem
            // 
            this.trackinfosToolStripMenuItem.Name = "trackinfosToolStripMenuItem";
            this.trackinfosToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.trackinfosToolStripMenuItem.Text = "Trackinfos";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 518);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupLegende);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Main";
            this.Text = "P-Seminar Projekt: Wanderweg Ickeheim - github.com/Logxn - www.loganthompson.de";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupLegende.ResumeLayout(false);
            this.groupLegende.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupLegende;
        private System.Windows.Forms.Label labelQuelle;
        private System.Windows.Forms.Label labelGipsbruch;
        private System.Windows.Forms.Label labelStartZiel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem menuGraph;
        private System.Windows.Forms.ToolStripMenuItem HöhenverlaufMenu;
        private System.Windows.Forms.ToolStripMenuItem HöhenMenu;
        private System.Windows.Forms.ToolStripMenuItem trackinfosToolStripMenuItem;
    }
}

