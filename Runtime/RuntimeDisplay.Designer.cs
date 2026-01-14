namespace KEBOT
{
    partial class RuntimeDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuntimeDisplay));
            this.PieChart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.RuntimeBackground = new System.Windows.Forms.RichTextBox();
            this.RuntChartContainer = new System.Windows.Forms.GroupBox();
            this.BarChart11 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ZoomIn = new System.Windows.Forms.Button();
            this.YZoomIn = new System.Windows.Forms.Button();
            this.ZoomOut = new System.Windows.Forms.Button();
            this.YZoomOut = new System.Windows.Forms.Button();
            this.RuntimeContainter2 = new System.Windows.Forms.GroupBox();
            this.RuntimeScrollbar = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.PieChart1)).BeginInit();
            this.RuntChartContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarChart11)).BeginInit();
            this.RuntimeContainter2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PieChart1
            // 
            this.PieChart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.PieChart1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Bottom;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            chartArea1.Name = "ChartArea1";
            this.PieChart1.ChartAreas.Add(chartArea1);
            this.PieChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.AntiqueWhite;
            legend1.Name = "Legend1";
            this.PieChart1.Legends.Add(legend1);
            this.PieChart1.Location = new System.Drawing.Point(394, 16);
            this.PieChart1.Name = "PieChart1";
            this.PieChart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.BackSecondaryColor = System.Drawing.Color.White;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.PieChart1.Series.Add(series1);
            this.PieChart1.Size = new System.Drawing.Size(568, 259);
            this.PieChart1.TabIndex = 18;
            this.PieChart1.Text = "PieChart1";
            this.PieChart1.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
            // 
            // RuntimeBackground
            // 
            this.RuntimeBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.RuntimeBackground.Cursor = System.Windows.Forms.Cursors.Default;
            this.RuntimeBackground.Dock = System.Windows.Forms.DockStyle.Left;
            this.RuntimeBackground.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RuntimeBackground.Location = new System.Drawing.Point(3, 16);
            this.RuntimeBackground.Name = "RuntimeBackground";
            this.RuntimeBackground.ReadOnly = true;
            this.RuntimeBackground.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.RuntimeBackground.Size = new System.Drawing.Size(391, 259);
            this.RuntimeBackground.TabIndex = 19;
            this.RuntimeBackground.Text = "";
            // 
            // RuntChartContainer
            // 
            this.RuntChartContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.RuntChartContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RuntChartContainer.Controls.Add(this.PieChart1);
            this.RuntChartContainer.Controls.Add(this.RuntimeBackground);
            this.RuntChartContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RuntChartContainer.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.RuntChartContainer.Location = new System.Drawing.Point(0, 365);
            this.RuntChartContainer.Name = "RuntChartContainer";
            this.RuntChartContainer.Size = new System.Drawing.Size(965, 278);
            this.RuntChartContainer.TabIndex = 24;
            this.RuntChartContainer.TabStop = false;
            // 
            // BarChart11
            // 
            this.BarChart11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.BarChart11.BorderlineColor = System.Drawing.Color.Black;
            chartArea2.AxisX.MajorGrid.Interval = 0D;
            chartArea2.AxisY.Title = "Time";
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "Default";
            this.BarChart11.ChartAreas.Add(chartArea2);
            this.BarChart11.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.BackColor = System.Drawing.Color.AntiqueWhite;
            legend2.BorderColor = System.Drawing.Color.WhiteSmoke;
            legend2.Name = "Legend1";
            this.BarChart11.Legends.Add(legend2);
            this.BarChart11.Location = new System.Drawing.Point(3, 16);
            this.BarChart11.Name = "BarChart11";
            series2.ChartArea = "Default";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar100;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.YValuesPerPoint = 3;
            this.BarChart11.Series.Add(series2);
            this.BarChart11.Size = new System.Drawing.Size(959, 330);
            this.BarChart11.TabIndex = 20;
            this.BarChart11.Text = "z";
            this.BarChart11.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            title1.Name = "Runtime";
            this.BarChart11.Titles.Add(title1);
            // 
            // ZoomIn
            // 
            this.ZoomIn.AccessibleName = "ZoomIn";
            this.ZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ZoomIn.BackColor = System.Drawing.SystemColors.Window;
            this.ZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ZoomIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoomIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ZoomIn.Location = new System.Drawing.Point(894, 202);
            this.ZoomIn.Name = "ZoomIn";
            this.ZoomIn.Size = new System.Drawing.Size(45, 47);
            this.ZoomIn.TabIndex = 18;
            this.ZoomIn.Text = "V+";
            this.ZoomIn.UseVisualStyleBackColor = false;
            this.ZoomIn.Click += new System.EventHandler(this.ZoomIn_Click);
            // 
            // YZoomIn
            // 
            this.YZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.YZoomIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YZoomIn.Image = global::KEBOT.Properties.Resources.blue_background2;
            this.YZoomIn.Location = new System.Drawing.Point(837, 201);
            this.YZoomIn.Name = "YZoomIn";
            this.YZoomIn.Size = new System.Drawing.Size(51, 48);
            this.YZoomIn.TabIndex = 20;
            this.YZoomIn.Text = "H+";
            this.YZoomIn.UseVisualStyleBackColor = true;
            this.YZoomIn.Click += new System.EventHandler(this.YZoomIn_Click);
            // 
            // ZoomOut
            // 
            this.ZoomOut.AccessibleName = "ZoomOut";
            this.ZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ZoomOut.BackColor = System.Drawing.SystemColors.Window;
            this.ZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ZoomOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoomOut.ForeColor = System.Drawing.SystemColors.Control;
            this.ZoomOut.Location = new System.Drawing.Point(894, 255);
            this.ZoomOut.Name = "ZoomOut";
            this.ZoomOut.Size = new System.Drawing.Size(45, 48);
            this.ZoomOut.TabIndex = 19;
            this.ZoomOut.Text = "V-";
            this.ZoomOut.UseVisualStyleBackColor = false;
            this.ZoomOut.Click += new System.EventHandler(this.ZoomOut_Click);
            // 
            // YZoomOut
            // 
            this.YZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.YZoomOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YZoomOut.Image = global::KEBOT.Properties.Resources.blue_background2;
            this.YZoomOut.Location = new System.Drawing.Point(837, 255);
            this.YZoomOut.Name = "YZoomOut";
            this.YZoomOut.Size = new System.Drawing.Size(51, 47);
            this.YZoomOut.TabIndex = 21;
            this.YZoomOut.Text = "H-";
            this.YZoomOut.UseVisualStyleBackColor = true;
            this.YZoomOut.Click += new System.EventHandler(this.YZoomOut_Click);
            // 
            // RuntimeContainter2
            // 
            this.RuntimeContainter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.RuntimeContainter2.Controls.Add(this.ZoomIn);
            this.RuntimeContainter2.Controls.Add(this.ZoomOut);
            this.RuntimeContainter2.Controls.Add(this.YZoomOut);
            this.RuntimeContainter2.Controls.Add(this.YZoomIn);
            this.RuntimeContainter2.Controls.Add(this.BarChart11);
            this.RuntimeContainter2.Controls.Add(this.RuntimeScrollbar);
            this.RuntimeContainter2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RuntimeContainter2.Location = new System.Drawing.Point(0, 0);
            this.RuntimeContainter2.Name = "RuntimeContainter2";
            this.RuntimeContainter2.Size = new System.Drawing.Size(965, 365);
            this.RuntimeContainter2.TabIndex = 25;
            this.RuntimeContainter2.TabStop = false;
            this.RuntimeContainter2.Text = "Runtime Analysis";
            // 
            // RuntimeScrollbar
            // 
            this.RuntimeScrollbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RuntimeScrollbar.LargeChange = 1;
            this.RuntimeScrollbar.Location = new System.Drawing.Point(3, 346);
            this.RuntimeScrollbar.Maximum = 24;
            this.RuntimeScrollbar.Name = "RuntimeScrollbar";
            this.RuntimeScrollbar.Size = new System.Drawing.Size(959, 16);
            this.RuntimeScrollbar.TabIndex = 26;
            this.RuntimeScrollbar.Visible = false;
            this.RuntimeScrollbar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.RuntimeScrollbar_Scroll);
            // 
            // RuntimeDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(965, 643);
            this.ControlBox = false;
            this.Controls.Add(this.RuntimeContainter2);
            this.Controls.Add(this.RuntChartContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "RuntimeDisplay";
            this.Text = "RuntimeDisplay";
            ((System.ComponentModel.ISupportInitialize)(this.PieChart1)).EndInit();
            this.RuntChartContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BarChart11)).EndInit();
            this.RuntimeContainter2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ZoomIn;
        private System.Windows.Forms.Button YZoomIn;
        private System.Windows.Forms.Button ZoomOut;
        private System.Windows.Forms.Button YZoomOut;
        private System.Windows.Forms.HScrollBar RuntimeScrollbar;
        public System.Windows.Forms.DataVisualization.Charting.Chart BarChart11;
        public System.Windows.Forms.DataVisualization.Charting.Chart PieChart1;
        public System.Windows.Forms.RichTextBox RuntimeBackground;
        public System.Windows.Forms.GroupBox RuntChartContainer;
        public System.Windows.Forms.GroupBox RuntimeContainter2;
    }
}