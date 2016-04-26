namespace musicDB
{
    partial class AddAlbum
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
            this.label_title = new System.Windows.Forms.Label();
            this.label_artist = new System.Windows.Forms.Label();
            this.text_title = new System.Windows.Forms.TextBox();
            this.text_artist = new System.Windows.Forms.TextBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.label_err = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Location = new System.Drawing.Point(12, 68);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(30, 13);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "Title:";
            // 
            // label_artist
            // 
            this.label_artist.AutoSize = true;
            this.label_artist.Location = new System.Drawing.Point(12, 107);
            this.label_artist.Name = "label_artist";
            this.label_artist.Size = new System.Drawing.Size(33, 13);
            this.label_artist.TabIndex = 1;
            this.label_artist.Text = "Artist:";
            // 
            // text_title
            // 
            this.text_title.Location = new System.Drawing.Point(15, 84);
            this.text_title.Name = "text_title";
            this.text_title.Size = new System.Drawing.Size(100, 20);
            this.text_title.TabIndex = 2;
            // 
            // text_artist
            // 
            this.text_artist.Location = new System.Drawing.Point(15, 123);
            this.text_artist.Name = "text_artist";
            this.text_artist.Size = new System.Drawing.Size(100, 20);
            this.text_artist.TabIndex = 3;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(15, 227);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 4;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(397, 449);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(75, 23);
            this.btn_back.TabIndex = 5;
            this.btn_back.Text = "back";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // label_err
            // 
            this.label_err.AutoSize = true;
            this.label_err.ForeColor = System.Drawing.Color.Crimson;
            this.label_err.Location = new System.Drawing.Point(15, 166);
            this.label_err.Name = "label_err";
            this.label_err.Size = new System.Drawing.Size(20, 13);
            this.label_err.TabIndex = 6;
            this.label_err.Text = "Err";
            this.label_err.Visible = false;
            // 
            // AddAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 484);
            this.Controls.Add(this.label_err);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.text_artist);
            this.Controls.Add(this.text_title);
            this.Controls.Add(this.label_artist);
            this.Controls.Add(this.label_title);
            this.Name = "AddAlbum";
            this.Text = "AddAlbum";
            this.Load += new System.EventHandler(this.AddAlbum_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_artist;
        private System.Windows.Forms.TextBox text_title;
        private System.Windows.Forms.TextBox text_artist;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label_err;
    }
}