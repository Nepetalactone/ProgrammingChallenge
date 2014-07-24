using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04EncryptDecrypt
{
    class Program
    {

        static void Main(string[] args)
        {
            String text = "This cipher is completely insecure, never ever use it seriously";
            String password = "I'm serious";
            String cipherText = crypt(text, password);
            Console.WriteLine("Encrypted Text: " + cipherText);
            Console.WriteLine("Decrypted Text: " + crypt(cipherText, password));
            Console.ReadKey();
        }

        private static String crypt(String text, String password)
        {
            StringBuilder cipherText = new StringBuilder();
            int i = 0;
            foreach (char c in text)
            {
                if (i >= password.Length)
                {
                    i = 0;
                }
                cipherText.Append(Char.ConvertFromUtf32(c ^ password[i]));
                i++;
            }

            return cipherText.ToString();
        }
    }
}
