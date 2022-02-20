// See https://aka.ms/new-console-template for more information

namespace MemoryGameObj
{
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

}