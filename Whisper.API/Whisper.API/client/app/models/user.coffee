Model = require 'models/model'

module.exports = class User extends Model
  defaults:
    full_name: undefined

  initialize: ->
    @set
      "full_name": "#{@get "first_name"} #{@get "last_name"}"
