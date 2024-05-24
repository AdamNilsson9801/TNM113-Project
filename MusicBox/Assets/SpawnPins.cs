using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPins : MonoBehaviour
{
    public GameObject pinPrefab;
    public GameObject environment;

    public int numberOfPins;
    public float distToBoundary = 2f;

    private float minX, maxX, minY, maxY;
    private string[] pinTypes = { "chord", "tone" };
    private string[] majorChords = { "C", "G", "D", "A", "E", "B", "Fiss", "Ciss", "F", "Bess" };
    private string[] minorChords = { "A", "E", "B", "Fiss", "Ciss", "Giss", "Diss", "Bess", "F", "C" };

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

        spawnPins();
    }

    private void spawnPins()
    {
        for (int i = 0; i < numberOfPins; i++)
        {
            Vector2 spawnPos = new Vector2(Random.Range(minX, maxX),
                                            Random.Range(minY, maxY));

            GameObject pin = Instantiate(pinPrefab, spawnPos, Quaternion.identity);

            //if (pin != null)
            //{
            //    string randType = pinTypes[(int)Random.Range(0f, pinTypes.Length)];  

            //    if (randType == pinTypes[0]) //if chord pin
            //    {
            //        pin.GetComponent<Pin>().Initialize(spawnPos, 0.5f, Color.green, "chord");
            //        pin.GetComponent<Pin>().setColor();
            //        pin.GetComponent<Pin>().setChord(majorChords[(int)Random.Range(0, majorChords.Length)]);
            //    }
            //    else
            //    {
            //        pin.GetComponent<Pin>().Initialize(spawnPos, 0.5f, Color.blue, "tone");
            //        pin.GetComponent<Pin>().setColor();
            //    }

            //}

        }
    }

}
