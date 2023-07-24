using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIMag : MonoBehaviour
{
    [Header("生命值、体力值使用参数")] 
    public Image hpImage;
    public Image hpEffectImage;
    public Text hpText;
    [HideInInspector] public float hp;
    [SerializeField] private float maxHP;
    [SerializeField] private float hurt = 10;
    [SerializeField] private float addSpeed = 0.005f;

    [Header("UI控制参数")]
    public GameObject PausePanel;
    public GameObject KnapsackPanel;
    public GameObject GeneratePanel;



    // Start is called before the first frame update
    void Start()
    {
        //游戏开始时，使进度条达到满值状态
        hp = maxHP;
        //游戏开始时，使进度条达到空值状态
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
    /// 受伤的生命值HP扣除
    /// </summary>
    //public void BeAttacked()
    //{
    //    if(Input.GetKeyDown(KeyCode.V))
    //    {
    //        hp -= hurt;
    //    }
    //    //GameObject.Find("Canvas").GetComponentInChildren<ProgressBar>().hp -= 25;
    //    //当前生命值/最大生命值
    //    hpImage.fillAmount = hp / maxHP;
    //    //如果缓冲效果的fillamount（填充量）大于当前填充量
    //    if (hpEffectImage.fillAmount > hpImage.fillAmount)
    //    {
    //        //缓冲效果的填充量以[addSpeed]这个速度进行减少
    //        hpEffectImage.fillAmount -= addSpeed;
    //    }
    //    //如果缓冲效果的fillamount减少到当前值时
    //    else
    //    {
    //        //将当前填充量赋给缓冲效果，固定
    //        hpEffectImage.fillAmount = hpImage.fillAmount;
    //    }
    //    hpText.text = hp.ToString();
    //}
    public void PauseShow()
    {
        //按下ESC键时，触发事件
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel.SetActive(true);//加载暂停面板
        }
    }
    public void BagShow()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            KnapsackPanel.SetActive(true);//加载背包面板
        }
    }
    public void GenerateShow()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GeneratePanel.SetActive(true);//加载背包面板
        }
    }
}
