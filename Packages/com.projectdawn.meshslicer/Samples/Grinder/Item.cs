using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float3 Velocity;
    public float Drag;

    void Update()
    {
        float3 gravity = 10;

        // Add gravity
        Velocity += gravity * Time.deltaTime;


    }
}
