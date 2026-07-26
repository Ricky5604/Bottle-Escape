using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openHeight = 3f;
    public float speed = 2f;

    private Vector3 closedPosition;
    private Vector3 openPosition;

    private bool isOpen = false;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + Vector3.up * openHeight;
    }

    void Update()
    {
        Vector3 target = isOpen ? openPosition : closedPosition;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime);
    }

    public void OpenDoor()
    {
        isOpen = true;
    }

    public void CloseDoor()
    {
        isOpen = false;
    }
}