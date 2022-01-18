using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterProjectile : MonoBehaviour
{
    public float speed;
    public float lifetime;

    private void Awake()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
    }
}
