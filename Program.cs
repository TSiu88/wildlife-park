using System;
using AnimalTracker;
using System.Collections.Generic;

public class Program {
  static void Main()
  {
    // Create initial animals for list
    Animal lion = new Animal("lion", "savannah", "carnivore");
    Animal crocodile = new Animal("crocodile", "swamp", "carnivore");
    Animal giraffe = new Animal("giraffe", "savannah", "herbivore");
    List<Animal> Animals = new List<Animal>() {lion, crocodile, giraffe};

    // Ask for initial input
    Console.WriteLine("What do you want to do (Add/Show/Search)");
    string input = Console.ReadLine();

    // Ask for input on animal to add, then show all animals
    if (input == "Add"){
      Console.WriteLine("What species of animal do you want to add?");
      string speciesToAdd = Console.ReadLine();
      Console.WriteLine("What is their habitat?");
      string habitatToAdd = Console.ReadLine();
      Console.WriteLine("What is their diet category? (carnivore, herbivore, omnivore)");
      string dietToAdd = Console.ReadLine();

      Animal animalToAdd = new Animal(speciesToAdd, habitatToAdd, dietToAdd);
      Animals.Add(animalToAdd);
      Console.WriteLine("Animal added! ID: " + Animals[animalToAdd.GetTrackingNumber()].GetTrackingNumber() + " Species: " + Animals[animalToAdd.GetTrackingNumber()].GetSpecies() + " Habitat: " + Animals[animalToAdd.GetTrackingNumber()].GetHabitat() + " Diet Category: " + Animals[animalToAdd.GetTrackingNumber()].GetDietCategory());
      PrintAllAnimals(Animals);

      // Show all animals 
    } else if (input == "Show"){
      PrintAllAnimals(Animals);

      // Ask for what to search by, then ask for the specific item and show what found in search
    } else if (input == "Search"){
      Console.WriteLine("What to search by? (species/habitat/diet)");
      string searchCriteria = Console.ReadLine();
      List<Animal> AnimalSearch = new List<Animal>(0);

      if (searchCriteria == "species"){
        Console.WriteLine("What species are you looking for?");
        string speciesToSearch = Console.ReadLine();
        foreach (Animal animalChecking in Animals)
        {
          if (animalChecking.CheckSpecies(speciesToSearch)){
            AnimalSearch.Add(animalChecking);
          }
        }
      } else if (searchCriteria == "habitat"){
        Console.WriteLine("What habitat are you looking for?");
        string habitatToSearch = Console.ReadLine();
        foreach (Animal animalChecking in Animals)
        {
          if (animalChecking.CheckHabitat(habitatToSearch)){
            AnimalSearch.Add(animalChecking);
          }
        }
      } else if (searchCriteria == "diet"){
        Console.WriteLine("What diet category are you looking for?");
        string dietToSearch = Console.ReadLine();
        foreach (Animal animalChecking in Animals)
        {
          if (animalChecking.CheckDiet(dietToSearch)){
            AnimalSearch.Add(animalChecking);
          }
        }
      }
      PrintAllAnimals(AnimalSearch);
    }
  }
  // Print all animals found in list
  public static void PrintAllAnimals(List<Animal> Animals)
  {
    Console.WriteLine("Animals in Program:");
    Console.WriteLine(Animal.ParkArea("the Safari zone"));
    if (Animals.Count == 0){
      Console.WriteLine("No animals found.");
    } else {
      foreach(Animal anAnimal in Animals)
      {
        Console.WriteLine("ID: " + anAnimal.GetTrackingNumber() + " Species: " + anAnimal.GetSpecies() + " Habitat: " + anAnimal.GetSpecies() + " Diet Category: " + anAnimal.GetDietCategory());
      }
    }
  }
}