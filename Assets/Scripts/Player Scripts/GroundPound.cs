using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPound : MonoBehaviour
{
    private PlayerStatuses status;
    private Animator anim;

    [SerializeField] private float dropSpeed;
    private bool pounding;
    [SerializeField] private bool hangtime;

    private float hangTimer;
    private float currentHangtime;
    private float maxHangTime;

    [SerializeField]private float bounceWindow;
    [SerializeField]private float currentBounceTime;
    [SerializeField]private float bounceHeight;
    //[SerializeField]private bool bounceReady;


    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        dropSpeed = -30f;
        maxHangTime = 0.3f;
        currentHangtime = 0f;
        pounding = false;
        hangtime = false;
        //bounceReady = false;
        status = FindObjectOfType<PlayerStatuses>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        anim.SetBool("Pounding", false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetButtonDown("GroundPound"));

        if (!status.getGrounded() && Input.GetButtonDown("GroundPound"))
        {
            pounding = true;
            status.setPounding(true);
            anim.SetBool("Pounding", pounding);
            //Debug.Log("Ground pound input handled");

            if (!hangtime)
            {
                hangtime = true;
            }

        }

        if (status.getGrounded() && status.pounding)
        {
            status.bounceReady = true;

            // currentBounceTime += Time.deltaTime;
            // if(currentBounceTime > bounceWindow){
            //     currentBounceTime = 0;
            //     bounceReady = false;
                
            // }else if(Input.GetButtonDown("Jump") && bounceReady){
            //     rb.velocity = new Vector2(rb.velocity.x, bounceHeight);
            //     Debug.Log("Bounced");
            //     currentBounceTime = 0;
            //     bounceReady = false;
            // }else{
            //     currentBounceTime = 0;
            //     status.pounding = false;
            //     pounding = false;
            //     anim.SetBool("Pounding", pounding);
            // }
            status.pounding = false;
            pounding = false;
            anim.SetBool("Pounding", pounding);

            
           
        }

        if(status.bounceReady){
            currentBounceTime += Time.deltaTime;
            if(currentBounceTime > bounceWindow){
                currentBounceTime = 0;
                status.bounceReady = false;
                
            }
            // else if(Input.GetButtonDown("Jump")){
            //     rb.velocity = new Vector2(rb.velocity.x, bounceHeight);
            //     Debug.Log("Bounced");
            //     currentBounceTime = 0;
            //     status.bounceReady = false;
            // }
        }


    }

    void FixedUpdate()
    {
       
        if (pounding)
        {

            if (hangtime)
            {
                currentHangtime += Time.deltaTime;

                if (currentHangtime < maxHangTime)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 3.0f);
                }
                else
                {
                    hangtime = false;
                    currentHangtime = 0;
                }
            }

            if (!hangtime)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, dropSpeed);
            }



        }

        
    }
}
