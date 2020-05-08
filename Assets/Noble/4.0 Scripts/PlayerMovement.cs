using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Noble {


    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(PlayerInput))]

    public class PlayerMovement : MonoBehaviour {

        [Header("Settings")]
        public float speed;

        [Header("Input Hooks")]
        public Vector2 moveInput = Vector2.zero;

        // autowired
        private CharacterController controller;
        private Vector3 velocity = Vector3.zero;
        

        // Start is called before the first frame update
        void Start() {
            controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void FixedUpdate() {
            velocity.x = moveInput.x * speed * Time.fixedDeltaTime;
            velocity.z = moveInput.y * speed * Time.fixedDeltaTime;
            controller.Move(velocity);
        }

        public void OnMove(InputValue input) {
            moveInput = input.Get<Vector2>();
        }


    }

}