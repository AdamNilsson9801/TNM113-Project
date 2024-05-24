using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public float smoothTime = 0.25f;
    public float camPosZ = -10f;

    private List<GameObject> balls = new List<GameObject>();
    private GameObject activeBall = null;
    private Vector3 velocity = Vector3.zero;
    private Vector3 offset = new Vector3(0,0, -10);


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 0f, -10f);

    }

    // Update is called once per frame
    void LateUpdate()
    {
       if(activeBall != null)
        {
            FollowActive();
        } 
    }

    private void FollowActive()
    {
        //Target position
        Vector2 activePos = activeBall.transform.position;
        Vector3 targetPos = new Vector3(activePos.x, activePos.y, camPosZ);

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }

    public void SetActiveBall(GameObject _activeBall)
    {
        activeBall = _activeBall;
    }

    public GameObject GetActiveBall()
    {
        return activeBall;
    }
}

