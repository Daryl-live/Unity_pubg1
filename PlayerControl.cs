using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    //定义刚体
    private Rigidbody rBody;
    //声音组件 
    private AudioSource footPlayer;
    public AudioClip jump;
    public AudioClip hurt;
    public int jumpValue = 250;

    private bool isGround = true;

    public Text Hp_Text;

    public int hp = 100;
    public int currentHp;

    
    // Start is called before the first frame update
    void Start()
    {
        currentHp = hp;
        Hp_Text.text = hp + "";

        //获取组件
        rBody = GetComponent<Rigidbody>();
        footPlayer = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //按下空格键,且玩家在地面上，不处于跳跃状态
        if (Input.GetKeyDown(KeyCode.Space)&&isGround==true)
        {
            //施加一个向上的力
            rBody.AddForce(Vector3.up * jumpValue);
            footPlayer.PlayOneShot(jump);
        }
        //判读是否按下方向键
        float horizontal = Input.GetAxis("Horizontal");//获取水平方向值
        float vertical = Input.GetAxis("Vertical");//获取竖直方向值
        //按下按键时horizontal和vertical返回1或-1
        if((horizontal!=0||vertical!=0)&&isGround==true)
        {
            //检测当前是否播放，避免声音重叠
            if(footPlayer.isPlaying==false)
            {
                //播放声音
                footPlayer.Play();
            }
        }
        else
        {
            //停止声音
            footPlayer.Play();
        }
        //失败检测
        Dead();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //与地面碰撞
        if(collision.collider.tag=="Ground")
        {
            isGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        //与地面碰撞后，离开地面，即跳跃状态
        if (collision.collider.tag == "Ground")
        {
            isGround = false;
        }
    }

    public void gethit(int damage)
    {
        Debug.Log("受到攻击");
        currentHp -= damage;
        Hp_Text.text = currentHp + "";
        footPlayer.PlayOneShot(hurt);
        if (currentHp > 50)
        {
            Hp_Text.color = Color.white;
        }
        else
        {
            Hp_Text.color = Color.red;
        }

    }
    //死亡检测
    public void Dead()
    {
        if(currentHp<=0)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void Heal()
    {
        currentHp += 30;
        Hp_Text.text = currentHp + "";
        if (currentHp > 50)
        {
            Hp_Text.color = Color.white;
        }
        else
        {
            Hp_Text.color = Color.red;
        }
    }

}
