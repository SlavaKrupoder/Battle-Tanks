using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : Tank
{
    void Start()
    {
        Fire = false;
        Body = GetComponent<Rigidbody2D>();
        StartCoroutine(WaitFire(3f));
    }

    public override void ControlTank()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveDirection = new Vector2(0, 1);
            Rotation = new Vector3(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveDirection = new Vector2(0, -1);
            Rotation = new Vector3(0, 0, 180);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveDirection = new Vector2(-1, 0);
            Rotation = new Vector3(0, 0, 90);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveDirection = new Vector2(1, 0);
            Rotation = new Vector3(0, 0, -90);
        }
        else
        {
            MoveDirection = new Vector2(0, 0);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Fire)
            {
                Fire = false;
                Rigidbody2D _bulletInstance = Instantiate(BulletRb, GunTransform.position, Quaternion.identity) as Rigidbody2D;
                _bulletInstance.velocity = GunTransform.TransformDirection(Vector2.up * BulletSpeed);
                _bulletInstance.GetComponent<Bullet>()._isEnemy = 1;
            }
        }
        TankTransform.localRotation = Quaternion.Euler(Rotation);
        if (HpTank <= 0)
        {
            Destroy(gameObject);
            GameControl.playerDead = true;
        }
    }
}
