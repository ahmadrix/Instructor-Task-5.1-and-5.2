using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator PlayerAnim;
    public float horizontalInput;
    public float verticalInput;
    public bool onStair;
    private Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        PlayerAnim.SetFloat("Speed" , horizontalInput);
        if(Input.GetKey(KeyCode.RightArrow))             //function checks if right arrow is pressed
        {
            transform.Translate(Vector2.right * (Time.deltaTime * 10 * horizontalInput));
            // changing the angle to 180
            gameObject.transform.eulerAngles = new Vector3( gameObject.transform.eulerAngles.x,      
                0 , gameObject.transform.eulerAngles.z);
            PlayerAnim.SetFloat("Speed" , horizontalInput);
        }

        if(Input.GetKey(KeyCode.LeftArrow))         //function checks if left arrow is pressed
        {
            transform.Translate(Vector2.left * (Time.deltaTime * 10 * horizontalInput));
            // changing the angle to 0
            gameObject.transform.eulerAngles = new Vector3( gameObject.transform.eulerAngles.x,
                180 , gameObject.transform.eulerAngles.z);
            PlayerAnim.SetFloat("Speed" , -horizontalInput);
        }
        
        if(Input.GetKeyDown(KeyCode.Space))         //function checks if left arrow is pressed
        {
            PlayerAnim.SetFloat("Speed" , 0);
            PlayerAnim.SetBool("jump" , true);
            playerRb.AddForce(Vector2.up *  5 , ForceMode2D.Impulse);
        }
        if(Input.GetKeyUp(KeyCode.Space))         //function checks if left arrow is pressed
        {
            PlayerAnim.SetBool("jump" , false);
            
        }

        if (onStair && Input.GetKeyDown(KeyCode.UpArrow))
        {
            {
                playerRb.isKinematic = true;
                transform.Translate(Vector2.up * (Time.deltaTime *20* verticalInput));
            }
        }
        
        else if (onStair && Input.GetKeyDown((KeyCode.DownArrow)))
        {
            playerRb.isKinematic = true;
            transform.Translate(Vector2.down * (Time.deltaTime *20* verticalInput));
        }
        
        else if(!onStair && !Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerRb.isKinematic = false;
        }

        
        
        
    }

    
}
