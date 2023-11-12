using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(0, 0, -1 * speed * Time.deltaTime);
        
        if(gameObject.transform.position.z < -7.6) //brute force!!!!
        {
            gameObject.transform.position = new Vector3(0, 0, 38);
        }
    }
}
