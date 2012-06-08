Whisper.MainView = Backbone.View.extend({
    selectedSubView: 'map',
    events: {
        'click #checkin-link a': 'checkin',
        'click #show-list-link a' : 'showList',
        'click #show-map-link a' : 'showMap',
        'change #course-picker select': 'onSelectChange'
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
    checkin: function() {
        alert('checkin in');
    },
    onSelectChange: function(event){
        var selectElement, selectedOption, courseId, deferred, self = this;
        event.preventDefault();
        selectElement = $(event.target);
        selectedOption = $("option:selected", selectElement);
        courseId = selectedOption.val()
        var checkinsCollection = new Whisper.CheckinsCollection();
        checkinsCollection.setUrl(courseId);
        checkinsCollection.fetch({
            success:function(results){
                self.showMap(results)
            }});
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
