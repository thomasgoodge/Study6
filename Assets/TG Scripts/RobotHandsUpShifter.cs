using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotHandsUpShifter : MonoBehaviour
{

    public bool shiftUp = false;

    public GameObject hazardGem;
    public GameObject HazardWarningObject;
    public GameObject parentHandsObject;

    public GameObject thisHand;

    public Vector3 baseHandsPosition;
    public Vector3 HandsUpPosition;

    public int hazardLocation;

    public bool left = false;
    public bool right = false;
    public float  travelSpeed = 0.05f;

    [SerializeField] public Vector3 upShiftYaxis = new Vector3(0f, 0.1f,0f);



    // Start is called before the first frame update
    void Start()
    {  
        HazardWarningObject = GameObject.Find("HazardWarning");
        if (parentHandsObject == null)
        {
            parentHandsObject = GameObject.Find("PaintRobotSocialCue");
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        baseHandsPosition = parentHandsObject.transform.position;  
        HandsUpPosition = baseHandsPosition + upShiftYaxis;
        hazardGem = GameObject.Find("GhostCubie(Clone)");

        hazardLocation = HazardWarningObject.GetComponent<HazardOnsetManager>().hazardLocation;


        thisHand = gameObject;

       
        if (shiftUp == true)
        {
            if (hazardLocation <= 2 && thisHand.name == ("Shifter(L)"))
                {
                    left = true;
                    thisHand.transform.position =  Vector3.Lerp(transform.position, HandsUpPosition, travelSpeed);

                }

        
            if (hazardLocation >= 3 && thisHand.name == ("Shifter(R)"))
                {
                    right = true;
                    thisHand.transform.position =  Vector3.Lerp(transform.position, HandsUpPosition, travelSpeed);
                }
        
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, baseHandsPosition, travelSpeed);
        }
     
        if (hazardGem != null)
        {        
            shiftUp = true;
            
        }
       
        else 
        {

            shiftUp = false;
        }

       
        
        

    }
    

}
