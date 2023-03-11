using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumeup : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("radio").GetComponent<audio>().changeVolumeUP();
            Debug.Log("Volume Up");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("radio").GetComponent<audio>().buttonVolumeUp.transform.localPosition = new Vector3(-0.25f, 0f, 0);
        }
    }
}
