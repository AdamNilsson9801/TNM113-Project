using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class BallList : MonoBehaviour
{
    private List<GameObject> balls = new List<GameObject>();

    public void AddBallToList(GameObject ball)
    {
        balls.Add(ball);
    }

    public List<GameObject> GetList()
    {
        return balls;
    }

    private int ObjectIndex(GameObject obj)
    {
        return balls.IndexOf(obj);
    }

    private bool NextExists(int ind)
    {
        if (ind + 1 < balls.Count)
        {
            return true;
        }

        return false;
    }

    private bool PrevExists(int ind)
    {
        if (ind - 1 >= 0)
        {
            return true;
        }

        return false;
    }

    public GameObject GetNextBall(GameObject obj)
    {
        int index = ObjectIndex(obj);

        if (NextExists(index))
        {
            return balls[index + 1];
        }

        return null;
    }

    public GameObject GetPrevBall(GameObject obj)
    {
        int index = ObjectIndex(obj);

        if (PrevExists(index))
        {
            return balls[index - 1];
        }

        return null;
    }
}
