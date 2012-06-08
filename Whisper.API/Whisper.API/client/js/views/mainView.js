Whisper.MainView = Backbone.View.extend({
  initialize: function() {
      this.template = _.template($('#main-template').html());
  },
    render: function() {
        var model = {};
        var output = this.template(model);
        this.$el.html(output);
        var mapView = new Whisper.MapView({
            el: $('#map-canvas')[0]
        });
        mapView.render();

        return this;
    }
});