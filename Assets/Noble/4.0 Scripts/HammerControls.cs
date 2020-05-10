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
        
        if(collision.transform.parent.tag == "Enemy")
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
            collision.gameObject.GetComponentInParent<MoveToPlayer>().PlayDeath();
        }
       
    }


}
