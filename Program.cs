using System;
using AnimalTracker;
using System.Collections.Generic;

public class Program {

  private static bool _continue = true;
  private static List<Animal> Animals;
  static void Main()
  {
    // Create initial animals for list
    Animal lion = new Animal("lion", "savannah", "carnivore");
    Animal crocodile = new Animal("crocodile", "swamp", "carnivore");
    Animal giraffe = new Animal("giraffe", "savannah", "herbivore");
    Animals = new List<Animal>() {lion, crocodile, giraffe};

    while(_continue){
      // Ask for initial input
      Console.WriteLine("What do you want to do (Add/Show/Search/Quit)");
      string input = Console.ReadLine().ToLower();
      CheckQuit(input);

      if (input == "add"){
        AddAnimal();
        PrintAllAnimals(Animals);

        // Show all animals 
      } else if (input == "show"){
        PrintAllAnimals(Animals);
      } else if (input == "search"){
        SearchAnimals();
      } else {
        Console.WriteLine("Command not found. Please try again.");
      }
    }
    
  }

  // Ask for input on animal to add, then show all animals
  private static void AddAnimal()
  {
    Console.WriteLine("What species of animal do you want to add?");
      string speciesToAdd = Console.ReadLine().ToLower();
      CheckQuit(speciesToAdd);
      Console.WriteLine("What is their habitat?");
      string habitatToAdd = Console.ReadLine().ToLower();
      CheckQuit(habitatToAdd);
      Console.WriteLine("What is their diet category? (carnivore, herbivore, omnivore)");
      string dietToAdd = Console.ReadLine().ToLower();
      CheckQuit(dietToAdd);

      Animal animalToAdd = new Animal(speciesToAdd, habitatToAdd, dietToAdd);
      Animals.Add(animalToAdd);
      Console.WriteLine("Animal added! ID: " + Animals[animalToAdd.GetTrackingNumber()].GetTrackingNumber() + " Species: " + Animals[animalToAdd.GetTrackingNumber()].GetSpecies() + " Habitat: " + Animals[animalToAdd.GetTrackingNumber()].GetHabitat() + " Diet Category: " + Animals[animalToAdd.GetTrackingNumber()].GetDietCategory());
  }

  // Ask for what to search by, then ask for the specific item and show what found in search
  private static void SearchAnimals()
  {
    Console.WriteLine("What to search by? (species/habitat/diet)");
    string searchCriteria = Console.ReadLine().ToLower();
    CheckQuit(searchCriteria);
    List<Animal> AnimalSearch = new List<Animal>(0);

    if (searchCriteria == "species"){
      Console.WriteLine("What species are you looking for?");
      string speciesToSearch = Console.ReadLine().ToLower();
      CheckQuit(speciesToSearch);
      foreach (Animal animalChecking in Animals)
      {
        if (animalChecking.CheckSpecies(speciesToSearch)){
          AnimalSearch.Add(animalChecking);
        }
      }
    } else if (searchCriteria == "habitat"){
      Console.WriteLine("What habitat are you looking for?");
      string habitatToSearch = Console.ReadLine().ToLower();
      CheckQuit(habitatToSearch);
      foreach (Animal animalChecking in Animals)
      {
        if (animalChecking.CheckHabitat(habitatToSearch)){
          AnimalSearch.Add(animalChecking);
        }
      }
    } else if (searchCriteria == "diet"){
      Console.WriteLine("What diet category are you looking for?");
      string dietToSearch = Console.ReadLine().ToLower();
      CheckQuit(dietToSearch);
      foreach (Animal animalChecking in Animals)
      {
        if (animalChecking.CheckDiet(dietToSearch)){
          AnimalSearch.Add(animalChecking);
        }
      }
    }
    PrintAllAnimals(AnimalSearch);
  }
  // Print all animals found in list
  private static void PrintAllAnimals(List<Animal> Animals)
  {
    Console.WriteLine("Animals in Program:");
    Console.WriteLine(Animal.ParkArea("the Safari zone"));
    if (Animals.Count == 0){
      Console.WriteLine("No animals found.");
    } else {
      foreach(Animal anAnimal in Animals)
      {
        Console.WriteLine("ID: " + anAnimal.GetTrackingNumber() + " Species: " + anAnimal.GetSpecies() + " Habitat: " + anAnimal.GetHabitat() + " Diet Category: " + anAnimal.GetDietCategory());
      }
    }
  }

  private static void CheckQuit(String input)
  {
    if (input == "quit"){
      _continue = false;
      Environment.Exit(0);
    }
  }
}