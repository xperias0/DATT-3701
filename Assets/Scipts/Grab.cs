
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    bool isMatAdded = false;

    Dictionary<GameObject, List<Material>> objAndMats; 

    bool isRecovered = false;

    GameObject touchedObj= null;


    float timer = 0;
    [HideInInspector]
    public GameObject grabObject = null;

    Material mat;

    List<Material> Allmats;

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

        objAndMats = new Dictionary<GameObject, List<Material>>();
    }     
    private void Update()
    {

        Vector3 vloc = (hand.transform.position - lastHandPos).magnitude*1.4f*(hand.transform.position-lastHandPos).normalized;
        lastHandPos = hand.transform.position;

  

        if (grabObject&& !GameObject.Find("WhiteHand").GetComponent<HandController>().isGrab) {
          //  grabObject.GetComponent<Rigidbody>().AddForce(vloc, ForceMode.Impulse);
            grabObject.transform.parent = null;
            grabObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
            grabObject.gameObject.GetComponent<Rigidbody>().freezeRotation = false;
            grabObject = null;
            touchedObj= null;
        
          //  Debug.Log("TImer: "+timer);
        }
       
    
        
    }
    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
    
        touchedObj = other.gameObject;
        Material curMAt =null;
       
        if (!isMatAdded&&!isRecovered) {

            if (touchedObj.transform.childCount == 0)
            {

                List<Material> list = new List<Material>();
                list.Add(mat);
                Material[] mats = touchedObj.GetComponent<Renderer>().materials;

                foreach (Material m in mats)
                {
                    list.Add(m);
                }
                objAndMats.Add(touchedObj, list);

                touchedObj.GetComponent<Renderer>().materials = objAndMats[touchedObj].ToArray();
            }
            else {
               
                for (int i=0;i<touchedObj.transform.childCount;i++) {
                    if (!touchedObj.transform.GetComponent<Renderer>()) {
                        
                        GameObject t = touchedObj.transform.GetChild(i).gameObject;
                        if (t.tag=="childPart") {
                            List<Material> list = new List<Material>();
                            list.Add(mat);
                            foreach (Material m in t.GetComponent<Renderer>().materials) {
                            list.Add(m);
                            }

                            objAndMats.Add(t, list);
                            t.GetComponent<Renderer>().materials = list.ToArray();
                        }
                   
                    }
                
                }
            
            }

            isMatAdded = true;
        
        }

        if (isMatAdded) {
            
            if (objAndMats.Count == 1)
            {
                if (touchedObj.GetComponent<Renderer>()) {
                curMAt = touchedObj.GetComponent<Renderer>().material;
                }
                else
                {
                    curMAt = touchedObj.transform.GetChild(0).GetComponent<Renderer>().material;
                }
                string s = curMAt.name.Substring(0,4);
                
                if (s=="glow")
                {
                    float indes = Mathf.Lerp(curMAt.GetFloat("_Emiss"), target, Time.deltaTime * turnSpeed);
                    if (Mathf.Abs(target - curMAt.GetFloat("_Emiss")) < 0.02f)
                    {
                        target = target == max ? min : max;
                    }
                    curMAt.SetFloat("_Emiss", indes);
                    Debug.Log("GLow: " + indes);
                }



            }
            else
            {
                foreach (GameObject b in objAndMats.Keys)
                {
                    Material curM = b.GetComponent<Renderer>().material;
                    string s = curM.name.Substring(0, 4);
                    if (s=="glow")
                    {
                        float indes = Mathf.Lerp(curM.GetFloat("_Emiss"), target, Time.deltaTime * turnSpeed);
                        if (Mathf.Abs(target - curM.GetFloat("_Emiss")) < 0.02f)
                        {
                            target = target == max ? min : max;
                        }
                        curM.SetFloat("_Emiss", indes);

                    }
                }

              //    Debug.Log("GLow: " );
            }

        }
       
    


        if (other.gameObject.tag == "Grable" && grabObject == null && GameObject.Find("WhiteHand").GetComponent<HandController>().isGrab)
        {
            grabObject = other.gameObject;
             grabObject.gameObject.GetComponent<Rigidbody>().velocity= Vector3.zero;
            if (!isRecovered) {
                resetMat(grabObject, grabObject.transform.childCount);
                isRecovered = true;
            }         
            grabObject.transform.parent = transform;
            grabObject.gameObject.GetComponent<Rigidbody>().useGravity = false;
            grabObject.gameObject.GetComponent<Rigidbody>().freezeRotation = true;

            Debug.Log("grab: " + grabObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (touchedObj&&!isRecovered) {
            resetMat(touchedObj,touchedObj.transform.childCount);
        }
        other.transform.parent = null;
        other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        other.gameObject.GetComponent<Rigidbody>().freezeRotation = false;


        grabObject = null;
        touchedObj = null;
        isRecovered = false;
        isMatAdded= false;
     //   timer = Time.time;
      //  Debug.Log(other.name+" exit");
    }


    void resetMat(GameObject obj, int childCount)
    {

        if (childCount == 0)
        {
            foreach (GameObject b in objAndMats.Keys) {
                objAndMats[b].RemoveAt(0);
            }

            obj.GetComponent<Renderer>().materials = objAndMats[obj].ToArray();
        }

        else {
            foreach (GameObject b in objAndMats.Keys ) {
                objAndMats[b].RemoveAt(0);
                b.GetComponent<Renderer>().materials = objAndMats[b].ToArray();
            }    
        }

        objAndMats.Clear();
       isRecovered= true;
        isMatAdded = false;
  
    }
}
