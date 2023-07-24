using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnItem : MonoBehaviour
{
    [Header("生成最大值")]
    public int s_maxCount = 5;//定义设定数量
    [Header("生成间隔")]
    public float rate = 1f;
    public float SpawnTime = 2.5f;//定义生成时间
    public float StartTime = 1f;//定义开始时间
    public GameObject[] Item;//定义资源预制体数组
    private int s_curCount = 0;//定义当前数量

    //private List<float> Item_y;



    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnItems", StartTime, SpawnTime);//在time（StartTime）之后，第一次调用“方法”开始,每隔RepeatRate（SpawnTime）调用一次

    }

    // Update is called once per frame
    void Update()
    {
        rate -= Time.deltaTime;
        if (s_curCount < s_maxCount)//当前资源数量小于设定值
        {
            if (rate <= 0)//间隔rate秒执行 后面的语句
            {
                rate = 1.0f;
                SpawnItems();//执行方法
                s_curCount = s_curCount + 1;//当前数量+1，即循环一次
                Debug.Log("当前数量为：" + s_curCount);
                //Debug.Log("最大数量为：" + s_maxCount);
                Invoke("ReduceCount", 20f);//延迟执行
            }
        }
    }

    void SpawnItems()
    {
        int ItemIndex = Random.Range(0, Item.Length);//随机出设定预制体中的一个,从0开始计算，最大值为数组长度
        //Item[ItemIndex] = Resources.Load("Prefabs/Cube") as GameObject;
        //Item_y[ItemIndex] = Item[ItemIndex].transform.position.y;
        Vector2 p = Random.insideUnitCircle * 7.5f;//返回外圈半径R（7.5）内的随机坐标点
        Vector2 pos = p.normalized * (7.5f + p.magnitude);//取内空心圆半径r（7.5）外距离外圈p.magnitude的点,即R-r的范围内的坐标
        Vector3 pos2 = new Vector3(pos.x, 0.5f, pos.y);//限定在同一水平面，即确定物品高度
        Instantiate(Item[ItemIndex], pos2, Item[ItemIndex].transform.rotation);//实例化预制体Instantiate（预制体，坐标，角度）

    }
    public void ReduceCount()
    {
        s_curCount--;//减少当前值，用于刷新新的预制体
        Debug.Log("以摧毁，现数量为：" + s_curCount);
    }
}
