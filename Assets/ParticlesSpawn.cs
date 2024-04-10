using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject HazardWarningObject;
    [SerializeField] Vector3 currentVectorPosition;
        [SerializeField] public Vector3 yOffsetpart = new Vector3(0f, 0f, 0f);


    public bool playedPart = false;
    public bool hazardStatus = false;




    [SerializeField] ParticleSystem Particles;
    void Start()
    {
        hazardStatus = false;
    }

    // Update is called once per frame
    void Update()
    {
        hazardStatus = HazardWarningObject.GetComponent<HazardOnsetManager>().preHazard;

        if (hazardStatus == true && !playedPart)
        {
            Instantiate(Particles);
            playedPart = true;
        }
        if (hazardStatus == true)
    {
        Particles.transform.position = currentVectorPosition + yOffsetpart;

    }
else if (hazardStatus == false)
{
    playedPart = false;       
    transform.position = transform.position;
   

}

    }
}
