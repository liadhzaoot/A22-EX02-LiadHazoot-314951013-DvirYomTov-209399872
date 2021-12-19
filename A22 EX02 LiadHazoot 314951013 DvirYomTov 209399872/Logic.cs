using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A22_EX02_LiadHazoot_314951013_DvirYomTov_209399872
{
    public class Logic
    {
        //private List<Guess> m_guessesList;
        private string m_comChoose = "";
        private char[] m_comRangeGuess;
        //private Guess m_userGuess;
        private const int k_NumberOfLettersInComGuess = 4;
        public Logic()
        {
            //m_userGuess = i_userGuess;

            //comChooseRandomly();
            //bingoHit(m_userGuess);
        }
        public string ComChooseRandomly()
        {
            Random rd = new Random();
            int randIndex;
            char temp;
            int lastIndex;
            m_comRangeGuess = Guess.s_guessRangeArray;
            lastIndex = m_comRangeGuess.Length - 1;
            for (int i = 0; i < k_NumberOfLettersInComGuess; i++)
            {
                randIndex = rd.Next(0, lastIndex + 1);
                m_comChoose += m_comRangeGuess[randIndex];

                // replace with last letter for not choose again
                temp = m_comRangeGuess[lastIndex];
                m_comRangeGuess[lastIndex] = m_comRangeGuess[randIndex];
                m_comRangeGuess[randIndex] = temp;
                lastIndex--;
                
            }
            return m_comChoose;
        }
        public string BingoHit(Guess i_userGuess)
        {
            string points = "";
            for(int i = 0; i < k_NumberOfLettersInComGuess; i++)
            {
                for(int k = 0; k < k_NumberOfLettersInComGuess; k++)
                {
                    if (i_userGuess.userGuess[i] == m_comChoose[k] && i == k)
                    {
                        points = 'V' + points; // BINGO
                    }
                    else if(i_userGuess.userGuess[i] == m_comChoose[k] && i != k)
                    {
                        points += 'X'; // HIT
                    }
                }
            }
            return points;
        }
        public bool IsWin(string i_points)
        {
            bool isWin = true;
            foreach(char letter in i_points)
            {
                if (letter != 'V')
                {
                    isWin = false;
                }
            }
            return isWin;
        }
        public string GetComChoose()
        {
            return m_comChoose;
        }

        public void SetComChoose(string comChoose)
        {
            m_comChoose = comChoose;
        }
    }
}
