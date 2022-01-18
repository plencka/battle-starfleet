using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faction : IColorable, INameable
{
    private string name;
    private string iconName;
    private ShipSet shipSet;
    private Color color;

    public ShipSet GetShipSet()
    {
        return shipSet;
    }

    public Color GetColor()
    {
        return color;
    }

    public void SetColor(Color newColor)
    {
        color = newColor;
    }

    public string GetName()
    {
        return name;
    }

    public void SetName(string newName)
    {
        name = newName;
    }
}
