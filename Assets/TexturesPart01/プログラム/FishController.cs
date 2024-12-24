using UnityEngine;

public class FishController : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度
    public float turnSpeed = 100f; // 回転速度
    public float verticalSpeed = 3f; // 上下移動速度

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbodyコンポーネントを取得
    }

    void Update()
    {
        // 水平方向（左右前後）の移動
        float moveX = Input.GetAxis("Horizontal"); // A/Dまたは左右矢印キー
        float moveZ = Input.GetAxis("Vertical"); // W/Sまたは上下矢印キー
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        // 魚の移動
        rb.velocity = moveDirection * moveSpeed;

        // マウスで魚の向きを調整
        float turn = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;
        transform.Rotate(0f, turn, 0f);

        // 上下移動
        float moveY = 0f;
        if (Input.GetKey(KeyCode.Space)) // スペースキーで上に移動
        {
            moveY = verticalSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftControl)) // 左Ctrlで下に移動
        {
            moveY = -verticalSpeed;
        }

        // 上下方向の移動を加える
        rb.velocity = new Vector3(rb.velocity.x, moveY, rb.velocity.z);
    }
}
