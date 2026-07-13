using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    private Rigidbody rb;
    public float moveSpeed = 5f;
    
    // クラス全体で使うためにここで変数を宣言
    private float moveInput;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 1. 入力の取得（Updateで行うのが基本）
        moveInput = Input.GetAxis("Vertical");

        // 2. 方向転換
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -2f, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 2f, 0);
        }

        // 3. スペースキーで「押す」アニメーション
        // GetKeyにすることで、押している間ずっとtrue、離すと自動的にfalseになります
        if (anim != null)
        {
            anim.SetBool("isPushing", Input.GetKey(KeyCode.Space));
        }

        // 4. アニメーターの制御（歩き）
        if (anim != null)
        {
            // 入力が「0以外（＝前後に動いている）」なら歩くアニメーションを再生
            // Mathf.Absは絶対値（マイナスもプラスにする）です
            anim.SetBool("isWalking", Mathf.Abs(moveInput) > 0.1f);
        }


    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * moveSpeed * -1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.forward * moveSpeed);
        }
    }
}