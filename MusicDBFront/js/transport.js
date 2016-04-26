var artist = "jogos";

function artistClick(art)
{
    artist=art;
    //alert(artist);
    window.location.href = "artist.html?myVar1="+artist;


}

function albumClick(alb)
{
//    artist=art;
    //alert(artist);
    var win = window.open("album.html?myVar1="+alb, '_blank');
    win.focus();
    //window.location.href = "album.html?myVar1="+alb;


}

function goToLog()
{
//    artist=art;
    //alert(artist);
    window.location.href = "logView.html";


}

$(".input-group-btn").click( function()
{

    for (var i = titles.length - 1; i >= 0; i--) {
        if($('#search_input').val() == titles[i])
        {
            albumClick(find_id(titles[i]));
            return;
        }
    }

    for (var i = artists.length - 1; i >= 0; i--) {
        if($('#search_input').val() == artists[i])
        {
            artistClick(artists[i]);
            return;
        }
    }

    alert("Album or Artist not on DataBase!");
});

$("#search_input").keypress(function(e) {
    if(e.which == 13) {
        for (var i = titles.length - 1; i >= 0; i--) {
        if($('#search_input').val() == titles[i])
        {
            albumClick(find_id(titles[i]));
            return;
        }
    }

    for (var i = artists.length - 1; i >= 0; i--) {
        if($('#search_input').val() == artists[i])
        {
            artistClick(artists[i]);
            return;
        }
    }

    alert("Album or Artist not on DataBase!");
    }
});


function find_id(title)
{
    for(i=0;i<albums.length; i++)
    {
        if(albums[i].title==title)
            return i;
    }
}