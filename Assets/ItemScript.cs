using UnityEngine;

public class ItemScript : MonoBehaviour
{

    private Animator animator;

    void Start()
    {

        animator = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("Get");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

}
