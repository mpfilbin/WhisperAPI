Whisper.MainView = Backbone.View.extend({
    selectedSubView: 'map',
    events: {
        'click #checkin-link a': 'checkin',
        'click #show-list-link a' : 'showList',
        'click #show-map-link a' : 'showMap'
    },
    initialize: function() {
      this.template = _.template($('#main-template').html());
    },
    render: function() {
        var model = {};
        var output = this.template(model);
        this.$el.html(output);
        if (this.selectedSubView === 'map') {
            this.showMap();
        } else {
            this.showList();
        }
        return this;
    },
    checkin: function() {
        alert('checkin in');
    },
    showMap: function() {
        this.$el.find('#show-map-link').hide();
        this.$el.find('#show-list-link').show();
        if (this.listView) this.listView.$el.hide();

        if (!this.mapView) {
            this.mapView = new Whisper.MapView({
                el: $('#map-canvas')[0]
            });
        }
        this.mapView.render();
        this.mapView.$el.show();
        this.selectedSubView = 'map';
    },
    showList: function() {
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