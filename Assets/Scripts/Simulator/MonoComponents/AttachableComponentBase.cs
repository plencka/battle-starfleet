using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttachableComponentBase<T> : MonoBehaviour 
    where T : MonoBehaviour
{
    public static T CreateAndAttachTo(GameObject gameObject) {
        T component = gameObject.AddComponent<T>();
        return component;
    }
}
