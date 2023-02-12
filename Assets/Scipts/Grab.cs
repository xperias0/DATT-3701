
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Grab : MonoBehaviour
{
    // Start is called before the first frame update

    private static Grab m_instance = null;

    Vector3 lastHandPos;

    GameObject hand;

     public float min = 0.01f;

    public float max = 2f;

    float target = 0;

    public float turnSpeed;

    bool isAdded = false;

    bool isForced = false;

    bool isRecovered = false;

    GameObject touchedObj= null;


    float timer = 0;
    [HideInInspector]
    Material mat;

    List<Material> Allmats;

    public GameObject grabObject = null;
    public static Grab Instance
    {
        get
        {
            return m_instance;
        }
    }
    void Start()
    {
        hand = GameObject.Find("WhiteHand");

        mat = GameObject.Find("mat").GetComponent<Renderer>().material;

        target = max;

        Allmats= new List<Material>();
   
        lastHandPos = hand.transform.position;
    }     
    private void Update()
    {

        Vector3 vloc = (hand.transform.position - lastHandPos).magnitude*1.4f*(hand.transform.position-lastHandPos).normalized;
        lastHandPos = hand.transform.position;

  

        if (grabObject&& !GameObject.Find("WhiteHand").GetComponent<HandController>().isGrab) {
            grabObject.GetComponent<Rigidbody>().AddForce(vloc, ForceMode.Impulse);
            grabObject.transform.parent = null;
            grabObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
            grabObject.gameObject.GetComponent<Rigidbody>().freezeRotation = false;

            timer = Time.time;
            Debug.Log("TImer: "+timer);
        }
       
        if (Time.time - timer == 2f)
        {
            grabObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Debug.Log("Cur: " + timer + " TIme: " + Time.time);
        }
        
    }
    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
    
        touchedObj = other.gameObject;
        Material curMAt = null;
        if (!isAdded&&!isRecovered) {
            Allmats.Add(mat);
            foreach (Material m in touchedObj.GetComponent<Renderer>().materials)
            {
                Allmats.Add(m);
            }

            if (touchedObj.transform.childCount != 0)
            {
                touchedObj.transform.GetChild(0).GetComponent<Renderer>().materials = Allmats.ToArray();
                 curMAt = touchedObj.transform.GetChild(0).GetComponent<Renderer>().material;
            }
            else {
                touchedObj.GetComponent<Renderer>().materials = Allmats.ToArray();
                 curMAt = touchedObj.GetComponent<Renderer>().material;
            }
           
            isAdded= true;
        }
        if (curMAt!=null) {
            float indes = Mathf.Lerp(curMAt.GetFloat("_Emiss"), target, Time.deltaTime * turnSpeed);
            if (Mathf.Abs(target - curMAt.GetFloat("_Emiss")) < 0.02f)
            {
                target = target == max ? min : max;
            }
            curMAt.SetFloat("_Emiss", indes);
        }

       


        if (other.gameObject.tag == "Grable" && grabObject == null && GameObject.Find("WhiteHand").GetComponent<HandController>().isGrab)
        {
            grabObject = other.gameObject;

            resetMat(grabObject);
            isRecovered= true;
            grabObject.transform.parent = transform;
            grabObject.gameObject.GetComponent<Rigidbody>().useGravity = false;
            grabObject.gameObject.GetComponent<Rigidbody>().freezeRotation = true;

            Debug.Log("grab: " + grabObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (touchedObj) {
            resetMat(touchedObj);
        }
        other.transform.parent = null;
        other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        other.gameObject.GetComponent<Rigidbody>().freezeRotation = false;

        if (grabObject) {
        
        //  grabObject.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
         
           grabObject = null;
           isForced= false;
        }
        isRecovered = false;
     //   timer = Time.time;
      //  Debug.Log(other.name+" exit");
    }


    void resetMat(GameObject obj) {
        if (Allmats.Count>1) {
            Allmats.RemoveAt(0);
        }
        
        if (obj.transform.childCount != 0)
        {
            
            if (Allmats.Count != 0) {
                obj.transform.GetChild(0).GetComponent<Renderer>().materials = Allmats.ToArray();

            }
        }
        else {
            if (Allmats.Count!=0) {
                obj.GetComponent<Renderer>().materials = Allmats.ToArray();
            }
        }
        Debug.Log("Mats Clear");
        Allmats.Clear();
        isAdded = false;
    }

}
