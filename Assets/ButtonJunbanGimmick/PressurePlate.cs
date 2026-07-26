using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public DoorController door;

    private int objectCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        objectCount++;
        door.OpenDoor();
    }

    private void OnTriggerExit(Collider other)
    {
        objectCount--;

        if (objectCount <= 0)
        {
            objectCount = 0;
            door.CloseDoor();
        }
    }
}