using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunControl : MonoBehaviour
{
    //计时器
    public float timer = 0;

    [Header("射击参数")]
    //火花实例点
    public Transform FirePoint;
    //火花预制体
    public GameObject FirePre;
    //子弹实例点
    public Transform BulletPoint;
    //子弹预制体
    public GameObject BulletPre;
    //定义当前子弹数量
    [SerializeField] private int cur_BulletCount = 10;
    //定义最大子弹数量
    [SerializeField] private int cur_MaxBulletCount = 10;
    //定义备用弹匣数量
    [SerializeField] private int standby_BulletCount = 100;

    //定义射击间隔
    private float shootcd = 0.2f;
    //定义子弹更新UI
    public Text cur_BulletCountText;
    public Text standy_BulletCountText;

    [Header("音效")]
    //射击音效
    public AudioClip GunShootClip;
    //枪的声音播放组件
    public AudioSource GunSource;
    //换弹音效
    public AudioClip GunReloadClip;

    // Start is called before the first frame update
    void Start()
    {
        //初始化子弹UI
        InitUI();

        GunSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //时间累加
        timer += Time.deltaTime;
        //计时器判断：满足射击cd，按下鼠标左键，当前子弹数量大于0
        if (timer > shootcd && Input.GetMouseButton(0) && cur_BulletCount > 0)
        {
            //重置定时器
            timer = 0;
            //实例化开火特效及子弹
            Instantiate(FirePre, FirePoint.position, FirePoint.rotation);
            Instantiate(BulletPre, BulletPoint.position, BulletPoint.rotation);
            //减少当前子弹数
            cur_BulletCount--;
            //刷新子弹数UI
            cur_BulletCountText.text = cur_BulletCount + "/" + cur_MaxBulletCount;
            if (cur_BulletCount < 5)
            {
                cur_BulletCountText.color = Color.red;
            }
            else
            {
                cur_BulletCountText.color = Color.white;
            }
            //播放射击音效
            GunSource.PlayOneShot(GunShootClip);
            //射击时子弹为0，自动换弹
            if (cur_BulletCount == 0)//||Input.GetKeyDown(KeyCode.R)
            {
                //获取组件，设置动画条件，先执行动画
                GetComponent<Animator>().SetTrigger("Reload");
                //播放换弹音效
                GunSource.PlayOneShot(GunReloadClip);
                //延迟执行子弹更新
                //Invoke("Reload", 1.5f);
            }
        }
        //按下R键且当前子弹数<最大子弹数时，执行换弹操作
        if (cur_BulletCount < cur_MaxBulletCount && Input.GetKeyDown(KeyCode.R))
        {
            //获取组件，设置动画条件，先执行动画
            GetComponent<Animator>().SetTrigger("Reload");
            //播放换弹音效
            GunSource.PlayOneShot(GunReloadClip);
            //延迟执行子弹更新
            //Invoke("Reload", 1.5f);
        }

    }
    public void InitUI()
    {
        cur_BulletCountText.text = cur_BulletCount + "/" + cur_MaxBulletCount;
        standy_BulletCountText.text = standby_BulletCount + "";
    }

    public void AddBullet()
    {
        standby_BulletCount += 30;
        standy_BulletCountText.text = standby_BulletCount + "";
    }

    #region 动画事件
    void Reload()
    {

        // 填充子弹
        // 子弹不够、子弹足够
        int want = cur_MaxBulletCount - cur_BulletCount;
        if ((standby_BulletCount - want) < 0)
        {
            want = standby_BulletCount;
        }
        standby_BulletCount -= want;
        cur_BulletCount += want;

        //刷新子弹数UI
        cur_BulletCountText.text = cur_BulletCount + "/" + cur_MaxBulletCount;
        standy_BulletCountText.text = standby_BulletCount + "";
        if (cur_BulletCount < 5)
        {
            cur_BulletCountText.color = Color.red;
        }
        else
        {
            cur_BulletCountText.color = Color.white;
        }
        if (standby_BulletCount < 30)
        {
            standy_BulletCountText.color = Color.red;
        }
        else
        {
            standy_BulletCountText.color = Color.white;
        }
    }

    #endregion
}
