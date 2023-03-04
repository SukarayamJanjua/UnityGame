using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;
    public float xPosition = 0f;
    void Update()
    {

        //Here i assumed that you want to change the X 
        Vector3 newCamPosition = new Vector3(0, cameraTransform.position.y, cameraTransform.position.z);
        gameObject.transform.position = newCamPosition;
    }
}


