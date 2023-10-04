using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float distance = 5.0f; // Distance from the player
    public float height = 2.0f; // Height above the player
    public float sensitivity = 1.0f; // Mouse sensitivity (you can adjust this)

    private Vector2 rotation = Vector2.zero;
    private const string xAxis = "Mouse X";
    private const string yAxis = "Mouse Y";
    private Transform parentTransform;
    public float yRotationLimit = 88f;
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        parentTransform = transform.parent;
    }

    private void Update()
    {
        rotation.x += Input.GetAxis(xAxis) * sensitivity;
        rotation.y += Input.GetAxis(yAxis) * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -player.GetComponent<MouseLook>().yRotationLimit, player.GetComponent<MouseLook>().yRotationLimit);
        parentTransform.localRotation = Quaternion.Euler(0f, rotation.x, 0f);
        transform.localRotation = Quaternion.Euler(-rotation.y, 0f, 0f);

        Vector3 desiredPosition = player.position - player.forward * distance + Vector3.up * height;
        
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);
    }
}
