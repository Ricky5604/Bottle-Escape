using UnityEngine;

public class CannonBallItem : MonoBehaviour
{
    public static bool hasCannonBall = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasCannonBall = true;
            gameObject.SetActive(false);
        }
    }
}