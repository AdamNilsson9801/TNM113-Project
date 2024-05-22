using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Pin : MonoBehaviour
{
    public Vector2 position;
    public float size;
    public Color color;
    public string type;

    private TextMeshPro TMP;
    private string chord = null;

    public void Initialize(Vector2 _position, float _size, Color _color, string type)
    {
        position = _position;
        size = _size;
        color = _color;
        this.type = type;
    }

    public void setColor()
    {
        GetComponent<Renderer>().material.color = color;
    }

    public void setChord(string _chord)
    {
        chord = _chord;

        //Change display text
        TMP = GetComponentInChildren<TextMeshPro>();
        if (TMP != null)
        {
            TMP.text = chord;
            if (chord.Length > 1)
            {
                TMP.fontSize = 4f;
            }
        }

    }
    public string getChord()
    {
        return chord;
    }
}

