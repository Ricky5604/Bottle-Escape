using UnityEngine;

public class DoorOpenTrigger : MonoBehaviour
{
    public KeyDoorController door;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (KeyItem.hasKey)
        {
            door.OpenDoor();
        }
    }
}