using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPins : MonoBehaviour
{
    public GameObject pinPrefab;
    public GameObject environment;

    public int numberOfPins;
    public float distToBoundary = 2f;

    private List<GameObject> pinList = new List<GameObject>();
    private float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        if (environment != null)
        {
            minX = environment.transform.GetChild(0).transform.position.x + distToBoundary;
            maxX = environment.transform.GetChild(1).transform.position.x - distToBoundary;
            maxY = environment.transform.GetChild(2).transform.position.y - distToBoundary;
            minY = environment.transform.GetChild(3).transform.position.y + distToBoundary;
        }
    }

    public void spawnPins()
    {
        if (pinList.Count != 0)
        {
            //Remove all pins in list
            foreach (GameObject pin in pinList)
            {
                Destroy(pin);
            }
        }

        for (int i = 0; i < numberOfPins; i++)
        {
            Vector2 spawnPos = new Vector2(Random.Range(minX, maxX),
                                           Random.Range(minY, maxY));

            GameObject pin = Instantiate(pinPrefab, spawnPos, Quaternion.identity);

            pinList.Add(pin);
        }
    }
}
