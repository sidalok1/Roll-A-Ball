using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed; 
    public TextMeshProUGUI countText;
    private Rigidbody rb; 
    private int count;
    private float movementX;
    private float movementY;
    [SerializeField] private float jumpVal = 5;
    private bool onGround = true;
    private Vector3 spawn;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        spawn = rb.position;
        count = 0;
        SetCountText();
    }

    private void FixedUpdate() 
   {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed); 
        
   }

   void OnTriggerEnter(Collider other) 
   {
     if (other.gameObject.CompareTag("PickUp")) 
     {
          other.gameObject.SetActive(false);
          count++;
          SetCountText();
     }
     if (other.gameObject.CompareTag("GND")) {
          onGround = true;
          Debug.Log("Ground");
     }
     if (other.gameObject.CompareTag("Respawn")) {
          rb.position = spawn;
          rb.velocity = Vector3.zero;
          Debug.Log("respawning");
     }
   }

   void OnTriggerExit (Collider other) {
     if (other.gameObject.CompareTag("GND")) {
          onGround = false;
          Debug.Log("Not Ground");
     }
     if (other.gameObject.CompareTag("Respawn")) {
          rb.velocity = Vector3.zero;
          Debug.Log("respawn");
     }
   }

    void OnMove (InputValue movementValue)
   { 
        Vector2 v = movementValue.Get<Vector2>();
        movementX = v.x; 
        movementY = v.y; 
   }

   void SetCountText() 
   {
       countText.text =  "Count: " + count.ToString();
   }

    void OnJump () {
     
     if (onGround == true) {
          rb.velocity += new Vector3(0, jumpVal, 0);
          Debug.Log("Jumped");
     } else if (onGround == false) {
          Debug.Log("Off the ground!!!");
     }
     
    }
    
}
