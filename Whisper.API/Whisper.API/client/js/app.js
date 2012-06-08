var Whisper = Whisper || {};

(function($, Whisper){
  Whisper.app = {
    initialize: function() {
        var signin = new Whisper.SigninView({
        el: $("div#main-content").first()
        });
      signin.render();
    },
  currentUser: {
        accessToken:undefined,
        object:undefined
      }
  };
$(function(){
    Whisper.app.initialize();
  });
})(jQuery, Whisper);

// map example
//$(function() {
//    var map = new Whisper.Map({
//        id:'map_canvas',
//        zoomLevel:18,
//        callback:function () {
//
//        }
//    });
//});
