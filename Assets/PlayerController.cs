using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed;

    [SerializeField]
    private string playerInput;

    [SerializeField]
    private LayerMask boundsLayer;
    [SerializeField]
    private float wallCheckRayLength;
    public bool m_CheckForWall {
        get {
            return Physics.Raycast(transform.position, transform.right, wallCheckRayLength, boundsLayer)
                   && Physics.Raycast(transform.position, -transform.right, wallCheckRayLength, boundsLayer);
        }
    }

    public float moveDir {
        get {
            return Input.GetAxis(playerInput);
        }
    }

    private void FixedUpdate() {
        if(moveDir != 0) {
            Move();
        }
    }

    private void Move() {
        transform.Translate(Vector3.right * moveDir * playerSpeed, Space.World);
    }
    private void OnDrawGizmos() {
        drawWallCheckRays();

        void drawWallCheckRays() {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.right * wallCheckRayLength);
            Gizmos.DrawLine(transform.position, -transform.right * wallCheckRayLength);
        }
    }

}
