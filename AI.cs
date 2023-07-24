using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public enum EnemyState
{
    idle,
    run,
    attack
}
public class AI : MonoBehaviour
{

    [SerializeField] public EnemyState curr_State = EnemyState.idle;
    //动画控制器
    //private Animation ani;
    private Animator ani;
    //寻路代理
    private NavMeshAgent agent;
    //玩家
    private Transform player;

    private GameObject player1;

    [Header("敌人属性")]
    [SerializeField] private float EnemyHp = 100;
    [SerializeField] private float EnemyMaxHp = 100;
    public int damage;

    [Header("敌人属性UI")]
    public Text EnemyHpText;
    //public Slider EnemySlider;
    public Image EnemyHpImage;

    // Start is called before the first frame update
    void Start()
    {
        EnemyHp = 100;
        EnemyMaxHp = 100;
        damage = 20;
        //ani = GetComponent<Animation>();
        ani = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
        player1 = GameObject.FindWithTag("Player");
    }

    void puthit()
    {
        if (player1 != null)
        {
            player.GetComponent<PlayerControl>().gethit(damage);
            ani.SetBool("run", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(player.position, transform.position);
        switch (curr_State)
        {
            //0<3<10
            case EnemyState.idle:
                //进入警戒范围
                if (dis > 2 && dis < 10)
                {
                    curr_State = EnemyState.run;
                    ani.SetBool("run", true);
                }
                if (dis > 0 && dis < 2)
                {
                    curr_State = EnemyState.attack;
                    ani.SetBool("attack", true);
                }
                agent.speed = 1f;
                //播放动画
                ani.SetBool("run", false);
                //导航停止
                agent.isStopped = true;
                break;
            case EnemyState.run:
                //离开巡逻范围
                if (dis > 10)
                {
                    curr_State = EnemyState.idle;
                }
                if (dis > 0 && dis < 2)
                {
                    curr_State = EnemyState.attack;
                    
                }
                agent.speed = 2f;
                //播放动画
                ani.SetBool("run", true);
                //确保导航执行状态
                agent.isStopped = false;

                agent.SetDestination(player.position);
                //设置终点
                break;
            case EnemyState.attack:
                if (dis > 2)
                {
                    curr_State = EnemyState.run;
                    ani.SetBool("run", true);
                }
                agent.speed = 0.1f;
                ani.SetTrigger("attack");
                agent.isStopped = true;
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //被射中
        if (other.tag == "Bullet")
        {


            //敌人血量减少
            EnemyHp -=20;
            EnemyHpText.text = EnemyHp + "";

            float i = EnemyHp / EnemyMaxHp;
            //Debug.Log(i);
            //EnemySlider.value = i;
            EnemyHpImage.fillAmount = i;
            //血量不足
            if (EnemyHp <= 0)
            {
                //死亡
                Destroy(gameObject);
            }
        }
    }
}
