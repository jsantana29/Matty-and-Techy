using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendScript : MonoBehaviour
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
        if (status.isLaunched)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            //box.enabled = true;
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //box.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            status.canExtendDash = true;

        }
    }
}
