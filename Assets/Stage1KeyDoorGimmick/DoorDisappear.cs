using UnityEngine;

public class DoorDisappear : MonoBehaviour
{
    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}