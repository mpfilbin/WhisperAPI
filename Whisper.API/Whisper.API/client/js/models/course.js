Whisper.Course = Backbone.Model.extend({
  initialize: function(){
  }
});

Whisper.CourseCollection = Backbone.Collection.extend({
    initialize: function() {
        // todo: get the real student ID
        this.url = 'http://whisper.apphb.com/courses/student/';// + this.studentId;
    }
});