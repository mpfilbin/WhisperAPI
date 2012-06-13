# Whisper #

Whisper is an HTML5 web application targeted at the mobile platform that leverages location awareness against a set of web services to allow users to create ad hoc study sessions through course-specific check-ins. The user's coordinates are plotted on a map along with other students who have checked in to a given course. Whenever a user changes courses, the map is dynamically updated with any check-ins from their classmates.

## Project Purpose ##

Whisper was created as a prototype for the 2012 Pearson Hackathon and is not production-ready code. This application does not have a test suite and most of the application has no code coverage what-so-ever.

## Techologies ##

The following technolgies were used in the development of Whisper:

#### Client-side ####

* [HTML5 geolocation API](http://dev.w3.org/geo/api/spec-source.html) for determining the latitude and longitude of check-ins
* [Google Maps APIs](https://developers.google.com/maps/) for plotting a given user's positions on a map
* [Cascading Styles Sheets level 3](http://www.w3.org/TR/CSS/) for layout, styling, and visual representation
* [Backbone JavaScript Library](http://backbonejs.org/) for object representation, user-driven events, data-stores, and asynchronous service calls.
* [jQuery JavaScript Library](http://jquery.com/) for basic DOM scripting
* [Underscore.js JavaScript library](http://underscorejs.org/) for templating and utility methods.

#### Server-side ####
* [ASP.NET MVC version 3](http://www.asp.net/mvc) for development of the API tier
* [Simple DB](http://aws.amazon.com/simpledb/) as out non-relational database for storage of user meta-data such as check-ins and geolocations
* [App Harbor](https://appharbor.com/) for application server hosting and dynamic scalability.

#### Development Tools ####
* [Github](http://github.com) for source code management and versioning

## Architectural Overview ##

The server-side implementation uses a traditional MVC design pattern where domain objects are represented by models and client interaction are handled through controller actions. The application APIs are exposed through RESTful routes and data are expressed through either JSON or XML depending upon how the service is consumed. The server-side APIs are client agnostic and may be consumed using native mobile applications and HTML5 RIAs alike.

The client-side implementation uses a model-collection-view paradigm where, like the server-side code, domain objects are represented by JavaScript models which are fetched and instantiated using asynchronous service calls. Data in the models are bound to a single view using HTML templates and new views are rendered by a router that intercepts changes in the browser's URL bar (hash) that are initiated by thinks like button or link clicks. This means that the front-end's state is captured by the browser's history and can be traversed using the forward and backward arrows.

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
