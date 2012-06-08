Whisper.Course = Backbone.Model.extend({
  initialize: function(){
  }
});

Whisper.CourseCollection = Backbone.Collection.extend({
    model: Whisper.Course,
    initialize: function() {
        // todo: get the real student ID
        this.url = 'http://whisper.apphb.com/api/courses/students/'+ Whisper.app.currentUser.accessToken +"/"+ Whisper.app.currentUser.id;
    }
});
