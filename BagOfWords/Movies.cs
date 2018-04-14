using System.Collections.Generic;

namespace BagOfWords
{
    public class Movies
    {
        public List<MoviesWithSplit> Get()
        {
            return new List<MoviesWithSplit>{

                new MoviesWithSplit{Index ="A", Movie = "GALO, DOIDO, CABECA".ToLower(),MovieSplited = new List<string>()},
                new MoviesWithSplit{Index ="B", Movie = "QUATRO, FALA, PALAVRAS, ALUNO".ToLower(),MovieSplited = new List<string>()},
                new MoviesWithSplit{Index ="C", Movie = "RUMO, BRACO, DOIS, CABECA, PE".ToLower(),MovieSplited = new List<string>()},
                new MoviesWithSplit{Index ="D", Movie = "REI, ROMA, ROEV, REI, ATLETICO, SEIS, IPATINGA, REI".ToLower(),MovieSplited = new List<string>()},
                new MoviesWithSplit{Index ="E", Movie = "JOTA, MENISCO".ToLower(),MovieSplited = new List<string>()},
                new MoviesWithSplit{Index ="F", Movie = "FRANGAS, TREMERAM, MINEIRAO, BIGODE, PROERD, CAMISA".ToLower(),MovieSplited = new List<string>()},
                new MoviesWithSplit{Index ="G", Movie = "ALUNO, GALO, GALO".ToLower(),MovieSplited = new List<string>()},
                new MoviesWithSplit{Index ="H", Movie = "QUATRO, QUARTO, QUADRO".ToLower(),MovieSplited = new List<string>()},
                new MoviesWithSplit{Index ="I", Movie = "ALUNO, GALO".ToLower(),MovieSplited = new List<string>()},
                new MoviesWithSplit{Index ="J", Movie = "SENHOR DOS ANEIS".ToLower(),MovieSplited = new List<string>()},
                new MoviesWithSplit{Index ="K", Movie = "SENHOR DAS ARMAS".ToLower(),MovieSplited = new List<string>()}
            };
        }
    }
}