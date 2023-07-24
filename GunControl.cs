using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunControl : MonoBehaviour
{
    //��ʱ��
    public float timer = 0;

    [Header("�������")]
    //��ʵ����
    public Transform FirePoint;
    //��Ԥ����
    public GameObject FirePre;
    //�ӵ�ʵ����
    public Transform BulletPoint;
    //�ӵ�Ԥ����
    public GameObject BulletPre;
    //���嵱ǰ�ӵ�����
    [SerializeField] private int cur_BulletCount = 10;
    //��������ӵ�����
    [SerializeField] private int cur_MaxBulletCount = 10;
    //���屸�õ�ϻ����
    [SerializeField] private int standby_BulletCount = 100;

    //����������
    private float shootcd = 0.2f;
    //�����ӵ�����UI
    public Text cur_BulletCountText;
    public Text standy_BulletCountText;

    [Header("��Ч")]
    //�����Ч
    public AudioClip GunShootClip;
    //ǹ�������������
    public AudioSource GunSource;
    //������Ч
    public AudioClip GunReloadClip;

    // Start is called before the first frame update
    void Start()
    {
        //��ʼ���ӵ�UI
        InitUI();

        GunSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //ʱ���ۼ�
        timer += Time.deltaTime;
        //��ʱ���жϣ��������cd����������������ǰ�ӵ���������0
        if (timer > shootcd && Input.GetMouseButton(0) && cur_BulletCount > 0)
        {
            //���ö�ʱ��
            timer = 0;
            //ʵ����������Ч���ӵ�
            Instantiate(FirePre, FirePoint.position, FirePoint.rotation);
            Instantiate(BulletPre, BulletPoint.position, BulletPoint.rotation);
            //���ٵ�ǰ�ӵ���
            cur_BulletCount--;
            //ˢ���ӵ���UI
            cur_BulletCountText.text = cur_BulletCount + "/" + cur_MaxBulletCount;
            if (cur_BulletCount < 5)
            {
                cur_BulletCountText.color = Color.red;
            }
            else
            {
                cur_BulletCountText.color = Color.white;
            }
            //���������Ч
            GunSource.PlayOneShot(GunShootClip);
            //���ʱ�ӵ�Ϊ0���Զ�����
            if (cur_BulletCount == 0)//||Input.GetKeyDown(KeyCode.R)
            {
                //��ȡ��������ö�����������ִ�ж���
                GetComponent<Animator>().SetTrigger("Reload");
                //���Ż�����Ч
                GunSource.PlayOneShot(GunReloadClip);
                //�ӳ�ִ���ӵ�����
                //Invoke("Reload", 1.5f);
            }
        }
        //����R���ҵ�ǰ�ӵ���<����ӵ���ʱ��ִ�л�������
        if (cur_BulletCount < cur_MaxBulletCount && Input.GetKeyDown(KeyCode.R))
        {
            //��ȡ��������ö�����������ִ�ж���
            GetComponent<Animator>().SetTrigger("Reload");
            //���Ż�����Ч
            GunSource.PlayOneShot(GunReloadClip);
            //�ӳ�ִ���ӵ�����
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

    #region �����¼�
    void Reload()
    {

        // ����ӵ�
        // �ӵ��������ӵ��㹻
        int want = cur_MaxBulletCount - cur_BulletCount;
        if ((standby_BulletCount - want) < 0)
        {
            want = standby_BulletCount;
        }
        standby_BulletCount -= want;
        cur_BulletCount += want;

        //ˢ���ӵ���UI
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
