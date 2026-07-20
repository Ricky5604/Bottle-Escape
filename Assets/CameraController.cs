using UnityEngine;
using Unity.Cinemachine; // Unity 6 (Cinemachine v3) の必須宣言

public class CameraController : MonoBehaviour
{
    [Header("Cinemachineの設定")]
    // インスペクターから、あなたの Cinemachine Camera をドラッグ＆ドロップします
    public CinemachineCamera cinemachineCamera;

    [Header("カメラの距離設定")]
    public float height = 3f;       // カメラの高さ
    public float distance = 15f;     // プレイヤーからの距離

    // 4方向のオフセット（位置）を管理する配列
    private Vector3[] directionOffsets;
    private int currentDirectionIndex = 0; // 0:前, 1:右, 2:後, 3:左
    
    // CinemachineのFollowコンポーネントをコードから操作するための変数
    private CinemachineFollow cmFollow;

    void Start()
    {
        if (cinemachineCamera == null)
        {
            Debug.LogError("Cinemachine Camera がアタッチされていません！");
            return;
        }

        // カメラから「CinemachineFollow」コンポーネントを取得する（v3の仕様）
        cmFollow = cinemachineCamera.GetComponent<CinemachineFollow>();

        if (cmFollow == null)
        {
            Debug.LogError("Cinemachine Camera に 'Cinemachine Follow' が追加されていません。インスペクターを確認してください。");
            return;
        }

        // 東西南北の 4方向の Follow Offset をあらかじめ計算して登録
        directionOffsets = new Vector3[]
        {
            new Vector3(0, height, -distance),  // 0: 前 (Front)
            new Vector3(-distance, height, 0),  // 1: 右 (Right)
            new Vector3(0, height, distance),   // 2: 後 (Back)
            new Vector3(distance, height, 0)    // 3: 左 (Left)
        };

        // 初期位置を反映
        ApplyCameraOffset();
    }

    void Update()
    {
        if (cmFollow == null) return;

        // Eキーで右回りに90度回転
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentDirectionIndex = (currentDirectionIndex + 1) % directionOffsets.Length;
            ApplyCameraOffset();
        }

        // Qキーで左回りに90度回転
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentDirectionIndex--;
            if (currentDirectionIndex < 0)
            {
                currentDirectionIndex = directionOffsets.Length - 1;
            }
            ApplyCameraOffset();
        }
    }

    // 計算した Follow Offset を Cinemachine に直接流し込む処理
    void ApplyCameraOffset()
    {
        cmFollow.FollowOffset = directionOffsets[currentDirectionIndex];
    }
}