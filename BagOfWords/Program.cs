using System;
using System.Collections.Generic;
using System.Linq;

namespace BagOfWords
{
    public class Program
    {                    
        static void Main(string[] args)
        {
            var movies = new Movies();
            var stopWords = new StopWords();
            var bagOfWordsCalc = new BagOfWordsCalc();

            var moviesItems = movies.Get().ToList();
            var stopWordsItens = stopWords.Get().ToList();
            var finalWords = new List<string>();


            foreach (var item in moviesItems){
                foreach(var caracther in stopWords.CharactersToRemove()){
                    
                    item.Movie = item.Movie.Replace(caracther, "");
                
                }
                item.MovieSplited.AddRange(item.Movie.Split(' ').ToList());
            }

            foreach (var item in moviesItems)
            {
                var moviesWithoutStopWords = item.MovieSplited.Where(a => !stopWordsItens.Contains(a)).ToList();
                item.MovieSplited = moviesWithoutStopWords;
                finalWords.AddRange(item.MovieSplited.Where(a => !finalWords.Contains(a)));
                
            }



            var matrixMovies = new List<MatrixMovie>();

            foreach (var item in moviesItems)
            {
                foreach (var finalWord in finalWords)
                {
                    var exists = item.MovieSplited.Contains(finalWord)? 1: 0;
                    matrixMovies.Add(new MatrixMovie { Document = item.Movie, Word = finalWord, Exist = exists });
                }
            }



            var cosineSimilarity = new CosineSimilarity{ MatrixMovie = matrixMovies, BagOfWords = finalWords };

            var documents = moviesItems.Select(a =>a.Movie).ToList();


            var result = Combinations.GetPermutations(documents, 2).ToList();

            foreach(var item in result){
                var itens = new List<string>();
                
                foreach(var item2 in item){
                    itens.Add(item2);
                }

                var document1Index = moviesItems.FirstOrDefault(a => a.Movie == itens[0])?.Index;
                var document2Index = moviesItems.FirstOrDefault(a => a.Movie == itens[1])?.Index;
                
                var bagCalculation = bagOfWordsCalc.CalculateCosineSimilarity(cosineSimilarity, itens[0],itens[1],document1Index,document2Index);
            }


                Console.WriteLine();
                Console.WriteLine("TABELA FREQUENCIA");
                Console.WriteLine();

                foreach(var word in finalWords){
                    Console.Write("|"+word);
                }

                Console.WriteLine();

                foreach(var item in moviesItems){

                    Console.Write(item.Movie+ ": ");

                    foreach(var word in finalWords){

                        Console.Write(" | "+ item.MovieSplited.Count(f => word.Contains(f)));
                    }

                    Console.WriteLine();
                }



            Console.WriteLine();
            Console.ReadLine();

        }
    }



    public class MatrixMovie{

        public string Document { get; set;}
        public string Word { get; set; }
        public int Exist { get; set; }
    }

    public class MoviesWithSplit{

        public string Movie { get; set; }
        public string Index{get;set;}
        public List<string> MovieSplited { get; set; }
    }


}
