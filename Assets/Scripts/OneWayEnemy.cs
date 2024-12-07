using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayEnemy : MonoBehaviour
{
    [SerializeField] float _moveSpeed;

    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).position += transform.GetChild(i).up * _moveSpeed * Time.deltaTime;
        }

    }
}
