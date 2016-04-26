/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package web;

import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;
import util.Stupid;

/**
 *
 * @author rofler
 */
@WebServlet(name = "Interface", urlPatterns = {"/Interface"})
public class Interface extends HttpServlet {

    int login_attempts = 0;

    JSONArray albums_json;
    JSONArray logs_json;

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");

        JSONParser parser = new JSONParser();

        albums_json = new JSONArray();
        try {
            albums_json = (JSONArray) parser.parse(new FileReader(Stupid.stupid.get_Album_path()));
        } catch (ParseException ex) {
            //Logger.getLogger(Interface.class.getName()).log(Level.SEVERE, null, ex);
            System.err.println("Parse Exception");
        }

        Stupid.stupid.refresh_artists_json(albums_json);
        Stupid.stupid.refresh_titles_json(albums_json);

        String pass = request.getParameter("pass");
        String choice = request.getParameter("choice");
        boolean nocookies = false;
        String cookie_pass = "";

        if (pass != null) {
            /*System.err.println("entrou no else");*/
            Cookie cooki = new Cookie("pass", pass);
            cooki.setMaxAge(900);
            response.addCookie(cooki);
            response.sendRedirect("Interface");

            return;
        }
        try {
            Cookie[] cookies = request.getCookies();
            int numberOfCookies = cookies.length;
            System.err.println("number of cookies: " + numberOfCookies);

            for (Cookie cookie : cookies) {
                if (cookie.getName().equals("pass")) {
                    cookie_pass = cookie.getValue();
                }
            }

            //System.err.println("cookie value: " + request.getCookies()[0].getValue());
            //System.err.println("cookie2 value: " + request.getCookies()[1].getValue());
            //System.err.println("cookie time: " + request.getCookies()[0].getMaxAge());
        } catch (Exception err) {
            System.err.println("exc");
            nocookies = true;
        }

        try (PrintWriter out = response.getWriter()) {
            if (nocookies || !cookie_pass.equals("j")) {

                /* TODO output your page here. You may use following sample code. */
                out.println("<!DOCTYPE html>");
                out.println("<html>");
                out.println("<head>");
                out.println("<title>musicDB server</title>");
                out.println("</head>");
                out.println("<body>");
                out.println("<h1>Papers please!</h1></br>");

                out.println("<form>");

                out.println("<b>pass:</b>");
                out.println("<input type=\"text\" name=\"pass\">\n"
                        + "            <input type=\"submit\" value=\"jogos\">");

                out.println("</form>");
                if (login_attempts > 0) {
                    out.println("<b>login attemts: " + login_attempts + "<br />");
                }

                login_attempts++;

                out.println("</form>");

                out.println("</body>");
                out.println("</html>");

            } else if (choice != null) {

                if (choice.equals("AddAlbum")) {
                    out.println("<!DOCTYPE html>");
                    out.println("<html>");
                    out.println("<head>");
                    out.println("<title>MusicDB</title>");
                    out.println("</head>");
                    out.println("<body>");

                    out.println("<h1>Add new album</h1></br>");

                    out.println("<form>");

                    out.println("<input type=\"text\" name=\"AlbumTitle\"  >");
                    out.println("<input type=\"text\" name=\"AlbumArtist\"  >");
                    out.println("<input type=\"submit\" name=\"choice\" value=\"AddingAlbum\" >");

                    out.println("</form>");

                    out.println("</body>");
                    out.println("</html>");
                } else if (choice.equals("AlbumDetails") && request.getParameter("AlbumTitle") != null) {

                    String album_title = request.getParameter("AlbumTitle");

                    if (Stupid.stupid.find_album_json(album_title, albums_json).isEmpty()) {
                        response.sendRedirect("Interface");
                        return;
                    }

                    int album_id = Stupid.stupid.find_album_json(album_title, albums_json).get(0);

                    //System.err.println("album id: " + album_id);
                    JSONObject album = (JSONObject) albums_json.get(album_id);

                    out.println("<!DOCTYPE html>");
                    out.println("<html>");
                    out.println("<head>");
                    out.println("<title>MusicDB</title>");
                    out.println("</head>");
                    out.println("<body>");

                    out.println("<!DOCTYPE html>");
                    out.println("<html>");
                    out.println("<head>");
                    out.println("<title>MusicDB</title>");
                    out.println("</head>");
                    out.println("<body>");

                    out.println("<h1>Album details: " + album.get("title").toString() + "</h1></br>");

                    //button form
                    out.println("<form>");

                    out.println("<input style=\"display: none\" id=\"search_input\" type=\"text\" name=\"AlbumTitle\" value=\"" + album_title + "\" >");
                    out.println("<input type=\"submit\" name=\"choice\" value=\"AlbumDetails_buttonEdit\" >");
                    out.println("<input type=\"submit\" name=\"choice\" value=\"AlbumDetails_buttonAddTrack\">");

                    out.println("</form>");

                    out.println("</br>");

                    //details form
                    out.println("<form>");

                    out.println("<b>id:&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp </b><input name=\"AlbumDetails_ID\" value=\"" + album_id + "\" disabled></br>");
                    out.println("<b>title: &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b><input name=\"AlbumDetails_title\" value=\"" + album_title + "\" disabled></br>");
                    out.println("<b>artist: &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b><input name=\"AlbumDetails_artist\" value=\"" + album.get("artist").toString() + "\" disabled></br>");
                    out.println("<b>approved: &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b><input name=\"AlbumDetails_approved\" value=\"" + album.get("approved").toString() + "\" disabled></br>");
                    out.println("<b>genre: &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b><input name=\"AlbumDetails_genre\" value=\"" + album.get("genre").toString() + "\" disabled></br>");
                    out.println("<b>date_included: </b><input name=\"AlbumDetails_date_included\" value=\"" + album.get("date_included") + "\" disabled></br>");
                    out.println("<b>comment: &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b><input name=\"AlbumDetails_comment\" value=\"" + album.get("comment").toString() + "\" disabled></br>");

                    JSONArray tracks = (JSONArray) album.get("tracks");
                    for (int i = 0; i < tracks.size(); i++) {
                        if (i == 0) {
                            out.println("<b>Tracks:</b></br>"
                                    + "<b>Number &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Title</b></br>");
                        }

                        JSONObject track = (JSONObject) tracks.get(i);
                        out.println("<input size=\"3\" name=\"AlbumDetails_track" + i + "_number\" value=\"" + track.get("number").toString() + "\" disabled> <input name=\"AlbumDetails_track" + i + "_title\" value=\"" + track.get("title").toString() + "\" disabled> </br>");

                    }

                    out.println("</form>");
                    out.println("</body>");
                    out.println("</html>");

                } else if (choice.equals("AddingAlbum")) {

                    System.out.println("title: " + request.getParameter("AlbumTitle"));
                    System.out.println("artist: " + request.getParameter("AlbumArtist"));
                    response.sendRedirect("Interface");

                } else if (choice.equals("AlbumDetails_buttonEdit") && request.getParameter("AlbumTitle") != null) {
                    String album_title = request.getParameter("AlbumTitle");

                    if (Stupid.stupid.find_album_json(album_title, albums_json).isEmpty()) {
                        response.sendRedirect("Interface");
                        return;
                    }

                    int album_id = Stupid.stupid.find_album_json(album_title, albums_json).get(0);

                    //System.err.println("album id: " + album_id);
                    JSONObject album = (JSONObject) albums_json.get(album_id);

                    out.println("<!DOCTYPE html>");
                    out.println("<html>");
                    out.println("<head>");
                    out.println("<title>MusicDB</title>");
                    out.println("</head>");
                    out.println("<body>");

                    out.println("<!DOCTYPE html>");
                    out.println("<html>");
                    out.println("<head>");
                    out.println("<title>MusicDB</title>");
                    out.println("</head>");
                    out.println("<body>");

                    out.println("<h1>Album details: " + album.get("title").toString() + "</h1></br>");

                    //button form
/*                    out.println("<form>");

                    out.println("<input style=\"display: none\" id=\"search_input\" type=\"text\" name=\"AlbumTitle\" value=\"" + album_title + "\" >");
                    out.println("<input type=\"submit\" name=\"choice\" value=\"AlbumDetails_buttonEdit\" >");
                    out.println("<input type=\"submit\" name=\"choice\" value=\"AlbumDetails_buttonAddTrack\">");

                    out.println("</form>");

                    out.println("</br>");*/

                    //details form
                    out.println("<form>");

                    out.println("<b>id:&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp </b><input name=\"AlbumDetails_ID\" value=\"" + album_id + "\" ></br>");
                    out.println("<b>title: &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b><input name=\"AlbumDetails_title\" value=\"" + album_title + "\" ></br>");
                    out.println("<b>artist: &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b><input name=\"AlbumDetails_artist\" value=\"" + album.get("artist").toString() + "\" ></br>");
                    out.println("<b>approved: &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b><input name=\"AlbumDetails_approved\" value=\"" + album.get("approved").toString() + "\" ></br>");
                    out.println("<b>genre: &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b><input name=\"AlbumDetails_genre\" value=\"" + album.get("genre").toString() + "\" ></br>");
                    out.println("<b>date_included: </b><input name=\"AlbumDetails_date_included\" value=\"" + album.get("date_included") + "\" ></br>");
                    out.println("<b>comment: &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</b><input name=\"AlbumDetails_comment\" value=\"" + album.get("comment").toString() + "\" ></br>");

                    JSONArray tracks = (JSONArray) album.get("tracks");
                    for (int i = 0; i < tracks.size(); i++) {
                        if (i == 0) {
                            out.println("<b>Tracks:</b></br>"
                                    + "<b>Number &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Title</b></br>");
                        }

                        JSONObject track = (JSONObject) tracks.get(i);
                        out.println("<input size=\"3\" name=\"AlbumDetails_track" + i + "_number\" value=\"" + track.get("number").toString() + "\" > <input name=\"AlbumDetails_track" + i + "_title\" value=\"" + track.get("title").toString() + "\" > </br>");

                    }

                    out.println("</form>");
                    out.println("</body>");
                    out.println("</html>");
                }

            } else {
                //System.err.println("i'm here");
                login_attempts = 0;

                /* TODO output your page here. You may use following sample code. */
                out.println("<!DOCTYPE html>");
                out.println("<html>");
                out.println("<head>");
                out.println("<title>MusicDB</title>");
                out.println("</head>");
                out.println("<body>");

                out.println("<h1>Welcome Master!</h1></br>");
                out.println("<h2>What would you like to do?</h2></br>");

                out.println("<form>");

                out.println("<input id=\"search_input\" type=\"text\" name=\"AlbumTitle\" >");
                out.println("<input type=\"submit\" name=\"choice\" value=\"AlbumDetails\" >");

                out.println("</form></br>");

                out.println("<form>");

                out.println("<input type=\"submit\" class=\"form-control\" autocomplete=\"off\" name=\"choice\" value=\"AddAlbum\" >");

                out.println("</form>");

                /*                out.println("    <script src=\"../bower_components/jquery/dist/jquery.min.js\"></script>\n"
                        + "    <script src=\"//code.jquery.com/ui/1.11.4/jquery-ui.js\"></script>");*/
                out.println("<script src=\"https://dl.dropboxusercontent.com/u/51725489/musicdb/musicdb/musicdb/data/Public_artist_list.json\"></script>\n"
                        + "    <script src=\"https://dl.dropboxusercontent.com/u/51725489/musicdb/musicdb/musicdb/data/Public_title_list.json\"></script>");

                out.println("<script src=javascript/jquery.min.js></script>");
                out.println("<script src=\"//code.jquery.com/ui/1.11.4/jquery-ui.js\"></script>");
                out.println("<script src=javascript/autocomp.js></script>");

                out.println("</body>");
                out.println("</html>");

            }
        }

    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
