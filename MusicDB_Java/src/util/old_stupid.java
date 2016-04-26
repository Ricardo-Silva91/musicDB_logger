/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package util;

import entities.Album;
import entities.log_entry;
import entities.track;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
import static org.apache.commons.io.FilenameUtils.separatorsToSystem;
import org.json.simple.JSONObject;

/**
 *
 * @author rofler
 */
public class old_stupid {
    
    static String Album_path = separatorsToSystem("../MusicDB_json/album_list.json");
        static String Album_path_public = separatorsToSystem("../MusicDB_json/Public_album_list.json");

        public static String get_Album_path() {
            return Album_path;
        }

        public static void set_Album_path(String new_path) {
            Album_path = new_path;
        }

        static String titles_path = separatorsToSystem("../MusicDB_json/title_list2.json");
        static String titles_path_public = separatorsToSystem("../MusicDB_json/Public_title_list2.json");

        public static String get_titles_path() {
            return titles_path;
        }

        public static void set_titles_path(String new_path) {
            titles_path = new_path;
        }

        static String artists_path = separatorsToSystem("../MusicDB_json/artist_list2.json");
        static String artists_path_public = separatorsToSystem("../MusicDB_json/Public_artist_list2.json");

        public static String get_artists_path() {
            return artists_path;
        }

        public static void set_artists_path(String new_path) {
            artists_path = new_path;
        }

        static String log_path = separatorsToSystem("../MusicDB_json/log2.json");
        static String log_path_public = separatorsToSystem("../MusicDB_json/Public_log2.json");

        public static String get_log_path() {
            return log_path;
        }

        public static void set_log_path(String new_path) {
            log_path = new_path;
        }
    
    public static void refresh_artists(Album[] Albums) {
            String[] artist_list = new String[Albums.length];
            int count = 0;

            JSONObject jo = new JSONObject();

            for (int i = 0; i < Albums.length; i++) {
                if (!artistExists(artist_list, Albums[i].artist)) {
                    artist_list[count] = Albums[i].artist;
                    count++;
                }
            }

            while (count < Albums.length) {
                artist_list[count] = "";
                count++;
            }

//            File.WriteAllText(artists_path, JsonConvert.SerializeObject(artist_list));
//            File.WriteAllText(@"../../data/Public_artist_list.json", "artists = " + JsonConvert.SerializeObject(artist_list));
        }
    
    private static Boolean artistExists(String[] artists, String a) {
            for (int i = 0; i < artists.length; i++) {
                if (artists[i] == a) {
                    return true;
                }
            }

            return false;
        }
    
    public static void refresh_titles(Album[] Albums) {
            String[] title_list = new String[Albums.length];

            for (int i = 0; i < Albums.length; i++) {
                title_list[i] = Albums[i].title;
            }

//            Array.Sort(title_list);
//            File.WriteAllText(titles_path, JsonConvert.SerializeObject(title_list));
//            File.WriteAllText(@"../../data/Public_title_list.json", "titles = " + JsonConvert.SerializeObject(title_list));
        }
    
            public static void save_new(Album[] Albums) {
//            File.WriteAllText(Album_path, JsonConvert.SerializeObject(Albums));
//            File.WriteAllText(@"../../data/Public_json1.json", "Albums = " + JsonConvert.SerializeObject(Albums) + ";");
        }
            
                    public static void save_log(log_entry[] log) {
//            File.WriteAllText(log_path, JsonConvert.SerializeObject(log));
//            File.WriteAllText(@"../../data/Public_log.json", "log = " + JsonConvert.SerializeObject(log) + ";");
        }

            public static int find_alb(String title, Album[] Albums) {
            for (int i = 0; i < Albums.length; i++) {
                if (title.toLowerCase() == Albums[i].title.toLowerCase()) {
                    return i;
                }
            }
            return -1;
        }

        public static int alb_exists(String title, Album[] Albums, String artist) {
            int alb_id = find_alb(title, Albums);

            if (alb_id != -1) {
                if (Albums[alb_id].artist != artist) {
                    return -1;
                } else {
                    return 1;
                }
            }

            return -1;
        }

        public static track[] addTrack(track[] tracks, String title, int numb) {
            track[] new_tracks = new track[tracks.length + 1];
            for (int i = 0; i < tracks.length; i++) {

                new_tracks[i] = new track(tracks[i].number, tracks[i].title);

                /*new_tracks[i] = new track 
                 {
                 number = tracks[i].number
                 , title = tracks[i].title };*/
            }
            //new_tracks[alb.tracks.length] = alb.tracks[1];

            new_tracks[tracks.length] = new track(numb, title);
            /*
             new_tracks[tracks.length] = new track 
             {
             title = title , number = numb };
             */
            new_tracks = sortTracks(new_tracks);

            return new_tracks;
        }
        
        public static log_entry[] newLogEntry(log_entry[] log, String wh, int type, String title) {
            log_entry[] new_log = new log_entry[log.length + 1];
            for (int i = 0; i < log.length; i++) {

                new_log[i] = new log_entry(log[i].title, log[i].what_happened, log[i].when_ih, log[i].type);

                /*
                 new_log[i] = new log_entry 
                 {
                 title = log[i].title ,what_happened = log[i].what_happened
                 , when_ih = log[i].when_ih
                 , type = log[i].type };
                 */
            }
            //new_tracks[alb.tracks.length] = alb.tracks[1];

            DateFormat dateFormat = new SimpleDateFormat("MM/dd/yyyy HH:mm");
            new_log[log.length] = new log_entry(title, wh, dateFormat.format(new Date()), type);

            /*
             new_log[log.length] = new log_entry 
             {
             title = title
             , what_happened = wh
             , when_ih = DateTime.Now.ToString("MM/dd/yyyy HH:mm")
             , type = type };*/
            return new_log;
        }
        
        public static track[] deleteTrack(track[] tracks, int numb) {
            track[] new_tracks = new track[tracks.length - 1];
            Boolean pass = false;

            for (int i = 0; i < tracks.length; i++) {
                if (pass == false) {
                    if (tracks[i].number != numb) {
                        new_tracks[i] = new track(tracks[i].number, tracks[i].title);
                    } //new_tracks[i] = new track { number = tracks[i].number, title = tracks[i].title };
                    else {
                        pass = true;
                    }
                } else {
                    new_tracks[i - 1] = new track(tracks[i].number, tracks[i].title);
                    //new_tracks[i-1] = new track { number = tracks[i].number, title = tracks[i].title };
                }
            }

            return new_tracks;

        }

        public static track[] sortTracks(track[] tracks) {
            track temp_track;
            Boolean quit = true;

            do {
                quit = true;
                for (int i = 0; i < tracks.length - 1; i++) {
                    if (tracks[i].number > tracks[i + 1].number) {
                        quit = false;
                        temp_track = tracks[i];
                        tracks[i] = tracks[i + 1];
                        tracks[i + 1] = temp_track;
                    }

                }
            } while (quit == false);

            return tracks;
        }
        
         public static Album[] addAlbum(Album[] Albums, String title, String artist) {
            Album[] new_Albums = new Album[Albums.length + 1];
            for (int i = 0; i < Albums.length; i++) {
                new_Albums[i] = Albums[i];
            }
            DateFormat dateFormat = new SimpleDateFormat("MM/dd/yyyy HH:mm");
            new_Albums[Albums.length] = new Album(title, artist, new track[0], Boolean.FALSE, "", "404.jpg", dateFormat.format(new Date()), "", Albums.length);

            /*
             new_Albums[Albums.length] = new Album 
             {
             id = Albums.length
             , title = title
             , artist = artist
             , tracks = new track[0]
             , date_included = DateTime.Now.ToString("M/d/yyyy") };
             */
            return new_Albums;
        }
         
         
        public static Boolean trackExists(track[] tracks, String title, int num) {
            for (int i = 0; i < tracks.length; i++) {
                if (tracks[i].number == num || tracks[i].title == title) {
                    return true;
                }
            }
            return false;
        }
        
}
