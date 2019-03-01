using UnityEngine;

public class Upgrader : MonoBehaviour
{
    public GameObject UpgradertObj;

    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.CompareTag("Enemy"))
        {
            Destroy(UpgradertObj);
        }
        if (coll.transform.CompareTag("Player"))
        {
            Destroy(UpgradertObj);
        }
    }
}
