using UnityEngine;

public class BlasterProjectile : MonoBehaviour
{
    GameObject source;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float lifetime;

    public void Awake()
    {
        Destroy(gameObject, lifetime);
    }

    void Start()
    {
        transform.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, speed, 0));
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetOwner(GameObject source)
    {

    }
}
