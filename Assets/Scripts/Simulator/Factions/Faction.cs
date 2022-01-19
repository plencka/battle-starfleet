using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Starfleet/Simulator/Faction")]
public class Faction : ScriptableObject, IColorable, INameable
{
    private Faction enemyFaction;

    private List<VehicleEntity> ships = new List<VehicleEntity>();

    [SerializeField]
    private string factionName;

    [SerializeField]
    private Sprite icon;

    [SerializeField]
    private ShipSet shipSet;

    [SerializeField]
    private Color color;

    public void AddVehicle(VehicleEntity vehicle)
    {
        ships.Add(vehicle);
    }

    public VehicleEntity GetRandomVehicle()
    {
        return ships[Random.Range(0, ships.Count)];
    }

    public Faction GetEnemyFaction()
    {
        return enemyFaction;
    }

    public void SetEnemyFaction(Faction otherFaction)
    {
        enemyFaction = otherFaction;
    }

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
