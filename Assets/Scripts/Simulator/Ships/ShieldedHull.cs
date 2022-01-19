using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShieldedHull : MonoBehaviour
{
    private ShieldedHullData healthData;

    static public ShieldedHull CreateComponent(GameObject gameObject, int hullPoints, int shieldPoints, Faction owner)
    {
        ShieldedHull component = gameObject.AddComponent<ShieldedHull>();
        component.healthData = new ShieldedHullData(hullPoints, shieldPoints, owner);

        return component;
    }

    public bool ApplyHealth(ShieldedHullData healthSource)
    {
        bool wasHit = healthData.ApplyHealth(healthSource);
        if (wasHit)
        {
            gameObject.GetComponent<Renderer>().material.SetFloat("_healthPercent", healthData.GetHull().GetPercentage());
        }
        return wasHit;
    }

    public void Update()
    {
        if (healthData.GetHull().IsDepleted())
        {
            Destroy(gameObject);
            return;
        }
    }
}
