namespace musicDB
{
    partial class Form1
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
            this.titles = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.details = new System.Windows.Forms.Button();
            this.add_album = new System.Windows.Forms.Button();
            this.err = new System.Windows.Forms.Label();
            this.title_listBox = new System.Windows.Forms.ListBox();
            this.btn_show = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backup = new System.Windows.Forms.Button();
            this.open_new_albums = new System.Windows.Forms.Button();
            this.save_backup = new System.Windows.Forms.SaveFileDialog();
            this.open_saved_albums = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.new_coll = new System.Windows.Forms.Button();
            this.text_abumId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titles
            // 
            this.titles.Location = new System.Drawing.Point(78, 78);
            this.titles.Name = "titles";
            this.titles.Size = new System.Drawing.Size(100, 20);
            this.titles.TabIndex = 5;
            this.titles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.titles_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Album Name:";
            // 
            // details
            // 
            this.details.Location = new System.Drawing.Point(78, 136);
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(75, 23);
            this.details.TabIndex = 7;
            this.details.Text = "View details";
            this.details.UseVisualStyleBackColor = true;
            this.details.Click += new System.EventHandler(this.details_Click);
            // 
            // add_album
            // 
            this.add_album.Location = new System.Drawing.Point(217, 136);
            this.add_album.Name = "add_album";
            this.add_album.Size = new System.Drawing.Size(75, 23);
            this.add_album.TabIndex = 8;
            this.add_album.Text = "add album";
            this.add_album.UseVisualStyleBackColor = true;
            this.add_album.Click += new System.EventHandler(this.add_album_Click);
            // 
            // err
            // 
            this.err.AutoSize = true;
            this.err.ForeColor = System.Drawing.Color.Crimson;
            this.err.Location = new System.Drawing.Point(75, 193);
            this.err.Name = "err";
            this.err.Size = new System.Drawing.Size(26, 13);
            this.err.TabIndex = 9;
            this.err.Text = "Erro";
            this.err.Visible = false;
            // 
            // title_listBox
            // 
            this.title_listBox.FormattingEnabled = true;
            this.title_listBox.Location = new System.Drawing.Point(0, 258);
            this.title_listBox.Name = "title_listBox";
            this.title_listBox.Size = new System.Drawing.Size(292, 394);
            this.title_listBox.TabIndex = 10;
            this.title_listBox.Visible = false;
            this.title_listBox.SelectedIndexChanged += new System.EventHandler(this.title_listBox_SelectedIndexChanged);
            // 
            // btn_show
            // 
            this.btn_show.Location = new System.Drawing.Point(78, 229);
            this.btn_show.Name = "btn_show";
            this.btn_show.Size = new System.Drawing.Size(75, 23);
            this.btn_show.TabIndex = 11;
            this.btn_show.Text = "show all titles";
            this.btn_show.UseVisualStyleBackColor = true;
            this.btn_show.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(541, 493);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backup
            // 
            this.backup.Location = new System.Drawing.Point(388, 258);
            this.backup.Name = "backup";
            this.backup.Size = new System.Drawing.Size(97, 23);
            this.backup.TabIndex = 13;
            this.backup.Text = "Save Backup";
            this.backup.UseVisualStyleBackColor = true;
            this.backup.Click += new System.EventHandler(this.backup_Click);
            // 
            // open_new_albums
            // 
            this.open_new_albums.Location = new System.Drawing.Point(388, 288);
            this.open_new_albums.Name = "open_new_albums";
            this.open_new_albums.Size = new System.Drawing.Size(97, 23);
            this.open_new_albums.TabIndex = 14;
            this.open_new_albums.Text = "Open Collection";
            this.open_new_albums.UseVisualStyleBackColor = true;
            this.open_new_albums.Click += new System.EventHandler(this.open_new_albums_Click);
            // 
            // open_saved_albums
            // 
            this.open_saved_albums.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "label2";
            // 
            // new_coll
            // 
            this.new_coll.Location = new System.Drawing.Point(388, 317);
            this.new_coll.Name = "new_coll";
            this.new_coll.Size = new System.Drawing.Size(97, 23);
            this.new_coll.TabIndex = 16;
            this.new_coll.Text = "Start New";
            this.new_coll.UseVisualStyleBackColor = true;
            this.new_coll.Click += new System.EventHandler(this.new_coll_Click);
            // 
            // text_abumId
            // 
            this.text_abumId.Location = new System.Drawing.Point(245, 78);
            this.text_abumId.Name = "text_abumId";
            this.text_abumId.Size = new System.Drawing.Size(100, 20);
            this.text_abumId.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Album Id:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 651);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_abumId);
            this.Controls.Add(this.new_coll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.open_new_albums);
            this.Controls.Add(this.backup);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_show);
            this.Controls.Add(this.title_listBox);
            this.Controls.Add(this.err);
            this.Controls.Add(this.add_album);
            this.Controls.Add(this.details);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titles);
            this.Name = "Form1";
            this.Text = "Music Database (BackEnd)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox titles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button details;
        private System.Windows.Forms.Button add_album;
        private System.Windows.Forms.Label err;
        private System.Windows.Forms.ListBox title_listBox;
        private System.Windows.Forms.Button btn_show;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button backup;
        private System.Windows.Forms.Button open_new_albums;
        private System.Windows.Forms.SaveFileDialog save_backup;
        private System.Windows.Forms.OpenFileDialog open_saved_albums;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button new_coll;
        private System.Windows.Forms.TextBox text_abumId;
        private System.Windows.Forms.Label label3;
    }
}

