User = require "models/user"

describe "A User", ->

  # Before each test harness, create a new instance of the User model class
  beforeEach ->
    @user = new User
      first_name: "Mike"
      last_name: "Filbin"
      courses: [1, 2, 3, 4, 5]

  # After each test harness is executed, destroy the instance of the user model class
  afterEach ->
    @user.dispose()

  describe "when created", ->
    it "should expect to have a first name", ->
      expect(@user.attributes).to.have.property('first_name')
      expect(@user.get "first_name").to.equal "Mike"

    it "should expect to have a last name", ->
      expect(@user.attributes).to.have.property('last_name')
      expect(@user.get "last_name").to.equal "Filbin"

    it "should expect to have a full name that is a combination of the first and last names", ->
      expect(@user.attributes).to.have.property('full_name')
      expect(@user.get "full_name").to.equal "Mike Filbin"

    it "should expect to have a list of course ids for which the user is enrolled", ->
      expect(@user.attributes).to.have.property("courses")
      expect(@user.get "courses").to.contain(5)
