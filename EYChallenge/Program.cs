using System;
using System.Linq;

namespace EYChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EncodeText("we the people of the united states in order to form a more perfect union etc");
            Console.WriteLine();
            EncodeText("cheating is not allowed");
            Console.WriteLine();
            EncodeText("the rocks");
        }

        private static void EncodeText(string s)
        {
            var stringWithoutSpaces = RemoveWhitespace(s);
            var textLength = stringWithoutSpaces.Length;
            var squareRoot = Math.Sqrt(textLength);
            var roundedSquareRoot = Math.Ceiling(squareRoot);
            var roundedSquareRootInt = Convert.ToInt32(roundedSquareRoot);

            var letterTable = CreateLetterTable(roundedSquareRootInt, textLength, stringWithoutSpaces);

            for(int i = 0; i < letterTable.Length; i++)
            {
                for(int j = 0; j < letterTable.Length; j++)
                {
                    Console.Write(letterTable[j][i]);                
                }
                Console.Write(" ");
            }
        }

        private static char[][] CreateLetterTable(int roundedSquareRootInt, int textLength, string stringWithoutSpaces)
        {
            char[][] letterTable = new char[roundedSquareRootInt][];

            int position = 0;

            for (int i = 0; i < roundedSquareRootInt; i++)
            {
                letterTable[i] = new char[roundedSquareRootInt];
                for (int j = 0; j < roundedSquareRootInt; j++)
                {
                    if (position > textLength - 1)
                    {
                        break;
                    }
                    letterTable[i][j] = stringWithoutSpaces[position];
                    position++;
                }
            }
            return letterTable;
        }

        public static string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
