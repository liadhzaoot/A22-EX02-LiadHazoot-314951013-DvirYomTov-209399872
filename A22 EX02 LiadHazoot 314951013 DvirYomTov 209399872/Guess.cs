using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A22_EX02_LiadHazoot_314951013_DvirYomTov_209399872
{
    public class Guess
    {
        public static char[] s_guessRangeArray = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        private string m_Guess;
        private const int k_NumberOfLettersInGuess = 4;
        public Guess()
        {
        }

        private void guessValidation(string i_Guess)
        {
            List<char> tempGuessRangeArray = new List<char>(s_guessRangeArray);
            if (i_Guess.Length != k_NumberOfLettersInGuess)
            {
                throw new RangeException("guess has to be 4 letters");
            }
            foreach (char letter in i_Guess)
            {
                    if (!tempGuessRangeArray.Contains(letter))
                    {
                        throw new RangeException(String.Format("invalid guess: '{0}'", letter));
                    }
                    tempGuessRangeArray.Remove(letter);
            }
        }
    


        public string userGuess
        {
            get
            {
                return m_Guess;
            }
            set
            {

                guessValidation(value);
                m_Guess = value;
            }



        }

        
    }

}

