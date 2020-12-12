using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    private Transform LocalPlayer;
    private Vector3 DesiredPosition = new Vector3(0,0,0);

    [Tooltip("Dealay on Following the Player")]
    public float FollowSpeed;
    [Tooltip("Offset of the Camera mean the distance from the player")]
    public Vector3 Offset;

    private void Start()
    {
        LocalPlayer = GameObject.Find("LocalPlayer").GetComponent<Transform>(); // initialising localPlayer Object
    }

    void FixedUpdate()
    {
        DesiredPosition = LocalPlayer.position + Offset;
        transform.position = Vector3.Lerp(transform.position, DesiredPosition, FollowSpeed);
        
    }
}
