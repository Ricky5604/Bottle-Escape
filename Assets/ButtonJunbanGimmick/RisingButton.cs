using UnityEngine;

public class RisingButton : MonoBehaviour
{
    public float riseHeight = 2f;
    public float speed = 2f;

    private bool rising = false;
    private Vector3 startPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + Vector3.up * riseHeight;
    }

    private void Update()
    {
        if (rising)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.deltaTime);
        }
    }

    public void Rise()
    {
        rising = true;
    }
}