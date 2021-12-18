using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A22_EX02_LiadHazoot_314951013_DvirYomTov_209399872
{
    public class Guess
    {
        private static char[] s_guessRangeArray = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        private string m_Guess;
        public Guess()
        {
        }

        private void guessValidation(string i_Guess)
        {
            foreach(char letter in i_Guess)
            {
                if (!Char.IsLetter(letter))
                {
                    throw new TypeException("guess wrong type");
                }
                if(!s_guessRangeArray.Contains(letter))
                {
                    throw new RangeException("guess out of array range 'A' - 'H'");
                }
            }
        }

        public string userGuess { 
            get
            {
                return m_Guess;
            } 
            set
            {
                try
                {
                    guessValidation(value);
                    m_Guess = value;
                }
                catch (TypeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (RangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
        }

    }
}
