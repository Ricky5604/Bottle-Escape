using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance;

    public GameObject[] redPlatforms;
    public GameObject[] bluePlatforms;
    public GameObject[] yellowPlatforms;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ChangePlatform(ColorType.Red);   // 初期状態
    }

    public void ChangePlatform(ColorType color)
    {
        SetGroup(redPlatforms, color == ColorType.Red);
        SetGroup(bluePlatforms, color == ColorType.Blue);
        SetGroup(yellowPlatforms, color == ColorType.Yellow);
    }

    void SetGroup(GameObject[] group, bool active)
    {
        foreach (GameObject obj in group)
        {
            obj.GetComponent<PlatformBlock>().SetActive(active);
        }
    }
}