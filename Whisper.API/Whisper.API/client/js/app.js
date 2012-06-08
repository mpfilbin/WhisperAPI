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
        id:undefined,
        object:undefined
      }
  };
$(function(){
    Whisper.app.initialize();
  });
})(jQuery, Whisper);

