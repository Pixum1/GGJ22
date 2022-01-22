using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed;

    [SerializeField]
    private string playerInput;

    private float moveDir;

    private void Update() {
        moveDir = Input.GetAxisRaw(playerInput);
    }

    private void FixedUpdate() {
        if (moveDir != 0) {
            Move();
        }
    }

    private void Move() {
        transform.position += new Vector3(moveDir * playerSpeed * Time.fixedDeltaTime, 0, 0);
    }
}
