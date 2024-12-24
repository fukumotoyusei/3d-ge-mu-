using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 魚（ターゲット）の位置
    public Vector3 offset; // カメラのオフセット位置
    void Update()
    {
        transform.position = target.position + offset; // カメラ位置をターゲット+オフセットに設定
        transform.LookAt(target); // 魚の方向を向く
    }
    void LateUpdate()
    {
        // カメラの位置を更新
        transform.position = target.position + offset;

        // カメラの向きを魚に合わせる
        transform.LookAt(target);

        // カメラの向きが反転しないように調整（必要に応じて）
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);  // Y軸回転のみ
    }
}