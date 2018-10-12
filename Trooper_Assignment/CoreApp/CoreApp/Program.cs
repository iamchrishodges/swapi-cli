using SharpTrooper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() >= 4)
            {
                ErrorHandler.PrintError("UnsatisfiedArgs", true, 24);
            }

            
            FilmHandler filmHandler = new FilmHandler();
            Film f = filmHandler.GetFilmByTitle(args[0]);
            List<string> urlList = filmHandler.GetFilmEntityUrlList(args[1], f);
 
            
            if(args.Count() == 4 && args[3].Equals("-t")) //Switches between the Parallel and Sequential Request for Enity Properties
            {
                ParallelEntityPropertyLoop(urlList, filmHandler, args);
            }
            else
            {
                SequentialEntityPropertyLoop(urlList, filmHandler, args);
            }
            
            Console.Read();
        }

        /// <summary>
        /// Requests Information Regarding the properties of an entity. Performs action through threading.
        /// </summary>
        /// <param name="resourceUrlList"></param>
        /// <param name="filmHandler"></param>
        /// <param name="args"></param>
        public static void ParallelEntityPropertyLoop(List<string> resourceUrlList, FilmHandler filmHandler, string[] args)
        {
            List<string> resultsList = new List<String>();
            Parallel.ForEach(resourceUrlList, new ParallelOptions() { MaxDegreeOfParallelism = 4 }, url =>
            {
                string prop = filmHandler.GetEntityProperty(args[1], args[2], url);
                if (resultsList.IndexOf(prop) == -1)
                {
                    resultsList.Add(prop);
                    Console.WriteLine(prop);
                }
            });
        }

        /// <summary>
        /// Requests Information Regarding the properties of an entity. Performs action sequentially.
        /// </summary>
        /// <param name="resourceUrlList"></param>
        /// <param name="filmHandler"></param>
        /// <param name="args"></param>
        public static void SequentialEntityPropertyLoop(List<string> resourceUrlList, FilmHandler filmHandler, string[] args)
        {
            List<string> resultsList = new List<String>();
            foreach (var url in resourceUrlList)
            {
                string prop = filmHandler.GetEntityProperty(args[1], args[2], url);
                if (resultsList.IndexOf(prop) == -1)
                {
                    resultsList.Add(prop);
                    Console.WriteLine(prop);
                }
            }
        }
    }
}
