using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public Vector2 position;
    public float size;
    public Color color;

    public Pin(Vector2 _position, float _size, Color _color)
    {
        position = _position;
        size = _size;
        color = _color;
    }
}

