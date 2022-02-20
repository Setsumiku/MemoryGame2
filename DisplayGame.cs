// See https://aka.ms/new-console-template for more information

namespace MemoryGameObj
{
    class DisplayGame
    {
        public static void Display(List<Field> fields, int length, Play playObject)
        {
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.Write("\vA:");
            for (int i = 0; i < length; i++)//length=8 here if hard mode
            {
                if (fields[i].IsSet == true)
                {
                    Console.Write("\t" + fields[i].FieldValue);
                }
                else
                {
                    Console.Write("\tX");
                }
            }
            Console.Write("\n\vB:");
            for (int i = length; i < length * 2; i++)
            {
                if (fields[i].IsSet == true)
                {
                    Console.Write("\t" + fields[i].FieldValue);
                }
                else
                {
                    Console.Write("\tX");
                }
            }
            Console.WriteLine();
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("\tGuesses Left:"+playObject.GuessesLeft+"\tPairs Left: "+playObject.PairsLeft);
        }
    }

}