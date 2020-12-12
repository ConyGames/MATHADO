using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerMovement : MonoBehaviour
{
    private Transform LocalPlayer;
    private Vector3 DesiredPosition = new Vector3(0,0,0);

    [Tooltip("Dealay on Following the Player")]
    public float FollowSpeed;
    [Tooltip("Offset of the Camera mean the distance from the player")]
    public Vector3 Offset;

    
    void Start()
    {
        LocalPlayer = GameObject.Find("LocalPlayer").GetComponent<Transform>(); // initialising localPlayer Object
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DesiredPosition = LocalPlayer.position + Offset;
        transform.position = Vector3.Lerp(transform.position, DesiredPosition, FollowSpeed);
        transform.LookAt(LocalPlayer);
        
    }
}
