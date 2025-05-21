using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
    [SerializeField]
    private Image arrowImage;

    private Vector3 clickPosition;

    void Start()
    {
        // ç≈èâÇÕîÒï\é¶Ç…Ç∑ÇÈ
        if (arrowImage != null)
        {
            arrowImage.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (arrowImage == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
            arrowImage.gameObject.SetActive(true); // ï\é¶
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 dist = clickPosition - Input.mousePosition;
            float size = dist.magnitude;
            float angleRad = Mathf.Atan2(dist.y, dist.x);

            arrowImage.rectTransform.position = clickPosition;
            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);
            arrowImage.rectTransform.sizeDelta = new Vector2(size, size);
        }

        if (Input.GetMouseButtonUp(0))
        {
            arrowImage.gameObject.SetActive(false); // îÒï\é¶
        }
    }
}
