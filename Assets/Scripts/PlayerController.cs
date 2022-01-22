using System;
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

    [SerializeField]
    private Collider plane;

    private float outerBounds, innerBounds;

    public Action<PlayerController> e_playerDies;

    private void Start() {
        outerBounds = plane.bounds.min.x + transform.localScale.x / 2f;
        innerBounds = plane.bounds.max.x - transform.localScale.x / 2f;
    }

    private void Update() {
        moveDir = Input.GetAxisRaw(playerInput);
        KeepPlayerInBounds();
    }

    private void FixedUpdate() {
        if (moveDir != 0) {
            Move();
        }
    }

    private void Move() {
        transform.position += new Vector3(moveDir * playerSpeed * Time.fixedDeltaTime, 0, 0);
    }

    private void KeepPlayerInBounds() {
        if (transform.position.x <= outerBounds) {
            transform.position = new Vector3(outerBounds, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= innerBounds) {
            transform.position = new Vector3(innerBounds, transform.position.y, transform.position.z);
        }
    }

    private void OnDestroy() {
        e_playerDies?.Invoke(this);
    }
}
