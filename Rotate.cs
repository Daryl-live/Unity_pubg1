using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float RotateSpeed = 50f;//定义旋转速度
    public float DestroyTime = 10f;//定义摧毁时间

    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("Cylinder").GetComponent<SpawnItem>().ReduceCount();
        Destroy(gameObject, DestroyTime);//在固定时间摧毁物品
                                         //Invoke("ReduceCount", DestroyTime);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * RotateSpeed, Space.World);//物体根据旋转速度,以y轴为轴旋转
    }

}
