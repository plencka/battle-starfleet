using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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
    void AddOrModifyShipType(ShipType shipTypeData)
    {
        foreach (ShipType ship in shipTypeList)
        {
            if(shipTypeData.GetShipType() == ship.GetShipType())
            {
                shipTypeList.Remove(ship);
            }
        }

        shipTypeList.Add(shipTypeData);
    }

    ShipType GetShipType(ShipTypes type)
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
