using System;
using System.Collections.Generic;
using System.Linq;

namespace BagOfWords
{
    public class BagOfWordsCalc{
            public double CalculateCosineSimilarity(CosineSimilarity cosineSimilarity, string documentA, string documentB, string documentAIndex, string documentBIndex){
                
                var document1 = cosineSimilarity.MatrixMovie.Where(m => m.Document.ToLower() == documentA.ToLower());
                var document2 = cosineSimilarity.MatrixMovie.Where(m => m.Document.ToLower() == documentB.ToLower());

                double item1 = 0;
                double sqrtItem1 = 0;
                double sqrtItem2 = 0;

                for(var i = 0; i < cosineSimilarity.BagOfWords.Count; i++){

                    item1 += document1.ElementAt(i).Exist * document2.ElementAt(i).Exist;
                    sqrtItem1 += Math.Pow(document1.ElementAt(i).Exist, 2);
                    sqrtItem2 += Math.Pow(document2.ElementAt(i).Exist, 2);
                }
                
                var finalResult = item1 / (Math.Sqrt(sqrtItem1) * Math.Sqrt(sqrtItem2));

                foreach(var item in cosineSimilarity.BagOfWords){

                    Console.Write("|"+item);
                }

                Console.WriteLine();
                Console.Write(string.Concat("DOCUMENTO BINÁRIO ",documentAIndex,": "));

                foreach(var item in document1){

                    Console.Write(" | "+item.Exist);
                }

                Console.WriteLine();
                Console.Write(string.Concat("DOCUMENTO BINÁRIO ",documentBIndex,": "));

                foreach(var item in document2){

                    Console.Write(" | "+item.Exist);
                }



                Console.WriteLine();
                Console.WriteLine(string.Concat("SIM(",documentAIndex,",",documentBIndex,") = ",finalResult));
                Console.WriteLine();


                return finalResult;
            }
    }
}