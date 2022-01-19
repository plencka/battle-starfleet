using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Starfleet/Simulator/Faction")]
public class Faction : ScriptableObject, IColorable, INameable
{
    [SerializeField]
    private string factionName;

    [SerializeField]
    private Sprite icon;

    [SerializeField]
    private ShipSet shipSet;

    [SerializeField]
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
        return factionName;
    }

    public Sprite GetIconFile()
    {
        return icon;
    }

    public void SetName(string newName)
    {
        factionName = newName;
    }
}
