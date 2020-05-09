using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerCamera : MonoBehaviour {

    [Header("Settings")]
    public GameObject yawAxis;
    public GameObject pitchAxis;
    public float lookSpeed;

    [Header("Input Hooks")]
    public Vector2 lookInput = Vector2.zero;

    [Header("Runtime Values")]
    [SerializeField]
    private float yawAngle;
    [SerializeField]
    private float pitchAngle;
    


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        yawAngle += lookInput.x * lookSpeed * Time.deltaTime;
        pitchAngle += lookInput.y * lookSpeed * Time.deltaTime;
        yawAxis.transform.rotation = Quaternion.AngleAxis(yawAngle, Vector3.up);
        pitchAxis.transform.rotation = Quaternion.AngleAxis(pitchAngle, Vector3.right);
    }

    public void OnLook(InputValue input) {
        lookInput = input.Get<Vector2>();
    }

}
