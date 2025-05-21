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
            // �N���b�N�������W�Ɨ��������W�̍������擾
            Vector3 dist = clickPosition - Input.mousePosition;
            // �N���b�N�ƃ����[�X���������W�Ȃ�Ζ���
            if (dist.sqrMagnitude == 0) { return; }
            //������W�������AjumpPower���������킹���l���ړ��ʂƂ���B
            rb.linearVelocity = dist.normalized * jumpPower;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("�Փ˂���");
    }
    private void OnCollisionStay(Collision collision)
    {
        isCanJump = true;
        Debug.Log("�ڐG��");
    }
    private void OnCollisionExit(Collision collision)
    {
        isCanJump = false;
        Debug.Log("���E����");
    }

}
