using UnityEngine;

public class Area
{
    public float x { get; }
    public float y { get; }
    public Area(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public bool Contains(float x, float y) //x and y length from the center of a rectangle.
    {
        if( (x > -this.x && x < this.x) && (y > -this.y && y < this.y) )
        {
            return true;
        }
        return false;
    }


    public Vector2 GetRandomPointInArea()
    {
        return new Vector2(Random.Range(-x, x),
                Random.Range(-y, y));
    }
}
