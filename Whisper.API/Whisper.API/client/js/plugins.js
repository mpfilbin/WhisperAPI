// usage: log('inside coolFunc', this, arguments);
// paulirish.com/2009/log-a-lightweight-wrapper-for-consolelog/
window.log = function f(){ log.history = log.history || []; log.history.push(arguments); if(this.console) { var args = arguments, newarr; args.callee = args.callee.caller; newarr = [].slice.call(args); if (typeof console.log === 'object') log.apply.call(console.log, console, newarr); else console.log.apply(console, newarr);}};

// make it safe to use console.log always
(function(a){function b(){}for(var c="assert,count,debug,dir,dirxml,error,exception,group,groupCollapsed,groupEnd,info,log,markTimeline,profile,profileEnd,time,timeEnd,trace,warn".split(","),d;!!(d=c.pop());){a[d]=a[d]||b;}})
(function(){try{console.log();return window.console;}catch(a){return (window.console={});}}());


// place any jQuery/helper plugins in here, instead of separate, slower script files.

// because some of the devs run Windows and some run Linux, and because this project is part ASP.NET MVC 4
// and part rich client-side app, we serve the javascript locally and always connect to the deployed
// version for the API service calls. The result is an AJAX *cross-domain* call.
// Ramifications include the need to have a cross domain policy file in the root and fully qualified URLs
// to be called by backbone (instead of relative URLs). Here, we override the url function to be able to call
// fully qualified URLs.

// see original url() function in Backbone annotated source http://backbonejs.org/docs/backbone.html
Backbone.Model.prototype.url = function() {
    var domain = 'http://whisper.apphb.com';
    var base = getValue(this, 'urlRoot') || getValue(this.collection, 'url') || urlError();
    var url = domain + (base.charAt(0) == '/' ? '' : '/') + base;

    console.log('attempting to load Model data from: ', url);

    if (this.isNew()) return url;
    return url + (base.charAt(base.length - 1) == '/' ? '' : '/') + encodeURIComponent(this.id);
}
