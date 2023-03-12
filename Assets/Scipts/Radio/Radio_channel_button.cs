using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio_channel_button : MonoBehaviour
{
    public int num =-1;



    private void OnTriggerStay(Collider other)
    {
        if (num >= 3)
        {
            num = num-3;
            //Debug.Log("Current Channel is: " + num);
        }
        if (other.CompareTag("Player"))
        {
            GameObject.Find("radio").GetComponent<audio>().changeChannel(num++);
            Debug.Log("Current Channel is: " + num);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("radio").GetComponent<audio>().buttonChannel_1.transform.localPosition = new Vector3(-0.5f, 0f, 0);
            //GameObject.Find("radio").GetComponent<audio>().buttonChannel_2.transform.localPosition = new Vector3(-0.1f, 0f, 0);
            //GameObject.Find("radio").GetComponent<audio>().buttonChannel_3.transform.localPosition = new Vector3(-0.2f, 0f, 0);
        }
    }
}

