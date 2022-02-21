// See https://aka.ms/new-console-template for more information

namespace MemoryGameObj
{
    class Play
    {
        int pairsLeft;
        int guessesLeft;
        bool playedYetChecker;
        public Play(int pairs, int guesses)
        {
            this.pairsLeft = pairs;
            this.guessesLeft = guesses;
            this.playedYetChecker = false;
        }
        public int PairsLeft
        {
            get 
            { 
                return pairsLeft; 
            }
            set 
            { 
                pairsLeft = value; 
            }
        }
        public int GuessesLeft
        {
            get 
            { 
                return guessesLeft; 
            }
            set 
            { 
                guessesLeft = value; 
            }
        }
        public bool PlayedYetChecker
        {
            get 
            { 
                return playedYetChecker; 
            }
            set 
            { 
                playedYetChecker = value; 
            }
        }
        public static void PlayRound(List<Field> fields, int length, Play playObject)
        {
            if (playObject.playedYetChecker == false)//going here if first move in game or a pair was just flipped (playedYetChecker is badly named)
            {
                char[] input = GetInput.UserInput(length);
                if (input[0] == 'a')
                {
                    if(fields[(int)Char.GetNumericValue(input[1]) - 1].IsDone == false)
                    {
                        fields[(int)Char.GetNumericValue(input[1]) - 1].IsSet = true;
                        playObject.playedYetChecker = true;
                        DisplayGame.Display(fields, length, playObject);
                    }
                    else
                    {
                        DisplayGame.Display(fields, length, playObject);
                        Console.WriteLine("Cannot flip an already flipped pair");
                    }
                }
                else
                {
                    if(fields[(int)Char.GetNumericValue(input[1]) + length - 1].IsDone == false)
                    {
                        fields[(int)Char.GetNumericValue(input[1]) + length - 1].IsSet = true;
                        playObject.playedYetChecker = true;
                        DisplayGame.Display(fields, length, playObject);
                    }
                    else
                    {
                        DisplayGame.Display(fields, length, playObject);
                        Console.WriteLine("Cannot flip an already flipped pair");
                    }
                }
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
                        playObject.playedYetChecker=false;
                    }
                    else
                    {
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
                        playObject.playedYetChecker = false;
                        playObject.pairsLeft--;
                    }
                    else
                    {
                        playObject.guessesLeft--;
                    }
                    DisplayGame.Display(fields, length, playObject);
                }
                else
                {
                    DisplayGame.Display(fields, length, playObject);
                    Console.WriteLine("Cannot flip an already flipped pair");
                }
            }
        }
    }

}