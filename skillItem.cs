using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class skillItem : MonoBehaviour
{
    public float coldTime = 2;//定义冷却时间
    private float Timer = 0;//定义计时器
    private Image FilledImage;//定义填充图片   需要using UnityEngine.UI
    private bool isStartTimer = false;//定义状态：是否开始计时/点击判断
    public KeyCode keyCode;//定义按键输入
   
    // Start is called before the first frame update
    void Start()
    {
        FilledImage = transform.Find("FilledImage").GetComponent<Image>();//transform.Find("名字").GetComponent<类型>()  找到需要的组件
        //FilledImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyCode))//Input.GetKeyDown(按键)
        {
            isStartTimer = true;//触发冷却
        }
        if(isStartTimer)
        {
            Timer += Time.deltaTime;//计时器开始累加
            FilledImage.fillAmount = (coldTime - Timer) / coldTime;//根据时间比例来赋值填充比例
            if(Timer>=coldTime)//冷却结束，属性重置
            {
                FilledImage.fillAmount = 0;
                Timer = 0;
                isStartTimer = false;//重置状态

            }
        }
    }
    public void OnClick()
    {
        isStartTimer = true;//触发冷却
    }
}
