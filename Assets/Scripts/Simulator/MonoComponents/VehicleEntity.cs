using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleEntity : MoveableEntity
{
    void Awake()
    {
        TintMaterial.CreateAndAttachTo(gameObject)
            .SetColor(new Color(255, 0, 0, 255));
    }

    private void Update()
    {
        Move();
    }
}
