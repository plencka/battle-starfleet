public class Area
{
    public float x;
    public float y;
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
}
