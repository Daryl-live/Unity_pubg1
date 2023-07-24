using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class skillItem : MonoBehaviour
{
    public float coldTime = 2;//������ȴʱ��
    private float Timer = 0;//�����ʱ��
    private Image FilledImage;//�������ͼƬ   ��Ҫusing UnityEngine.UI
    private bool isStartTimer = false;//����״̬���Ƿ�ʼ��ʱ/����ж�
    public KeyCode keyCode;//���尴������
   
    // Start is called before the first frame update
    void Start()
    {
        FilledImage = transform.Find("FilledImage").GetComponent<Image>();//transform.Find("����").GetComponent<����>()  �ҵ���Ҫ�����
        //FilledImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyCode))//Input.GetKeyDown(����)
        {
            isStartTimer = true;//������ȴ
        }
        if(isStartTimer)
        {
            Timer += Time.deltaTime;//��ʱ����ʼ�ۼ�
            FilledImage.fillAmount = (coldTime - Timer) / coldTime;//����ʱ���������ֵ������
            if(Timer>=coldTime)//��ȴ��������������
            {
                FilledImage.fillAmount = 0;
                Timer = 0;
                isStartTimer = false;//����״̬

            }
        }
    }
    public void OnClick()
    {
        isStartTimer = true;//������ȴ
    }
}
