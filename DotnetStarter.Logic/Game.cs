using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetStarter.Logic
{
    public class Game
    {
        private int totalScore = 0;
        private int frameScore = 0;
        private int rollsRemaining = 2;
        private int rollsRemainingBonus = 0;

        public int Frames { get; set; }

        public void Roll(int pingsKnockedDown)
        {
            if (Frames >= 10)
                throw new Exception("Game is over");

            AddScore(pingsKnockedDown);
            HandleBonus(pingsKnockedDown);

            bool IsStrike = pingsKnockedDown == 10;
            bool IsSpare = rollsRemaining == 1 && frameScore == 10;
            bool IsSecondRoleDefaultCase = rollsRemaining == 1 && frameScore != 10;
            bool IsFirstRollDefaultCase = rollsRemaining == 2;
            
            switch (pingsKnockedDown)
            {
                case (< 10) when IsFirstRollDefaultCase:
                    rollsRemaining--;
                    break;
                case (< 10) when IsSpare:
                    rollsRemainingBonus = 1;
                    ResetFrame();
                    break;
                case (< 10) when IsSecondRoleDefaultCase:
                    ResetFrame();
                    break;
                case (>= 10) when IsStrike:
                    rollsRemainingBonus = 2;
                    ResetFrame();
                    break;
                default:
                    break;
            }
        }

        private void AddScore(int pingsKnockedDown)
        {
            totalScore += pingsKnockedDown;
            frameScore += pingsKnockedDown;
        }

        private void HandleBonus(int pingsKnockedDown)
        {
            if (rollsRemainingBonus > 0)
            {
                totalScore += pingsKnockedDown;
                rollsRemainingBonus--;
            }
        }

        private void ResetFrame()
        {
            rollsRemaining = 2;
            Frames++;
            frameScore = 0;
        }

        public int GetScore() => totalScore;
    }
}
