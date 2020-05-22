using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicParkColter
{
    class Program
    {
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input. I'm using 0 as your answer.");
                return 0;
            }
        }

        static DateTime PromptForDateTime(string prompt)
        {
            Console.Write(prompt);
            var userInputAsString = Console.ReadLine();
            DateTime userInputAsDateTime = DateTime.Parse(userInputAsString);
            var isThisGoodInput = DateTime.TryParse(userInputAsString, out userInputAsDateTime);

            if (isThisGoodInput)
            {
                return userInputAsDateTime;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input. I'm using 1/1/0001 as you answer.");
                return new DateTime(1, 1, 1);
            }

        }
        static void Main(string[] args)
        {
            var velociraptor = new Dinosaur
            {
                Name = "Velociraptor",
                EnclosureNumber = 12,
                DietType = "Carnivore",
                Age = 10,
                Weight = 500,
                WhenAcquired = new DateTime(2019, 7, 2),
            };

            var tyrannosaurus = new Dinosaur
            {
                Name = "Tyrannosaurus",
                EnclosureNumber = 14,
                DietType = "Carnivore",
                Age = 15,
                Weight = 2000,
                WhenAcquired = new DateTime(2017, 8, 25),
            };

            var brachiosaurus = new Dinosaur
            {
                Name = "Brachiosaurus",
                EnclosureNumber = 17,
                DietType = "Herbivore",
                Age = 7,
                Weight = 6000,
                WhenAcquired = new DateTime(2016, 6, 18),
            };

            var listOfDinosaur = new List<Dinosaur>();

            listOfDinosaur.Add(velociraptor);
            listOfDinosaur.Add(tyrannosaurus);
            listOfDinosaur.Add(brachiosaurus);


            Console.WriteLine();
            Console.WriteLine($"Welcome to Dinosaur Zoo Inventory for Jurassic Park, please make a selection from the menu below.");
            Console.WriteLine();

            var userHasChosenToQuit = false;

            while (userHasChosenToQuit == false)
            {
                Console.WriteLine("Choose:");
                Console.WriteLine("(V)iew all the dinosaurs in inventory");
                Console.WriteLine("(A)dd a new dinosaur to the inventory");
                Console.WriteLine("(R)emove a dinosaur from the inventory");
                Console.WriteLine("(T)ransfer the dionsaur to a new enclosure");
                Console.WriteLine("S(u)mmary of inventroy by diet");
                Console.WriteLine("(Q)uit the application");
                Console.WriteLine();

                var choice = PromptForString("Choice: ");
                if (choice == "Q")
                {
                    userHasChosenToQuit = true;
                }

                if (choice == "T")
                {
                    var nameOfDinosaurToFind = PromptForString("Name of transferred dinosaur: ");
                    var foundDinosaur = listOfDinosaur.FirstOrDefault(dinosaur => dinosaur.Name == nameOfDinosaurToFind);
                    if (foundDinosaur == null)
                    {
                        Console.WriteLine($"There is no dinosaur named {nameOfDinosaurToFind}");
                    }
                    else
                    {
                        var foundDinosaurDescription = foundDinosaur.Description();
                        Console.WriteLine(foundDinosaurDescription);

                        var newDinosaurEnclosureNumber = PromptForInteger("New enclosure number: ");

                        foundDinosaur.EnclosureNumber = newDinosaurEnclosureNumber;
                    }
                }

                if (choice == "R")
                {
                    var nameOfDinosaurToFind = PromptForString("Name of dinosaur being removed: ");

                    var foundDinosaur = listOfDinosaur.FirstOrDefault(dinosaur => dinosaur.Name == nameOfDinosaurToFind);

                    if (foundDinosaur == null)
                    {
                        Console.WriteLine($"There is no dinosaur named {nameOfDinosaurToFind}");
                    }
                    else
                    {
                        var foundDinosaurDescription = foundDinosaur.Description();
                        Console.WriteLine(foundDinosaurDescription);

                        var shouldWeAdoptOut = PromptForString("Sure you want to remove this dinosaur from the inventory? (Y/N): ");

                        if (shouldWeAdoptOut == "Y")
                        {
                            listOfDinosaur.Remove(foundDinosaur);
                        }
                    }
                }

                if (choice == "A")
                {
                    var newName = PromptForString("Name: ");
                    var newEnclosureNumber = PromptForInteger("Enclosure Number: ");
                    var newDietType = PromptForString("Diet Type: ");
                    var newAge = PromptForInteger("Age: ");
                    var newWeight = PromptForInteger("Weight: ");
                    var newWhenAcquired = PromptForDateTime("When Acquired in the Format of MM/DD/YYYY: ");

                    var newDinosaur = new Dinosaur
                    {
                        Age = newAge,
                        Weight = newWeight,
                        DietType = newDietType,
                        Name = newName,
                        WhenAcquired = newWhenAcquired,
                        EnclosureNumber = newEnclosureNumber,
                    };

                    listOfDinosaur.Add(newDinosaur);
                }

                if (choice == "V")
                {
                    Console.WriteLine("Here are All the Dinosaurs");

                    var newDinoList = listOfDinosaur.OrderBy(dino => dino.WhenAcquired);

                    foreach (var Dinosaur in newDinoList)
                    {
                        var description = Dinosaur.Description();
                        Console.WriteLine(description);

                    }
                }
                if (choice == "u")
                {
                    var herbivores = listOfDinosaur.Count(dino => dino.DietType == "Herbivore");
                    var carnivores = listOfDinosaur.Count(dino => dino.DietType == "Carnivore");
                    var messageAboutDietType = $"The amount of Carnivores is {carnivores} and the amount of Herbivores is {herbivores}.";
                    Console.WriteLine(messageAboutDietType);

                }
            }
        }

    }
}
