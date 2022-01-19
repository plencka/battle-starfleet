using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleEntity : MoveableEntity
{
    [SerializeField]
    private Faction owner;
    private ShipType data;
    private List<Blaster> blasters = new List<Blaster>();


    void Start()
    {
        ShieldedHull.CreateComponent(gameObject, data.GetHullPoints(), data.GetShieldPoints(), owner);
        transform.localScale = data.GetScale() * new Vector3(1,1,1);
        TintMaterial.CreateAndAttachTo(gameObject)
            .SetColor(owner.GetColor());

        Blaster blaster = Blaster.CreateAndAttachTo(gameObject);
        blasters.Add(blaster);
        blaster.SetUpBlaster((GameObject)Resources.Load("Prefabs/Projectile", typeof(GameObject)), 25f, new Vector3(0, 0, 0));
        blaster.SetProjectileColor(owner.GetColor());

        GetComponent<Renderer>().material.SetTexture("_diffuseText", data.GetDiffuseTexture());
        GetComponent<Renderer>().material.SetTexture("_tintTexture", data.GetTintTexture());
    }

    private void Update()
    {
        Move();
        foreach(Blaster blaster in blasters)
        {
            blaster.Shoot(GetCurrentTarget());
        }
    }

    public void SetOwner(Faction newOwner)
    {
        owner = newOwner;
    }

    public void SetShipType(ShipType type)
    {
        data = type;
    }

    public Faction GetOwner()
    {
        return owner;
    }
}
