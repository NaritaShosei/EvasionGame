using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayEnemy : MonoBehaviour
{
    [SerializeField] float _moveSpeed;

    void Update()
    {
        transform.position += transform.up * _moveSpeed * Time.deltaTime;
    }
}
