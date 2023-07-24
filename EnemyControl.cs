using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    [Header("敌人属性")]
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
        //被射中
        if (other.tag == "Bullet")
        {
            //敌人血量减少
            EnemyHp--;
            ani.SetTrigger("hurt");
            //血量不足
            if (EnemyHp <= 0)
            {
                //死亡
                Destroy(gameObject);
                player1.GetComponent<PlayerControl>().Heal();
            }
        }
    }
}
