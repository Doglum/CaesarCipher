using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            //asks user what mode they want
            Console.WriteLine("Encode or Decode? (e/d)");
            string modeChoice = Console.ReadLine().ToLower();
            Console.WriteLine("Input plaintext:");
            string a = Console.ReadLine();
            //ensures the user inputs a number as a key
            while (true)
            {
                try
                {
                    Console.WriteLine("Input key:");
                    int b = Convert.ToInt16(Console.ReadLine());
                    if (modeChoice== "d")
                        Console.WriteLine(Decode(a, b));
                    else
                        Console.WriteLine(Encode(a, b));
                    break;
                }
                catch
                {
                    Console.WriteLine("Enter valid key");
                }
            }
            Console.ReadLine();
        }

        
        static string Encode(string plaintext, int key)
        {
            string encodedText = "";
            //loops through each character
            foreach (char letter in plaintext)
            {
                int a = (int)letter; //converts letter into unicode value
                int a2 = a + (key % 26); //shifts it

                //if the shift takes it beyond a value in the alphabet, wrap back to begining
                if (a<=122 && a>=97)  //capital letter check
                {
                    if (a2 > 122)
                        a2 -= 26;
                    encodedText += ((char)a2); //converts back to character and adds to message
                }
                else if (a>=65 && a<=90) //lowercase letter check
                {
                    if(a2>90)
                        a2 -= 26;
                    encodedText += ((char)a2);
                }
                else //if not in the alphabet, ignore it
                    encodedText += letter;
            }
            return encodedText;
        }

        //inverse of above function
        static string Decode(string plaintext, int key)
        {
            string decodedText = "";
            foreach (char letter in plaintext)
            {
                int a = (int)letter;
                int a2 = a - (key % 26);

                if (a <= 122 && a >= 97)
                {
                    if (a2 < 97)
                        a2 += 26;
                    decodedText += ((char)a2);
                }
                else if (a >= 65 && a <= 90)
                {
                    if (a2 < 65)
                        a2 += 26;
                    decodedText += ((char)a2);
                }
                else
                    decodedText += letter;
            }
            return decodedText;
        }
    }
}
