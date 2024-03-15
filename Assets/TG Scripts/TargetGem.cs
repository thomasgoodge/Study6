using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGem : MonoBehaviour
{
/*
    public GameObject targetGem;
    public GameObject targetGem2;
    public GameObject hazardGem;
    public GameObject scanGem;
*/
    public GameObject visualCueObject;

    public GameObject centreGem;

    public GameObject thisHead;

    public GameObject HazardWarningObject;

    public GameObject userCamera;

    public MeshRenderer RobotMesh;

    public float  rotationSpeed = 1.0f;

    public Vector3 SearchTarget;

    public Transform targetCamera;

    public bool faceScreen = false;

    public bool showHead = true;

    public Vector3 CentreTarget = new Vector3(0f, 0f, 0.5f);
    // Start is called before the first frame update
    void Start()
    {
        
        thisHead = GameObject.Find("Robot_Guardian");
       
        transform.LookAt(targetCamera);
        showHead = true;

        if (visualCueObject == null)
        {
            visualCueObject = GameObject.Find("VisualCue");
        }
        if (visualCueObject == null)
        {
            visualCueObject = GameObject.Find("TargetVisualCue");
        }
     
    }

    // Update is called once per frame
    void Update()
    {
        //visualCue = GameObject.Find("VisualCue");
        /*
        hazardGem = GameObject.Find("GhostCubie(Clone)");
        targetGem = GameObject.Find("Hexgon(Clone)");
        targetGem2 = GameObject.Find("Penta(Clone)");
        scanGem = GameObject.Find("ScanCubie(Clone)");
        centreGem = GameObject.Find("FOE");
        */


    //SearchTarget = targetGem.transform.position +  new Vector3(0.1f,0.1f,0f);
    if (visualCueObject != null && faceScreen == true)
    {
        RotateTowards(visualCueObject.transform.position);
    }
//    tile.transform.position = new Vector3(tile.transform.position.x + 1, tile.transform.position.y, tile.transform.position.z);
        
    
        showHead = HazardWarningObject.GetComponent<HazardOnsetManager>().stopwatchRunning;

        if (showHead == false)
            {
                 RobotMesh.enabled = false;
            }
        else if (showHead == true)
            {
                RobotMesh.enabled = true;
            }
        else
        {
            RobotMesh.enabled = true;
        }
        
    }
  

    void RotateTowards(Vector3 targetPosition)
    {
        Vector3 targetDirection = targetPosition - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        
        
        // Use Lerp to smoothly interpolate between the current rotation and the target rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void HeadFaceScreen()
    {
        faceScreen = true;
    }

}


