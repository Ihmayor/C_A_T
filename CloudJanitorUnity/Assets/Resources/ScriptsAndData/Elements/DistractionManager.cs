using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Distractions;

    [SerializeField]
    private Camera targetCam;

    [SerializeField]
    private GameObject targetPlayer;

    [SerializeField]
    private IntVariable numOfDistractors;
    

    public void OnLevelLoad()
    {
        DeleteAllDistractions();
        foreach(GameObject distractor in Distractions)
        {
            populateScreenWithDistractors(distractor, numOfDistractors.Value);
        }

    }

    private void populateScreenWithDistractors(GameObject distractorPrefab, int numberToGenerate)
    {
        Bounds screenBounds = new Bounds(targetCam.WorldToScreenPoint(targetCam.transform.position), new Vector3(Screen.width, Screen.height));
        for(int i = 0; i< numberToGenerate; i++)
        {
            Vector3 newPos = targetCam.ScreenToWorldPoint( generateRandomPlacement(screenBounds));

            while (Physics2D.OverlapPoint(newPos) is CircleCollider2D)
            {
                newPos = targetCam.ScreenToWorldPoint(generateRandomPlacement(screenBounds));
            }

            Instantiate(distractorPrefab, newPos, Quaternion.identity, this.transform);
        }
    }

    private Vector3 generateRandomPlacement(Bounds screenBounds)
    {
        return new Vector3(
        Random.Range(screenBounds.min.x, screenBounds.max.x),
        Random.Range(targetPlayer.transform.position.y+200f, targetPlayer.transform.position.y+screenBounds.max.y*1.5f),
        Random.Range(246.4226f, 246.4226f));
    }

    private void DeleteAllDistractions()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }


}
