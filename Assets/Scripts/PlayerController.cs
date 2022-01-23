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
    public float maxHeightBounds;

    public bool moveInvertet;

    public Action<PlayerController> e_playerDies;

    [SerializeField]
    private float afkTime = 2f;
    private float afkTimer;

    private void Start() {
        SetLevelBounds();
    }

    private void Update() {
        moveDir = Input.GetAxisRaw(playerInput);
        KeepPlayerInBounds();

        if(afkTimer > afkTime) {
            transform.position -= new Vector3(0, 0, 5 * Time.deltaTime);
        }

        afkTimer += Time.deltaTime;
    }

    private void FixedUpdate() {
        if (moveDir != 0) {
            Move();
        }
    }

    private void Move()
    {
        if (moveInvertet)
        {
            transform.position -= new Vector3(moveDir * playerSpeed * Time.fixedDeltaTime, 0, 0);
        }
        else
        {
            transform.position += new Vector3(moveDir * playerSpeed * Time.fixedDeltaTime, 0, 0);
        }

        afkTimer = 0;
    }
    private void SetLevelBounds() {
        outerBounds = plane.bounds.min.x + transform.localScale.x / 2f;
        innerBounds = plane.bounds.max.x - transform.localScale.x / 2f;
        maxHeightBounds = plane.bounds.center.z + plane.bounds.extents.z / 2f;
    }

    private void KeepPlayerInBounds() {
        if (transform.position.x <= outerBounds) {
            transform.position = new Vector3(outerBounds, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= innerBounds) {
            transform.position = new Vector3(innerBounds, transform.position.y, transform.position.z);
        }
        if (transform.position.z >= maxHeightBounds) { 
            transform.position = new Vector3(transform.position.x, transform.position.y, maxHeightBounds);
        }
    }

    private void OnDestroy() {

        e_playerDies?.Invoke(this);
    }
}
