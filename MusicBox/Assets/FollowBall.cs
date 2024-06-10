using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Scrollbar;


public class FollowBall : MonoBehaviour
{
    public float smoothTime = 0.25f;

    public float minZ = 5f; // Minimum z-position for the camera
    public float maxZ = 15f; // Maximum z-position for the camera
    public float zoomSpeed = 1f; // Speed of camera movement with mouse wheel


    private GameObject activeBall = null;
    private Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 0f, -10f);

    }
    private void Update()
    {

        //Get the amount the mouse wheel has been scrolled
        float zoomInput = Input.GetAxis("Mouse ScrollWheel") * 10f;

        if (zoomInput != 0)
        {
            Debug.Log(zoomInput);
            float zoomAmount = zoomInput * zoomSpeed * Time.deltaTime;

            // Calculate the new orthographic size of the camera
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - zoomAmount, minZ, maxZ);

        }

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (activeBall != null)
        {
            FollowActive();
        }
    }

    private void FollowActive()
    {
        //Target position
        Vector2 activePos = activeBall.transform.position;
        Vector3 targetPos = new Vector3(activePos.x, activePos.y, transform.position.z);

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

