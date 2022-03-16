using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;

    public float jumpForce;
    public float sideForce;

    Rigidbody rb;

    enum side { l, m, r};

    side currentSide;
    side prevSide;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        currentSide = side.m;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity == Vector3.zero)
        {
            if (Input.GetKeyDown("space"))
            {
                rb.AddForce(new Vector3(0, 1, 0) * jumpForce);
            }
            else if (Input.GetKeyDown("a") && currentSide != side.l)
            {
                prevSide = currentSide;
                currentSide--;
                rb.AddForce(new Vector3(-1, 0, 0) * sideForce);            
            }
            else if (Input.GetKeyDown("d") && currentSide != side.r)
            {
                prevSide = currentSide;
                currentSide++;
                rb.AddForce(new Vector3(1, 0, 0) * sideForce);
            }
        }    

        if( (currentSide == side.l && gameObject.transform.position.x < -3.5 ) ||
            (currentSide == side.r && gameObject.transform.position.x > 3.5 )||
            (currentSide == side.m && gameObject.transform.position.x > 0 && prevSide == side.l) ||
            (currentSide == side.m && gameObject.transform.position.x < 0 && prevSide == side.r))

        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            GameManager.instance.resetScore();
        }
    }

}
