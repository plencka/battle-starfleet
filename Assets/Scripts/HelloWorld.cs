using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Hello World");
    }

    void Update()
    {
        transform.Rotate(0, 0, 10 * Time.deltaTime);
    }
}
