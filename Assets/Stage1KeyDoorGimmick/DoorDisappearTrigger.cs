using UnityEngine;

public class DoorDisappearTrigger : MonoBehaviour
{
    public DoorDisappear door;

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