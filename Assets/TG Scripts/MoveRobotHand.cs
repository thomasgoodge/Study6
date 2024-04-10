using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRobotHand : MonoBehaviour
{


    public GameObject targetHandObject;
    public GameObject indexFinger;
    public GameObject fingersLeft;
    public GameObject fingersRight;
    public GameObject HazardWarningObject;
    public GameObject parentHandObject;
    public GameObject visualCueObject;
    public Vector3 baseHandPosition;
    public Vector3 upHandPosition;

    public int hazardLocation;
    public bool hazardStatus = false;

    public float  travelSpeed = 0.05f;
    public float  rotationSpeed = 1.0f;

    public Quaternion handOffset = Quaternion.Euler(-30f, 0f, 0f);
   

    // Start is called before the first frame update
    void Start()
    {
        HazardWarningObject = GameObject.Find("HazardWarning");
        
        if (targetHandObject == null)
                {
                    targetHandObject = GameObject.Find("VisualCue");
                }
          
    }

    // Update is called once per frame
    void Update()
    {
        hazardStatus = HazardWarningObject.GetComponent<HazardOnsetManager>().preHazard;
        hazardLocation = HazardWarningObject.GetComponent<HazardOnsetManager>().hazardLocation;
        transform.LookAt(targetHandObject.transform.position);

            if (hazardLocation <= 2)
                {
                    fingersLeft.SetActive(!hazardStatus);
                    fingersRight.SetActive(true);

                }
            else
                {
                    fingersRight.SetActive(!hazardStatus);
                    fingersLeft.SetActive(true);
                }     

    }



}
