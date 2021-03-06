var Whisper = Whisper || {};

(function($, Whisper){
  Whisper.app = {
    map: undefined,
    initialize: function() {
      _.extend(this, Backbone.Events);
      this.registerRoutes();
      this.router.navigate("#/signin", {trigger: true});
    },
    registerRoutes: function(){
      var router = Backbone.Router.extend({
        routes: {
          "signin": "renderLogin",
          "main": "renderMainView"
        },
        renderMainView: function(){
          var courseCollection = new Whisper.CourseCollection();
          var mainView = new Whisper.MainView({
                el: $('#main-content')[0],
                model: courseCollection
                /*model: {
                 courses: courses,
                 //selectedCourseId: courses.first().id
                 }*/
            });
            mainView.render();
        },
        renderLogin: function(){
          var signin = new Whisper.SigninView({
            el: $("div#main-content")[0]
          });
          signin.render();
        }
      });
      this.router = new router;
      Backbone.history.start();
    },
    currentUser: {
        accessToken:undefined,
        id:undefined,
        student:undefined
    }
  };
$(function(){
    Whisper.app.initialize();
  });
})(jQuery, Whisper);
