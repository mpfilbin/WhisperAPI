Whisper.MapView = Backbone.View.extend({
    map:undefined,
    render:function () {
        if (!this.map) {
            this.map = new Whisper.Map({
                id: this.el.id,
                zoomLevel:15
            });
        }
        return this;
    }
});

