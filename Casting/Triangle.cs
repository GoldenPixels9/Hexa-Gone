using System;

namespace Byui.Games.Casting;

/// <summary>
/// An evil triangle
/// </summary>
/// <remarks>
/// The responsibility of Triangle is to control triangle actions and behaviors
/// </remarks>
public class Triangle : Image
{
    public Triangle() 
    {
    }

    public void SetRandomEdgePosition()
    {
        Random rand = new Random();
        int side = rand.Next(1, 5);
        float triangle_x = 0;
        float triangle_y = 0;
        if (side == 1) { // Spawn on left edge
            triangle_x = this.GetLeft();
            triangle_y = rand.Next(0, (int)Math.Round(GetTop()));
        }
        else if (side == 2) { // Spawn on top edge
            triangle_y = this.GetTop(); 
            triangle_x = rand.Next(0, (int)Math.Round(GetRight()));
        }
        else if (side == 3) { // Spawn on right edge
            triangle_x = this.GetRight(); 
            triangle_y = rand.Next(0, (int)Math.Round(GetTop()));
        }
        else if (side == 4) { // Spawn on bottom edge
            triangle_y = this.GetBottom(); 
            triangle_x = rand.Next(0, (int)Math.Round(GetRight()));
        }
    }

}