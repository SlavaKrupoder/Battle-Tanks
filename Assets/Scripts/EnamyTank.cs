using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnamyTank : Tank
{
    private int _move;
    public List<SpriteRenderer> UpgradeGunList;
    public List<SpriteRenderer> UpgradeTrukList;
    public List<SpriteRenderer> UpgradeArmorList;
    private bool _changeMove = false;
    
    public int UpgradeType;

    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        Fire = false;
        _move = 0;
        StartCoroutine(WaitMove(Random.Range(0f, 5f)));
        StartCoroutine(WaitFire(Random.Range(1f, 3f)));
    }

    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.CompareTag("Wall"))
        {
            _changeMove = true;
            var enemyPosition = Body.transform.rotation;
            if(enemyPosition.z == 180)
            {
                _move = 1;
            }
            if (enemyPosition.z == 0)
            {
                _move = 2;
            }
            if (enemyPosition.z == 90)
            {
                _move = 4;
            }
            if (enemyPosition.z == -90)
            {
                _move = 3;
            }
        }
        if (coll.transform.CompareTag("Upgrade"))
        {
            var classTank = Random.Range(1, 4);
            UpgradeType = classTank;
            TankUpgrade();
        }
    }

    IEnumerator WaitMove(float t)
    {
        if (_changeMove == false)
        {
            _move = Random.Range(1, 5);
        }
        yield return new WaitForSeconds(t);
        StartCoroutine(WaitMove(Random.Range(1f, 3f)));
    }

    public override void ControlTank()
    {
        switch (_move)
        {
            case 1:
                MoveDirection = new Vector2(0, 1);
                Rotation = new Vector3(0, 0, 0);
                break;

            case 2:
                MoveDirection = new Vector2(0, -1);
                Rotation = new Vector3(0, 0, 180);
                break;

            case 3:
                MoveDirection = new Vector2(-1, 0);
                Rotation = new Vector3(0, 0, 90);
                break;

            case 4:
                MoveDirection = new Vector2(1, 0);
                Rotation = new Vector3(0, 0, -90);
                break;

            default:
                MoveDirection = new Vector2(0, 0);
                break;
        }
        _changeMove = false;
        if (Fire)
        {
            Fire = false;
            Rigidbody2D _bulletInstance = Instantiate(BulletRb, GunTransform.position, Quaternion.identity) as Rigidbody2D;
            _bulletInstance.velocity = GunTransform.TransformDirection(Vector2.up * BulletSpeed);
            Bullet _bullet = BulletRb.transform.GetComponent<Bullet>();
            _bullet._isEnemy = 2;
        }
        TankTransform.localRotation = Quaternion.Euler(Rotation);
        if (HpTank <= 0)
        {
            Destroy(gameObject);
            GameControl.score += 1; 
        }
    }

    void TankUpgrade()
    {
        switch (UpgradeType)
        {
            case 1://TT
                var UpgradeArmorListCount = UpgradeArmorList.Count;
                for (var i = 0; i < UpgradeArmorListCount; i++)
                {
                    var obj = UpgradeArmorList[i];
                    obj.enabled = true;
                }
                break;

            case 2://PT
                var obj1 = UpgradeGunList[0];
                obj1.enabled = true;
                break;

            case 3://LT
                var UpgradeTrukListCount = UpgradeTrukList.Count;
                for (var i = 0; i < UpgradeTrukListCount; i++)
                {
                    var obj2 = UpgradeTrukList[i];
                    obj2.enabled = true;
                }
                break;

            default://default tank
                break;
        }
        TypeUpgrde = UpgradeType;
    }
}