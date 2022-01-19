class ShieldedHullData
{
    Faction owner;
    private Health shield;
    private Health hull;

    public ShieldedHullData(int hullPoints, int shieldPoints, Faction newOwner)
    {
        shield = new Health(shieldPoints);
        hull = new Health(hullPoints);
        owner = newOwner;
    }

    public Faction GetOwner()
    {
        return owner;
    }

    public Health getShield()
    {
        return shield;
    }

    public Health getHull()
    {
        return hull;
    }

    public void ApplyHealth(ShieldedHullData healthSource)
    {
        if (healthSource.GetOwner() && healthSource.GetOwner() != owner)
        {
            shield.Points += healthSource.shield.Points;
            hull.Points += healthSource.hull.Points;
        }
    }
}
