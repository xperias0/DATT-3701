using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class text : MonoBehaviour
{
    // Start is called before the first frame update
   
    
    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Time :"+Time.time.ToString("f2");
    }
}
