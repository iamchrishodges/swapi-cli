# swapi-cli
This project demonstrates a simple implementation of requesting resources from a RESTful API through C#.


# Contents 
The following outline the locations of the key components of the app.

* CoreApp
  * CoreApp.sln : Main Solution File for project
  * CoreApp
    * CoreApp.csproj : Main csproj for project.
    * Program.cs : Main "runner" of the CLI .
    * FilmHandler.cs : Core logic for retrieving data from 
    * ErrorHandler.cs : Simple Error Handling implemented in a unified location.
  
* SharpTrooper : A C# helper library to simplify the consumption of the Star Wars API
   * SharpTrooper.csproj : Location for helper library's Solution File.
   * Core
      * SharpTrooperCore.cs : Backbone of API consumption. Contains 4 custom methods added to complete the project (Found in Region ChrisHodges)

# Acknowledgements

* *SharpTrooper* by Olcay Bayram (https://github.com/olcay/SharpTrooper)

# Goal
Given a Star Wars Movie, an Entity from the Movie, and a desired Entity Property Name, return the list of Entity Property Values without duplicates.

# Build
The application is currently configured for Debug Mode to allow users to test Command Line Arguments directly in Visual Studio.

To switch to Release, you can open the CoreApp properties in Visual Studio, navigate to "Build," and update the Configuration from "Debug" to "Release." Once this is configured a CoreApp.exe will be built in CoreApp/bin/Release/ where Command Line Arguments can be run directly against the app.

# Run
To run, this project requires the following parameters:
  1. Movie_Title: A film title, enclosed in double-quotes
  2. Entity_Name: An entity name on the [film entity](http://swapi.co/documentation#films) which represents a collection of other entities. For example, a film has a property named "characters" which is a JSON array with references to the set of [people](http://swapi.co/documentation#people) that appear in the film. The value for this second command line argument will be one of the following: "characters", "planets", "starships".
  3. Entity_Property_Name: An entity property name, which will exist on the entity identified in number 2 above, and that property will be a string property (not an array).

By default, the application will run requests for the Entity Property Values sequentially.
An optional *-t* flag can be added as a fourth argument which will run requests for the Entity Property Values through threads.

*CoreApp.exe "Movie Title" Entity_Name Entity_Property_Name*

# Notes about performance

The biggest performance hog in this application is retrieving the JSON for the film and converting the JSON to C# Objects. Potentially, some of the objects that are not required could be ignored from the JSON but this would limit the functionality should requirements change and additional film entities be desired. Overall, in a production application, I would provide additional logging to the user to show that some work is being performed behind the scenes. In order to maintain the desired output displayed in the prompt, I left these messages out of the project. I did create a very simple "error" handling class to centralize the storage of error messages that are currently used whenever the application should terminate due to unexpected behavior.

In regards to requesting resources for the Entity, I tested a few different single thread and multi thread options and the single thread option proved to work best on my computer. The additional command line argument allows for both options to be tested and, by default, the single thread option will be used.

