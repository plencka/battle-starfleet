using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Movement : MonoBehaviour
{
    public float turnSpeed = 1;
    public float speed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, turnSpeed) * Time.deltaTime);
        transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
    }
}
