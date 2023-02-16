using System;
using System.Collections.Generic;

namespace PUPPoints
{
    internal class Program
    {
        static double pointsBalance;
        static List<string> productsView = new List<string>() { "P01 Wilkins Water (100ml) - 20 points",
                                                            "P02 Coke Zero (25ml) - 30 points",
                                                            "P03 Nova Jack n Jill - 15 points"}; 

        static List<string> servicesView = new List<string>() { "S01 Food Delivery - 40 points",
                                                            "S02 Pasabuy - 40 points",
                                                            "S03 Angkas (up to 5kms) - 30 points"};

        static List<string> productsPoints = new List<string>() { "P01 20", "P02 30", "P03 15"};
        static List<string> servicesPoints = new List<string>() { "S01 40", "S02 40", "S03 30"};

        static void Main(string[] args)
        {
            pointsBalance = 100; //default points

            Console.WriteLine("PUP Points");
            Console.WriteLine("*****************************");

            ShowMainMenu();

            string userInput = GetUserInput();

            while (userInput != "x") //looping statement 
            {
                switch (userInput) //conditional statement
                {
                    case "1":
                        ViewPoints();
                        ShowMainMenu();
                        userInput = GetUserInput();
                        break;
                    case "2":
                        RedeemPoints();
                        ShowMainMenu();
                        userInput = GetUserInput();

                        break;
                    case "3":
                        break;
                    default:
                       break;
                }
            }
        }

        static void ShowMainMenu() //method signature
        {
            Console.WriteLine("_________MAIN MENU__________");
            Console.WriteLine("Enter 1 to View Points");
            Console.WriteLine("Enter 2 to Redeem Points");
            Console.WriteLine("Enter 3 to Give Points");
            Console.WriteLine("Enter x to exit application");
            Console.WriteLine("____________________________");
        }

        static string GetUserInput() //method signature
        {
            Console.Write(">> user input: ");
            string input = Console.ReadLine();

            //return statement
            return input;
        }

        static void ViewPoints()
        {
            Console.WriteLine($"Current points balance is: {pointsBalance}");
        }

        static void RedeemPoints()
        {
            ShowRedeemables();

            Console.WriteLine("\nEnter the Product or Service Code you want to redeem...");
            string selected = GetUserInput();

            double points = GetProductsAndServicesPoints(selected);

            if (points <= pointsBalance)
            {
                pointsBalance = pointsBalance - points;
                Console.WriteLine("Successfully redeemed points...");
                ViewPoints();
            }
            else
            {
                Console.WriteLine("Failed Transaction! Insufficient balance.");
                ViewPoints();
            }
        }

        static void ShowRedeemables()
        {
            Console.WriteLine($"Select Products or Services from accredit Partners");

            Console.WriteLine("PRODUCTS");
            foreach (var product in productsView)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("\n SERVICES");
            foreach (var service in servicesView)
            {
                Console.WriteLine(service);
            }
        }

        static double GetProductsAndServicesPoints(string selected)
        {
            double points = 0.0;

            if (selected.StartsWith('P'))
            {
                foreach (var prodPoints in productsPoints)
                {
                    if (prodPoints.Contains(selected.Substring(0, 3)))
                    {
                        points = Convert.ToDouble(prodPoints.Substring(4, 2));
                    }
                }
            }
            else if (selected.StartsWith('S'))
            {
                foreach (var servPoints in servicesPoints)
                {
                    if (servPoints.Contains(selected.Substring(0, 3)))
                    {
                        points = Convert.ToDouble(servPoints.Substring(4, 2));
                    }
                }
            }

            return points;
        }
    }
}
