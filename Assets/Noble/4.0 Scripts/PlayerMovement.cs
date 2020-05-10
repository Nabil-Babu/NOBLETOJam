using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Noble {


    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(PlayerInput))]

    public class PlayerMovement : MonoBehaviour {

        private int ANIM_VELOCITY = Animator.StringToHash("Velocity");

        [Header("Dependencies")]
        public Animator animator;

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
        

        [Header("Runtime Values")]
        [SerializeField]
        private float angle;
        [SerializeField]
        private Vector3 currentVelocity = Vector3.zero;
        [SerializeField]
        private Vector3 velNormalized = Vector3.zero;

        // Start is called before the first frame update
        void Start() {
            controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void FixedUpdate() {
            var vel = new Vector3();
            vel.x = moveInput.x * speed;
            vel.z = moveInput.y * speed;
            vel.y = currentVelocity.y;
            vel = transform.TransformDirection(vel);

            if (controller.isGrounded) {
                vel.y = 0;
            }
            vel.y -= gravity;

            currentVelocity = Vector3.Lerp(currentVelocity, vel, controlFactor);
            

            // normally use the input. but since we slide we want to animate feet when sliding.
            velNormalized = currentVelocity.normalized;
            var animVel = Mathf.Max(Mathf.Abs(velNormalized.z), Mathf.Abs(velNormalized.x));
            animator.SetFloat(ANIM_VELOCITY, animVel);

            // leave this as last step
            controller.Move(currentVelocity * Time.fixedDeltaTime);
        }

        public void OnMove(InputValue input) {
            moveInput = input.Get<Vector2>();
        }

        public void OnLook(InputValue input) {
            lookInput = input.Get<Vector2>();
        }
    }

}