namespace musicDB
{
    partial class Details
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
            this.l_title = new System.Windows.Forms.Label();
            this.l_artist = new System.Windows.Forms.Label();
            this.l_tracks = new System.Windows.Forms.Label();
            this.text_title = new System.Windows.Forms.TextBox();
            this.text_artist = new System.Windows.Forms.TextBox();
            this.tracks_grid = new System.Windows.Forms.DataGridView();
            this.btn_change = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.l_genre = new System.Windows.Forms.Label();
            this.text_genre = new System.Windows.Forms.TextBox();
            this.l_approved = new System.Windows.Forms.Label();
            this.check_approved = new System.Windows.Forms.CheckBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_upload = new System.Windows.Forms.Button();
            this.browse_pic_dialog = new System.Windows.Forms.FolderBrowserDialog();
            this.browse_pi = new System.Windows.Forms.OpenFileDialog();
            this.pic_box = new System.Windows.Forms.PictureBox();
            this.btn_del_track = new System.Windows.Forms.Button();
            this.l_comment = new System.Windows.Forms.Label();
            this.text_comment = new System.Windows.Forms.TextBox();
            this.l_id = new System.Windows.Forms.Label();
            this.text_id = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tracks_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_box)).BeginInit();
            this.SuspendLayout();
            // 
            // l_title
            // 
            this.l_title.AutoSize = true;
            this.l_title.Location = new System.Drawing.Point(12, 9);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(26, 13);
            this.l_title.TabIndex = 0;
            this.l_title.Text = "title:";
            // 
            // l_artist
            // 
            this.l_artist.AutoSize = true;
            this.l_artist.Location = new System.Drawing.Point(12, 49);
            this.l_artist.Name = "l_artist";
            this.l_artist.Size = new System.Drawing.Size(29, 13);
            this.l_artist.TabIndex = 1;
            this.l_artist.Text = "artist";
            // 
            // l_tracks
            // 
            this.l_tracks.AutoSize = true;
            this.l_tracks.Location = new System.Drawing.Point(12, 246);
            this.l_tracks.Name = "l_tracks";
            this.l_tracks.Size = new System.Drawing.Size(39, 13);
            this.l_tracks.TabIndex = 2;
            this.l_tracks.Text = "tracks:";
            this.l_tracks.Click += new System.EventHandler(this.l_tracks_Click);
            // 
            // text_title
            // 
            this.text_title.Enabled = false;
            this.text_title.Location = new System.Drawing.Point(15, 26);
            this.text_title.Name = "text_title";
            this.text_title.Size = new System.Drawing.Size(276, 20);
            this.text_title.TabIndex = 3;
            // 
            // text_artist
            // 
            this.text_artist.Enabled = false;
            this.text_artist.Location = new System.Drawing.Point(15, 66);
            this.text_artist.Name = "text_artist";
            this.text_artist.Size = new System.Drawing.Size(276, 20);
            this.text_artist.TabIndex = 4;
            // 
            // tracks_grid
            // 
            this.tracks_grid.AllowUserToAddRows = false;
            this.tracks_grid.AllowUserToDeleteRows = false;
            this.tracks_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tracks_grid.Location = new System.Drawing.Point(15, 267);
            this.tracks_grid.Name = "tracks_grid";
            this.tracks_grid.ReadOnly = true;
            this.tracks_grid.Size = new System.Drawing.Size(530, 213);
            this.tracks_grid.TabIndex = 5;
            this.tracks_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tracks_grid_CellContentClick);
            // 
            // btn_change
            // 
            this.btn_change.Location = new System.Drawing.Point(15, 510);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(75, 23);
            this.btn_change.TabIndex = 6;
            this.btn_change.Text = "Change";
            this.btn_change.UseVisualStyleBackColor = true;
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(120, 510);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 7;
            this.btn_add.Text = "Add Track";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Visible = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(470, 604);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(75, 23);
            this.btn_back.TabIndex = 8;
            this.btn_back.Text = "back";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // l_genre
            // 
            this.l_genre.AutoSize = true;
            this.l_genre.Location = new System.Drawing.Point(12, 89);
            this.l_genre.Name = "l_genre";
            this.l_genre.Size = new System.Drawing.Size(37, 13);
            this.l_genre.TabIndex = 9;
            this.l_genre.Text = "genre:";
            // 
            // text_genre
            // 
            this.text_genre.Enabled = false;
            this.text_genre.Location = new System.Drawing.Point(15, 106);
            this.text_genre.Name = "text_genre";
            this.text_genre.Size = new System.Drawing.Size(276, 20);
            this.text_genre.TabIndex = 10;
            // 
            // l_approved
            // 
            this.l_approved.AutoSize = true;
            this.l_approved.Location = new System.Drawing.Point(15, 552);
            this.l_approved.Name = "l_approved";
            this.l_approved.Size = new System.Drawing.Size(56, 13);
            this.l_approved.TabIndex = 11;
            this.l_approved.Text = "Approved:";
            this.l_approved.Click += new System.EventHandler(this.l_approved_Click);
            // 
            // check_approved
            // 
            this.check_approved.AutoSize = true;
            this.check_approved.Enabled = false;
            this.check_approved.Location = new System.Drawing.Point(34, 568);
            this.check_approved.Name = "check_approved";
            this.check_approved.Size = new System.Drawing.Size(15, 14);
            this.check_approved.TabIndex = 12;
            this.check_approved.UseVisualStyleBackColor = true;
            this.check_approved.CheckedChanged += new System.EventHandler(this.check_approved_CheckedChanged);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(227, 510);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 13;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Visible = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_upload
            // 
            this.btn_upload.Location = new System.Drawing.Point(470, 510);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(75, 23);
            this.btn_upload.TabIndex = 14;
            this.btn_upload.Text = "Upload Pic";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Visible = false;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // browse_pi
            // 
            this.browse_pi.FileName = "browse_pic";
            // 
            // pic_box
            // 
            this.pic_box.Location = new System.Drawing.Point(398, 9);
            this.pic_box.Name = "pic_box";
            this.pic_box.Size = new System.Drawing.Size(147, 145);
            this.pic_box.TabIndex = 15;
            this.pic_box.TabStop = false;
            // 
            // btn_del_track
            // 
            this.btn_del_track.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_del_track.Location = new System.Drawing.Point(120, 540);
            this.btn_del_track.Name = "btn_del_track";
            this.btn_del_track.Size = new System.Drawing.Size(75, 23);
            this.btn_del_track.TabIndex = 16;
            this.btn_del_track.Text = "Delete Track";
            this.btn_del_track.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_del_track.UseVisualStyleBackColor = true;
            this.btn_del_track.Visible = false;
            this.btn_del_track.Click += new System.EventHandler(this.button1_Click);
            // 
            // l_comment
            // 
            this.l_comment.AutoSize = true;
            this.l_comment.Location = new System.Drawing.Point(12, 132);
            this.l_comment.Name = "l_comment";
            this.l_comment.Size = new System.Drawing.Size(54, 13);
            this.l_comment.TabIndex = 17;
            this.l_comment.Text = "Comment:";
            // 
            // text_comment
            // 
            this.text_comment.Enabled = false;
            this.text_comment.Location = new System.Drawing.Point(15, 148);
            this.text_comment.Multiline = true;
            this.text_comment.Name = "text_comment";
            this.text_comment.Size = new System.Drawing.Size(359, 84);
            this.text_comment.TabIndex = 18;
            // 
            // l_id
            // 
            this.l_id.AutoSize = true;
            this.l_id.Location = new System.Drawing.Point(395, 166);
            this.l_id.Name = "l_id";
            this.l_id.Size = new System.Drawing.Size(21, 13);
            this.l_id.TabIndex = 19;
            this.l_id.Text = "id: ";
            // 
            // text_id
            // 
            this.text_id.Enabled = false;
            this.text_id.Location = new System.Drawing.Point(398, 183);
            this.text_id.Name = "text_id";
            this.text_id.Size = new System.Drawing.Size(100, 20);
            this.text_id.TabIndex = 20;
            // 
            // Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 635);
            this.Controls.Add(this.text_id);
            this.Controls.Add(this.l_id);
            this.Controls.Add(this.text_comment);
            this.Controls.Add(this.l_comment);
            this.Controls.Add(this.btn_del_track);
            this.Controls.Add(this.pic_box);
            this.Controls.Add(this.btn_upload);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.check_approved);
            this.Controls.Add(this.l_approved);
            this.Controls.Add(this.text_genre);
            this.Controls.Add(this.l_genre);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_change);
            this.Controls.Add(this.tracks_grid);
            this.Controls.Add(this.text_artist);
            this.Controls.Add(this.text_title);
            this.Controls.Add(this.l_tracks);
            this.Controls.Add(this.l_artist);
            this.Controls.Add(this.l_title);
            this.Name = "Details";
            this.Text = "Details";
            this.Load += new System.EventHandler(this.Details_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tracks_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_title;
        private System.Windows.Forms.Label l_artist;
        private System.Windows.Forms.Label l_tracks;
        private System.Windows.Forms.TextBox text_title;
        private System.Windows.Forms.TextBox text_artist;
        private System.Windows.Forms.DataGridView tracks_grid;
        private System.Windows.Forms.Button btn_change;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label l_genre;
        private System.Windows.Forms.TextBox text_genre;
        private System.Windows.Forms.Label l_approved;
        private System.Windows.Forms.CheckBox check_approved;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.FolderBrowserDialog browse_pic_dialog;
        private System.Windows.Forms.OpenFileDialog browse_pi;
        private System.Windows.Forms.PictureBox pic_box;
        private System.Windows.Forms.Button btn_del_track;
        private System.Windows.Forms.Label l_comment;
        private System.Windows.Forms.TextBox text_comment;
        private System.Windows.Forms.Label l_id;
        private System.Windows.Forms.TextBox text_id;
    }
}