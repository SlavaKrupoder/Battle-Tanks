using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage = 1;
    public int _isEnemy = 0;
    public GameObject BulletObj;
    
    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        EnamyTank _enemy = coll.transform.GetComponent<EnamyTank>();
        PlayerTank _player = coll.transform.GetComponent<PlayerTank>();
        if (coll.transform.CompareTag("Wall"))
        {
            Destroy(BulletObj);
        }
        if (coll.transform.CompareTag("Enemy"))
        {
            if (_isEnemy == 1)
            {
                _enemy.HpTank -= Damage;
            }
            Destroy(BulletObj);
        }
        if (coll.transform.CompareTag("Player"))
        {
            _player.HpTank -= Damage;
            Destroy(BulletObj);
        }
    }
}