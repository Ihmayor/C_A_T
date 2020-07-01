using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.5f;
    public float lookAboveFactor = 0.4f;
    
    public float boundaryMax;
    public float boundaryMin;


    private Vector3 startPosition;

    private void Start()
    {
        transform.parent = null;
        startPosition = transform.position;
    }

    public void ResetCamera()
    {
        transform.position = startPosition; 
    }

    private void FixedUpdate()
    {
        BoundWatch();
    }

    private void BoundWatch()
    {
        float maxSetY = target.position.y + lookAboveFactor;
        float minSetY = target.position.y - lookAboveFactor;

        float deltaY = target.position.y - transform.position.y;

        Vector3 delta = Vector3.zero;

        if (maxSetY > boundaryMax || minSetY < boundaryMin)
        {
            if (transform.position.y < target.position.y)
            {
                delta.y = deltaY - lookAboveFactor;
            }
            else
            {
                delta.y = deltaY + lookAboveFactor;
            }
          //   StartCoroutine(SmoothPosition(transform.position + delta, 0.1f));
        }
        transform.position += delta;
    }

    private IEnumerator SmoothPosition(Vector3 newPosition, float time)
    {
        float elapsedTime = 0;
        Vector3 startingPos = transform.position;
        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, newPosition, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    private void CloseWatch()
    {
        float offsetY = target.position.y + lookAboveFactor;

        Vector3 desiredPosition = new Vector3(transform.position.x, offsetY, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }



}
