using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        DestroySelf();
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

}
