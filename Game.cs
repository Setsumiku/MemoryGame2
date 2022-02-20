// See https://aka.ms/new-console-template for more information

namespace MemoryGameObj
{
    class Game
    {
        private int difficulty;
        private string[] words;
        public Game(int difficulty, string[]words)
        {
            this.difficulty = difficulty;
            this.words = words;
        }
        public static string[] Generate(int difficulty, string[] wordArray)
        {
            Random random = new Random();
            string[] words = new string[difficulty];
            for (int i = 0; i < difficulty; i++)
            {
                words[i] = wordArray[random.Next(wordArray.Length)];
            }
            return words;
        }
        public static string[] Shuffle(string[] wordArray)
        {
            Random random = new Random();
            string[] words = new string[wordArray.Length];
            for (int i = 0; i < wordArray.Length; i++)
            {
                words[i] = wordArray[random.Next(words.Length)];
            }
            return words;
        }
    }

}