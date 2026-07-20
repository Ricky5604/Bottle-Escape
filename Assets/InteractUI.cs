using UnityEngine;

public class InteractUI : MonoBehaviour
{
    public static InteractUI Instance;

    public GameObject interactText;

    void Awake()
    {
        Instance = this;
        interactText.SetActive(false);
    }

    public void Show()
    {
        interactText.SetActive(true);
    }

    public void Hide()
    {
        interactText.SetActive(false);
    }
}