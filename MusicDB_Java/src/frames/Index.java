/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package frames;

import java.awt.PopupMenu;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import util.Stupid.stupid;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

/**
 *
 * @author rofler
 */
public class Index extends javax.swing.JFrame {

    String[] title_list;
    String[] artist_list;
    JSONArray albums_json;
    JSONArray logs_json;

    /**
     * Creates new form index
     */
    public Index() {

        try {
            JSONParser parser = new JSONParser();
            File f = new File(stupid.get_Album_path());

            albums_json = new JSONArray();
            albums_json = (JSONArray) parser.parse(new FileReader(stupid.get_Album_path()));
            JSONObject album = (JSONObject) albums_json.get(0);

            logs_json = (JSONArray) parser.parse(new FileReader(stupid.get_log_path()));

            //System.out.println(album.get("approved").toString());
            
            stupid.refresh_artists_json(albums_json);
            stupid.refresh_titles_json(albums_json);
            
            initComponents();

            text_albumTitle.setText(album.get("title").toString());
            
            
            

        } catch (IOException ex) {
            Logger.getLogger(Index.class.getName()).log(Level.SEVERE, null, ex);
        } catch (ParseException ex) {
            Logger.getLogger(Index.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        button_addAlbum = new javax.swing.JButton();
        jScrollPane1 = new javax.swing.JScrollPane();
        text_albumTitle = new javax.swing.JTextPane();
        label1 = new java.awt.Label();
        button_details = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        button_addAlbum.setText("add album");
        button_addAlbum.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                button_addAlbumActionPerformed(evt);
            }
        });

        jScrollPane1.setViewportView(text_albumTitle);

        label1.setText("album title");

        button_details.setText("view details");
        button_details.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                button_detailsActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addComponent(button_addAlbum)
                .addGap(50, 50, 50))
            .addGroup(layout.createSequentialGroup()
                .addGap(41, 41, 41)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(button_details)
                    .addComponent(label1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 107, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addContainerGap(240, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(label1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(5, 5, 5)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(button_details)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 124, Short.MAX_VALUE)
                .addComponent(button_addAlbum)
                .addGap(56, 56, 56))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void button_addAlbumActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_button_addAlbumActionPerformed
        // TODO add your handling code here:
        this.dispose();
        new AddAlbum().setVisible(true);
    }//GEN-LAST:event_button_addAlbumActionPerformed

    private void button_detailsActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_button_detailsActionPerformed

        stupid.refresh_artists_json(albums_json);
        stupid.refresh_titles_json(albums_json);

        //stupid.deleteTrack_json(albums_json, 0, 1);
        //stupid.addTrack_json(albums_json, 0, "jonhattan", 1);
        //stupid.newLogEntry_json(logs_json, "test", 2, "Bestiary");
        //stupid.save_new_json(albums_json);
        ArrayList<Integer> temp_list = stupid.find_album_json(text_albumTitle.getText(), albums_json);

        
        
        if (temp_list.size() == 1) {
            this.dispose();
            new AlbumDetails(albums_json, temp_list.get(0)).setVisible(true);
        }
        else
        {
            System.err.println("just wait");
        }

        //if(stupid.artistExists_json(text_albumTitle.getText()))
        //  System.out.println("yes");

    }//GEN-LAST:event_button_detailsActionPerformed

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(Index.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(Index.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(Index.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(Index.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new Index().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton button_addAlbum;
    private javax.swing.JButton button_details;
    private javax.swing.JScrollPane jScrollPane1;
    private java.awt.Label label1;
    private javax.swing.JTextPane text_albumTitle;
    // End of variables declaration//GEN-END:variables
}