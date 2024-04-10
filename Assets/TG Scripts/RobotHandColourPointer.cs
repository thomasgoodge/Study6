using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotHandColourPointer : MonoBehaviour
{

        public bool runningBase = false;
        public GameObject targetHandBaseObject;
            public GameObject HazardWarningObject;



    // Start is called before the first frame update
    void Start()
    {
                if (targetHandBaseObject == null)
                {
                    targetHandBaseObject = GameObject.Find("AOI(BottomCentre)");
                }
        
    }

    // Update is called once per frame
    void Update()
    {
        runningBase = HazardWarningObject.GetComponent<HazardOnsetManager>().stopwatchRunning;

        if (runningBase)
        {
            transform.LookAt(targetHandBaseObject.transform.position);
        }
        
    }
}
