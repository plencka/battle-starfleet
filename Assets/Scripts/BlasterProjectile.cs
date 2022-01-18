using UnityEngine;

public class BlasterProjectile : MonoBehaviour
{
    public float speed;
    public float lifetime;

    public void Awake()
    {
        Destroy(gameObject, lifetime);
    }

    void Start()
    {
        transform.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, speed, 0));
    }
}
