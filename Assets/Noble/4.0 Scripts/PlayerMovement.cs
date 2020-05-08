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
        public Vector2 leftMoveInput = Vector2.zero;
        public Vector2 rightMoveInput = Vector2.zero;
        

        // autowired
        private CharacterController controller;
        private Vector3 currentVelocity = Vector3.zero;

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
            //vel.x = leftMoveInput.x * speed * Time.fixedDeltaTime;
            //vel.z = leftMoveInput.y * speed * Time.fixedDeltaTime;


            if (leftMoveInput.y > 0 && rightMoveInput.y > 0) {
                // fwd
                vel.z = (leftMoveInput.y + rightMoveInput.y) * speed * Time.fixedDeltaTime;
            } else if (leftMoveInput.y < 0 && rightMoveInput.y < 0) {
                // back
                vel.z = (leftMoveInput.y + rightMoveInput.y) * speed * Time.fixedDeltaTime;
            }

            angle += (leftMoveInput.y - rightMoveInput.y)*turnSpeed * Time.fixedDeltaTime;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

            if (controller.isGrounded) {
                currentVelocity.y = 0;
            }
            currentVelocity.y -= gravity * Time.fixedDeltaTime;


            vel = transform.TransformDirection(vel);
            currentVelocity = Vector3.Lerp(currentVelocity, vel, controlFactor * Time.fixedDeltaTime);

            

            controller.Move(currentVelocity);
        }


        

        public void OnMoveLeft(InputValue input) {
            leftMoveInput = input.Get<Vector2>();
        }

        public void OnMoveRight(InputValue input) {
            rightMoveInput = input.Get<Vector2>();
        }
    }

}