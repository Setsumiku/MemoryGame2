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
            int pairsLeft;
            int guessesLeft;
            List<Field> fields = new List<Field>();
            DateTime date1;
            DateTime date2;
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
            {//setup for easy
                pairsLeft = 4;
                guessesLeft = 8;
                wordArray = Game.Generate(4, puzzleWords);
                wordList.AddRange(wordArray);
                wordList.AddRange(wordArray);
                wordArray = wordList.OrderBy(a => Guid.NewGuid()).ToArray();
            }
            else
            {//setup for hard
                pairsLeft = 8;
                guessesLeft = 15;
                wordArray = Game.Generate(8, puzzleWords);
                wordList.AddRange(wordArray);
                wordList.AddRange(wordArray);
                wordArray = wordList.OrderBy(a => Guid.NewGuid()).ToArray();
            }
            for (int i = 0; i < wordArray.Length / 2; i++)//filling the A row on the list with fields/words
            {
                fields.Add(new Field('a', i, wordArray[i]));
            }
            for (int i = wordArray.Length / 2; i < wordArray.Length; i++)//filling the B row on the list with fields/words
            {
                fields.Add(new Field('b', i, wordArray[i]));
            }
            date1= DateTime.Now;
            Play playObject = new Play(pairsLeft, guessesLeft);
            while (true)
            {
                Play.PlayRound(fields, wordArray.Length / 2, playObject);//going to main game logic
                if (playObject.GuessesLeft == 0)
                {
                    date2 = DateTime.Now;
                    Console.Clear();
                    Console.WriteLine("You lose");
                    System.TimeSpan diff1 = date2.Subtract(date1);
                    Console.WriteLine("You spent "+diff1.Seconds+" seconds on the game ");
                    break;
                }
                if (playObject.PairsLeft == 0)
                {
                    date2 = DateTime.Now;
                    Console.Clear();
                    Console.WriteLine("You win!");
                    System.TimeSpan diff1 = date2.Subtract(date1);
                    Console.WriteLine("You had "+playObject.GuessesLeft+" chances left and you spent " + diff1.Seconds + " seconds on the game");
                    Console.WriteLine("Please write your name");
                    string name=Console.ReadLine().ToString();
                    System.IO.File.WriteAllText("scores.txt", name+"|"+DateTime.Now.ToString()+"|"+ diff1.Seconds.ToString()+"|"+ playObject.GuessesLeft.ToString());
                    break;
                }
            }
            Console.WriteLine("Do you want to play again? Y/N");
            do
            {
                userInput = Console.ReadKey(true);
                if (userInput.Key != ConsoleKey.Y && userInput.Key != ConsoleKey.N) Console.WriteLine("Please press Y if you want to play again or N if you don't");
            } while (userInput.Key != ConsoleKey.Y && userInput.Key != ConsoleKey.N);
            if (userInput.Key == ConsoleKey.Y)
            {
                Console.Clear();
                Init.Start();
            }else System.Environment.Exit(0);
        }
    }
}