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
        //�Փ˂��Ă���_�̏�񂪕����i�[����Ă���
        ContactPoint[] contacts = collision.contacts;
        //9�Ԗڂ̉q�ˏ�񂩂�A�Փ˂��Ă���_�̖@�����擾�B
        Vector3 otherNormal = contacts[0].normal;
        // ������������x�N�g���B������1�B
        Vector3 upVector = new Vector3(0, 1, 0);
        // ������Ɩ@���̓��ρB��̃x�N�g���͂Ƃ��ɒ�����1�Ȃ̂ŁA
        float dotUN = Vector3.Dot(upVector, otherNormal);
        //���ϒl�ɋt�O�p�Ԑ�arccos���|���Ċp�x���Z�o�B�����x���@
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
        if (dotDeg <= 45)
        {
            isCanJump = true;
        }
        Debug.Log("�ڐG��");
    }
    private void OnCollisionExit(Collision collision)
    {
        isCanJump = false;
        Debug.Log("���E����");
    }

}
