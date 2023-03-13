using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sauce : MonoBehaviour
{
    public ParticleSystem system;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.rotation.x>0.7|| gameObject.transform.rotation.z > 0.7)
        {

            system.Play(true);
            Debug.Log(gameObject.transform.rotation.x);
        }
        else
        {
            system.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            Debug.Log(gameObject.transform.rotation.x);
        }
    }
}
