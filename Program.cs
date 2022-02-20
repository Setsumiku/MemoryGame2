// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace MemoryGameObj
{

    class MemoryGame
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string[] puzzleWords = File.ReadAllLines("Words.txt");
            string[] wordArray;
            List<string> wordList=new List<String>();
            bool playedYetChecker = false;
            int pairsLeft;
            int guessesLeft;
            List<Field> fields = new List<Field>();
            Console.WriteLine("Hello, welcome to the memory game.");
            Console.WriteLine("Please choose your difficulty, input E for easy, H for hard\n");
            ConsoleKeyInfo userInput;
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
                for(int i = 0; i < wordArray.Length; i++)
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
            for (int i = 0; i < wordArray.Length/2; i++)//filling the list with fields/words
            {
                fields.Add(new Field('a', i, wordArray[i]));
            }
            for (int i = wordArray.Length/2; i < wordArray.Length; i++)//filling the list with fields/words
            {
                fields.Add(new Field('b', i, wordArray[i]));
            }
            Play playObject= new Play(pairsLeft,guessesLeft);
            while (true)//change this later lol
            {
                Play.PlayRound(fields, wordArray.Length/2, playedYetChecker, playObject);
                playedYetChecker = true;
            }
        }

    }
    

    class Field
    {
        private char rowLetter;
        private int columnNumber;
        private bool isSet;
        private string fieldValue;
        public static int fieldNumber;
        private bool isDone;

        public Field(char row,int column,string valueF)
        {
            this.rowLetter = row;
            this.columnNumber = column;
            this.fieldValue = valueF;
            this.isSet = false;
            this.isDone = false;
            fieldNumber++;
        }
        public bool IsSet
        {
            get
            {
                if (this.isDone == true) this.isSet = true;
                return isSet;
            }
            set
            {
                isSet = value;
            }
        }
        public string FieldValue
        {
            get 
            {
                return fieldValue;
            }
            set
            {
                fieldValue = value;
            }
        }
        public char RowLetter
        {
            get
            {
                return rowLetter;
            }
            set
            {
                rowLetter = value;
            }
        }
        public int ColumnNumber
        {
            get 
            { 
                return columnNumber; 
            }
            set
            {
                columnNumber = value;
            }
        }
        public bool IsDone
        {
            get 
            { 
                return isDone; 
            }
            set 
            { 
                isDone = value; 
            }
        }
        public static bool FieldCompare(List<Field> fields, Field currentCheck)
        {
            foreach (Field fieldListElement in fields)
            {
                if (fieldListElement.fieldValue==currentCheck.fieldValue && fieldListElement.isDone==false && currentCheck.isDone==false && fieldListElement.rowLetter!=currentCheck.rowLetter||fieldListElement.columnNumber!=currentCheck.columnNumber&& fieldListElement.fieldValue == currentCheck.fieldValue && fieldListElement.isDone == false && currentCheck.isDone == false)//thanks debugging for letting me fix the bug... which made me do this monstrosity
                {
                    if (fieldListElement.isSet == true && currentCheck.isSet == true)
                    {
                        fieldListElement.isDone = true;
                        currentCheck.isDone = true;
                        //fieldListElement.isSet = true;
                        //currentCheck.isSet = true;
                        return true;
                    }
                    //else fieldListElement.isSet = false;
                }
               // else
                //{ if i go from b to a flip condition
                    //fieldListElement.isSet = false;
                    //return false;
                    //currentCheck.isSet = true;
                    //if (fieldListElement.isDone == true) fieldListElement.isSet = true;
                    //if (currentCheck.isDone==true) currentCheck.isSet = true;
                //}

                fieldListElement.isSet = false;
                if (fieldListElement.fieldValue == currentCheck.fieldValue && fieldListElement.rowLetter == currentCheck.rowLetter && fieldListElement.columnNumber == currentCheck.columnNumber) fieldListElement.isSet = true;//hacked up solution to wrongly unflipping the word when foreach passes through the currently checked argument, might come back later if there's time
            }
            currentCheck.isSet = true;
            return false;
        }
    }

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
    class Play
    {
        int pairsLeft;
        int guessesLeft;
        //Field previousFieldChoice = new Field('c',-1,"none");
        public Play(int pairs, int guesses)
        {
            this.pairsLeft = pairs;
            this.guessesLeft = guesses;
        }
        public int PairsLeft
        {
            get { return pairsLeft; }
            set { pairsLeft = value; }
        }
        public int GuessesLeft
        {
            get { return guessesLeft; }
            set { guessesLeft = value; }
        }
        public static void PlayRound(List<Field> fields, int length, bool playedYetChecker, Play playObject)
        {
            if (playedYetChecker == false)
            {
                char[] input = GetInput.UserInput(length);
                if (input[0] == 'a')
                {
                    fields[(int)Char.GetNumericValue(input[1]) - 1].IsSet = true;
                }
                else
                {
                    fields[(int)Char.GetNumericValue(input[1]) + length - 1].IsSet = true;
                }
                DisplayGame.Display(fields, length, playObject);
            }
            else
            {
                char[] input = GetInput.UserInput(length);
                if (input[0] == 'a' && fields[(int)Char.GetNumericValue(input[1]) - 1].IsDone==false)
                {
                    fields[(int)Char.GetNumericValue(input[1]) - 1].IsSet = true;
                    if (Field.FieldCompare(fields, fields[(int)Char.GetNumericValue(input[1]) - 1]))
                    {
                        playObject.pairsLeft--;
                    }
                    else
                    {
                        //fields[(int)Char.GetNumericValue(input[1]) - 1].IsSet = false;
                        playObject.guessesLeft--;
                    }
                    DisplayGame.Display(fields, length, playObject);
                }
                else 
                if(input[0] == 'b' && fields[(int)Char.GetNumericValue(input[1]) +length- 1].IsDone==false)
                {
                    fields[(int)Char.GetNumericValue(input[1]) +length- 1].IsSet = true;
                    if (Field.FieldCompare(fields, fields[(int)Char.GetNumericValue(input[1]) +length- 1]))
                    {
                        playObject.pairsLeft--;
                    }
                    else
                    {
                        //fields[(int)Char.GetNumericValue(input[1]) +length- 1].IsSet = false;
                        playObject.guessesLeft--;
                    }
                    DisplayGame.Display(fields, length, playObject);
                }//if you hit flip right away
                else
                {
                    DisplayGame.Display(fields, length, playObject);
                    Console.WriteLine("Cannot flip an already finished pair");
                }
            }
            //DisplayGame.Display(fields, length, playObject);
        }
        private static bool CheckIfPlayed()
        {
            return true;
        }
    }
    class GetInput
    {
        public static char[] UserInput(int size)
        {
            char[] input;
            do
            {
                Console.WriteLine("Please Input your chosen row and column eg. 'A1'");
                input = Console.ReadLine().ToLower().ToCharArray();
                if (TestInput.TestUserInput(input, size))
                {
                    return input;
                }
                Console.WriteLine("Incorrect Input");
            }while(true);
        }
    }
    class TestInput
    {
        public static bool TestUserInput(char[] input, int size)
        {
            if (input.Length != 2)
            {
                return false;
            }
            if ((input[0] == 'a') || (input[0] == 'b'))
            {
                if ((int)Char.GetNumericValue(input[1]) <= size && (int)Char.GetNumericValue(input[1]) > 0) return true;
            }
            return false;
        }
    }
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