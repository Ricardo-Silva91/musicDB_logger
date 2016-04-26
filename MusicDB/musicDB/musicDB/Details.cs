using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace musicDB
{
    public partial class Details : Form
    {
        String title="";
        album[] albums;
        int index;
        album alb;
        jogos[] j;
        String pic_path;
        log_entry[] log;

        public Details( String t)
        {
            InitializeComponent();
            title = t;
        }

        public Details(int ind)
        {
            InitializeComponent();
            index = ind;
        }

        private void Details_Load(object sender, EventArgs e)
        {
            albums = JsonConvert.DeserializeObject<album[]>(File.ReadAllText(stupid.get_album_path()));
            log = JsonConvert.DeserializeObject<log_entry[]>(File.ReadAllText(stupid.get_log_path()));

            if(title!="")
            {
                index = stupid.find_alb(title, albums);
            }

            alb = albums[index];

            text_title.Text = alb.title;
            text_artist.Text = alb.artist;
            text_genre.Text = alb.genre;
            text_comment.Text = alb.comment;
            text_id.Text = alb.id.ToString();

            check_approved.Checked = alb.approved;


            j = get_tracks(alb.tracks);
            tracks_grid.DataSource = j;

            try
            {

                if (alb.pic_name != null)
                {

                    FileStream fileStream = new FileStream(@"../../data/pics/" + alb.pic_name, FileMode.Open, FileAccess.Read);
                    pic_box.Image = resizeImage(Image.FromStream(fileStream), new Size(pic_box.Width, pic_box.Height));
                    fileStream.Close();

                    //pic_box.Image = resizeImage(Image.FromFile(@"../../data/pics/" + alb.pic_name), new Size(pic_box.Width, pic_box.Height));
                    pic_path = alb.pic_name;
                }
                else
                {
                    pic_box.Image = resizeImage(Image.FromFile(@"../../data/pics/404.jpg"), new Size(pic_box.Width, pic_box.Height));
                }
            }
            catch(Exception errr)
            {
                pic_box.Image = null;
            }
            //tracks_grid.Sort(tracks_grid.Columns[1], ListSortDirection.Descending);

           // tracks_grid.DataSource = (from arr in alb.tracks select new { track_title = "jogos", number = "jogos" });
        }


        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }


        


        private jogos[] get_tracks(track[] t)
        {
            jogos[] j= new jogos[t.Length];

            for(int i=0; i<t.Length; i++)
            {
                j[i] = new jogos { number = t[i].number, title = t[i].title };
            }
            return j;
        }

        private track[] get_jogos(jogos[] t)
        {
            track[] j = new track[t.Length];

            for (int i = 0; i < t.Length; i++)
            {
                j[i] = new track { number = t[i].number, title = t[i].title };
            }
            return j;
        }

        public class jogos
        {
            public int number { get; set; }
            public String title { get; set; }
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            if (btn_change.Text == "Change")
            {
                text_artist.Enabled = true;
                text_title.Enabled = true;
                text_genre.Enabled = true;
                text_comment.Enabled = true;
                check_approved.Enabled = true;
                btn_change.Text = "Save";
                btn_add.Visible = true;
                btn_cancel.Visible = true;
                btn_upload.Visible = true;
                tracks_grid.ReadOnly = false;
                btn_del_track.Visible = true;
            }
            else
            {
                if (stupid.find_alb(title, albums) == -1 || stupid.find_alb(title, albums) == index)
                {

                    text_artist.Enabled = false;
                    text_title.Enabled = false;
                    text_genre.Enabled = false;
                    text_comment.Enabled = false;
                    check_approved.Enabled = false;

                    alb.artist = text_artist.Text;
                    alb.title = text_title.Text;
                    alb.genre = text_genre.Text;
                    alb.comment = text_comment.Text;
                    alb.approved = check_approved.Checked;
                    alb.tracks = get_jogos(j);
                    alb.pic_name = pic_path;

                    btn_add.Visible = false;
                    btn_cancel.Visible = false;
                    btn_upload.Visible = false;
                    btn_change.Text = "Change";
                    tracks_grid.ReadOnly = true;
                    btn_del_track.Visible = false;

                    albums[index] = alb;

                    try
                    {

                        if (alb.pic_name != null)
                        {
                            FileStream fileStream = new FileStream(@"../../data/pics/" + alb.pic_name, FileMode.Open, FileAccess.Read);
                            pic_box.Image = resizeImage(Image.FromStream(fileStream), new Size(pic_box.Width, pic_box.Height));
                            fileStream.Close();

                            //pic_box.Image = resizeImage(Image.FromFile(@"../../data/pics/" + alb.pic_name), new Size(pic_box.Width, pic_box.Height));
                            pic_path = alb.pic_name;
                        }
                        else
                        {
                            pic_box.Image = resizeImage(Image.FromFile(@"../../data/pics/404.jpg"), new Size(pic_box.Width, pic_box.Height));
                        }
                    }
                    catch(Exception errr)
                    {
                        pic_box.Image = null;
                    }

                    stupid.save_new(albums);
                    log = stupid.newLogEntry(log, "Album " + alb.title + " edited.", 2, alb.title);
                    stupid.save_log(log);
                }
                else { }

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //Details ev = new Details(titles.Text);
            AddTrack ev = new AddTrack(title);
            //this.Hide();
            ev.ShowDialog();
            //this.Close();


            albums = JsonConvert.DeserializeObject<album[]>(File.ReadAllText(stupid.get_album_path()));
            log = JsonConvert.DeserializeObject<log_entry[]>(File.ReadAllText(stupid.get_log_path()));

            index = stupid.find_alb(title, albums);

            alb = albums[index];
            j = get_tracks(alb.tracks);
            tracks_grid.DataSource = j;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Form1 ev = new Form1();
            this.Hide();
            ev.ShowDialog();
            this.Close();

        }

        private void tracks_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(btn_change.Text == "Save")
            {
                tracks_grid.BeginEdit(true);
            }
            else
            {
                tracks_grid.BeginEdit(false);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {

            albums = JsonConvert.DeserializeObject<album[]>(File.ReadAllText(stupid.get_album_path()));
            alb = albums[index];

            text_title.Text = alb.title;
            text_artist.Text = alb.artist;
            text_genre.Text = alb.genre;
            text_comment.Text = alb.comment;

            check_approved.Checked = alb.approved;

            alb.tracks = albums[index].tracks;

            j = get_tracks(alb.tracks);
            tracks_grid.DataSource = j;


            text_artist.Enabled = false;
            text_title.Enabled = false;
            text_genre.Enabled = false;
            text_comment.Enabled = false;
            check_approved.Enabled = false;
            //pic_path = null;

            btn_add.Visible = false;
            btn_cancel.Visible = false;
            btn_upload.Visible = false;
            btn_change.Text = "Change";
            tracks_grid.ReadOnly = true;
            btn_del_track.Visible = false;

            log = stupid.newLogEntry(log, "Editing of album " + alb.title + " cancelled.", 4, alb.title);
            stupid.save_log(log);

        }

        private void btn_upload_Click(object sender, EventArgs e)
        {

            //pic_box.Image = null;

            browse_pi.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (browse_pi.ShowDialog() == DialogResult.OK)
            {
               // label1.Text = browse_pi.FileName;
                //pic_box.Image = null;
                if (File.Exists(@"../../data/pics/" + alb.title + ".jpg"))
                    File.Delete(@"../../data/pics/" + alb.title + ".jpg");
                   
                File.Copy(browse_pi.FileName, @"../../data/pics/"+alb.title+".jpg", true);

                try
                {

                    FileStream fileStream = new FileStream(@"../../data/pics/" + alb.pic_name, FileMode.Open, FileAccess.Read);
                    pic_box.Image = resizeImage(Image.FromStream(fileStream), new Size(pic_box.Width, pic_box.Height));
                    fileStream.Close();
                }
                catch (Exception errr)
                {
                    pic_box.Image = null;
                }


                pic_path = alb.title + ".jpg";
            }
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //btn_del_track.Text = tracks_grid.SelectedRows[0].Cells[0].Value.ToString();

            //btn_del_track.Text = tracks_grid.Rows[tracks_grid.SelectedCells[0].RowIndex].Cells[0].Value.ToString();

            alb.tracks = stupid.deleteTrack(alb.tracks, Int16.Parse(tracks_grid.Rows[tracks_grid.SelectedCells[0].RowIndex].Cells[0].Value.ToString()));
            j = get_tracks(alb.tracks);
            tracks_grid.DataSource = j;


        }

        private void l_tracks_Click(object sender, EventArgs e)
        {

        }

        private void l_approved_Click(object sender, EventArgs e)
        {

        }

        private void check_approved_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
