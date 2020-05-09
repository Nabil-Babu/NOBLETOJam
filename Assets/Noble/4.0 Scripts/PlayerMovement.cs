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
        public float controlFactor;
        public float turnSpeed;
        public float gravity;

        [Header("Input Hooks")]
        public Vector2 moveInput = Vector2.zero;
        public Vector2 lookInput = Vector2.zero;
        

        // autowired
        private CharacterController controller;
        private Vector3 currentVelocity = Vector3.zero;

        [Header("Players Parts")]
        // Head
        public GameObject head;

        [Header("Runtime Values")]
        [SerializeField]
        private float angle;

        // Start is called before the first frame update
        void Start() {
            controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void FixedUpdate() {
            var vel = new Vector3();
            vel.x = moveInput.x * speed * Time.fixedDeltaTime;
            vel.z = moveInput.y * speed * Time.fixedDeltaTime;


            if (controller.isGrounded) {
                currentVelocity.y = 0;
            }
            currentVelocity.y -= gravity * Time.fixedDeltaTime;

            var angle = new Vector3();

            angle.x = lookInput.x * turnSpeed * Time.fixedDeltaTime;

            head.transform.rotation = Quaternion.AngleAxis(angle.x, Vector3.up);

            currentVelocity = Vector3.Lerp(currentVelocity, vel, controlFactor * Time.fixedDeltaTime);

            controller.Move(currentVelocity);
        }


        

        public void OnMove(InputValue input) {
            moveInput = input.Get<Vector2>();
        }

        public void OnLook(InputValue input) {
            lookInput = input.Get<Vector2>();
        }
    }

}