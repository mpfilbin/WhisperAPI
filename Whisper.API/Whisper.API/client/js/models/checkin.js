Whisper.Checkin = Backbone.Model.extend({
   url:  "http://whisper.apphb.com/api/location/checkin/",
    initialize: function(){
        this.url = this.url + Whisper.app.currentUser.id;
    },
    setCheckinData:function(courseId, lat, lon){
        this.url = this.url + "/" + courseId + "/" + lat + "/" + lon;
    }
});

Whisper.CheckinsCollection = Backbone.Collection.extend({
    model: Whisper.Checkin,
    initialize: function(){
    },
    setUrl:function(courseId){
        this.url = 'http://whisper.apphb.com/api/checkins/course/'+ Whisper.app.currentUser.accessToken +"/"+ courseId;
    }

})
