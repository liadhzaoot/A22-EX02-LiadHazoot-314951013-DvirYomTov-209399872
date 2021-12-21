using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;

namespace A22_EX02_LiadHazoot_314951013_DvirYomTov_209399872
{
    public class UI
    {
        private int m_BoardSize;
        public UI(int i_BoardSize)
        {
            m_BoardSize = i_BoardSize;
        }

        public void DrawBoard(List<Guess> i_userGuessesList, List<string> i_pointsList)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            this.drawHeader();

            for (int i = 0; i < this.m_BoardSize; i++)
            {
                if (i < i_userGuessesList.Count)
                {
                    string line = string.Format("|{0}|{1}|", fixStringLength(i_userGuessesList[i].userGuess)
                        , fixStringLength(i_pointsList[i]));
                    Console.WriteLine(line);
                    Console.WriteLine("|=========|=========|");
                }

                else
                {
                    Console.WriteLine("|         |         |");
                    Console.WriteLine("|=========|=========|");
                }
            }
            

        }

        private void drawHeader()                //draw the 2 first lines
        {
            Console.WriteLine("Current board status:\n");  
            Console.WriteLine("|Pins:    |Result:  |");
            Console.WriteLine("|=========|=========|");
            Console.WriteLine("| # # # # |         |");
            Console.WriteLine("|=========|=========|");
        }

        private string fixStringLength(string i_value, int i_length=9)
        {
            string o_fixValue = " ";

            foreach (char letter in i_value)
            {
                o_fixValue += letter + " ";
            }

            for (int i = 0; i < i_length - (i_value.Length * 2 + 1); i++) //adding spaces to complete the lenth require
            {
                o_fixValue += " ";
            }

            return o_fixValue;
        }

        //private string fixResultLength(string i_reusult, int i_length=7)
        //{
        //    string o_fixValue = "";

        //    for (int i = 0; i <i_reusult.Length - 1; i++) //adding space after each letter except the last one
        //    {
        //        o_fixValue += i_reusult[i] + " ";
        //    }

        //    for(int i=0; i<i_length - i_reusult.Length*2; i++) //adding spaces to complete the lenth require
        //    {
        //        o_fixValue += " ";
        //    }

        //    return o_fixValue;
        //}


        

    }


}
