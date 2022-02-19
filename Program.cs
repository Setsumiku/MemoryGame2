// See https://aka.ms/new-console-template for more information
using System;

namespace MemoryGame
{

    class MemoryGame
    {
        static void Main(string[] args)
        {
            string[] puzzleWords = File.ReadAllLines("Words.txt");
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
                Game Play = new Game(4,puzzleWords);
            }
            else
            {
                Game Play = new Game(8,puzzleWords);
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

        public Field(char row,int column,string valueF)
        {
            this.rowLetter = row;
            this.columnNumber = column;
            this.fieldValue = valueF;
            this.isSet = false;
            fieldNumber++;
        }
        public bool IsSet
        {
            get
            {
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
        
    }

    class Game
    {
        public Game(int difficulty, string[]words)
        {

        }
    }
    class GameWordPrepper
    {
        public GameWordPrepper(string[] wordArray)
        {

        }
    }
}