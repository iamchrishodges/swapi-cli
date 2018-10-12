using System.Collections.Generic;
using SharpTrooper.Core;
using SharpTrooper.Entities;

namespace CoreApp
{
    class FilmHandler
    {
        private List<string> _movies = new List<string> { "A New Hope", "The Empire Strikes Back", "Return of the Jedi", "The Phantom Menace", "Attack of the Clones", "Revenge of the Sith", "The Force Awakens" };
        private SharpTrooperCore core = new SharpTrooperCore();

        public List<string> movies
        {
            get { return _movies; }
        }

        /// <summary>
        /// Checks to see if the movie exists in our records and retrieves the "index" order of film based on movie list stored in code.
        /// </summary>
        /// <param name="title"></param>
        /// <returns>Index required for Film URLS</returns>
        public int FindFilmIndex(string title)
        {
            var i = movies.IndexOf(title);
            if(i < 0)
            {
                ErrorHandler.PrintError("FilmNotFound", true, 24);
            }
            return i + 1;
        }

        /// <summary>
        /// Requests a film given a title.
        /// </summary>
        /// <param name="title"></param>
        /// <returns>Film object.</returns>
        public Film GetFilmByTitle(string title)
        {
            int index = FindFilmIndex(title);

            var film = core.GetFilm(index.ToString());

            if (!film.title.Equals(title)) //Should the API itself change, this will let us know if our list above is outdated.
            {
                ErrorHandler.PrintError("InternalFilmIncorrect", true, 2);
            }

            return film;
        }

        /// <summary>
        /// Retrieves desired property list from a known Film
        /// </summary>
        /// <param name="entityName"></param>
        /// <param name="x"></param>
        /// <returns>List of Urls of Entities</returns>
        public List<string> GetFilmEntityUrlList(string entityName, Film x)
        {
            List<string> returnValue = new List<string>();
            switch (entityName) { 
            
                case "starships":
                    returnValue = x.starships;
                    break;
                case "planets":
                    returnValue = x.planets;
                    break;
                case "characters":
                    returnValue = x.characters;
                    break;
                default:
                    ErrorHandler.PrintError("FilmPropertyDNE", true, 24);
                    break;
            }
            
            return returnValue;
        }

        /// <summary>
        /// Requests a list of properties from API for a given film entity and attempts to obtain the specified property of the entity
        /// </summary>
        /// <param name="filmPropName"></param>
        /// <param name="propName"></param>
        /// <param name="propUrl"></param>
        /// <returns>The property requested, if applicable</returns>
        public string GetEntityProperty (string filmEntityName, string propName, string propUrl){

            string returnValue = "";
            switch (filmEntityName)
            {
                case "starships":
                    Starship star = core.GetStarshipByURL(propUrl);
                    if (ErrorHandler.HasProperty(star, propName))
                    {
                        returnValue = star.GetType().GetProperty(propName).GetValue(star, null).ToString();
                    }

                    break;
                case "planets":
                    Planet planet = core.GetPlanetByURL(propUrl);
                    if (ErrorHandler.HasProperty(planet, propName))
                    {
                        returnValue = planet.GetType().GetProperty(propName).GetValue(planet, null).ToString();
                    }
                    break;
                case "characters":
                    People people = core.GetPeopleByURL(propUrl);
                    if (ErrorHandler.HasProperty(people, propName))
                    {
                        returnValue = people.GetType().GetProperty(propName).GetValue(people, null).ToString();
                    }
                    break;
            }

            return returnValue;
          
        }


    }
}
