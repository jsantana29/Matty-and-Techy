using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CannonLaunch : MonoBehaviour
{
    public float launchX;
    public float launchY;
    public float force;

    private PlayerStatuses status;
    // Start is called before the first frame update
    void Start()
    {
        status = FindObjectOfType<PlayerStatuses>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cannon Launch") && !status.isLaunched)
        {
            status.isLaunched = true;
        }


    }

    private void FixedUpdate()
    {
        if (status.isLaunched)
        {
            //cannonJump();
            cannonLaunch();
            status.isLaunched = false;
        }
    }

    void cannonLaunch()
    {
        if (transform.localScale.x > 0)
        {
           
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + launchX, GetComponent<Rigidbody2D>().velocity.y + launchY) * force;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(launchX, launchY).normalized * force , ForceMode2D.Impulse);
        }
        else
        {
            
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + launchX, GetComponent<Rigidbody2D>().velocity.y + launchY);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-launchX, launchY).normalized * force , ForceMode2D.Impulse);
        }
        Debug.Log("Launch");
        
    }

    void cannonJump()
    {
        //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, );
    }
}
