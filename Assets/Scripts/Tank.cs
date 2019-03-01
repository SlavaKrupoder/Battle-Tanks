using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour
{
    public int HpTank = 1;
    public float Speed = 100;
    public float BulletSpeed = 15;
    public Transform TankTransform;
    public Transform GunTransform;
    public Rigidbody2D BulletRb;
    public Rigidbody2D Body;
    public Vector2 MoveDirection;
    public Vector3 Rotation;
    public bool Fire = false;
    public int TypeUpgrde;
    private int _bulletUpgrde;

    public void UpgradeChange()
    {
        if (TypeUpgrde >= 0)
        {
            Bullet _bullet = BulletRb.transform.GetComponent<Bullet>();
            if (TypeUpgrde == 3)
            {
                Speed += 35;
            }
            if (TypeUpgrde == 1)
            {
                HpTank += 3;
                Speed -= 10;
            }
            if (TypeUpgrde == 2)
            {
                _bullet.Damage += 2;
                BulletSpeed -= 5;
            }
            TypeUpgrde = -1;
        }
    }

    public void FixMove()
    {
        Body.AddForce(MoveDirection * Speed);
    }

    public virtual void ControlTank()
    {
    }

    public IEnumerator WaitFire(float t)
    {
        yield return new WaitForSeconds(t);
        Fire = true;
        StartCoroutine(WaitFire(Random.Range(1f, 3f)));
    }

    void Update()
    {
        ControlTank();
        UpgradeChange();
    }

    void FixedUpdate()
    {
        FixMove();
    }
}