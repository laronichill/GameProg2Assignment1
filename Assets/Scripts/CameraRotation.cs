using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float Sensitivity {
        get { return sensitivity; }
        set { sensitivity = value; }
    }
    public float sensitivity = 1f;
    public float yRotationLimit = 88f;
    private Vector2 rotation = Vector2.zero;
    private const string xAxis = "Mouse X";
    private const string yAxis = "Mouse Y";
    private Transform parentTransform;
    
    private void Start()
    {
        parentTransform = transform.parent;
    }

    private void Update()
    {
        rotation.x += Input.GetAxis(xAxis) * sensitivity;
        rotation.y += Input.GetAxis(yAxis) * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
        parentTransform.localRotation = Quaternion.Euler(0f, rotation.x, 0f);
        transform.localRotation = Quaternion.Euler(-rotation.y, 0f, 0f);
    }
}
