using System;
using System.Collections.Generic;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            ListImplementation list = new ListImplementation() { 1, 3, 5, 7 };

            list.Add(9);
            //Console.WriteLine(list[4]); // works

            // Console.WriteLine(list.Contains(9)); //works

            //int[] masivche = new int[10];
            //list.CopyTo(masivche, 3);
            //for(int i=0; i<10; i++)
            //{
            //    Console.WriteLine(masivche[i]);
            //} works

            //Console.WriteLine(list.IndexOf(3)); works

            //list.Insert(1, 2);
            //Console.WriteLine(list[1]); //works

            //list.Insert(1, 2);
            //list.Remove(2);
            //Console.WriteLine(list.Contains(2)); works 

            //list.Insert(1, 2);
            //list.RemoveAt(1);
            //Console.WriteLine(list.Contains(2)); works

            foreach (int x in list)
                Console.WriteLine(x);

            list.Clear();
            //Console.WriteLine(list[0]); // works

            Console.ReadLine();
        }
    }
}
