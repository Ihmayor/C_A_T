using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffTargetAffector : MonoBehaviour
{
    public GameObject target;

    /// <summary>
    /// Target Starts Flying/floating
    /// </summary>
    public void OnFlyStart()
    {
        target.transform.position += new Vector3(0, 0.75f, 0);
        Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        target.AddComponent<Float>();
    }

    /// <summary>
    /// Target Stops Flying/floating
    /// </summary>
    public void OnFlyEnd()
    {
        Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
        Destroy(target.GetComponent<Float>());
    }
}
