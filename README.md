# swapi-cli
This project demonstrates a simple implementation of requesting resources from a RESTful API thorugh C#.


# Contents
* CoreApp
  * Program.cs : Main "runner" of the CLI .
  * FilmHandler.cs : Core logic for retrieving data from 
  * ErrorHandler.cs : Simple Error Handling implemented in a unified location.
  
* SharpTrooper : A C# helper library to simplify the consumption of the Star Wars API
   * Core
      * SharpTrooperCore.cs : Backbone of API consumption. Contains 4 custom methods added to complete the project (Found in Region ChrisHodges)

# Acknowledgements

* *SharpTrooper* by Olcay Bayram (https://github.com/olcay/SharpTrooper)

# Goal
Given a Star Wars Movie, an Entity from the Movie, and a desired Entity Property Name, return the list of Entity Property Values without duplicates.

# Build

TBD

# Run
To run, this project requires the following parameters:
  1. Movie_Title: A film title, enclosed in double-quotes
  2. Entity_Name: An entity name on the [film entity](http://swapi.co/documentation#films) which represents a collection of other entities. For example, a film has a property named "characters" which is a JSON array with references to the set of [people](http://swapi.co/documentation#people) that appear in the film. The value for this second command line argument will be one of the following: "characters", "planets", "starships".
  3. Entity_Property_Name: An entity property name, which will exist on the entity identified in number 2 above, and that property will be a string property (not an array).

By default, the application will run requests for the Entity Property Values sequentially.
An optional *-t* flag can be added as a fourth argument which will run requests for the Entity Property Values through threads.

*CoreApp.exe "Movie Title" Entity_Name Entity_Property_Name*
