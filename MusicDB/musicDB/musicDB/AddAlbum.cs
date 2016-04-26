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
    public partial class AddAlbum : Form
    {

        public static album[] albums;
        log_entry[] log;

        public AddAlbum()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Form1 ev = new Form1();
            this.Hide();
            ev.ShowDialog();
            this.Close();
        }

        private void AddAlbum_Load(object sender, EventArgs e)
        {
            albums = JsonConvert.DeserializeObject<album[]>(File.ReadAllText(stupid.get_album_path()));
            log = JsonConvert.DeserializeObject<log_entry[]>(File.ReadAllText(stupid.get_log_path()));


            stupid.refresh_artists(albums);
            String[] artist_list = JsonConvert.DeserializeObject<String[]>(File.ReadAllText(stupid.get_artists_path()));


            var source = new AutoCompleteStringCollection();
            source.AddRange(artist_list);


            text_artist.AutoCompleteCustomSource = source;
            text_artist.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            text_artist.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (text_artist.Text != "" && text_title.Text != "")
            {
                if (stupid.alb_exists(text_title.Text, albums, text_artist.Text) != -1)
                {
                    label_err.Text = "Error: album already in DB.";
                    label_err.Visible = true;
                    return;
                }
                else
                {
                    albums = stupid.addAlbum(albums, text_title.Text, text_artist.Text);
                    stupid.save_new(albums);

                    log = stupid.newLogEntry(log, "Album " + text_title.Text + " added.", 1, text_title.Text);
                    stupid.save_log(log);

                    Form1 ev = new Form1();
                    this.Hide();
                    ev.ShowDialog();
                    this.Close();
                }
            }
        }

       
    }
}
