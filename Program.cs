using System;
using System.Collections.Generic;

namespace HungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Ninja bob = new Ninja();
            Buffet buffet = new Buffet();
            while(!bob.IsFull)
            {
                Food food = buffet.Serve();
                bob.Eat(food);
            }
            Console.Write("The Ninja ate: ");
            foreach(Food foo in bob.FoodHistory)
            {
                
                Console.Write(foo.Name+", ");
            }
            Console.WriteLine();
        }   
    }

    class Food
    {
        public string Name;
        public int Calories;
        public bool IsSpicy;
        public bool IsSweet;

        public Food(string name, int calories, bool spicy, bool sweet){
            Name = name;
            Calories = calories;
            IsSpicy = spicy;
            IsSweet = sweet;
        }
    }

    class Buffet
    {
        public List<Food> Menu;

        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("Tacos", 500, true, true),
                new Food("Sweet and Sour Chicken", 1000, false, true),
                new Food("Pizza", 200, false, false),
                new Food("Eggs", 100, false, false),
                new Food("Salad", -100, false, false),
                new Food("Noodles", 400, false, false),
                new Food("Strawberries", -50, false, false),

            };
        }
        public Food Serve()
        {
            Random rand = new Random();
            Console.WriteLine(Menu[rand.Next(Menu.Count)].Name);
            return Menu[rand.Next(Menu.Count)];
        }
    }

    class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;

        public Ninja()
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>();
        }

        public bool IsFull
        {
            get
            {
                if(calorieIntake > 1200)
                {
                    return true;
                } 
                else 
                {
                    return false;
                }
            }
        }


        public void Eat(Food item)
        {
            if(!IsFull){
                calorieIntake += item.Calories;
                FoodHistory.Add(item);
                // Console.WriteLine($"The ninja ate the {item.Name}");
                if(item.IsSpicy)
                {
                    Console.WriteLine("That was Spicy!");
                }
                if(item.IsSweet)
                {
                    Console.WriteLine("That was Sweet!");
                }
            } else {
                Console.WriteLine("The ninja is full! Please don't eat any more!");
            }
        }
    }
}
