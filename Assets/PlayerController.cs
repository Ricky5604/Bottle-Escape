using UnityEngine;

public class PlayerController : MonoBehaviour   //本番環境
{
    Animator anim;
    private Rigidbody rb;
    public float moveSpeed = 10f;
    
    private float moveInput;
    private bool isTouchingBox; // 箱に触れているかどうかの判定用

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 1. 入力の取得
        moveInput = Input.GetAxis("Vertical");

        // 2. 方向転換（Time.deltaTimeで速度を安定化）
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -300f * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 300f * Time.deltaTime, 0);
        }

        // 3. アニメーターの制御
        if (anim != null)
        {
            // 歩き：前後に入力があるとき
            anim.SetBool("isWalking", Mathf.Abs(moveInput) > 0.1f);
            
            // 押す：箱に触れていて、かつ前進（Wキーなど）の入力があるとき
            // moveInput > 0.1f の部分は、モデルの向きに合わせて < -0.1f に変えるなど調整してください
            bool pushing = isTouchingBox && moveInput > 0.1f;
            anim.SetBool("isPushing", pushing);
        }
    }

    void FixedUpdate()
    {
        // 入力がある場合（移動中）
        if (Mathf.Abs(moveInput) > 0.1f)
        {
            float forceDirection = moveInput * -1f; 
            rb.AddForce(transform.forward * forceDirection * moveSpeed, ForceMode.Acceleration);
        }
        // 入力がない場合（ブレーキ）
        else
        {
            Vector3 currentVelocity = rb.linearVelocity;
            // 0.2fの部分を大きくするほど早く止まり、小さくするほど滑ります
            rb.linearVelocity = Vector3.Lerp(currentVelocity, new Vector3(0, currentVelocity.y, 0), 0.2f);
        }
    }

    // 箱に触れたとき
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("move_box"))
        {
            isTouchingBox = true;
        }
    }

    // 箱から離れたとき
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("move_box"))
        {
            isTouchingBox = false;
        }
    }
}