﻿using System;
using System.Collections.Generic;
using System.IO;

namespace HH.BL
{
    public class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("а", "q");
            dictionary.Add("б", "w");
            dictionary.Add("в", "e");
            dictionary.Add("г", "r");
            dictionary.Add("д", "t");
            dictionary.Add("е", "y");
            dictionary.Add("ё", "u");
            dictionary.Add("ж", "i");
            dictionary.Add("з", "o");
            dictionary.Add("и", "p");
            dictionary.Add("й", "a");
            dictionary.Add("к", "s");
            dictionary.Add("л", "d");
            dictionary.Add("м", "f");
            dictionary.Add("н", "g");
            dictionary.Add("о", "h");
            dictionary.Add("п", "j");
            dictionary.Add("р", "k");
            dictionary.Add("с", "l");
            dictionary.Add("т", "z");
            dictionary.Add("у", "x");
            dictionary.Add("ф", "c");
            dictionary.Add("х", "v");
            dictionary.Add("ч", "b");
            dictionary.Add("ш", "n");
            dictionary.Add("щ", "m");
            dictionary.Add("ю", "<");
            dictionary.Add("я", ">");
            dictionary.Add("ц", "?");
            dictionary.Add("ъ", ".");
            dictionary.Add("ы", "_");
            dictionary.Add("ь", "=");
            dictionary.Add("э", ",");
            dictionary.Add("і", ":");
            dictionary.Add("ї", ";");


            //@"E:/Algorithms-and-Data-Structures-/z3.txt"
            Console.Clear();
            Console.WriteLine("Coder example");

            Console.Write("Enter your message: ");
            string input = encode(Console.ReadLine());
            Console.WriteLine("Decoded message: {0}", input);
            int mode = 0;

            List<string> fileData = new List<string>();

            while (mode == 0 || mode > 3)
            {
                Console.WriteLine("Data Coder Programm \n");
                Console.WriteLine("1. Encode\n");
                Console.WriteLine("2. Decode\n");
                Console.WriteLine("3. Help\n\n");
                Console.WriteLine("Введите цифру для выбора: >>>");
                try
                {
                    mode = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    mode = 0;
                }
            }
            Console.WriteLine("Extra options\n");
            Console.WriteLine("Enter file name:");
            string fileIn = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Enter output file name:");
            string fileOut = Console.ReadLine();
            StreamReader reader = new StreamReader(fileIn);
            StreamWriter writer = new StreamWriter(fileOut);

            string line;
            switch (mode)
            {
                case 1:
                    mode = 0;
                    while (mode == 0 || mode > 2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Choose encoding method\n");
                        Console.WriteLine("1.Permutation\n");
                        Console.WriteLine("2.Change\n");
                        Console.Write(">>>");
                        try
                        {
                            mode = int.Parse(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            mode = 0;
                        }
                    }
                    while ((line = reader.ReadLine()) != null)
                    {
                        fileData.Add(line);
                    }
                    reader.Close();
                    switch (mode)
                    {
                        case 1:
                            foreach (string li in fileData)
                            {
                                writer.WriteLine(decode(li));
                            }
                            writer.Close();
                            break;
                        case 2:
                            foreach (string li in fileData)
                            {
                                char[] charsli = li.ToCharArray();
                                for (int i = 0; i < charsli.Length; i++)
                                {
                                    charsli(i) = (char)(charsli[i] - 40);
                                }
                                writer.WriteLine(new string(charsli));
                            }
                            writer.Close();
                            break;
                    }
                    break;
            }
    
        }
        static string decode(string input)
        {
            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (dictionary.ContainsValue(chars[i]))
                {
                    foreach (KeyValuePair<char, char> pair in dictionary)
                    {
                        if (pair.Value.Equals(chars[i]))
                        {
                            chars[i] = pair.Key;
                            break;
                        }
                    }
                }
                return new string(chars);
            }
        }
        static string encode(string input)
        {
            char[] chars = input.ToCharArray();
            for (int i = 0; i <= chars.Length - 1; i++)
            {
                if (dictionary.ContainsKey(chars[i]))
                {
                    chars[i] = dictionary[chars[i]];
                }
            }
            return new string(chars);
        }
        
    }
}
