namespace KEBOT
{
    partial class Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.searchtext = new System.Windows.Forms.TextBox();
            this.FindNext = new System.Windows.Forms.Button();
            this.FindPrevious = new System.Windows.Forms.Button();
            this.CapOption = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // searchtext
            // 
            this.searchtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtext.Location = new System.Drawing.Point(12, 12);
            this.searchtext.Multiline = true;
            this.searchtext.Name = "searchtext";
            this.searchtext.Size = new System.Drawing.Size(259, 32);
            this.searchtext.TabIndex = 0;
            this.searchtext.TextChanged += new System.EventHandler(this.searchtext_TextChanged);
            // 
            // FindNext
            // 
            this.FindNext.Location = new System.Drawing.Point(277, 12);
            this.FindNext.MaximumSize = new System.Drawing.Size(90, 34);
            this.FindNext.MinimumSize = new System.Drawing.Size(90, 34);
            this.FindNext.Name = "FindNext";
            this.FindNext.Size = new System.Drawing.Size(90, 34);
            this.FindNext.TabIndex = 1;
            this.FindNext.Text = "Find Next";
            this.FindNext.UseVisualStyleBackColor = true;
            this.FindNext.Click += new System.EventHandler(this.FindNext_Click);
            // 
            // FindPrevious
            // 
            this.FindPrevious.Location = new System.Drawing.Point(277, 49);
            this.FindPrevious.Name = "FindPrevious";
            this.FindPrevious.Size = new System.Drawing.Size(90, 34);
            this.FindPrevious.TabIndex = 2;
            this.FindPrevious.Text = "Find Previous";
            this.FindPrevious.UseVisualStyleBackColor = true;
            this.FindPrevious.Click += new System.EventHandler(this.FindPrevious_Click);
            // 
            // CapOption
            // 
            this.CapOption.AutoSize = true;
            this.CapOption.Location = new System.Drawing.Point(25, 59);
            this.CapOption.Name = "CapOption";
            this.CapOption.Size = new System.Drawing.Size(95, 17);
            this.CapOption.TabIndex = 3;
            this.CapOption.Text = "Cap Sensative";
            this.CapOption.UseVisualStyleBackColor = true;
            this.CapOption.CheckedChanged += new System.EventHandler(this.CapOption_CheckedChanged);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(374, 85);
            this.Controls.Add(this.CapOption);
            this.Controls.Add(this.FindPrevious);
            this.Controls.Add(this.FindNext);
            this.Controls.Add(this.searchtext);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(390, 124);
            this.MinimumSize = new System.Drawing.Size(390, 124);
            this.Name = "Search";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Search";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Load += new System.EventHandler(this.search);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchtext;
        private System.Windows.Forms.Button FindNext;
        private System.Windows.Forms.Button FindPrevious;
        private System.Windows.Forms.CheckBox CapOption;
    }
}