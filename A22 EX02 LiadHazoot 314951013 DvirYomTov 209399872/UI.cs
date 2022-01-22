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

        public UI()
        {

        }

        public void DrawBoard(ref List<Guess> i_userGuessesList, ref List<string> i_resultsList)
        {
            this.ClearBoard();
            this.drawHeader();
            this.drawGuessesAndResults(ref i_userGuessesList, ref i_resultsList);

        }

        public void ClearBoard()
        {
            Ex02.ConsoleUtils.Screen.Clear();
        }

        private void drawGuessesAndResults(ref List<Guess> i_userGuessesList, ref List<string> i_resultsList)
        {
            for (int i = 0; i < this.m_BoardSize; i++)
            {
                if (i < i_userGuessesList.Count)
                {
                    string line = string.Format("|{0}|{1}|", fixStringLength(i_userGuessesList[i].userGuess)
                        , fixStringLength(i_resultsList[i]));
                    Console.WriteLine(line);
                }

                else
                {
                    Console.WriteLine("|         |         |");
                }

                Console.WriteLine("|=========|=========|");
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

        private string fixStringLength(string i_value, int i_length = 9)
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


        public static void PrintMessage(string i_Message)
        {
            Console.WriteLine(i_Message);
        }


        //public string GetBoardSizeFromUser() 
        //{
        //    PrintMessage("Enter number of guesses between 4-10");
        //    string boardSizeStr = Console.ReadLine();
        //    return boardSizeStr;
        //}

        public void SetBoardSize(int i_BoadSize)
        {
            m_BoardSize = i_BoadSize;
        }

        public string GetUserInput(string i_Massage = "")
        {
            if (i_Massage != "")
            {
                PrintMessage(i_Massage);
            }
            string userInput = Console.ReadLine();
            return userInput;
        }


    }
}
