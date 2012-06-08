Whisper.SigninView = Backbone.View.extend({
  loginForm: undefined,
  events: {
    "submit #login-form form" : "submitLoginForm",
    "click a#login-link" : "showForm"
  },
  initialize: function(){
    this.template = _.template($('#signin-template').html());
  },
  render: function(){
    var output = this.template({
      signin_uri: "http://whisper.apphb.com/api/signin"
    });
    $(this.el).html(output);
    return this;
  },
  showForm: function(event){
    event.preventDefault();
    $("#login-form").show();
  },
  submitLoginForm: function(event){
    var data, self = this;
    event.preventDefault();
    formData = $("#login-form form").serializeArray();
    $.ajax({
      url: "http://whisper.apphb.com/api/signin",
      method: "POST",
      context: self,
      cache: false,
      dataType: 'json',
      data: formData,
      success: this.signinSuccess,
      error: this.signinFailure
    });
  },
  signinSuccessful: function(result){
    console.log(result);
  },
  signinFailure: function(failure){
    console.log(failure);
  }
});
