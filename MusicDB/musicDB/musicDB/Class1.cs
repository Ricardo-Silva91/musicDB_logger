using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace musicDB
{
        public class album
        {
            public String title;
            public String artist;
            public track[] tracks;
            public Boolean approved;
            public String genre;
            public String pic_name;
            public String date_included;
            public String comment;
            public int id;
        }

        public class track
        {
            public int number;
            public String title;
        }

        public class log_entry
        {
            public String title; 
            public String what_happened;
            public String when_ih;
            public int type;        //1-new album;  2-album edited; 3-track added; 4-cancelled

        }

    public static class stupid
    {

        static String album_path = "../../data/json1.json";

        public static String get_album_path()
        {
            return album_path;
        }

        public static void set_album_path(String new_path)
        {
            album_path = new_path;
        }

        static String titles_path = "../../data/title_list.json";

        public static String get_titles_path()
        {
            return titles_path;
        }

        public static void set_titles_path(String new_path)
        {
            titles_path = new_path;
        }

        static String artists_path = "../../data/artist_list.json";

        public static String get_artists_path()
        {
            return artists_path;
        }

        public static void set_artists_path(String new_path)
        {
            artists_path = new_path;
        }

        static String log_path = "../../data/log.json";

        public static String get_log_path()
        {
            return log_path;
        }

        public static void set_log_path(String new_path)
        {
            log_path = new_path;
        }




        public static void refresh_artists(album[] albums)
        {
            String[] artist_list = new String[albums.Length];
            int count = 0;
            for (int i = 0; i < albums.Length; i++)
            {
                if (!artistExists(artist_list, albums[i].artist))
                {
                    artist_list[count] = albums[i].artist;
                    count++;
                }
            }

            while(count <albums.Length )
            {
                artist_list[count] = "";
                count++;
            }

            File.WriteAllText(artists_path, JsonConvert.SerializeObject(artist_list));
            File.WriteAllText(@"../../data/Public_artist_list.json", "artists = " + JsonConvert.SerializeObject(artist_list));

        }

        private static Boolean artistExists(String[] artists, String a )
        {
            for(int i=0; i<artists.Length; i++)
            {
                if (artists[i] == a)
                    return true;
            }

            return false;
        }

        public static void refresh_titles(album[] albums)
        {
            String[] title_list = new String[albums.Length];

            for (int i = 0; i < albums.Length; i++)
            {
                title_list[i] = albums[i].title;
            }

            Array.Sort(title_list);
            File.WriteAllText(titles_path, JsonConvert.SerializeObject(title_list));

            File.WriteAllText(@"../../data/Public_title_list.json", "titles = " + JsonConvert.SerializeObject(title_list));

        }
        public static void save_new(album[] albums)
        {
            File.WriteAllText(album_path, JsonConvert.SerializeObject(albums));
            File.WriteAllText(@"../../data/Public_json1.json", "albums = " + JsonConvert.SerializeObject(albums) + ";");
        }

        public static void save_log(log_entry[] log)
        {
            File.WriteAllText(log_path, JsonConvert.SerializeObject(log));
            File.WriteAllText(@"../../data/Public_log.json", "log = " + JsonConvert.SerializeObject(log) + ";");
        }

        public static int find_alb(String title, album[] albums)
        {
            for (int i=0; i<albums.Length; i++)
            {
                if(title.ToLower() == albums[i].title.ToLower())
                {
                    return i;
                }
            }
            return -1;
        }

        public static int alb_exists(String title, album[] albums, String artist)
        {
            int alb_id = find_alb(title, albums);

            if(alb_id != -1)
            {
                if (albums[alb_id].artist != artist)
                    return -1;
                else
                    return 1;
            }

            return -1;
        }


        public static track[] addTrack(track[] tracks, String title, int numb)
        {
            track[] new_tracks = new track[tracks.Length + 1];
            for (int i = 0; i < tracks.Length; i++)
            {
                new_tracks[i] = new track { number = tracks[i].number, title = tracks[i].title };
            }
            //new_tracks[alb.tracks.Length] = alb.tracks[1];
            new_tracks[tracks.Length] = new track { title = title , number = numb };

            new_tracks = sortTracks(new_tracks);

            return new_tracks;
        }

        public static log_entry[] newLogEntry(log_entry[] log, String wh, int type, String title)
        {
            log_entry[] new_log = new log_entry[log.Length + 1];
            for (int i = 0; i < log.Length; i++)
            {
                new_log[i] = new log_entry {  title=log[i].title ,what_happened = log[i].what_happened, when_ih = log[i].when_ih, type=log[i].type };
            }
            //new_tracks[alb.tracks.Length] = alb.tracks[1];
            new_log[log.Length] = new log_entry { title = title, what_happened = wh, when_ih = DateTime.Now.ToString("MM/dd/yyyy HH:mm"), type = type };


            return new_log;
        }

        public static track[] deleteTrack(track[] tracks, int numb)
        {
            track[] new_tracks = new track[tracks.Length - 1];
            Boolean pass= false;


            for (int i = 0; i < tracks.Length; i++)
            {
                if (pass == false)
                {
                    if (tracks[i].number != numb)
                        new_tracks[i] = new track { number = tracks[i].number, title = tracks[i].title };
                    else
                        pass = true;
                }
                else
                {
                    new_tracks[i-1] = new track { number = tracks[i].number, title = tracks[i].title };
                }
            }

            return new_tracks;

        }


        public static track[] sortTracks(track[] tracks)
        {
            track temp_track;
            Boolean quit = true;

            do
            {
                quit = true;
                for (int i = 0; i < tracks.Length - 1; i++)
                {
                    if (tracks[i].number > tracks[i + 1].number)
                    {
                        quit = false;
                        temp_track = tracks[i];
                        tracks[i] = tracks[i + 1];
                        tracks[i + 1] = temp_track;
                    }

                }
            } while (quit == false);

            return tracks;
        }


        public static album[] addAlbum(album[] albums, String title, String artist)
        {
            album[] new_albums = new album[albums.Length + 1];
            for (int i = 0; i < albums.Length; i++)
                new_albums[i] = albums[i];
            new_albums[albums.Length] = new album {id=albums.Length, title = title, artist = artist, tracks = new track[0], date_included = DateTime.Now.ToString("M/d/yyyy") };
            return new_albums;
        }
             
        public static Boolean trackExists(track[] tracks, String title, int num)
        {
            for( int i=0; i<tracks.Length; i++)
            {
                if (tracks[i].number == num || tracks[i].title == title)
                    return true;
            }
            return false;
        }


    }



    
    
}
