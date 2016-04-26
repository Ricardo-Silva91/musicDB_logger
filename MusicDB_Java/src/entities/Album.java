/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package entities;

/**
 *
 * @author rofler
 */
public class Album {

    public String title;
    public String artist;
    public track[] tracks;
    public Boolean approved;
    public String genre;
    public String pic_name;
    public String date_included;
    public String comment;
    public int id;

    public Album(String title, String artist, track[] tracks, Boolean approved, String genre, String pic_name, String date_included, String comment, int id) {
        this.title = title;
        this.artist = artist;
        this.tracks = tracks;
        this.approved = approved;
        this.genre = genre;
        this.pic_name = pic_name;
        this.date_included = date_included;
        this.comment = comment;
        this.id = id;
    }

    
    
    public String getTitle() {
        return title;
    }

    public String getArtist() {
        return artist;
    }

    public track[] getTracks() {
        return tracks;
    }

    public Boolean getApproved() {
        return approved;
    }

    public String getGenre() {
        return genre;
    }

    public String getPic_name() {
        return pic_name;
    }

    public String getDate_included() {
        return date_included;
    }

    public String getComment() {
        return comment;
    }

    public int getId() {
        return id;
    }
    
    

}
