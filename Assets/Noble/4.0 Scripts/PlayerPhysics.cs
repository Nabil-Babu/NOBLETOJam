using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerPhysics : MonoBehaviour {

    public enum MODE {
        None,
        Direct,
        ApplyForces
    }

    public MODE physicsMode;
    public float directPower;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate() {

    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (!enabled) {
            return;
        }
        if (physicsMode == MODE.None) {
            return; // do nothing
        }
        var hitRB = hit.gameObject.GetComponentInParent<Rigidbody>();
        if (hitRB == null || hitRB.isKinematic) {
            return; // do nothing
        }
        CharacterController controller = hit.controller;
        var footPos = controller.transform.position.y - controller.center.y - controller.height / 2;
        if (hit.point.y <= footPos) {
            // we are standing on it
            return; // do nothing
        }
        if (physicsMode == MODE.ApplyForces) {
            Debug.Log("Apply Forces");
            hitRB.velocity = controller.velocity;

        } else if (physicsMode == MODE.Direct) {
            Debug.Log("Direct Velocity");
            var force = controller.velocity * directPower;
            hitRB.AddForceAtPosition(force, hit.point);
        }


    }

}

