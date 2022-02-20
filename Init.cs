// See https://aka.ms/new-console-template for more information

namespace MemoryGameObj
{
    class Init
    {
        public static void Start()
        {
            Random rnd = new Random();
            string[] puzzleWords = File.ReadAllLines("Words.txt");
            string[] wordArray;
            List<string> wordList = new List<String>();
            bool playedYetChecker = false;
            int pairsLeft;
            int guessesLeft;
            List<Field> fields = new List<Field>();
            ConsoleKeyInfo userInput;
            Console.WriteLine("Hello, welcome to the memory game.");
            Console.WriteLine("Please choose your difficulty, input E for easy, H for hard\n");

            do
            {
                userInput = Console.ReadKey(true);
                if (userInput.Key != ConsoleKey.E && userInput.Key != ConsoleKey.H) Console.WriteLine("Please press E for easy or H for hard difficulty:");
            } while (userInput.Key != ConsoleKey.E && userInput.Key != ConsoleKey.H);
            Console.WriteLine("\nLet's start the game at " + userInput.Key.ToString() + " mode");
            if (userInput.Key == ConsoleKey.E)
            {
                pairsLeft = 4;
                guessesLeft = 8;
                wordArray = Game.Generate(4, puzzleWords);
                wordList.AddRange(wordArray);
                wordList.AddRange(wordArray);
                wordArray = wordList.OrderBy(a => Guid.NewGuid()).ToArray();
                for (int i = 0; i < wordArray.Length; i++)
                {
                    Console.WriteLine(wordArray[i]);
                }
                //wordList.OrderBy(x => rnd.Next());
                //wordArrayC = wordArrayA + wordArrayB;
            }
            else
            {
                pairsLeft = 8;
                guessesLeft = 15;
                wordArray = Game.Generate(8, puzzleWords);
                wordList.AddRange(wordArray);
                wordList.AddRange(wordArray);
                wordArray = wordList.OrderBy(a => Guid.NewGuid()).ToArray();
                for (int i = 0; i < wordArray.Length; i++)
                {
                    Console.WriteLine(wordArray[i]);
                }
            }
            for (int i = 0; i < wordArray.Length / 2; i++)//filling the list with fields/words
            {
                fields.Add(new Field('a', i, wordArray[i]));
            }
            for (int i = wordArray.Length / 2; i < wordArray.Length; i++)//filling the list with fields/words
            {
                fields.Add(new Field('b', i, wordArray[i]));
            }
            Play playObject = new Play(pairsLeft, guessesLeft);
            while (true)//change this later lol
            {
                Play.PlayRound(fields, wordArray.Length / 2, playedYetChecker, playObject);
                playedYetChecker = true;
            }
        }
    }

}