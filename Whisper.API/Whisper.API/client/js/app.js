var Whisper = Whisper || {};

(function($, Whisper){
  $(function(){
    var signin = new Whisper.SigninView({
      el: $("div#main-content").first()
    });
    signin.render();
  });
})(jQuery, Whisper);

