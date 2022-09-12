﻿using System;
using System.Collections.Generic;

namespace Deliverable_Two
{
    class Program
    {
        public static float buffetCostPer = 9.99f;
        public static float coffeeCostPer = 2.00f;
        public static float waterCostPer = 0f;
        public static float total;
        public static int partySize;

        public static int maxPartyAmount = 6;

        public static List<int> waters = new List<int>();
        public static List<int> coffees = new List<int>();

        static void Main(string[] args)
        {
            Console.WriteLine("Hi. Welcome to our buffet. All you can eat for $9.99! We only charge extra for coffee. How many people in your group? Please, parties of 6 or fewer.\n");

            partySize = int.Parse(Console.ReadLine());

            if (partySize <= maxPartyAmount)
            {
                FollowToTable();
            }

            else
            {
                Console.WriteLine("I'm sorry. We can not serve more than {0}.", maxPartyAmount.ToString());//end of program
            }
        }

        public static void FollowToTable()
        {
            Console.WriteLine();
            Console.WriteLine("A table for {0}. Please follow me and take a seat.\n", partySize);

            TakeOrder();
            
        }

        public static void TakeOrder()
        {
            for (int i = 0; i < partySize; i++)
            {
                string[] drinks = new string[partySize];
                //Console.WriteLine("Amount of drinks = " + drinks.Length + "\n");//testing feature

                Console.WriteLine("Alright, person number " + (i + 1) + ", water or coffee?");
                drinks[i] = Console.ReadLine().ToUpper();//how to capitalize first letter of string only?

                switch (drinks[i])
                {
                    case "WATER":
                        Console.WriteLine("{0}, good choice!\n", drinks[i]);
                        waters.Add(i);
                        break;

                    case "COFFEE":
                        Console.WriteLine("{0}, good choice!\n", drinks[i]);
                        coffees.Add(i);
                        break;

                    default:
                        Console.WriteLine("We don't have {0}. No drink for you!\n", drinks[i]);
                        break;
                }
            }

            RelayOrder();
        }

        public static void RelayOrder()
        {
            switch (coffees.Count)
            {
                case 1:
                    Console.Write("Okay. So that's {0} coffee ", coffees.Count);
                    break;

                default:
                    Console.Write("Okay. So that's {0} coffees ", coffees.Count);

                    break;
            }

            switch (waters.Count)
            {
                case 1:
                    Console.WriteLine("and {0} glass of water. I'll be right back. Feel free to grab your food!\n", waters.Count);
                    break;

                default:
                    Console.WriteLine("and {0} glasses of water. I'll be right back. Feel free to grab your food!\n", waters.Count);
                    break;
            }

            Bill();
        }

        public static void Bill()
        {
            Console.WriteLine("Here is your bill.");
            Console.WriteLine($"{partySize} buffets = ${partySize * buffetCostPer}");
            float buffetTotal = partySize * buffetCostPer;

            Console.WriteLine($"{coffees.Count} coffees = ${coffees.Count * coffeeCostPer}");
            float CoffeeTotal = coffees.Count * coffeeCostPer;

            switch (waters.Count)
            {
                case 1:
                    Console.WriteLine($"{waters.Count} water = free");
                    break;

                default:
                    Console.WriteLine($"{waters.Count} waters = free");
                    break;
            }

            total = buffetTotal + CoffeeTotal;

            Console.WriteLine($"Your total is {total}\n");

            Console.WriteLine("Have a great rest of your day!");
        }
    }
}

/*
The program will ask the user for a party size, ask for each party member’s drink order, keep track of how many times each drink was ordered, and at the end, present a bill with the accurate total price.

This is an all-you-can-eat buffet, so the price for each person is the same. (Set the buffet price to $9.99 per person.) The guests only pay extra for drinks... and this buffet only has two drinks! You can choose the two drinks and their prices. (For example, water is free, and coffee is $2.00).

You'll want to set up some variables to use throughout your program, such as number variables that keep track of how many of each drink is ordered, and how much the drinks cost. (Hint: what number data type could be used to represent money? It's not an integer...) Limit the party size to six people. If the user inputs a party size that is too large, simply provide them with a polite rejection message and end the program.

Otherwise, print out the drink options for the user. Now, set up a loop that asks each person for which drink they'd like. Keep track of how many of each drink is ordered because you'll need this number to calculate the bill.

After taking the orders, calculate the total and print out that value to the user.
*/