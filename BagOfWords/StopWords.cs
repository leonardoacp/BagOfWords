using System.Collections.Generic;

namespace BagOfWords
{
    public class StopWords
    {

        public IEnumerable<string> Get()
        {
            return new List<string>{
                "dos",
                "das",
                "do",
                "o",
                ","
            };
        }


        public IEnumerable<string> CharactersToRemove(){

            return new List<string>{
                ","
            };
        }


    }
}