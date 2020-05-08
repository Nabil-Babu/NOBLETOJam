using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Noble {


    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(PlayerInput))]

    public class PlayerMovement : MonoBehaviour {

        public Vector2 moveInput = Vector2.zero;
        private CharacterController controller;

        private Vector3 speed = Vector3.zero;  

        // Start is called before the first frame update
        void Start() {
            speed = new Vector3(10,0,10);
            controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void FixedUpdate() {


            controller.Move(new Vector3(moveInput.x, 0, moveInput.y));
        }

        public void OnMove(InputValue input) {
            moveInput = input.Get<Vector2>();
        }


    }

}