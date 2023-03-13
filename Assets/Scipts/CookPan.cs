using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookPan : MonoBehaviour
{
    // Start is called before the first frame update

    bool isOpened = false;
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag== "cooable") {        
    //        collision.transform.GetComponent<Rigidbody>().isKinematic = true;
    //        collision.transform.GetComponent<Rigidbody>().isKinematic = false;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cookable")
        {
            other.transform.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.GetComponent<Rigidbody>().isKinematic = false;
            Debug.Log(other.name+" enter");
        }
    }


    private void OnTriggerStay(Collider other)
    {
        isOpened = GameObject.Find("fireButton").GetComponent<ButtonEnableParticle>().isOpen;
        if (other.gameObject.tag == "cookable" && isOpened)
        {
            Cookable b = other.gameObject.GetComponent<Cookable>();
            b.cookTime += Time.fixedDeltaTime;
            Debug.Log(other.gameObject.name + " on Pan: ");
        }
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    isOpened = GameObject.Find("fireButton").GetComponent<ButtonEnableParticle>().isOpen;
    //    if (collision.gameObject.tag == "cooable" && isOpened) {
    //        Cookable b = collision.gameObject.GetComponent<Cookable>();
    //        b.cookTime += Time.fixedDeltaTime;
    //        Debug.Log(collision.gameObject.name+" on Pan: " );
    //    }
    //}
}
