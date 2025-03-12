using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace StringTutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string to encrypt:");
            string plaintext = Console.ReadLine();

            try
            {
                Console.WriteLine($"The encrypted message is {EncryptString(plaintext)}");
            }
            catch (ArgumentNullException ex)
            {
                  Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        static string EncryptString(string inputString)
        {   
            // Guard clause to check if input is a valid string
            if (string.IsNullOrWhiteSpace(inputString))
            {
                throw new ArgumentNullException(nameof(inputString));
            }

            // Reverse the string
            inputString = inputString.Trim();

            char[] array = inputString.ToCharArray();
            Array.Reverse(array);

            // Convert every second charatcer to uppercase
            for (int i = 0; i<inputString.Length; i++)
            {
                if(i%2 == 0)
                {
                    array[i] = Char.ToUpper(array[i]);
                }
            }

            // Interpolateion and concatenation
            inputString = new string(array);
            inputString = "Secret-" + inputString + "-Code";

            // String conversion using ASCII values to shift each character by 1
            array = inputString.ToCharArray();
            var newArray = array.Select(x => (char)((int)(x + 1)));
            array = newArray.ToArray();

            string finalEncryption = new string(array);
            return finalEncryption;
        }
    }
}
