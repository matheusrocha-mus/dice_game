﻿using System;
using System.Threading;
using System.Threading.Tasks;

public class Dice_Game
{
    public static void Scoreboard(int pts1, int pts2, string name1, string name2)  
    {  
        Console.WriteLine("Scoreboard: [" + name1 + " " + pts1 + " | " + pts2 + " " + name2 + "]\n");
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Player 1, please input your name:");
        string name1 = Console.ReadLine();
        Console.WriteLine("Player 2, please input your name:");
        string name2 = Console.ReadLine();
        Console.Clear();
        if (name1 == name2)
        {
            Console.WriteLine("Both players input the same name. Player 1, please input your FULL name:");
            name1 = Console.ReadLine();
            Console.WriteLine("Player 2, please also input your FULL name:");
            name2 = Console.ReadLine();
            Console.Clear();
            if (name1 == name2)
            {
                Console.WriteLine("Congratulations, you are either playing dumb or both of you have exactly the same name! The odds of that are borderline impossible! In this case, Player2, please create a username instead of your name:");
                name2 = Console.ReadLine();
                Console.Clear();
            }
        }
        int pts1 = 0;
        int pts2 = 0;
        var input = "0";
        Random dice = new Random();
        string type_roll = "roll";
        string type_1 = "1";
        string type_exit = "exit";
        string type_2 = "2";
        bool confirm_roll = true;
        bool confirm_1 = true;
        bool confirm_exit = true;
        bool confirm_2 = true;
        int[] rolls1 = new int[3];
        int[] rolls2 = new int[3];
        bool valid_entry = true;
        bool valid_round = true;

        do
        {
            Console.WriteLine("Round 1\n");
            Scoreboard(pts1, pts2, name1, name2);
            Console.WriteLine(name1 + ", roll the dice!");

            do
            {
                Console.WriteLine("1) Type 'roll' \n2) Type 'exit' to exit game");
                input = Convert.ToString(Console.ReadLine());
                confirm_roll = input.Equals(type_roll, StringComparison.OrdinalIgnoreCase);
                confirm_1 = input.Equals(type_1, StringComparison.OrdinalIgnoreCase);
                confirm_exit = input.Equals(type_exit, StringComparison.OrdinalIgnoreCase);
                confirm_2 = input.Equals(type_2, StringComparison.OrdinalIgnoreCase);
                if (confirm_roll || confirm_1)
                {
                    valid_entry = true;
                    rolls1[0] = dice.Next(6, 7);
                    Console.WriteLine(name1 + " got a " + rolls1[0] + "!\n");
                }
                else if (confirm_exit || confirm_2)
                {
                    valid_entry = true;
                    Console.WriteLine("Thank you for playing!");
                    Timer t = new Timer(timerC, null, 2000, 2000);
                    void timerC(object state)
                    {
                        Environment.Exit(0);
                    }
                }
                else
                {
                    valid_entry = false;
                }
            } while (valid_entry == false);

            Console.WriteLine(name2 + ", roll the dice!");

            do
            {
                Console.WriteLine("1) Type 'roll' \n2) Type 'exit' to exit game");
                input = Convert.ToString(Console.ReadLine());
                confirm_roll = input.Equals(type_roll, StringComparison.OrdinalIgnoreCase);
                confirm_1 = input.Equals(type_1, StringComparison.OrdinalIgnoreCase);
                confirm_exit = input.Equals(type_exit, StringComparison.OrdinalIgnoreCase);
                confirm_2 = input.Equals(type_2, StringComparison.OrdinalIgnoreCase);
                if (confirm_roll || confirm_1)
                {
                    valid_entry = true;
                    rolls2[0] = dice.Next(6, 7);
                    Console.WriteLine(name2 + " got a " + rolls2[0] + "!\n");
                }
                else if (confirm_exit || confirm_2)
                {
                    valid_entry = true;
                    Console.WriteLine("Thank you for playing!");
                    Timer t = new Timer(timerC, null, 2000, 2000);
                    void timerC(object state)
                    {
                        Environment.Exit(0);
                    }
                }
                else
                {
                    valid_entry = false;
                }
            } while (valid_entry == false);

            if (rolls1[0] > rolls2[0])
            {
                valid_round = true;
                Console.WriteLine(name1 + " won this round!");
            }

            if (rolls2[0] > rolls1[0])
            {
                valid_round = true;
                Console.WriteLine(name2 + " won this round!");
            }

            if (rolls1[0] == rolls2[0])
            {
                valid_round = false;
                Console.WriteLine("Draw! Roll again...");
                Timer t = new Timer(timerC, null, 3000, 3000);
                void timerC(object state)
                {
                    Console.Clear();
                }
            }

        } while (valid_round == false);
        
        Console.Clear();

        Console.ReadKey();
    }
}