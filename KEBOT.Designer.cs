using System;
using System.Reflection;

namespace KEBOT
{
    partial class KEBOT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        /// 

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KEBOT));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsXcel = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThemeMenu_DefaultThemeSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.ThemeMenu_PrinterFriendlyThemeSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ActiveRead = new System.Windows.Forms.CheckBox();
            this.StartTime = new System.Windows.Forms.Label();
            this.EndTime = new System.Windows.Forms.Label();
            this.Get_Data = new System.Windows.Forms.Button();
            this.DialogueBox = new System.Windows.Forms.TextBox();
            this.MachineList = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HAAS2012L = new System.Windows.Forms.ToolStripMenuItem();
            this.HAAS2012M = new System.Windows.Forms.ToolStripMenuItem();
            this.HAAS2105 = new System.Windows.Forms.ToolStripMenuItem();
            this.Doosan2107 = new System.Windows.Forms.ToolStripMenuItem();
            this.mazak2111 = new System.Windows.Forms.ToolStripMenuItem();
            this.mazak2112 = new System.Windows.Forms.ToolStripMenuItem();
            this.mazak2260 = new System.Windows.Forms.ToolStripMenuItem();
            this.DOOSAN2271 = new System.Windows.Forms.ToolStripMenuItem();
            this.mazak2272 = new System.Windows.Forms.ToolStripMenuItem();
            this.mazak2280 = new System.Windows.Forms.ToolStripMenuItem();
            this.mazak2281 = new System.Windows.Forms.ToolStripMenuItem();
            this.mazak2282 = new System.Windows.Forms.ToolStripMenuItem();
            this.mazak2283 = new System.Windows.Forms.ToolStripMenuItem();
            this.lAPMASTER2321 = new System.Windows.Forms.ToolStripMenuItem();
            this.amada3111 = new System.Windows.Forms.ToolStripMenuItem();
            this.amada3112 = new System.Windows.Forms.ToolStripMenuItem();
            this.BDTRONIC3321 = new System.Windows.Forms.ToolStripMenuItem();
            this.Rversion = new System.Windows.Forms.Label();
            this.dataSet1 = new System.Data.DataSet();
            this.ReportMenu = new System.Windows.Forms.MenuStrip();
            this.ViewTypeStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullDataLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.machineStateDataLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addComment = new System.Windows.Forms.ToolStripMenuItem();
            this.runtimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cycleTimeAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.paneldisplay = new System.Windows.Forms.Panel();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.MachineList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.ReportMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Location = new System.Drawing.Point(545, 4);
            this.dateTimePicker1.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Value = new System.DateTime(2025, 9, 1, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker2.Location = new System.Drawing.Point(809, 3);
            this.dateTimePicker2.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 1;
            this.dateTimePicker2.Value = new System.DateTime(2025, 9, 30, 0, 0, 0, 0);
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.themeToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.searchToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1260, 24);
            this.MainMenu.TabIndex = 2;
            this.MainMenu.Text = "FileMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAsXcel});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportAsXcel
            // 
            this.exportAsXcel.Name = "exportAsXcel";
            this.exportAsXcel.Size = new System.Drawing.Size(152, 22);
            this.exportAsXcel.Text = "Export as Excel";
            this.exportAsXcel.Click += new System.EventHandler(this.exportAsXcel_Click);
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ThemeMenu_DefaultThemeSelect,
            this.ThemeMenu_PrinterFriendlyThemeSelect});
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.themeToolStripMenuItem.Text = "Theme";
            // 
            // ThemeMenu_DefaultThemeSelect
            // 
            this.ThemeMenu_DefaultThemeSelect.Name = "ThemeMenu_DefaultThemeSelect";
            this.ThemeMenu_DefaultThemeSelect.Size = new System.Drawing.Size(154, 22);
            this.ThemeMenu_DefaultThemeSelect.Text = "Default";
            this.ThemeMenu_DefaultThemeSelect.Click += new System.EventHandler(this.ThemeMenu_DefaultThemeSelect_Click);
            // 
            // ThemeMenu_PrinterFriendlyThemeSelect
            // 
            this.ThemeMenu_PrinterFriendlyThemeSelect.Name = "ThemeMenu_PrinterFriendlyThemeSelect";
            this.ThemeMenu_PrinterFriendlyThemeSelect.Size = new System.Drawing.Size(154, 22);
            this.ThemeMenu_PrinterFriendlyThemeSelect.Text = "Printer Friendly";
            this.ThemeMenu_PrinterFriendlyThemeSelect.Click += new System.EventHandler(this.ThemeMenu_PrinterFriendlyThemeSelect_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // ActiveRead
            // 
            this.ActiveRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ActiveRead.AutoSize = true;
            this.ActiveRead.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ActiveRead.Location = new System.Drawing.Point(1086, 7);
            this.ActiveRead.Name = "ActiveRead";
            this.ActiveRead.Size = new System.Drawing.Size(109, 17);
            this.ActiveRead.TabIndex = 4;
            this.ActiveRead.Text = "ActiveReadMode";
            this.ActiveRead.UseVisualStyleBackColor = false;
            this.ActiveRead.CheckedChanged += new System.EventHandler(this.ActiveRead_CheckedChanged);
            // 
            // StartTime
            // 
            this.StartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartTime.AutoSize = true;
            this.StartTime.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.StartTime.Location = new System.Drawing.Point(484, 6);
            this.StartTime.Name = "StartTime";
            this.StartTime.Size = new System.Drawing.Size(55, 13);
            this.StartTime.TabIndex = 5;
            this.StartTime.Text = "Start Time";
            // 
            // EndTime
            // 
            this.EndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EndTime.AutoSize = true;
            this.EndTime.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.EndTime.Location = new System.Drawing.Point(751, 6);
            this.EndTime.Name = "EndTime";
            this.EndTime.Size = new System.Drawing.Size(52, 13);
            this.EndTime.TabIndex = 6;
            this.EndTime.Text = "End Time";
            // 
            // Get_Data
            // 
            this.Get_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Get_Data.Location = new System.Drawing.Point(1015, 3);
            this.Get_Data.Name = "Get_Data";
            this.Get_Data.Size = new System.Drawing.Size(65, 23);
            this.Get_Data.TabIndex = 7;
            this.Get_Data.Text = "Get Data";
            this.Get_Data.UseVisualStyleBackColor = true;
            this.Get_Data.Click += new System.EventHandler(this.Get_Data_Click);
            // 
            // DialogueBox
            // 
            this.DialogueBox.BackColor = System.Drawing.Color.Black;
            this.DialogueBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DialogueBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.DialogueBox.Location = new System.Drawing.Point(154, 686);
            this.DialogueBox.Multiline = true;
            this.DialogueBox.Name = "DialogueBox";
            this.DialogueBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DialogueBox.Size = new System.Drawing.Size(1106, 66);
            this.DialogueBox.TabIndex = 10;
            // 
            // MachineList
            // 
            this.MachineList.BackColor = System.Drawing.Color.DimGray;
            this.MachineList.Dock = System.Windows.Forms.DockStyle.Left;
            this.MachineList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.HAAS2012L,
            this.HAAS2012M,
            this.HAAS2105,
            this.Doosan2107,
            this.mazak2111,
            this.mazak2112,
            this.mazak2260,
            this.DOOSAN2271,
            this.mazak2272,
            this.mazak2280,
            this.mazak2281,
            this.mazak2282,
            this.mazak2283,
            this.lAPMASTER2321,
            this.amada3111,
            this.amada3112,
            this.BDTRONIC3321});
            this.MachineList.Location = new System.Drawing.Point(0, 24);
            this.MachineList.Name = "MachineList";
            this.MachineList.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MachineList.Size = new System.Drawing.Size(154, 728);
            this.MachineList.TabIndex = 13;
            this.MachineList.Text = "Machines";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.homeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(141, 29);
            this.homeToolStripMenuItem.Text = "WorkCenter";
            // 
            // HAAS2012L
            // 
            this.HAAS2012L.BackColor = System.Drawing.Color.Transparent;
            this.HAAS2012L.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HAAS2012L.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.HAAS2012L.Name = "HAAS2012L";
            this.HAAS2012L.Size = new System.Drawing.Size(141, 29);
            this.HAAS2012L.Text = "HAAS 2102L";
            this.HAAS2012L.Click += new System.EventHandler(this.HAAS2012L_Click_1);
            // 
            // HAAS2012M
            // 
            this.HAAS2012M.BackColor = System.Drawing.Color.Transparent;
            this.HAAS2012M.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HAAS2012M.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.HAAS2012M.Name = "HAAS2012M";
            this.HAAS2012M.Size = new System.Drawing.Size(141, 29);
            this.HAAS2012M.Text = "HAAS 2102M";
            this.HAAS2012M.Click += new System.EventHandler(this.HAAS2012M_Click_1);
            // 
            // HAAS2105
            // 
            this.HAAS2105.BackColor = System.Drawing.Color.Transparent;
            this.HAAS2105.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.HAAS2105.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.HAAS2105.Name = "HAAS2105";
            this.HAAS2105.Size = new System.Drawing.Size(141, 29);
            this.HAAS2105.Text = "HAAS 2105";
            this.HAAS2105.Click += new System.EventHandler(this.hAAS2105ToolStripMenuItem_Click);
            // 
            // Doosan2107
            // 
            this.Doosan2107.BackColor = System.Drawing.Color.Transparent;
            this.Doosan2107.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.Doosan2107.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Doosan2107.Name = "Doosan2107";
            this.Doosan2107.Size = new System.Drawing.Size(141, 29);
            this.Doosan2107.Text = "DOOSAN 2107";
            this.Doosan2107.Click += new System.EventHandler(this.dOOSAN2107ToolStripMenuItem_Click);
            // 
            // mazak2111
            // 
            this.mazak2111.BackColor = System.Drawing.Color.Transparent;
            this.mazak2111.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mazak2111.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.mazak2111.Name = "mazak2111";
            this.mazak2111.Size = new System.Drawing.Size(141, 29);
            this.mazak2111.Text = "MAZAK 2111";
            this.mazak2111.Click += new System.EventHandler(this.mazak2111_Click);
            // 
            // mazak2112
            // 
            this.mazak2112.BackColor = System.Drawing.Color.Transparent;
            this.mazak2112.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.mazak2112.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.mazak2112.Name = "mazak2112";
            this.mazak2112.Size = new System.Drawing.Size(141, 29);
            this.mazak2112.Text = "MAZAK 2112";
            this.mazak2112.Click += new System.EventHandler(this.mazak2112_Click);
            // 
            // mazak2260
            // 
            this.mazak2260.BackColor = System.Drawing.Color.Transparent;
            this.mazak2260.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.mazak2260.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.mazak2260.Name = "mazak2260";
            this.mazak2260.Size = new System.Drawing.Size(141, 29);
            this.mazak2260.Text = "MAZAK 2260";
            this.mazak2260.Click += new System.EventHandler(this.mazak2260_Click);
            // 
            // DOOSAN2271
            // 
            this.DOOSAN2271.BackColor = System.Drawing.Color.Transparent;
            this.DOOSAN2271.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.DOOSAN2271.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.DOOSAN2271.Name = "DOOSAN2271";
            this.DOOSAN2271.Size = new System.Drawing.Size(141, 29);
            this.DOOSAN2271.Text = "DOOSAN 2271";
            this.DOOSAN2271.Click += new System.EventHandler(this.DOOSAN2271_Click);
            // 
            // mazak2272
            // 
            this.mazak2272.BackColor = System.Drawing.Color.Transparent;
            this.mazak2272.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.mazak2272.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.mazak2272.Name = "mazak2272";
            this.mazak2272.Size = new System.Drawing.Size(141, 29);
            this.mazak2272.Text = "MAZAK 2272";
            this.mazak2272.Click += new System.EventHandler(this.mazak2272_Click);
            // 
            // mazak2280
            // 
            this.mazak2280.BackColor = System.Drawing.Color.Transparent;
            this.mazak2280.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.mazak2280.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.mazak2280.Name = "mazak2280";
            this.mazak2280.Size = new System.Drawing.Size(141, 29);
            this.mazak2280.Text = "MAZAK 2280";
            this.mazak2280.Click += new System.EventHandler(this.mazak2280_Click);
            // 
            // mazak2281
            // 
            this.mazak2281.BackColor = System.Drawing.Color.Transparent;
            this.mazak2281.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.mazak2281.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.mazak2281.Name = "mazak2281";
            this.mazak2281.Size = new System.Drawing.Size(141, 29);
            this.mazak2281.Text = "MAZAK 2281";
            this.mazak2281.Click += new System.EventHandler(this.mazak2281_Click);
            // 
            // mazak2282
            // 
            this.mazak2282.BackColor = System.Drawing.Color.Transparent;
            this.mazak2282.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.mazak2282.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.mazak2282.Name = "mazak2282";
            this.mazak2282.Size = new System.Drawing.Size(141, 29);
            this.mazak2282.Text = "MAZAK 2282";
            this.mazak2282.Click += new System.EventHandler(this.mazak2282_Click);
            // 
            // mazak2283
            // 
            this.mazak2283.BackColor = System.Drawing.Color.Transparent;
            this.mazak2283.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.mazak2283.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.mazak2283.Name = "mazak2283";
            this.mazak2283.Size = new System.Drawing.Size(141, 29);
            this.mazak2283.Text = "MAZAK 2283";
            this.mazak2283.Click += new System.EventHandler(this.mazak2283_Click);
            // 
            // lAPMASTER2321
            // 
            this.lAPMASTER2321.BackColor = System.Drawing.Color.Transparent;
            this.lAPMASTER2321.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lAPMASTER2321.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lAPMASTER2321.Name = "lAPMASTER2321";
            this.lAPMASTER2321.Size = new System.Drawing.Size(141, 25);
            this.lAPMASTER2321.Text = "LAPMASTER 2321";
            this.lAPMASTER2321.Click += new System.EventHandler(this.lAPMASTER2321_Click);
            // 
            // amada3111
            // 
            this.amada3111.BackColor = System.Drawing.Color.Transparent;
            this.amada3111.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.amada3111.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.amada3111.Name = "amada3111";
            this.amada3111.Size = new System.Drawing.Size(141, 29);
            this.amada3111.Text = "SPARTAN 3111";
            this.amada3111.Click += new System.EventHandler(this.amada3111_Click);
            // 
            // amada3112
            // 
            this.amada3112.BackColor = System.Drawing.Color.Transparent;
            this.amada3112.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.amada3112.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.amada3112.Name = "amada3112";
            this.amada3112.Size = new System.Drawing.Size(141, 29);
            this.amada3112.Text = "AMADA 3112";
            this.amada3112.Click += new System.EventHandler(this.amada3112_Click);
            // 
            // BDTRONIC3321
            // 
            this.BDTRONIC3321.BackColor = System.Drawing.Color.Transparent;
            this.BDTRONIC3321.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BDTRONIC3321.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BDTRONIC3321.Name = "BDTRONIC3321";
            this.BDTRONIC3321.Size = new System.Drawing.Size(141, 25);
            this.BDTRONIC3321.Text = "BDTRONIC 3321";
            this.BDTRONIC3321.Click += new System.EventHandler(this.BDTRONIC3321_Click);
            // 
            // Rversion
            // 
            this.Rversion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Rversion.AutoSize = true;
            this.Rversion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Rversion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Rversion.Location = new System.Drawing.Point(1208, 6);
            this.Rversion.Name = "Rversion";
            this.Rversion.Size = new System.Drawing.Size(40, 13);
            this.Rversion.TabIndex = 15;
            this.Rversion.Text = "0.0.1.3";
            this.Rversion.Click += new System.EventHandler(this.Rversion_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // ReportMenu
            // 
            this.ReportMenu.BackColor = System.Drawing.Color.White;
            this.ReportMenu.BackgroundImage = global::KEBOT.Properties.Resources.blue_background2;
            this.ReportMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ReportMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.ReportMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewTypeStripMenuItem,
            this.aboutToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.addComment,
            this.runtimeToolStripMenuItem,
            this.cycleTimeAnalysis});
            this.ReportMenu.Location = new System.Drawing.Point(154, 24);
            this.ReportMenu.Name = "ReportMenu";
            this.ReportMenu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ReportMenu.Size = new System.Drawing.Size(129, 662);
            this.ReportMenu.TabIndex = 11;
            this.ReportMenu.Text = "menuStrip1";
            // 
            // ViewTypeStripMenuItem
            // 
            this.ViewTypeStripMenuItem.BackColor = System.Drawing.Color.White;
            this.ViewTypeStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewTypeStripMenuItem.Name = "ViewTypeStripMenuItem";
            this.ViewTypeStripMenuItem.Size = new System.Drawing.Size(116, 29);
            this.ViewTypeStripMenuItem.Text = "Viewtype";
            this.ViewTypeStripMenuItem.Click += new System.EventHandler(this.ViewTypeStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 21);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click_1);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullDataLogToolStripMenuItem,
            this.machineStateDataLogToolStripMenuItem});
            this.dataToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(116, 21);
            this.dataToolStripMenuItem.Text = "Data Log";
            this.dataToolStripMenuItem.Click += new System.EventHandler(this.dataToolStripMenuItem_Click);
            // 
            // fullDataLogToolStripMenuItem
            // 
            this.fullDataLogToolStripMenuItem.Name = "fullDataLogToolStripMenuItem";
            this.fullDataLogToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.fullDataLogToolStripMenuItem.Text = "Full Data Log";
            this.fullDataLogToolStripMenuItem.Click += new System.EventHandler(this.fullDataLogToolStripMenuItem_Click_1);
            // 
            // machineStateDataLogToolStripMenuItem
            // 
            this.machineStateDataLogToolStripMenuItem.Name = "machineStateDataLogToolStripMenuItem";
            this.machineStateDataLogToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.machineStateDataLogToolStripMenuItem.Text = "Machine State Data Log";
            this.machineStateDataLogToolStripMenuItem.Click += new System.EventHandler(this.machineStateDataLogToolStripMenuItem_Click_1);
            // 
            // addComment
            // 
            this.addComment.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addComment.Name = "addComment";
            this.addComment.Size = new System.Drawing.Size(116, 21);
            this.addComment.Text = "Add Comment";
            this.addComment.Click += new System.EventHandler(this.addComment_Click);
            // 
            // runtimeToolStripMenuItem
            // 
            this.runtimeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runtimeToolStripMenuItem.Name = "runtimeToolStripMenuItem";
            this.runtimeToolStripMenuItem.Size = new System.Drawing.Size(116, 21);
            this.runtimeToolStripMenuItem.Text = "Runtime";
            this.runtimeToolStripMenuItem.Click += new System.EventHandler(this.runtimeToolStripMenuItem_Click);
            // 
            // cycleTimeAnalysis
            // 
            this.cycleTimeAnalysis.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cycleTimeAnalysis.Name = "cycleTimeAnalysis";
            this.cycleTimeAnalysis.Size = new System.Drawing.Size(116, 19);
            this.cycleTimeAnalysis.Text = "CycleTime Analysis ";
            this.cycleTimeAnalysis.Click += new System.EventHandler(this.cycleTimeAnalysis_Click);
            // 
            // paneldisplay
            // 
            this.paneldisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.paneldisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneldisplay.Location = new System.Drawing.Point(283, 24);
            this.paneldisplay.Name = "paneldisplay";
            this.paneldisplay.Size = new System.Drawing.Size(977, 662);
            this.paneldisplay.TabIndex = 36;
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // KEBOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1260, 752);
            this.Controls.Add(this.paneldisplay);
            this.Controls.Add(this.Rversion);
            this.Controls.Add(this.ReportMenu);
            this.Controls.Add(this.Get_Data);
            this.Controls.Add(this.EndTime);
            this.Controls.Add(this.StartTime);
            this.Controls.Add(this.ActiveRead);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.DialogueBox);
            this.Controls.Add(this.MachineList);
            this.Controls.Add(this.MainMenu);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.ReportMenu;
            this.Name = "KEBOT";
            this.Text = "KEB Operations Tracker";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.MachineList.ResumeLayout(false);
            this.MachineList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ReportMenu.ResumeLayout(false);
            this.ReportMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.CheckBox ActiveRead;
        private System.Windows.Forms.Label StartTime;
        private System.Windows.Forms.Label EndTime;
        private System.Windows.Forms.Button Get_Data;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThemeMenu_DefaultThemeSelect;
        private System.Windows.Forms.ToolStripMenuItem ThemeMenu_PrinterFriendlyThemeSelect;
        public System.Windows.Forms.TextBox DialogueBox;
        private System.Windows.Forms.MenuStrip ReportMenu;
        private System.Windows.Forms.MenuStrip MachineList;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HAAS2012L;
        private System.Windows.Forms.ToolStripMenuItem HAAS2012M;
        private System.Windows.Forms.ToolStripMenuItem ViewTypeStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runtimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HAAS2105;
        private System.Windows.Forms.ToolStripMenuItem Doosan2107;
        private System.Windows.Forms.ToolStripMenuItem mazak2111;
        private System.Windows.Forms.ToolStripMenuItem mazak2112;
        private System.Windows.Forms.ToolStripMenuItem mazak2260;
        private System.Windows.Forms.ToolStripMenuItem DOOSAN2271;
        private System.Windows.Forms.ToolStripMenuItem mazak2272;
        private System.Windows.Forms.ToolStripMenuItem mazak2280;
        private System.Windows.Forms.ToolStripMenuItem mazak2281;
        private System.Windows.Forms.ToolStripMenuItem mazak2282;
        private System.Windows.Forms.ToolStripMenuItem mazak2283;
        private System.Windows.Forms.ToolStripMenuItem lAPMASTER2321;
        private System.Windows.Forms.ToolStripMenuItem amada3111;
        private System.Windows.Forms.ToolStripMenuItem amada3112;
        private System.Windows.Forms.ToolStripMenuItem BDTRONIC3321;
        private System.Windows.Forms.ToolStripMenuItem fullDataLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem machineStateDataLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addComment;
        private System.Windows.Forms.ToolStripMenuItem cycleTimeAnalysis;
        private System.Windows.Forms.Label Rversion;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAsXcel;
        private System.Data.DataSet dataSet1;
        private System.ServiceProcess.ServiceController serviceController1;
        private System.Windows.Forms.Panel paneldisplay;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
    }
}

