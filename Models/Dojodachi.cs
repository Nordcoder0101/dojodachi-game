namespace dojodachi.Models
{
  public class Dojodachi 
  {
    public int Happiness = 20; 
    public int Fullness = 20;
    public int Energy = 50;
    public int Meals = 3;
    public string Message;
    public bool HasLost = false;
    public bool HasWon = false;

    public Dojodachi(){}
    
    public Dojodachi(int happiness, int fullness, int energy, int meals )
    {
      Happiness = happiness;
      Fullness = fullness;
      Energy = energy;
      Meals = meals;
    }

  }
}