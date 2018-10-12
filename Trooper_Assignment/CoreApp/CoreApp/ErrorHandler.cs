using System;
using System.Collections.Generic;
using System.Threading;

namespace CoreApp
{
    public static class ErrorHandler
    {
        private static readonly Dictionary<string, string> _errors = new Dictionary<string, string>() {
            { "FilmNotFound" , "Film cannot be found in current context." },
            { "UnsatisfiedArgs", "Arguments provided do not satisfy requirements." },
            { "InternalFilmIncorrect", "There was an internal error that occurred. Film title in application is incorect." },
            { "FilmPropertyDNE", "Film property does not exist." },
            { "EntityPropertyDNE", "Entity property does not exist." }
        };

        public static Dictionary<string, string> errors
        {
            get { return _errors; }
        }
 
 
        /// <summary>
        /// Prints error to console and exits applicaiton if necessary.
        /// </summary>
        /// <param name="errorName"></param>
        /// <param name="shouldExit"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public static string PrintError(string errorName, bool shouldExit = false, int errorCode = 0)
        {
            string x = errors[errorName];
            Console.Error.WriteLine(x);

            if (shouldExit)
            {
                Thread.Sleep(1000);
                Environment.Exit(errorCode);
            }

            return x;
        }

        /// <summary>
        /// Checks whether an object has a given property.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static bool HasProperty(this object obj, string propertyName)
        {

            if(obj.GetType().GetProperty(propertyName) == null)
            {
                PrintError("EntityPropertyDNE", true, 13);
                return false;
            }
            return true;
        }


    }
}
