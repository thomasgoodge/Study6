using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFindHazard : MonoBehaviour
{
    public GameObject HazardWarningObject;
    public GameObject hazardGem;
    public GameObject robotHead;
    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        HazardWarningObject = GameObject.Find("HazardWarning");
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        hazardGem = GameObject.Find("GhostCubie(Clone)");
        robotHead = GameObject.Find("LaserPointer");


         if (hazardGem != null)
        {
            List<Vector3> pos = new List<Vector3>();
            pos.Add(hazardGem.transform.position + new Vector3(0f, -0.08f,0f));
            pos.Add(robotHead.transform.position);
            line.startWidth = 0.01f;
            line.endWidth = 0.01f;
            line.SetPositions(pos.ToArray());
            line.useWorldSpace = true;
           
            
        }

    }
}
