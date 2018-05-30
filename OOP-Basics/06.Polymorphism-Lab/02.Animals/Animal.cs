using System;
using System.Collections.Generic;
using System.Text;


public class Animal
{
    private string name;
    private string favouriteFood;

    protected Animal(string name, string favouriteFood)
    {
        this.Name = name;
        this.FavouriteFood = favouriteFood;
    }
    public string Name { get; protected set; }
    public string FavouriteFood { get; protected set; }

    public virtual string ExplainSelf()
    {
        return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
    }
}

