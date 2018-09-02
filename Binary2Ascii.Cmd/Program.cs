using System;

namespace Binary2Ascii.Cmd
{
    class Program
    {
        public const string HELP_MESSAGE = "Binary2Ascii\n\nUsage:\n\tBinary2Ascii [binaryblob]\n\tBinary2Ascii -s [string]";

        private const string ARG_FROM_STRING = "-s";

        static void PressAnyKey()
        {
            Console.WriteLine("\n\nPress Any Key To Continue...\n");
            Console.Read();
        }
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine(HELP_MESSAGE);
                PressAnyKey();
                return;
            }

            if (args[0] == ARG_FROM_STRING)
            {
                if (args.Length < 2 || args[1] == null)
                {
                    Console.WriteLine(HELP_MESSAGE);
                    return;
                }

                string str = args[1];
                
                TextBlob textBlob = TextBlob.FromString(str, ",");
                Console.WriteLine("ASCII Output\n{0}\n", textBlob.ToBinaryBlob());
            }
            else
            {
                string blob = args[0];

                TextBlob textBlob = new TextBlob(blob);
                Console.WriteLine("ASCII to String (7bit):\n{0}\n\nExtended ASCII to String (8bit):\n{1}\n\n", textBlob.Ascii7Value, textBlob.Ascii8Value);
            }
            PressAnyKey();
        }
    }
}
