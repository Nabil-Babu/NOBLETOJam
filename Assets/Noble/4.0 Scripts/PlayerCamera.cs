using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;


public class PlayerCamera : MonoBehaviour {

    [Header("Dependencies")]
    public CinemachineVirtualCamera vCam;


    [Header("Settings")]
    public GameObject yawAxis;
    public float minHeight;
    public float maxHeight;
    public float yawSpeed;
    public float pitchSpeed;

    [Header("Input Hooks")]
    public Vector2 lookInput = Vector2.zero;

    [Header("Runtime Values")]
    [SerializeField]
    private float yawAngle;
    [SerializeField]
    private float camHeight;

    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        yawAngle += lookInput.x * yawSpeed * Time.deltaTime;
        yawAxis.transform.localRotation = Quaternion.AngleAxis(yawAngle, Vector3.up);
        camHeight += lookInput.y * pitchSpeed * Time.deltaTime;
        camHeight = Mathf.Clamp(camHeight, minHeight, maxHeight);
        CinemachineTransposer trans = vCam.GetCinemachineComponent<CinemachineTransposer>();
        var offset = trans.m_FollowOffset;
        offset.y = camHeight;
        trans.m_FollowOffset = offset;


    }

    public void OnLook(InputValue input) {
        lookInput = input.Get<Vector2>();
    }

}
