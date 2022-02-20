// See https://aka.ms/new-console-template for more information

namespace MemoryGameObj
{
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

}