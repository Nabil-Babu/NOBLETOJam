using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerControls : MonoBehaviour
{
    public GameObject target;
    public bool killBoxOccupied = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent.tag == "Enemy")
        {
            Debug.Log("Kill Box Entered");
            target = other.transform.parent.gameObject;
            killBoxOccupied = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.transform.parent.tag == "Enemy")
        {
            Debug.Log("Kill Box Exited");
            killBoxOccupied = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.parent.tag == "Enemy")
        {
            Debug.Log("Kill Box Occupied");
            killBoxOccupied = true;
        }
    }

    public void KillTarget()
    {
        Debug.Log(killBoxOccupied);
        if(killBoxOccupied == true)
        {
            Debug.Log("Kill!");
        }
    }
}
