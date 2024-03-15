using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{

    public Transform targetObject;
  
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targetObject);
    }
}
