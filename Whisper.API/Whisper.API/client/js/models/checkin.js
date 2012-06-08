Whisper.Checkin = Backbone.Model.extend({
  initialize: function(){
  }
});

Whisper.CheckinsCollection = Backbone.Collection.extend({
    model: Whisper.Checkin,
    couseId: undefined,
    initialize: function(){
    },
    setUrl:function(courseId){
        this.url = 'http://whisper.apphb.com/api/checkins/course/'+ Whisper.app.currentUser.accessToken +"/"+ courseId;
    }

})
