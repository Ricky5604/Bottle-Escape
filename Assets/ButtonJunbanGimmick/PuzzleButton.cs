using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    public int buttonID;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        PuzzleManager.Instance.PressButton(buttonID);
    }
}