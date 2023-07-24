using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    [Header("��������")]
    [SerializeField] private int EnemyHp = 5;

    public Animator ani;

    private GameObject player1;
    void Start()
    {
        ani = GetComponent<Animator>();
        player1 = GameObject.FindWithTag("Player");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //������
        if (other.tag == "Bullet")
        {
            //����Ѫ������
            EnemyHp--;
            ani.SetTrigger("hurt");
            //Ѫ������
            if (EnemyHp <= 0)
            {
                //����
                Destroy(gameObject);
                player1.GetComponent<PlayerControl>().Heal();
            }
        }
    }
}
