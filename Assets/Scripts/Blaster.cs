using UnityEngine;

public class Blaster : MonoBehaviour
{
    public float maxAngle;
    public Vector3 gunBarrelPosition;
    public GameObject projectile;
    public GameObject target;

    private Range range;

    void Start()
    {
        range = new Range(-maxAngle, maxAngle);
    }

    void Update()
    {
        Shoot();
    }

    Quaternion getQuaterionRotation(float angle)
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        return Quaternion.Euler(new Vector3(currentRotation.x, currentRotation.y, currentRotation.z + angle));
    }

    float Aim()
    {
        Vector2 dir = PredictTargetPosition() - transform.position;
        return Vector2.SignedAngle(transform.up, dir);
    }

    Vector3 PredictTargetPosition()
    {
        float distance = (target.transform.position - transform.position).magnitude;
        float projectileVelocity = projectile.GetComponent<BlasterProjectile>().speed;
        return target.transform.position + (distance / projectileVelocity) * target.GetComponent<Rigidbody>().velocity;
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.X)) //To be deleted later
        {
            float currentAimAngle = Aim();
            Debug.Log(currentAimAngle);
            if (range.Contains(currentAimAngle))
            {
                Quaternion quaterionRotation = getQuaterionRotation(currentAimAngle);
                Instantiate(projectile, transform.position + gunBarrelPosition, quaterionRotation);
            }
        }
    }
}
