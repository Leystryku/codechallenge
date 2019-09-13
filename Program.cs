using System;

namespace codechallenge
{
    class Program
    {
        static void Main(string[] args)
        {   
            ItemHandler handler = ItemHandler.GetInstance();
 
            Console.WriteLine("Karta - Cart Checkout!");
            Console.WriteLine("Simply input Apple or Banana or Peach and amount! (e.g. Apple 10)\n\n");

            while(true)
            {


                string curline = Console.ReadLine();

                if(curline.Length == 0)
                    continue;
                
                if(curline == "debug")
                {
                    handler.PrintItems();
                    continue;
                }

                string[] words = curline.Split(' ');

                if(words.Length <2)
                {
                    Console.WriteLine("Wrong Syntax - ItemName Amount e.g. Apple 10");
                    continue;
                }
                
                string itemname = words[0];
                string samount = words[1];    

                int amount;

                if(!int.TryParse(samount, out amount))
                {
                    Console.WriteLine("Parsing the amount failed!");
                    continue;
                }

                if(0>amount)
                {
                    Console.WriteLine("No negative amounts!");
                    continue;
                }

                Item item = handler.FindItemByName(itemname);

                if(item == null)
                {
                    Console.WriteLine(itemname + " is not a valid item!");
                    continue;
                }

                String servicereply = handler.BuyItem(item, amount);

                Console.WriteLine(servicereply);
            }

        }
    }
}
