using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [Header("子弹参数")]
    public float BulletSpeed=1000f;

    public Vector3 hitPos;

    public GameObject BulletEf;
    // Start is called before the first frame update
    void Start()
    {
        //给子弹一个向前的力，模拟射击
        GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * BulletSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {

            //摧毁子弹自身
            Destroy(gameObject);

            
        }
        if(other.tag == "Enemy"|| other.tag == "HealBox")
        {
            hitPos = other.bounds.ClosestPoint(transform.position);
            
            GameObject go = Instantiate(BulletEf, hitPos, Quaternion.identity);
            Destroy(go, 1f);
            //摧毁子弹自身
            Destroy(gameObject);

        }
    }
}
