using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [Header("�ӵ�����")]
    public float BulletSpeed=1000f;

    public Vector3 hitPos;

    public GameObject BulletEf;
    // Start is called before the first frame update
    void Start()
    {
        //���ӵ�һ����ǰ������ģ�����
        GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * BulletSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {

            //�ݻ��ӵ�����
            Destroy(gameObject);

            
        }
        if(other.tag == "Enemy"|| other.tag == "HealBox")
        {
            hitPos = other.bounds.ClosestPoint(transform.position);
            
            GameObject go = Instantiate(BulletEf, hitPos, Quaternion.identity);
            Destroy(go, 1f);
            //�ݻ��ӵ�����
            Destroy(gameObject);

        }
    }
}
