using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    public void Stage1()
    {
        SceneManager.LoadScene("stage1");
    }

    public void Stage2()
    {
        SceneManager.LoadScene("stage2");
    }

    public void Stage3()
    {
        SceneManager.LoadScene("stage3");
    }
}