using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    private float fallMultiplier = 3.5f;
    private float lowJumpMultiplier = 12f;
    [SerializeField]private float jumpHeight = 19f;
    [SerializeField]private float superJumpHeight = 30f;

    [SerializeField]private float doubleJumpHeight = 16f;

    private bool jumped;
    private bool doubleJumped;
    private int numberOfJumps = 0;

    private PlayerStatuses status;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        status = FindObjectOfType<PlayerStatuses>();

    }

    // Update is called once per frame
    void Update()
    {
        // if(status.isLaunched){
        //     return;
        // }
        //Checks for the jump button press
        if (Input.GetButtonDown("Jump") && (status.getGrounded() || status.getHanging()))
        {
            jumped = true;
        }

        if (Input.GetButtonDown("Jump") && !(status.getGrounded() || status.getHanging() || status.isLaunched) && numberOfJumps > 0)
        {
            doubleJumped = true;
        }

        if (status.getGrounded() || status.getHanging())
        {
            numberOfJumps = 1;
            doubleJumped = false;
        }


    }

    private void FixedUpdate()
    {
        // if(status.isLaunched){
        //     return;
        // }

        //Checks if the player pressed the jump button before applying the jump
        if (jumped || doubleJumped)
        {
            if(status.bounceReady){
                jump(superJumpHeight, doubleJumpHeight);
                Debug.Log("Bounced");
            }else{
                jump(jumpHeight, doubleJumpHeight);
            }
            
            numberOfJumps--;
            jumped = false;

            if (doubleJumped)
            {
                doubleJumped = false;
            }
        }

        if (status.getTechyBounce())
        {
            techyBounce();
            status.setTechyBounce(false);
        }

        //Increases gravity when player is falling. Also accounts for when the player only holds jump for a short time
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void jump(float jumpVal, float doubleJumpVal)
    {
        if (jumped)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVal);
            Debug.Log("Jump height: "+jumpVal);
        }
        else if (doubleJumped)
        {
            rb.velocity = new Vector2(rb.velocity.x, doubleJumpVal);
        }

    }

    void techyBounce()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight * 3);
        //status.setPounding(false);
    }


}
