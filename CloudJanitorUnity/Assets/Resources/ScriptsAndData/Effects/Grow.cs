using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    private float amplitude = 1.5f;
    private float frequency = 1f;

    // Position Storage Variables
    Vector3 localScaleOffset = new Vector3();
    Vector3 tempScale = new Vector3();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        localScaleOffset = transform.localScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Float up/down with a Sin()
        tempScale = localScaleOffset;
        tempScale.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        tempScale.x += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        gameObject.transform.localScale = tempScale;
    }
    
    
    IEnumerator LerpScale(Vector3 scale,float time)
    {
        Vector3 startingScale = transform.localScale;

        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            transform.localScale = Vector3.Lerp(startingScale, scale, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
