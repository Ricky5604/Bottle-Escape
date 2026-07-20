using UnityEngine;

public class PlatformBlock : MonoBehaviour
{
    private Renderer rend;
    private Collider col;

    void Awake()
    {
        rend = GetComponentInChildren<Renderer>();
        col = GetComponent<Collider>();
    }

    public void SetActive(bool active)
    {
        if (rend != null)
            rend.enabled = active;

        if (col != null)
            col.enabled = active;
    }
}