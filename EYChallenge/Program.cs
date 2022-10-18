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

            char[][] jaggedArray = new char[roundedSquareRootInt][];

            int position = 0;

            for (int i = 0; i < roundedSquareRoot; i++)
            {
                jaggedArray[i] = new char[roundedSquareRootInt];
                for(int j = 0; j < roundedSquareRoot; j++)
                {
                    if (position > textLength - 1)
                    {
                        break;
                    }
                    jaggedArray[i][j] = stringWithoutSpaces[position];
                    position++;
                }
            }

            for(int i = 0; i < jaggedArray.Length; i++)
            {
                for(int j = 0; j < jaggedArray.Length; j++)
                {
                    Console.Write(jaggedArray[j][i]);                
                }
                Console.Write(" ");
            }
        }

        public static string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
