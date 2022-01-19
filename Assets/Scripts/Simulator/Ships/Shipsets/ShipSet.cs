using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Starfleet/Simulator/ShipSet")]
public class ShipSet : ScriptableObject
{
    public enum ShipTypes{
        kFighter,
        kSupport,
        kCapital,
        kFlagship,
    }

    [SerializeField]
    private List<ShipType> shipTypeList;

    public ShipType GetShipType(ShipTypes type)
    {
        foreach (ShipType ship in shipTypeList)
        {
            if (type == ship.GetShipType())
            {
                return ship;
            }
        }

        throw new System.ArgumentNullException("ShipType not found.");
    }
}
