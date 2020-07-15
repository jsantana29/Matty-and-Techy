using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
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
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground"){
            status.setGrounded(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Ground"){
            status.setGrounded(false);
        }
        
    }
}
