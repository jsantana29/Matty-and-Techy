using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPoundBounce : MonoBehaviour
{
    private PlayerStatuses status;
    // Start is called before the first frame update
    void Start()
    {
        status = FindObjectOfType<PlayerStatuses>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (status.getPounding())
        // {
        //     GetComponent<BoxCollider2D>().enabled = true;
        // }
        // else
        // {
        //     GetComponent<BoxCollider2D>().enabled = false;
        // }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Techy" && status.getPounding())
        {
            Debug.Log("Bouncing on turtle");
            status.setTechyBounce(true);

        }
    }
}
