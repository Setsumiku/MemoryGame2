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
            HashSet<string> wordsHash = new HashSet<string>();
            while (wordsHash.Count < difficulty)
            {
                wordsHash.Add(wordArray[random.Next(0,wordArray.Length)]);
            }
            string[] words = wordsHash.ToArray();
            return words;
        }
    }

}