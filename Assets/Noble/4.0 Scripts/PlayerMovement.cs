using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Noble {


    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour {

        public Vector2 moveInput = Vector2.zero;

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void FixedUpdate() {

        }

        public void OnMove(InputValue input) {
            moveInput = input.Get<Vector2>();
        }


    }

}