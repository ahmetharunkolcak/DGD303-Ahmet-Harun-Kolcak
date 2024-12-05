using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hýzý
    public float rotationSpeed = 700f; // Dönüþ hýzý

    private void Update()
    {
        // Yön tuþlarý (WASD) ile hareket
        float horizontal = Input.GetAxis("Horizontal"); // A ve D tuþlarý
        float vertical = Input.GetAxis("Vertical"); // W ve S tuþlarý

        // Hareket vektörü oluþturma
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

        // Normalizasyon (Çapraz hareketlerde hýzýn artmasýný engeller)
        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }

        // Karakteri hareket ettirme
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // Karakteri hareket ettiði yöne döndürme
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
