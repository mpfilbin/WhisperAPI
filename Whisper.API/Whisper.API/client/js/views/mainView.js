Whisper.MainView = Backbone.View.extend({
    selectedSubView: 'map',
    events: {
        'click #checkin-link a': 'checkin',
        'click #show-list-link a' : 'showList',
        'click #show-map-link a' : 'showMap',
        'mouseup #course-picker select': 'onSelectChange',
        'click button#check-in': "checkin"
    },
    initialize: function() {
      this.template = _.template($('#main-template').html());
    },
    render: function() {
      var model, output, self = this;
        this.model.fetch({
            success: function(results, response){
                output = self.template({courses:results});
                self.$el.html(output);
                if (self.selectedSubView === 'map') {
                    self.showMap();
                } else {
                    self.showList();
                }
            }
        });
        return this;
    },
    checkin: function(event) {
        var currentCourseId, checkin, lat, lon, self = this;
        event.preventDefault();
        currentCourseId = this.getSelectedCourseId();
        checkin = new Whisper.Checkin;
        navigator.geolocation.getCurrentPosition(function(position){
            lat = position.coords.latitude;
            lon = position.coords.longitude;
            checkin.setCheckinData(currentCourseId, lat, lon);
            checkin.fetch({
                success:function(result, response){
                    console.log(result);
                }
            })

        });
    },

    getSelectedCourseId:function(event){
        var selectElement;
        if(typeof event !== "undefined"){
            selectElement = $(event.target);
        }else{
            selectElement = $("#course-picker select");
        }
        return ("option:selected", selectElement).val();

    },
    onSelectChange: function(event){
        var selectedCouseId, checkinsCollection, self = this;
        event.preventDefault();
        selectedCouseId = this.getSelectedCourseId(event)
        checkinsCollection = new Whisper.CheckinsCollection();
        checkinsCollection.setUrl(selectedCouseId);
        checkinsCollection.fetch({
            success:function(results, response){
                self.showMap(results.toJSON());
            },
            error: function(results, response){
                console.log(response);
            }
        });
    },
    showMap: function(checkins) {
        this.$el.find('#show-map-link').hide();
        this.$el.find('#show-list-link').show();
        if (this.listView) this.listView.$el.hide();

        if (!this.mapView) {
            this.mapView = new Whisper.MapView({
                el: $('#map-canvas')[0]
            });
        }
        this.mapView.render();
        this.mapView.clear();
        this.mapView.$el.show();
        this.selectedSubView = 'map';
        if(typeof checkins !== 'undefined'){
            this.mapView.map.placeMarker(checkins);
        }
    },
    showList: function(checkins) {
        this.$el.find('#show-list-link').hide();
        this.$el.find('#show-map-link').show();
        if (this.mapView) this.mapView.$el.hide();

        if (!this.listView) {
            this.listView = new Whisper.CheckinListView({
                el: $('#recent-checkins')[0]
            });
        }

        this.listView.render();
        this.listView.$el.show();
        this.selectedSubView = 'list';
    }
});
