using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public int[] correctOrder = { 1, 2, 3, 4, 5, 6, 7 };

    public RisingButton lastButton;

    private int currentIndex = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void PressButton(int buttonID)
    {
        if (buttonID == correctOrder[currentIndex])
        {
            currentIndex++;

            if (currentIndex >= correctOrder.Length)
            {
                Debug.Log("パズル成功");

                lastButton.Rise();

                currentIndex = 0;
            }
        }
        else
        {
            Debug.Log("失敗");

            currentIndex = 0;
        }
    }
}