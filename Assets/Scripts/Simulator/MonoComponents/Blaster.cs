using UnityEngine;

public class Blaster : AttachableComponentBase<Blaster>
{
    private Color projectileColor;
    private float maxDistance = 10;
    private float maxAngle = 60;
    private Vector3 gunBarrelPosition = new Vector3(0, 0.25f, 0);
    private GameObject projectile;

    private Range range;

    private float shootDelay = 0.2f;
    private float lastShotTimestamp = 0f;

    void Start()
    {
        range = new Range(-maxAngle, maxAngle);
    }

    private Quaternion GetQuaterionRotation(float angle)
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        return Quaternion.Euler(new Vector3(currentRotation.x, currentRotation.y, currentRotation.z + angle));
    }

    private float CalculateAim(GameObject target)
    {
        Vector2 dir = PredictTargetPosition(target) - transform.position;
        return Vector2.SignedAngle(transform.up, dir);
    }

    private Vector3 PredictTargetPosition(GameObject target)
    {
        float distance = (target.transform.position - transform.position).magnitude;
        float projectileVelocity = projectile.GetComponent<BlasterProjectile>().GetSpeed();
        return target.transform.position + (distance / projectileVelocity) * target.GetComponent<Rigidbody>().velocity;
    }

    public void SetUpBlaster(GameObject projectilePrefab, float angleMax, Vector3 blasterOffset)
    {
        projectile = projectilePrefab;
        maxAngle = angleMax;
        gunBarrelPosition = blasterOffset;
    }

    public void SetProjectileColor(Color newColor)
    {
        projectileColor = newColor;
    }

    public void Shoot(GameObject target)
    {
        if (lastShotTimestamp + shootDelay < Time.time)
        {
            if (!target)
            {
                return;
            }

            if (target.GetComponent<VehicleEntity>().GetOwner().GetInstanceID() 
                == (gameObject.GetComponent<VehicleEntity>().GetOwner().GetInstanceID()))
            {
                return;
            }

            if (Vector3.Distance(transform.position, target.transform.position) > maxDistance)
            {
                return;
            }

            float currentAimAngle = CalculateAim(target);
            if (range.Contains(currentAimAngle))
            {
                Quaternion quaterionRotation = GetQuaterionRotation(currentAimAngle);
                GameObject projectileInstance = Instantiate(projectile,
                    transform.position + gunBarrelPosition,
                    quaterionRotation);
                projectileInstance.GetComponent<TrailRenderer>().material.color = projectileColor;
                projectileInstance.GetComponent<BlasterProjectile>().SetOwner(gameObject);
                lastShotTimestamp = Time.time;
            }
        }
    }
}
