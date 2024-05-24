using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBall : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject BallList;
    public void NewBallButton(string type)
    {
        //Create instance of ball and set the type
        GameObject ball = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
        ball.GetComponent<SynthBall>().SetBallType(type);

        //Add ball to list
        BallList.GetComponent<BallList>().AddBallToList(ball);
    }
}
