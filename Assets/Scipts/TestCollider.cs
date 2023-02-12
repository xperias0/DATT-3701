using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollider : MonoBehaviour
{
    // Start is called before the first frame update

    
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Hand Stay£¡");
    }
}
