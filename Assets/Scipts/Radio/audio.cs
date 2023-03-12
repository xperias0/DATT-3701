using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class audio : MonoBehaviour
{
    public List<AudioClip> sources;

    public AudioSource AudioSource;
    private float radioVolume = 0.1f;

    private bool power;



    //button press position
    public GameObject buttonPower;
    public GameObject buttonVolumeUp;
    public GameObject buttonVolumeDown;
    public GameObject buttonChannel_1;
    public GameObject buttonChannel_2;
    public GameObject buttonChannel_3;



    //public UnityEvent onPress;
    //public UnityEvent onRelease;
    public AudioSource sound_button;
    bool isPressed;





    public void changeChannel(int num)
    {
        GetComponent<AudioSource>().clip = sources[num];
        GetComponent<AudioSource>().Play();
        sound_button.Play();

        if (num == 0)
        {
            buttonChannel_1.transform.localPosition = new Vector3(-0.5f, -0.05f, 0);
            Debug.Log("Current Channel: " + sources[num]);
        }

        if (num == 1)
        {
            buttonChannel_1.transform.localPosition = new Vector3(-0.5f, -0.05f, 0);
            Debug.Log("Current Channel: " + sources[num]);
        }

        if (num == 2)
        {
            buttonChannel_1.transform.localPosition = new Vector3(-0.5f, -0.05f, 0);
            Debug.Log("Current Channel: " + sources[num]);
        }

    }

    public void changeVolumeUP()
    {
        AudioSource.volume += radioVolume;
        sound_button.Play();
        buttonVolumeUp.transform.localPosition = new Vector3(-0.25f, -0.05f, 0);

    }
    public void changeVolumeDOWN()
    {
        AudioSource.volume -= radioVolume;
        sound_button.Play();
        buttonVolumeDown.transform.localPosition = new Vector3(-0.45f, -0.05f, 0);
    }

    public void Power()
    {
        if (GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Pause();
            sound_button.Play();
            buttonPower.transform.localPosition = new Vector3(0.1f, -0.05f, 0);

        }
        else
        {
            GetComponent<AudioSource>().UnPause();
            sound_button.Play();
            buttonPower.transform.localPosition = new Vector3(0.1f, -0.05f, 0);
        }
    }

    public void Start()
    {
        AudioSource.volume = 0.1f;
        GetComponent<AudioSource>().clip = sources[0];
        AudioSource.Play();

    }
}
