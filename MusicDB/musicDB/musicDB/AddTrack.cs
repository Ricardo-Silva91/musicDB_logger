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
    public partial class AddTrack : Form
    {

        String title;
        album[] albums;
        int index;
        album alb;
        log_entry[] log;

        public AddTrack(String t)
        {
            InitializeComponent();
            title = t;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (text_number.Text != "" && text_title.Text != "")
            {
                try
                {

                    if (!stupid.trackExists(alb.tracks, text_title.Text, Int16.Parse(text_number.Text)))
                    {
                        label_error.Visible = false;
                        alb.tracks = stupid.addTrack(alb.tracks, text_title.Text, Int16.Parse(text_number.Text));
                        albums[index] = alb;
                        stupid.save_new(albums);

                        log = stupid.newLogEntry(log, "Track " + text_title.Text + " (" + text_number.Text + ") added to " + alb.title, 3, alb.title);
                        stupid.save_log(log);

                        //Details ev = new Details(title);
                        this.Hide();
                        //ev.ShowDialog();
                        this.Close();

                    }
                    else
                    {
                        label_error.Text = "Track with same number or title already exists!";
                        label_error.Visible = true;
                    }


                }catch(Exception epk)
                {
                    label_error.Text = "Exception: please verify the introduced values.\n" + epk;
                }

            }
            else
            {

            }

        }

        private void AddTrack_Load(object sender, EventArgs e)
        {

            albums = JsonConvert.DeserializeObject<album[]>(File.ReadAllText(stupid.get_album_path()));
            log = JsonConvert.DeserializeObject<log_entry[]>(File.ReadAllText(stupid.get_log_path()));

            index = stupid.find_alb(title, albums);

            alb = albums[index];




        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            //Details ev = new Details(title);
            this.Hide();
            //ev.ShowDialog();
            this.Close();
        }
    }
}
