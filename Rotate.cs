using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float RotateSpeed = 50f;//������ת�ٶ�
    public float DestroyTime = 10f;//����ݻ�ʱ��

    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("Cylinder").GetComponent<SpawnItem>().ReduceCount();
        Destroy(gameObject, DestroyTime);//�ڹ̶�ʱ��ݻ���Ʒ
                                         //Invoke("ReduceCount", DestroyTime);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * RotateSpeed, Space.World);//���������ת�ٶ�,��y��Ϊ����ת
    }

}
