using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 clickPosition;
    [SerializeField]
    private float jumpPower = 10;
    private bool isCanJump;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }
        if (isCanJump && Input.GetMouseButtonUp(0))
        {
            // クリックした座標と離した座標の差分を取得
            Vector3 dist = clickPosition - Input.mousePosition;
            // クリックとリリースが同じ座標ならば無視
            if (dist.sqrMagnitude == 0) { return; }
            //差分を標準化し、jumpPowerをかけ合わせた値を移動量とする。
            rb.linearVelocity = dist.normalized * jumpPower;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("衝突した");
    }
    private void OnCollisionStay(Collision collision)
    {
        //衝突している点の情報が複数格納されている
        ContactPoint[] contacts = collision.contacts;
        //9番目の衛突情報から、衝突している点の法線を取得。
        Vector3 otherNormal = contacts[0].normal;
        // 上方向を示すベクトル。長さは1。
        Vector3 upVector = new Vector3(0, 1, 0);
        // 上方向と法線の内積。二つのベクトルはともに長さが1なので、
        float dotUN = Vector3.Dot(upVector, otherNormal);
        //内積値に逆三角間数arccosを掛けて角度を算出。それを度数法
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
        if (dotDeg <= 45)
        {
            isCanJump = true;
        }
        Debug.Log("接触中");
    }
    private void OnCollisionExit(Collision collision)
    {
        isCanJump = false;
        Debug.Log("離脱した");
    }

}
