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
    public partial class Form1 : Form
    {

        public static album[] albums;
        public log_entry[] log;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            albums = JsonConvert.DeserializeObject<album[]>(File.ReadAllText(stupid.get_album_path()));
            log = JsonConvert.DeserializeObject<log_entry[]>(File.ReadAllText(stupid.get_log_path()));


            stupid.refresh_titles(albums);
            stupid.refresh_artists(albums);
            String[] title_list = JsonConvert.DeserializeObject<String[]>(File.ReadAllText(stupid.get_titles_path()));


            var source = new AutoCompleteStringCollection();
            source.AddRange(title_list);


            titles.AutoCompleteCustomSource = source;
            titles.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            titles.AutoCompleteSource = AutoCompleteSource.CustomSource;

            title_listBox.DataSource = title_list;
            
        }

        private void details_Click(object sender, EventArgs e)
        {
            if(titles.Text!="")
            {
                if (stupid.find_alb(titles.Text, albums) == -1)
                {
                    err.Text = "Error: album not in DB.";
                    err.Visible = true;
                    return;
                }

                Details ev = new Details(titles.Text);
                this.Hide();
                ev.ShowDialog();
                this.Close();
            }
            else
            {
                Details ev = new Details(int.Parse(text_abumId.Text));
                this.Hide();
                ev.ShowDialog();
                this.Close();

            }
        }


        private void title_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            titles.Text = title_listBox.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            title_listBox.Visible = true;
            btn_show.Visible = false;
        }

  

        private void titles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int ind = stupid.find_alb(titles.Text, albums);

                if (ind == -1)
                {
                    err.Text = "Error: album not in DB.";
                    err.Visible = true;
                    return;
                }

                Details ev = new Details(albums[ind].title);
                this.Hide();
                ev.ShowDialog();
                this.Close();
            }
        }

        private void add_album_Click(object sender, EventArgs e)
        {
            AddAlbum ev = new AddAlbum();
            this.Hide();
            ev.ShowDialog();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            for(int i=0; i<albums.Length;i++)
            {
                albums[i].id = i;
                //albums[i].tracks = stupid.sortTracks(albums[i].tracks);
                //albums[i].approved = true;
                //albums[i].date_included = DateTime.Now.ToString("M/d/yyyy");
                //albums[i].comment = "";
                //albums[i].id = i;

            }

            stupid.save_new(albums);
            stupid.refresh_artists(albums);
            stupid.refresh_titles(albums);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backup_Click(object sender, EventArgs e)
        {

            save_backup.Filter = "Json files (*.json) | *.json";

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                label2.Text = folderBrowserDialog1.SelectedPath;
                File.WriteAllText(folderBrowserDialog1.SelectedPath + "/albums.json", JsonConvert.SerializeObject(albums));
                File.WriteAllText(folderBrowserDialog1.SelectedPath +  "/log.json", JsonConvert.SerializeObject(log));

            }
        }

        private void open_new_albums_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() ==DialogResult.OK)
            {
                try
                {
                    if (File.Exists(folderBrowserDialog1.SelectedPath + "/albums.json") && File.Exists(folderBrowserDialog1.SelectedPath + "/log.json"))
                    {

                        stupid.set_album_path(folderBrowserDialog1.SelectedPath + "/albums.json");
                        stupid.set_log_path(folderBrowserDialog1.SelectedPath + "/log.json");
                        stupid.set_titles_path(folderBrowserDialog1.SelectedPath + "/titles.json");
                        stupid.set_artists_path(folderBrowserDialog1.SelectedPath + "/artists.json");

                        File.WriteAllText(folderBrowserDialog1.SelectedPath + "/titles.json", "");
                        File.WriteAllText(folderBrowserDialog1.SelectedPath + "/artists.json", "");




                        //loadOut
                        albums = JsonConvert.DeserializeObject<album[]>(File.ReadAllText(stupid.get_album_path()));
                        log = JsonConvert.DeserializeObject<log_entry[]>(File.ReadAllText(stupid.get_log_path()));


                        stupid.refresh_titles(albums);
                        stupid.refresh_artists(albums);
                        String[] title_list = JsonConvert.DeserializeObject<String[]>(File.ReadAllText(stupid.get_titles_path()));


                        var source = new AutoCompleteStringCollection();
                        source.AddRange(title_list);


                        titles.AutoCompleteCustomSource = source;
                        titles.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        titles.AutoCompleteSource = AutoCompleteSource.CustomSource;

                        title_listBox.DataSource = title_list;


                    }
                    else
                    {
                        MessageBox.Show("Error folder specified does not contain apropriate albums.json and log.json files.");
                    }

                }
                catch(Exception err)
                {
                    MessageBox.Show("Error: " + err.ToString());
                }
            }
        }

        private void new_coll_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                label2.Text = folderBrowserDialog1.SelectedPath;
                File.WriteAllText(folderBrowserDialog1.SelectedPath + "/albums.json", JsonConvert.SerializeObject(new album[0]));
                File.WriteAllText(folderBrowserDialog1.SelectedPath + "/log.json", JsonConvert.SerializeObject(new log_entry[0]));

            }
        }

    }


    /*
     * 
      string json = @"{
         'Name': 'Bad Boys',
         'ReleaseDate': '1995-4-7T00:00:00',
         'Genres': [
             'Action',
             'Comedy'
         ]
      }";

Movie m = JsonConvert.DeserializeObject<Movie>(json);

string name = m.Name;
// Bad Boys
     * 
     * 
     */

    /*
    Product product = new Product();
product.Name = "Apple";
product.Expiry = new DateTime(2008, 12, 28);
product.Sizes = new string[] { "Small" };

string json = JsonConvert.SerializeObject(product);
// {
//   "Name": "Apple",
//   "Expiry": "2008-12-28T00:00:00",
//   "Sizes": [
//     "Small"
//   ]
// }*/



    
    
    
}
