namespace KEBOT
{
    partial class CommentEnter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommentEnter));
            this.ConfirmCommentButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.CommentBox = new System.Windows.Forms.TextBox();
            this.Author = new System.Windows.Forms.TextBox();
            this.Comment_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ROWID = new System.Windows.Forms.Label();
            this.RowtextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ConfirmCommentButton
            // 
            this.ConfirmCommentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ConfirmCommentButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ConfirmCommentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmCommentButton.Location = new System.Drawing.Point(22, 318);
            this.ConfirmCommentButton.Name = "ConfirmCommentButton";
            this.ConfirmCommentButton.Size = new System.Drawing.Size(156, 51);
            this.ConfirmCommentButton.TabIndex = 0;
            this.ConfirmCommentButton.Text = "Confirm";
            this.ConfirmCommentButton.UseVisualStyleBackColor = false;
            this.ConfirmCommentButton.Click += new System.EventHandler(this.ConfirmCommentButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.CancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(315, 318);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(156, 51);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CommentBox
            // 
            this.CommentBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommentBox.Location = new System.Drawing.Point(12, 85);
            this.CommentBox.Multiline = true;
            this.CommentBox.Name = "CommentBox";
            this.CommentBox.Size = new System.Drawing.Size(472, 227);
            this.CommentBox.TabIndex = 2;
            this.CommentBox.TextChanged += new System.EventHandler(this.CommentBox_TextChanged);
            // 
            // Author
            // 
            this.Author.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Author.Location = new System.Drawing.Point(315, 30);
            this.Author.MaxLength = 40;
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(169, 26);
            this.Author.TabIndex = 4;
            this.Author.TextChanged += new System.EventHandler(this.Author_TextChanged);
            // 
            // Comment_Label
            // 
            this.Comment_Label.AutoSize = true;
            this.Comment_Label.BackColor = System.Drawing.Color.Transparent;
            this.Comment_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comment_Label.Location = new System.Drawing.Point(12, 62);
            this.Comment_Label.Name = "Comment_Label";
            this.Comment_Label.Size = new System.Drawing.Size(85, 20);
            this.Comment_Label.TabIndex = 5;
            this.Comment_Label.Text = "Comment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(311, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Author Name";
            // 
            // ROWID
            // 
            this.ROWID.AutoSize = true;
            this.ROWID.BackColor = System.Drawing.Color.Transparent;
            this.ROWID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ROWID.Location = new System.Drawing.Point(12, 7);
            this.ROWID.Name = "ROWID";
            this.ROWID.Size = new System.Drawing.Size(63, 20);
            this.ROWID.TabIndex = 7;
            this.ROWID.Text = "RowID";
            // 
            // RowtextBox
            // 
            this.RowtextBox.BackColor = System.Drawing.SystemColors.Info;
            this.RowtextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RowtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RowtextBox.Location = new System.Drawing.Point(12, 30);
            this.RowtextBox.MaxLength = 64;
            this.RowtextBox.Name = "RowtextBox";
            this.RowtextBox.ReadOnly = true;
            this.RowtextBox.Size = new System.Drawing.Size(297, 26);
            this.RowtextBox.TabIndex = 8;
            // 
            // CommentEnter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::KEBOT.Properties.Resources.blue_background2;
            this.ClientSize = new System.Drawing.Size(496, 381);
            this.ControlBox = false;
            this.Controls.Add(this.RowtextBox);
            this.Controls.Add(this.ROWID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Comment_Label);
            this.Controls.Add(this.Author);
            this.Controls.Add(this.CommentBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConfirmCommentButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CommentEnter";
            this.Text = "CommentEnter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button ConfirmCommentButton;
        protected new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox CommentBox;
        private System.Windows.Forms.TextBox Author;
        private System.Windows.Forms.Label Comment_Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ROWID;
        private System.Windows.Forms.TextBox RowtextBox;
    }
}