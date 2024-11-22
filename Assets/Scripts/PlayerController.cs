using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var hMove = Input.GetAxisRaw("Horizontal") * _moveSpeed;
        var vMove = Input.GetAxisRaw("Vertical") * _moveSpeed;
        _rb.velocity = new Vector2(hMove, vMove);
    }

    private void Death()
    {
        Debug.Log("YOU DIED");
    }
}
