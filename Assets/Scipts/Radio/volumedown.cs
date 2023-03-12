using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumedown : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("radio").GetComponent<audio>().changeVolumeDOWN();
            Debug.Log("Volume Down");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("radio").GetComponent<audio>().buttonVolumeDown.transform.localPosition = new Vector3(-0.45f, 0f, 0);
        }
    }
}
