using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private PlayerStatuses status;

    [SerializeField]private float launchPower;
    [SerializeField]private float launchHeight;
    [SerializeField]private float launchTime;
    [SerializeField]private float launchCooldown;
    [SerializeField]private float current;

    [SerializeField] private TrailRenderer tr;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        status = FindObjectOfType<PlayerStatuses>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        // if(status.canExtendDash && Input.GetButtonDown("Jump")){
        //     rb.velocity = new Vector2(transform.localScale.x * launchPower, rb.velocity.y);
        //     Debug.Log("Extended dash");
        // }
        if(status.getPounding()){
            stopLaunch();
        }

        if(status.grounded && status.isLaunched){
            current += Time.deltaTime;
            if(current > launchCooldown){
                stopLaunch();
            }else if(Input.GetButtonDown("Jump")){
                rb.velocity = new Vector2(transform.localScale.x * launchPower, rb.velocity.y + launchHeight);
                status.extendedDash = true;
                current = 0;
                Debug.Log("Extended dash");
            }
            
        }

        if(Input.GetButtonDown("Cannon Launch") && status.canLaunch){
            StartCoroutine(Launch());
        }

        if(Input.GetButtonDown("Cannon Launch") && status.extendedDash){
            stopLaunch();
        }

        
    }

    private IEnumerator Launch(){
        status.canLaunch = false;
        status.isLaunched = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * launchPower, launchHeight);
        tr.emitting = true;
        yield return new WaitForSeconds(launchTime);
        //tr.emitting = false;
        rb.gravityScale = originalGravity;
        //status.isLaunched = false;
        //yield return new WaitForSeconds(launchCooldown);
        //status.canLaunch = true;

    }

    private void stopLaunch(){
        status.canLaunch = true;
        status.isLaunched = false;
        tr.emitting = false;
        current = 0;
        status.extendedDash = false;
    }
}
