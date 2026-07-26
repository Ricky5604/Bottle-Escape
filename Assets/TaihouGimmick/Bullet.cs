using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Target target = collision.gameObject.GetComponent<Target>();

        if (target != null)
        {
            target.DestroyTarget();
        }

        Destroy(gameObject);
    }
}