using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] float _bulletSpeed;
    [SerializeField] Transform _muzzlePos;
    [SerializeField] List<GameObject> _bulletPrefab;//通常弾と特殊弾にするかも
    PlayerMove _player;

    private void Start()
    {
        _player = GetComponent<PlayerMove>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var bullet = Instantiate(_bulletPrefab[0], _muzzlePos.position, Quaternion.LookRotation(transform.forward, _player.mousePos));
            var bulletRb = bullet.GetComponent<Rigidbody2D>();
            var direction = _player.mousePos.normalized;
            bulletRb.velocity = _bulletSpeed * direction;
            Destroy(bullet, 2f);
        }
    }
}
