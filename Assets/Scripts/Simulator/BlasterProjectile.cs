using UnityEngine;

public class BlasterProjectile : MonoBehaviour
{
    GameObject source;
    ShieldedHullData healthData;
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
        healthData = new ShieldedHullData(-10, -10, source.GetComponent<VehicleEntity>().GetOwner());
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetOwner(GameObject newSource)
    {
        source = newSource;
    }

    private void OnTriggerEnter(Collider other)
    {
        ShieldedHull combatant = other.GetComponent<ShieldedHull>();
        if (combatant)
        {
            combatant.ApplyHealth(healthData);
        }
    }
}
