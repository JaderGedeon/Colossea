using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    public float moveSpeed;
    public float rotationSpeed;
    Vector3 movement;

    public Camera cam;
    RaycastHit hit;
    Rigidbody playerRigidbody;

    public Vector3 positionInFormation = new Vector3(0,0,0);

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    public void Move() {

        var lastPos = transform.position;
        transform.position = 
    
    }

    public void Rotation() {

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 200, LayerMask.GetMask("Ground")))
        {
            Vector3 playerToMouse = hit.point - transform.position + positionInFormation;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);

            //playerRigidbody.AddForce(playerToMouse * moveSpeed);
            playerRigidbody.MovePosition((Vector3)transform.position + (playerToMouse * moveSpeed * Time.deltaTime));
        }
    }
}
