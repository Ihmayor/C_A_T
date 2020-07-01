using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Floater v0.0.2
// by Donovan Keith
//
// [MIT License](https://opensource.org/licenses/MIT)
public class Float : MonoBehaviour
{
    private float amplitude = 0.02f;
    private float frequency = 1f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position += new Vector3(0, Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude, 0);
    }
}
