using UnityEngine;

public class KeyDoorController : MonoBehaviour
{
    public float openHeight = 4f;
    public float speed = 2f;

    Vector3 closedPos;
    Vector3 openPos;
    bool opening;

    void Start()
    {
        closedPos = transform.position;
        openPos = closedPos + Vector3.up * openHeight;
    }

    void Update()
    {
        if (opening)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                openPos,
                speed * Time.deltaTime);
        }
    }

    public void OpenDoor()
    {
        opening = true;
    }
}