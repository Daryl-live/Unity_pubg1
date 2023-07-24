using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIMag : MonoBehaviour
{
    [Header("����ֵ������ֵʹ�ò���")] 
    public Image hpImage;
    public Image hpEffectImage;
    public Text hpText;
    [HideInInspector] public float hp;
    [SerializeField] private float maxHP;
    [SerializeField] private float hurt = 10;
    [SerializeField] private float addSpeed = 0.005f;

    [Header("UI���Ʋ���")]
    public GameObject PausePanel;
    public GameObject KnapsackPanel;
    public GameObject GeneratePanel;



    // Start is called before the first frame update
    void Start()
    {
        //��Ϸ��ʼʱ��ʹ�������ﵽ��ֵ״̬
        hp = maxHP;
        //��Ϸ��ʼʱ��ʹ�������ﵽ��ֵ״̬
        //hp = minHP;
    }

    // Update is called once per frame
    void Update()
    {
        //BeAttacked();
        PauseShow();
        BagShow();
        GenerateShow();
    }

    /// <summary>
    /// ���˵�����ֵHP�۳�
    /// </summary>
    //public void BeAttacked()
    //{
    //    if(Input.GetKeyDown(KeyCode.V))
    //    {
    //        hp -= hurt;
    //    }
    //    //GameObject.Find("Canvas").GetComponentInChildren<ProgressBar>().hp -= 25;
    //    //��ǰ����ֵ/�������ֵ
    //    hpImage.fillAmount = hp / maxHP;
    //    //�������Ч����fillamount������������ڵ�ǰ�����
    //    if (hpEffectImage.fillAmount > hpImage.fillAmount)
    //    {
    //        //����Ч�����������[addSpeed]����ٶȽ��м���
    //        hpEffectImage.fillAmount -= addSpeed;
    //    }
    //    //�������Ч����fillamount���ٵ���ǰֵʱ
    //    else
    //    {
    //        //����ǰ�������������Ч�����̶�
    //        hpEffectImage.fillAmount = hpImage.fillAmount;
    //    }
    //    hpText.text = hp.ToString();
    //}
    public void PauseShow()
    {
        //����ESC��ʱ�������¼�
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel.SetActive(true);//������ͣ���
        }
    }
    public void BagShow()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            KnapsackPanel.SetActive(true);//���ر������
        }
    }
    public void GenerateShow()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GeneratePanel.SetActive(true);//���ر������
        }
    }
}
