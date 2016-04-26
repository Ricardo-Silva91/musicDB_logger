/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package util;

import entities.Album;
import entities.log_entry;
import entities.track;
import frames.Index;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;
import static org.apache.commons.io.FilenameUtils.separatorsToSystem;
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

/**
 *
 * @author rofler
 */
public class Stupid {

    public static class stupid {

        static String path_to_pics = separatorsToSystem("../MusicDB_json/pics/");

        public static String getPath_to_pics() {
            return path_to_pics;
        }

        
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

        public static void refresh_artists_json(JSONArray albums) {

            JSONArray artist_list = new JSONArray();
            int count = 0;

            for (int i = 0; i < albums.size(); i++) {
                JSONObject jo = (JSONObject) albums.get(i);
                if (!artist_list.contains(jo.get("artist"))) {
                    artist_list.add(jo.get("artist"));
                }
            }

            try {
                FileOutputStream fo = new FileOutputStream(new File(artists_path));
                fo.write(artist_list.toString().getBytes());

                fo = new FileOutputStream(new File(artists_path_public));
                fo.write(artist_list.toString().getBytes());

            } catch (FileNotFoundException ex) {
                Logger.getLogger(Stupid.class.getName()).log(Level.SEVERE, null, ex);
            } catch (IOException ex) {
                Logger.getLogger(Stupid.class.getName()).log(Level.SEVERE, null, ex);
            }
        }

        

        private static JSONArray artist_list;

        public static Boolean artistExists_json(String name) {

            boolean res = false;

            try {
                JSONParser parser = new JSONParser();
                File f = new File(stupid.get_Album_path());

                artist_list = new JSONArray();
                artist_list = (JSONArray) parser.parse(new FileReader(artists_path));
                //JSONObject album = (JSONObject) albums_json.get(0);

            } catch (IOException ex) {
                Logger.getLogger(Index.class.getName()).log(Level.SEVERE, null, ex);
            } catch (ParseException ex) {
                Logger.getLogger(Index.class.getName()).log(Level.SEVERE, null, ex);
            }

            for (int i = 0; i < artist_list.size(); i++) {

                if (artist_list.get(i).toString().equals(name)) {
                    res = true;
                    break;
                }

            }
            return res;
        }

        public static JSONArray get_titles( )
        {
            return title_list;
        }

        private static JSONArray title_list;
        
        public static void refresh_titles_json(JSONArray albums) {

            title_list = new JSONArray();

            for (int i = 0; i < albums.size(); i++) {
                JSONObject jo = (JSONObject) albums.get(i);
                if (!title_list.contains(jo.get("title"))) {
                    title_list.add(jo.get("title"));
                }
            }

            Collections.sort(title_list);

            try {
                FileOutputStream fo = new FileOutputStream(new File(titles_path));
                fo.write(title_list.toString().getBytes());

                fo = new FileOutputStream(new File(titles_path_public));
                fo.write(title_list.toString().getBytes());

            } catch (FileNotFoundException ex) {
                Logger.getLogger(Stupid.class.getName()).log(Level.SEVERE, null, ex);
            } catch (IOException ex) {
                Logger.getLogger(Stupid.class.getName()).log(Level.SEVERE, null, ex);
            }
        }

        

        public static void save_new_json(JSONArray albums) {
            try {
                FileOutputStream fo = new FileOutputStream(new File(Album_path));
                fo.write(albums.toString().getBytes());
                fo = new FileOutputStream(new File(Album_path_public));
                fo.write(albums.toString().getBytes());
            } catch (FileNotFoundException ex) {
                Logger.getLogger(Stupid.class.getName()).log(Level.SEVERE, null, ex);
            } catch (IOException ex) {
                Logger.getLogger(Stupid.class.getName()).log(Level.SEVERE, null, ex);
            }
        }



        public static void save_log_json(JSONArray logs) {
            try {
                FileOutputStream fo = new FileOutputStream(new File(log_path));
                fo.write(logs.toString().getBytes());
                fo = new FileOutputStream(new File(log_path_public));
                fo.write(logs.toString().getBytes());
            } catch (FileNotFoundException ex) {
                Logger.getLogger(Stupid.class.getName()).log(Level.SEVERE, null, ex);
            } catch (IOException ex) {
                Logger.getLogger(Stupid.class.getName()).log(Level.SEVERE, null, ex);
            }
        }


        public static ArrayList<Integer> find_album_json(String title, JSONArray albums) {
            ArrayList<Integer> res = new ArrayList<Integer>();

            for (int i = 0; i < albums.size(); i++) {
                JSONObject jo = (JSONObject) albums.get(i);
                if (title.equals(jo.get("title"))) {
                    res.add(Integer.parseInt(jo.get("id").toString()));
                }
            }

            return res;
        }


        public static int alb_exists_json(JSONArray albums, String title, String artist) {

            int res = 0;

            for (int i = 0; i < albums.size(); i++) {
                JSONObject jo = (JSONObject) albums.get(i);
                if (title.equals(jo.get("title")) && artist.equals(jo.get("artist"))) {
                    res = 1;
                    break;
                }
            }

            return res;

        }

        private static boolean track_exists_json(JSONArray tracks, String title, int number) {
            boolean res = false;

            for (int i = 0; i < tracks.size(); i++) {
                JSONObject jo = (JSONObject) tracks.get(i);
                if (title.equals(jo.get("title").toString()) || number == Integer.parseInt(jo.get("number").toString())) {
                    res = true;
                    break;
                }
            }

            return res;
        }

        private static int find_track_json(JSONArray tracks, String title, int number) {
            int res = -1;

            for (int i = 0; i < tracks.size(); i++) {
                JSONObject jo = (JSONObject) tracks.get(i);
                if (title.equals(jo.get("title").toString()) || number == Integer.parseInt(jo.get("number").toString())) {
                    res = i;//Integer.parseInt(jo.get("number").toString());
                    break;
                }
            }

            return res;
        }

        private static void sort_tracks_json(JSONArray tracks) {
            boolean isSorted = false;

            while (!isSorted) {

                isSorted = true;

                for (int i = 0; i < tracks.size() - 1; i++) {
                    JSONObject track1 = (JSONObject) tracks.get(i);
                    JSONObject track2 = (JSONObject) tracks.get(i + 1);
                    if (Integer.parseInt(track1.get("number").toString()) > Integer.parseInt(track2.get("number").toString())) {
                        tracks.set(i, track2);
                        tracks.set(i + 1, track1);
                        isSorted = false;
                    }
                }

            }
        }

        public static void addTrack_json(JSONArray albums, int album_id, String track_title, int track_number) {
            JSONObject album = (JSONObject) albums.get(album_id);

            JSONArray tracks = (JSONArray) album.get("tracks");

            if (!track_exists_json(tracks, track_title, track_number)) {
                JSONObject new_track = new JSONObject();
                new_track.put("number", track_number);
                new_track.put("title", track_title);

                tracks.add(new_track);

                System.err.println("tracks: " + tracks.toString());

                if (tracks.size() > 1) {
                    sort_tracks_json(tracks);
                }

                System.err.println("new tracks: " + tracks.toString());

                album.put("tracks", tracks);

                //System.err.println("album: " + album.toString());
                //albums.add(album);
                save_new_json(albums);
            }

        }

        

        public static void newLogEntry_json(JSONArray logs, String wh, int type, String title) {
            JSONObject new_log = new JSONObject();
            new_log.put("title", title);
            new_log.put("what_happened", wh);
            DateFormat dateFormat = new SimpleDateFormat("MM/dd/yyyy HH:mm");
            new_log.put("when_ih", dateFormat.format(new Date()));
            new_log.put("type", type);

            logs.add(new_log);

            save_log_json(logs);

        }

        

        public static void deleteTrack_json(JSONArray albums, int album_id, int track_number) {
            JSONObject album = (JSONObject) albums.get(album_id);

            JSONArray tracks = (JSONArray) album.get("tracks");

            if (track_exists_json(tracks, "", track_number)) {

                System.err.println("tracks: " + tracks.toString());
                //tracks.add(new_track);
                tracks.remove(find_track_json(tracks, "", track_number));

                System.err.println("new tracks: " + tracks.toString());

                album.put("tracks", tracks);

                //System.err.println("album: " + album.toString());
                //albums.add(album);
                save_new_json(albums);
            }
        }

        

        public static void addAlbum_json(JSONArray albums, String title, String artist) {
            if (alb_exists_json(albums, title, artist)==0) {
                JSONObject new_album = new JSONObject();
                
                new_album.put("title", title);
                new_album.put("artist", artist);
                new_album.put("approved", false);
                new_album.put("genre", "");
                new_album.put("pic_name", "404.jpg");
                DateFormat dateFormat = new SimpleDateFormat("MM/dd/yyyy HH:mm");
                new_album.put("date_included", dateFormat.format(new Date()));
                new_album.put("comment", "");
                new_album.put("id", albums.size());
                
                albums.add(new_album);
                
                save_new_json(albums);
            }

        }

       


    }

}
