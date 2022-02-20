// See https://aka.ms/new-console-template for more information

namespace MemoryGameObj
{
    class Play
    {
        int pairsLeft;
        int guessesLeft;
        public Play(int pairs, int guesses)
        {
            this.pairsLeft = pairs;
            this.guessesLeft = guesses;
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
                }
                else
                {
                    DisplayGame.Display(fields, length, playObject);
                    Console.WriteLine("Cannot flip an already flipped pair");
                }
            }
            //DisplayGame.Display(fields, length, playObject);
        }
    }

}