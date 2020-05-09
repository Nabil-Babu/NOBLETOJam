using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colliding");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Colliding  with Enemy");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggering");
    }
}
