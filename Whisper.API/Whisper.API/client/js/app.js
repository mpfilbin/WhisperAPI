Window.Whisper = Whisper || {};



$(function(){

  $("a#login-link").bind('click', function(event){
    event.preventDefault();
    $("div#login-form").show();
  });
});