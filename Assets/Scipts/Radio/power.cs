using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power : MonoBehaviour
{


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("radio").GetComponent<audio>().Power();
            Debug.Log("Power");
        }
        //Debug.Log("Power2");

    }
    



    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("radio").GetComponent<audio>().buttonPower.transform.localPosition = new Vector3(0.1f, 0f, 0);
        }
    }
}
