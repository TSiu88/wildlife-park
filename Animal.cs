using System;

namespace AnimalTracker {
  public class Animal
  {
    private string _species;
    private int _trackingNumber;
    private string _habitat;
    private string _dietCategory;

    private static int _currentNumber = -1;
    public Animal (string species, string habitat, string diet)
    {
      _species = species;
      _trackingNumber = SetTrackingNumber();
      _habitat = habitat;
      _dietCategory = diet;
    }

    public string GetSpecies()
    {
      return _species;
    }

    public int GetTrackingNumber()
    {
      return _trackingNumber;
    }

    private int SetTrackingNumber()
    {
      _currentNumber = _currentNumber +1;
      return _currentNumber;
    }
    public string GetHabitat()
    {
      return _habitat;
    }

    public void SetHabitat(string newHabitat)
    {
      _habitat = newHabitat;
    }

    public string GetDietCategory()
    {
      return _dietCategory;
    }

    public static string ParkArea (string area)
    {
      return "Animals tracked near " + area + " in the wildlife park.";
    }

    public bool CheckSpecies (string species)
    {
      if (_species == species){
        return true;
      } else {
        return false;
      }
    }

    public bool CheckHabitat (string habitat)
    {
      if (_habitat == habitat){
        return true;
      } else {
        return false;
      }
    }

    public bool CheckDiet (string diet)
    {
      if (_dietCategory == diet){
        return true;
      } else {
        return false;
      }
    }
  }
}