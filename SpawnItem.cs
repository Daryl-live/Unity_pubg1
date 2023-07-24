using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnItem : MonoBehaviour
{
    [Header("�������ֵ")]
    public int s_maxCount = 5;//�����趨����
    [Header("���ɼ��")]
    public float rate = 1f;
    public float SpawnTime = 2.5f;//��������ʱ��
    public float StartTime = 1f;//���忪ʼʱ��
    public GameObject[] Item;//������ԴԤ��������
    private int s_curCount = 0;//���嵱ǰ����

    //private List<float> Item_y;



    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnItems", StartTime, SpawnTime);//��time��StartTime��֮�󣬵�һ�ε��á���������ʼ,ÿ��RepeatRate��SpawnTime������һ��

    }

    // Update is called once per frame
    void Update()
    {
        rate -= Time.deltaTime;
        if (s_curCount < s_maxCount)//��ǰ��Դ����С���趨ֵ
        {
            if (rate <= 0)//���rate��ִ�� ��������
            {
                rate = 1.0f;
                SpawnItems();//ִ�з���
                s_curCount = s_curCount + 1;//��ǰ����+1����ѭ��һ��
                Debug.Log("��ǰ����Ϊ��" + s_curCount);
                //Debug.Log("�������Ϊ��" + s_maxCount);
                Invoke("ReduceCount", 20f);//�ӳ�ִ��
            }
        }
    }

    void SpawnItems()
    {
        int ItemIndex = Random.Range(0, Item.Length);//������趨Ԥ�����е�һ��,��0��ʼ���㣬���ֵΪ���鳤��
        //Item[ItemIndex] = Resources.Load("Prefabs/Cube") as GameObject;
        //Item_y[ItemIndex] = Item[ItemIndex].transform.position.y;
        Vector2 p = Random.insideUnitCircle * 7.5f;//������Ȧ�뾶R��7.5���ڵ���������
        Vector2 pos = p.normalized * (7.5f + p.magnitude);//ȡ�ڿ���Բ�뾶r��7.5���������Ȧp.magnitude�ĵ�,��R-r�ķ�Χ�ڵ�����
        Vector3 pos2 = new Vector3(pos.x, 0.5f, pos.y);//�޶���ͬһˮƽ�棬��ȷ����Ʒ�߶�
        Instantiate(Item[ItemIndex], pos2, Item[ItemIndex].transform.rotation);//ʵ����Ԥ����Instantiate��Ԥ���壬���꣬�Ƕȣ�

    }
    public void ReduceCount()
    {
        s_curCount--;//���ٵ�ǰֵ������ˢ���µ�Ԥ����
        Debug.Log("�Դݻ٣�������Ϊ��" + s_curCount);
    }
}
