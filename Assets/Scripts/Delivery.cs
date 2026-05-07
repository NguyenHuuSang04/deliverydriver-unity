using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float destroyDelay = 0.5f;
    // [SerializeField] Color32 notHasPackageColor = new Color32(1, 1, 1, 1);
    // [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField] Sprite carDefaultSprite; // hình xe ban đầu
    [SerializeField] Sprite carCarryingSprite; // hình xe khi đang chở hàng
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Va chạm vào: " + other.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            // spriteRenderer.color = hasPackageColor;
            spriteRenderer.sprite = carCarryingSprite; // Đổi hình xe
            Destroy(other.gameObject, destroyDelay);


        }
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            // spriteRenderer.color = notHasPackageColor;
            spriteRenderer.sprite = carDefaultSprite; // trả về hình cũ
        }

    }
}
