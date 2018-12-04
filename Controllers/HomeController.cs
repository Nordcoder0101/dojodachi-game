using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dojodachi.Models;

namespace dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            Dojodachi MyDojodachi = new Dojodachi();

            return View(MyDojodachi);
        }

        
        
        [HttpPost("Feed/{happiness}/{fullness}/{energy}/{meals}")]
        public JsonResult Feed(int happiness, int fullness, int energy, int meals)
        {
            
            Random Rand = new Random();
            Dojodachi MyDojodachi = new Dojodachi(happiness, fullness, energy, meals);
            int RandomFullnessIncrement = Rand.Next(5,11);
            int RandomNumber = Rand.Next(1, 5);

            if (MyDojodachi.Meals > 0 && RandomNumber != 4)
            {
                MyDojodachi.Meals --;
                MyDojodachi.Fullness += RandomFullnessIncrement;
                if (MyDojodachi.Fullness > 100)
                {
                    MyDojodachi.Message = "Congratulations!  You win!  Play again?";
                    MyDojodachi.HasWon = true;
                    return Json(MyDojodachi);
                }
                else
                {
                    MyDojodachi.Message = "You fed your Dojodachi, and it's more full!";
                    return Json(MyDojodachi);
                }
            }
            else if (MyDojodachi.Meals > 0 && RandomNumber == 4)
            {
                MyDojodachi.Meals --;
                MyDojodachi.Message = "You fed your Dojodchi but it was not satiated.";
                return Json(MyDojodachi);
            }
            else
            {
                
                MyDojodachi.Message = "You ran out of Meals and can't feed right now";
                return Json(MyDojodachi);
            }
            
            
        }

        
        [HttpPost("Play/{happiness}/{fullness}/{energy}/{meals}")]
        public JsonResult Play(int happiness, int fullness, int energy, int meals)
        {

            Random Rand = new Random();
            Dojodachi MyDojodachi = new Dojodachi(happiness, fullness, energy, meals);
            int RandomHappinessIncrement = Rand.Next(5, 11);
            int RandomNumber = Rand.Next(1,5);

            if (MyDojodachi.Energy >= 5 && RandomNumber != 4)
            {
                MyDojodachi.Energy -=5;
                MyDojodachi.Happiness += RandomHappinessIncrement;

                if(MyDojodachi.Happiness > 100)
                {
                    MyDojodachi.Message = "Congratulations!  You win!  Play again?";
                    MyDojodachi.HasWon = true;
                    return Json(MyDojodachi);
                }
                else
                {
                    MyDojodachi.Message = "You played with your Dojodachi and it is happier!";
                    return Json(MyDojodachi);
                }
                
            }
            else if (MyDojodachi.Energy >= 5 && RandomNumber == 4)
            {
                MyDojodachi.Energy -=5;
                
                MyDojodachi.Message = "You played with your DojoDachi, but your DojoDachi was not entertained.";
                return Json(MyDojodachi);
            }
            else
            {
                MyDojodachi.Message = "You don't have enough energy to play right now, rest up!";
                return Json(MyDojodachi);
            }
               
            
            
            
        }

        [HttpPost("Work/{happiness}/{fullness}/{energy}/{meals}")]
        public JsonResult Work(int happiness, int fullness, int energy, int meals)
        {
            Random Rand = new Random();
            Dojodachi MyDojodachi = new Dojodachi(happiness, fullness, energy, meals);
            int RandomMealsAdded = Rand.Next(1, 4);
            if (MyDojodachi.Energy >= 5)
            {
                MyDojodachi.Energy -= 5;
                MyDojodachi.Meals += RandomMealsAdded;
                MyDojodachi.Message = $"You worked and gained {RandomMealsAdded} meals";
                return Json(MyDojodachi);
            }    
            else
            {
                
            
            MyDojodachi.Message = "Oh no!  You have no energy, rest up!";
            return Json(MyDojodachi);
                
            }
                 
        
        }

    [HttpPost("Sleep/{happiness}/{fullness}/{energy}/{meals}")]
    public JsonResult Sleep(int happiness, int fullness, int energy, int meals)
    {
      Random Rand = new Random();
      Dojodachi MyDojodachi = new Dojodachi(happiness, fullness, energy, meals);
    
        MyDojodachi.Energy += 15;
        MyDojodachi.Fullness -= 5;
        MyDojodachi.Happiness -=5;

        if (MyDojodachi.Fullness <= 0 || MyDojodachi.Happiness <= 0)
        {
            MyDojodachi.HasLost = true;
            MyDojodachi.Message = "Oh no!  You lost the game...  Try again?";
        }
        else
        {
            MyDojodachi.Message = "Your Dojodachi feels rested...";
        }

        return Json(MyDojodachi);

        
        
      }
    

    }
}
