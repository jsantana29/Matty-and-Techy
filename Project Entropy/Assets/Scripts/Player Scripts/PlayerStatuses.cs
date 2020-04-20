using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatuses : MonoBehaviour
{
    //Terrain transforms
    public Transform groundcheck;
    public Transform wallCheck;
    public Transform cornerCheck;
    public Transform ceilingCheck;

    //Layer masks
    public LayerMask whatIsGround;
    public LayerMask whatIsWall;

    //Terrain check booleans
    public bool grounded;
    public bool hangingOffWall;
    public bool onCorner;
    public bool onCeiling;
    public bool knocked;
    public bool shootingDown;

    //Movement speed values
    private float currentMaxSpeed;
    private float sprintSpeed = 14f;
    private float normalSpeed = 7f;

    //Terrain check radii
    private float groundCheckRadius = 0.4f;
    private float wallCheckRadius = 0.1f;

    //Status options
    public bool isAlive = true;



    // Start is called before the first frame update
    void Start()
    {
        currentMaxSpeed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundCheckRadius, whatIsGround);
        hangingOffWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
    }

    public bool getGrounded()
    {
        return grounded;
    }

    public bool getHanging()
    {
        return hangingOffWall;
    }

    public bool getOnCeiling()
    {
        return onCeiling;
    }

    public bool getOnCorner()
    {
        return onCorner;
    }

    public float getMaxSpeed()
    {
        return currentMaxSpeed;
    }

    public bool getKnocked()
    {
        return knocked;
    }

    public bool getShootDown()
    {
        return shootingDown;
    }
    public void setShootDown(bool shootingDown)
    {
        this.shootingDown = shootingDown;
    }

    public void setKnocked(bool knocked)
    {
        this.knocked = knocked;
    }

    public void setSprintSpeed()
    {
        currentMaxSpeed = sprintSpeed;
    }

    public void setNormalSpeed()
    {
        currentMaxSpeed = normalSpeed;
    }

    public float getLocalScale()
    {
        return transform.localScale.x;
    }

}
