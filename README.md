# Whisper #

** This is my personal fork of our Hackathon project. I am doing my own refactoring **

Whisper is an HTML5 web application targeted at the mobile platform. It leverages location awareness against a set of web services to allow users to create ad hoc study sessions through course-specific check-ins. Whisper plots on a map the user's coordinates along with the coordinates of other students who have checked in to a given course. When a user changes courses, the map is dynamically updated with any check-ins from their classmates.

## Project Purpose ##

Aspenware created Whisper as a prototype for the 2012 Pearson Hackathon. It is not production-ready code. This application has no test suite and most of the application has no code coverage.

## Techologies ##

We used the following technologies to develop Whisper:

#### Client-side ####

* [HTML5 geolocation API](http://dev.w3.org/geo/api/spec-source.html) for determining the latitude and longitude of check-ins
* [Google Maps APIs](https://developers.google.com/maps/) for plotting user positions on a map
* [Cascading Styles Sheets level 3](http://www.w3.org/TR/CSS/) for layout, styling, and visual representation
* [Backbone JavaScript Library](http://backbonejs.org/) for object representation, user-driven events, data-stores, and asynchronous service calls
* [jQuery JavaScript Library](http://jquery.com/) for basic DOM scripting
* [Underscore.js JavaScript library](http://underscorejs.org/) for templating and utility methods

#### Server-side ####
* [ASP.NET MVC version 3](http://www.asp.net/mvc) for development of the API tier
* [Simple DB](http://aws.amazon.com/simpledb/) as the non-relational database for storage of user meta-data such as check-ins and geolocations
* [App Harbor](https://appharbor.com/) for application server hosting and dynamic scalability

#### Development Tools ####
* [Github](http://github.com) for source code management and versioning

## Architectural Overview ##

The server-side implementation uses a traditional MVC design pattern where models represent domain objects and controller actions handle client interaction. We expose application APIs through RESTful routes and we express data through either JSON or XML, depending upon how Whisper consumes the service. The server-side APIs are client agnostic and Whisper may consume them using both native mobile applications and HTML5 RIAs.

The client-side implementation uses a model-collection-view paradigm that, like the server-side code, represents domain objects by JavaScript models which Whisper fetches and instantiates using asynchronous service calls. We bound data in the models to a single view using HTML templates, and we rendered new views by a router that intercepts changes in the browser's URL bar via hashes, initiated by actions like button or link clicks. This means that the browser's history captures the front-end's state and this history can be traversed using the forward and backward arrows.

## Development Team ##

* **Rob Clark**: Application design, styling, and layout
* **Eric Bowen**: Middle-tier development
* **Adam Roderic**: Client-side development
* **Michael Filbin**: Client-side development

## The MIT License (MIT) ##

Copyright (c) 2012 Aspenware Internet Solutions

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
