using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Starfleet/Simulator/ShipType")]
public class ShipType : ScriptableObject
{
    [SerializeField]
    private ShipSet.ShipTypes _type;

    [SerializeField]
    private GameObject vehiclePrefab;

    [SerializeField]
    [Range(0f,100000f)]

    private float _hullPoints;
    [SerializeField]

    [Range(0f, 100000f)]
    private float _shieldPoints;

    [SerializeField]
    [Range(0f, 10f)]
    private float _scale;

    [SerializeField]
    private string _textureName;

    [SerializeField]
    [Range(0f, 1000f)]
    private float _speed;

    public Texture GetDiffuseTexture()
    {
        return (Texture)Resources.Load("Spaceships/"+ _textureName, typeof(Texture));
    }
    public Texture GetTintTexture()
    {
        return (Texture)Resources.Load("Spaceships/" + _textureName + "_tint", typeof(Texture));
    }

    public ShipSet.ShipTypes GetShipType()
    {
        return _type;
    }

    public GameObject GetPrefab()
    {
        return vehiclePrefab;
    }
}
