using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActiveBall : MonoBehaviour
{
    public GameObject list;
    public Camera cam;

    public void NextBall()
    {

        GameObject currentActive = cam.GetComponent<FollowBall>().GetActiveBall();

        if (currentActive != null)
        {

            //Get index
            GameObject nextBall = list.GetComponent<BallList>().GetNextBall(currentActive);

            if (nextBall != null)
            {
                cam.GetComponent<FollowBall>().SetActiveBall(nextBall);
            }
            else
            {
                Debug.Log("NextBall not exists");
            }
        }
    }
    public void PrevBall()
    {

        GameObject currentActive = cam.GetComponent<FollowBall>().GetActiveBall();

        if (currentActive != null)
        {

            //Get index
            GameObject prevBall = list.GetComponent<BallList>().GetPrevBall(currentActive);

            if (prevBall != null)
            {
                cam.GetComponent<FollowBall>().SetActiveBall(prevBall);
            }
            else
            {
                Debug.Log("PrevBall not exists");
            }
        }
    }
}
