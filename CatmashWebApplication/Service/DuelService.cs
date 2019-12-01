using CatmashWebApplication.Interfaces;
using CatmashWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatmashWebApplication.Service
{
    public class DuelService : IDuelService
    {
        public Cat[] ResultOfDuel(Cat winner, Cat loser)
        {
            int  upWinner, downLoser, highScore, lowScore;
            if (winner.Score >= loser.Score)
            {
                highScore = winner.Score;
                lowScore = loser.Score;
                
            }
            else
            {
                highScore =loser.Score; 
                lowScore = winner.Score;
            }

            upWinner = (((highScore - lowScore) / 100) * 2) + 10;
            downLoser = ((highScore - lowScore) / 100) + 10;

            if(winner.Score >= loser.Score)
            {
                winner.Score = winner.Score + upWinner;
                loser.Score = loser.Score - upWinner;
            }
            else
            {
                winner.Score = winner.Score + downLoser;
                loser.Score = loser.Score - downLoser;
            }
            return new Cat[2] { winner, loser };
        }

        public void GetCompetitors()
        {
            throw new NotImplementedException();
        }
    }
}
