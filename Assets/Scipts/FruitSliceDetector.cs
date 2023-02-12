using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSliceDetector : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer==7) {
            GameObject.Find("Canvas").GetComponent<ScoreManager>().addScore(5);

          //  other.transform.parent = transform;
        }
    }
}
