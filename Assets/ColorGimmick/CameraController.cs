using UnityEngine;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    [Header("Cinemachineの設定")]
    public CinemachineCamera cinemachineCamera;

    [Header("追従するプレイヤーを直接指定")]
    // ★ここにヒエラルキーからPlayer（またはCameraTarget）を直接ドラッグ＆ドロップしてください
    public Transform playerTransform; 

    [Header("カメラの距離設定")]
    public float height = 3f;       
    public float distance = 15f;     

    private int currentDirectionIndex = 0; // 0:前, 1:右, 2:後, 3:左
    private CinemachineFollow cmFollow;

    void Start()
    {
        if (cinemachineCamera == null)
        {
            Debug.LogError("Cinemachine Camera がアタッチされていません！");
            return;
        }

        cmFollow = cinemachineCamera.GetComponent<CinemachineFollow>();

        if (cmFollow == null)
        {
            Debug.LogError("Cinemachine Camera に 'Cinemachine Follow' が追加されていません。");
            return;
        }

        ApplyCameraOffset();
    }

    void Update()
    {
        if (cmFollow == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            currentDirectionIndex = (currentDirectionIndex + 1) % 4;
        }

        if (Input.GetMouseButtonDown(1))
        {
            currentDirectionIndex--;
            if (currentDirectionIndex < 0)
            {
                currentDirectionIndex = 3;
            }
        }

        // プレイヤーの動きに合わせて、毎フレーム高さを計算して上書きする
        ApplyCameraOffset();
    }

    void ApplyCameraOffset()
    {
        // プレイヤーが指定されていない場合は処理しない
        if (playerTransform == null) return;

        Vector3 targetOffset = Vector3.zero;

        // 【確実なロジック】プレイヤーのワールド座標のYを直接取得し、相殺されないようにセットする
        float playerY = playerTransform.position.y;

        switch (currentDirectionIndex)
        {
            case 0: // 前
                targetOffset = new Vector3(0, height + playerY, -distance);
                break;
            case 1: // 右
                targetOffset = new Vector3(-distance, height + playerY, 0);
                break;
            case 2: // 後
                targetOffset = new Vector3(0, height + playerY, distance);
                break;
            case 3: // 左
                targetOffset = new Vector3(distance, height + playerY, 0);
                break;
        }

        cmFollow.FollowOffset = targetOffset;
    }
}