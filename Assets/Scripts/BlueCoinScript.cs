using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BlueCoinScript : MonoBehaviour
{
    public float rotationSpeed = 90.0f;

    void Start()
    {
        gameObject.tag = "BlueCoinTag";
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    void Update()
    {
        float rotationAngle = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotationAngle);
        
    }
}
