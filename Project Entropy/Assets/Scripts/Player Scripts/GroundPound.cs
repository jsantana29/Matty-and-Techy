using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPound : MonoBehaviour
{
    private PlayerStatuses status;
    private Animator anim;

    [SerializeField] private float dropSpeed;
    private bool pounding;
    // Start is called before the first frame update
    void Start()
    {
        dropSpeed = -30f;
        pounding = false;
        status = FindObjectOfType<PlayerStatuses>();
        anim = GetComponent<Animator>();
        anim.SetBool("Pounding", false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetButtonDown("GroundPound"));

        if (!status.getGrounded() && Input.GetButtonDown("GroundPound"))
        {
            pounding = true;
            anim.SetBool("Pounding", pounding);
            //Debug.Log("Ground pound input handled");

        }
    }

    void FixedUpdate()
    {
        if (pounding)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, dropSpeed);

        }

        if (status.getGrounded())
        {
            pounding = false;
            anim.SetBool("Pounding", pounding);
        }
    }
}
