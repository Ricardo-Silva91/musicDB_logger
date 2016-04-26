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
public class log_entry {

    public String title;
    public String what_happened;
    public String when_ih;
    public int type;

    public log_entry(String title, String what_happened, String when_ih, int type) {
        this.title = title;
        this.what_happened = what_happened;
        this.when_ih = when_ih;
        this.type = type;
    }
    
    
}
