using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    public float moveSpeed;

    private Vector3 positionInFormation = new Vector3(0, 0, 0);
    private int unitID;
    private Vector3 cachedPos;
    private Rigidbody playerRigidBody;

    public Vector3 PositionInFormation { get => positionInFormation; set => positionInFormation = value; }
    public int UnitID { get => unitID; set => unitID = value; }

    public void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        cachedPos = transform.position;
    }

    public void Move(Vector3 hit) {

        var lastPos = transform.position;

        Vector3 playerToMouse = new Vector3(hit.x - lastPos.x + positionInFormation.x,
                                            0,
                                            hit.z - lastPos.z + positionInFormation.z);

        if (playerToMouse != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            cachedPos.x += playerToMouse.x * (moveSpeed * Time.deltaTime);
            cachedPos.z += playerToMouse.z * (moveSpeed * Time.deltaTime);

            Vector3 tempVect = new Vector3(cachedPos.x, transform.position.y, cachedPos.z);

            playerRigidBody.MovePosition(tempVect);
            playerRigidBody.MoveRotation(newRotation);

        }
    }
}
