using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletSpeed = 20f;

    bool playerInRange = false;

    void Update()
    {
        if (playerInRange &&
            CannonBallItem.hasCannonBall &&
            Input.GetKeyDown(KeyCode.E))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject bullet =
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.linearVelocity = firePoint.forward * bulletSpeed;

        CannonBallItem.hasCannonBall = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}