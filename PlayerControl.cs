using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    //�������
    private Rigidbody rBody;
    //������� 
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

        //��ȡ���
        rBody = GetComponent<Rigidbody>();
        footPlayer = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //���¿ո��,������ڵ����ϣ���������Ծ״̬
        if (Input.GetKeyDown(KeyCode.Space)&&isGround==true)
        {
            //ʩ��һ�����ϵ���
            rBody.AddForce(Vector3.up * jumpValue);
            footPlayer.PlayOneShot(jump);
        }
        //�ж��Ƿ��·����
        float horizontal = Input.GetAxis("Horizontal");//��ȡˮƽ����ֵ
        float vertical = Input.GetAxis("Vertical");//��ȡ��ֱ����ֵ
        //���°���ʱhorizontal��vertical����1��-1
        if((horizontal!=0||vertical!=0)&&isGround==true)
        {
            //��⵱ǰ�Ƿ񲥷ţ����������ص�
            if(footPlayer.isPlaying==false)
            {
                //��������
                footPlayer.Play();
            }
        }
        else
        {
            //ֹͣ����
            footPlayer.Play();
        }
        //ʧ�ܼ��
        Dead();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�������ײ
        if(collision.collider.tag=="Ground")
        {
            isGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        //�������ײ���뿪���棬����Ծ״̬
        if (collision.collider.tag == "Ground")
        {
            isGround = false;
        }
    }

    public void gethit(int damage)
    {
        Debug.Log("�ܵ�����");
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
    //�������
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
