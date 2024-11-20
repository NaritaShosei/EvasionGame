using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _moveSpeed = 5f;
    [NonSerialized] public Vector2 mousePos;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.localRotation = Quaternion.LookRotation(transform.forward, mousePos - (Vector2)transform.position);
    }

    void FixedUpdate()
    {
        var hMove = Input.GetAxisRaw("Horizontal") * _moveSpeed;
        var vMove = Input.GetAxisRaw("Vertical") * _moveSpeed;
        _rb.AddForce(new Vector2(hMove, vMove));
    }
}
