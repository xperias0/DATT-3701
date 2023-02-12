using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salt : MonoBehaviour
{
    public float timer = 10.0f;

    private float currentTimer = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        currentTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer -= Time.deltaTime;

        if (currentTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
