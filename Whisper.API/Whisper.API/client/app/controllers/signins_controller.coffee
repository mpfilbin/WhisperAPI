Controller = require 'controllers/controller'
Signin = require 'models/signin'
SigninPageView = require 'views/signin_view'

module.exports = class SigninsController extends Controller
  historyURL: 'signins'

  show: (params) ->
    @model = new Signin()
    @view = new SigninPageView({@model})
    @model.fetch()
