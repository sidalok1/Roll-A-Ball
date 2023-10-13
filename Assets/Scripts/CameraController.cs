using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private Vector2 mDelta;
    void Start()
    {
        offset = transform.position - player.transform.position; 
    }

    void LateUpdate()
    {
        mDelta = Mouse.current.delta.ReadValue()*Time.smoothDeltaTime;
        Debug.Log(mDelta);
        transform.position = player.transform.position + offset; 
    }
}
