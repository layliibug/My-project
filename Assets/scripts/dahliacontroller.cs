using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class dahliacontroller : MonoBehaviour
{

    public Animator animator;
    public Rigidbody2D rigidbody2D;
    public float speed;
    public float detectionRadius;
    public LayerMask pickupLayer;
    public TextMeshProUGUI uitext;
    public Image uiimage;
    public bool dialogueactive;

    // Start is called before the first frame update
    void Start()
    {
        uiimage = GameObject.Find("ui image").GetComponent<Image>();
        uitext = GameObject.Find("ui text").GetComponent<TextMeshProUGUI>();
        uiimage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = 1;
        if (Input.GetKey(KeyCode.W) && dialogueactive == false)
        {
            animator.Play("back");
            rigidbody2D.velocity = (Vector2.up* speed);
        }
        else if (Input.GetKey(KeyCode.A) && dialogueactive == false)
        {
            animator.Play("left");
            rigidbody2D.velocity = (Vector2.left* speed);
        }
        else if (Input.GetKey(KeyCode.S) && dialogueactive == false)
        {
            animator.Play("front");
            rigidbody2D.velocity=(Vector2.down*speed);
        }
        else if (Input.GetKey(KeyCode.D) && dialogueactive == false)
        {
            animator.Play("right");
            rigidbody2D.velocity = (Vector2.right* speed);
        }
        else if (Input.GetKeyDown(KeyCode.E) && dialogueactive == false)
        {
            pickupobject();
        }
        else if (Input.GetKeyDown(KeyCode.E) && dialogueactive == true)
        {
            closedialogue();
        }
        else
        {
            //animator.Play("idle");
            animator.speed = 0;
            rigidbody2D.velocity=Vector2.zero;
        }
    }

    private void closedialogue()
    {
        dialogueactive = false;
        uiimage.enabled = false;
        uitext.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("door");
        transform.position = collision.gameObject.GetComponent<DoorScript>().teleport.position;        
    }

    private void pickupobject()
    {
        Collider2D result = Physics2D.OverlapCircle(transform.position, 0.5f, pickupLayer);
        if(result != null)
        {
            pickup newPickup = result.GetComponent<pickup>();
            newPickup.PickedUp();
            uitext.text = newPickup.textToShow;

            dialogueactive = true;
            uiimage.enabled = true;
        }        
    }


    //bracelet + charms

    //customisable outfits

}
