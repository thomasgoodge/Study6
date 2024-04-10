using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotHandsPointer : MonoBehaviour
{


    public bool faceScreen = false;
        public float  rotationSpeed = 1.0f;

    public GameObject handsCueObject;

    // Start is called before the first frame update
    void Start()
    {
        if (handsCueObject == null)
        {
            handsCueObject = GameObject.Find("Base");
        }
        if (handsCueObject == null)
        {
            handsCueObject = GameObject.Find("VisualCue");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (handsCueObject != null && faceScreen == true)
    {
        RotateTowards(handsCueObject.transform.position);
    }
    }


      public void HandsFaceScreen()
    {
        faceScreen = true;
    }

    void RotateTowards(Vector3 targetPosition)
    {
        Vector3 targetDirection = targetPosition - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        
        
        // Use Lerp to smoothly interpolate between the current rotation and the target rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
