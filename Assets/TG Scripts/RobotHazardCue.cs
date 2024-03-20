using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotHazardCue : MonoBehaviour
{
    //Script to make an object move between two points defined in the Unity playspace

    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 0.5f;


    [SerializeField] float speed = 0.5f;

    [SerializeField] float amount = 0.01f;

    public Renderer rend;
    public bool hazardStatus = false;

    public bool playedPart = false;
    public GameObject HazardOnsetManagerScript;

    [SerializeField] Vector3 currentVectorPosition;


    [SerializeField] ParticleSystem Particles;
    [SerializeField] public float yOffsetpart = 0f;


    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;

        playedPart = false;
        rend.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
       // Oscillate();
        currentVectorPosition = this.transform.position;
        

        hazardStatus = HazardOnsetManagerScript.GetComponent<HazardOnsetManager>().preHazard;

        
if (hazardStatus == true && !playedPart)
{
    Instantiate(Particles);
    playedPart = true;
}

if (hazardStatus == true)
{
    transform.position = new Vector3(Mathf.Sin(Time.time * speed) * amount, transform.position.y, transform.position.z);
    rend.enabled = true;
    Particles.transform.position = currentVectorPosition + new Vector3(0f, yOffsetpart, 0f);
    
}
else if (hazardStatus == false)
{
    playedPart = false;
    rend.enabled = false;
    transform.position = transform.position;
}

        
    }


}
