var Whisper = Whisper || {};

(function($, Whisper){
  $(function(){
    var signin = new Whisper.SigninView({
      el: $("div#main-content").first()
    });
    signin.render();
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
