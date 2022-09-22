using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Target of the camera
    public Transform target;
    // Time betwrrn the actual position and de final position
    public float smoothTime = 10f;
    // Adiccional vector to adapt the camera position 
    public Vector3 positionVariation; 

  
    private void LateUpdate()
    {
        Vector3 finalPosition = target.position + positionVariation;
        Vector3 smoothPosition = Vector3.Lerp(this.transform.position, finalPosition, smoothTime*Time.deltaTime);
        this.transform.position = smoothPosition;

        transform.LookAt(target);
    }
}
