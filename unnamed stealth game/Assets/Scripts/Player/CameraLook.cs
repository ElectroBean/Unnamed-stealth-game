using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {

    public Transform lookAt;
    private Transform camTransform;

    private Camera cam;
    private GameObject player;

    public float distance = 5.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensitivityX = 4.0f;
    public float sensitivityY = 4.0f;

    private const float yAngleMin = -25.0f;
    private const float yAngleMax = 50.0f;

    private float XAxisClamp = 0;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Use this for initialization
    void Start ()
    {
        camTransform = transform;
        cam = gameObject.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;
        //currentX = Mathf.Clamp(currentX, yAngleMin, yAngleMax);
        currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);
	}

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        Vector3 targetBodyRotation = player.transform.rotation.eulerAngles;
        targetBodyRotation.y += Input.GetAxis("Mouse X") * sensitivityX;
        player.transform.rotation = Quaternion.Euler(targetBodyRotation);

        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
