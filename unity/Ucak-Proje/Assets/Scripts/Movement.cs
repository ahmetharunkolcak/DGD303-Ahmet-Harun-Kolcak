using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket h�z�
    public float rotationSpeed = 700f; // D�n�� h�z�

    private void Update()
    {
        // Y�n tu�lar� (WASD) ile hareket
        float horizontal = Input.GetAxis("Horizontal"); // A ve D tu�lar�
        float vertical = Input.GetAxis("Vertical"); // W ve S tu�lar�

        // Hareket vekt�r� olu�turma
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

        // Normalizasyon (�apraz hareketlerde h�z�n artmas�n� engeller)
        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }

        // Karakteri hareket ettirme
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // Karakteri hareket etti�i y�ne d�nd�rme
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
