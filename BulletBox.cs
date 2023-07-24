using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletBox : MonoBehaviour
{

    private GameObject gun;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(gameObject);
            gun = GameObject.FindWithTag("Weapon");
            gun.GetComponent<GunControl>().AddBullet();
        }
    }
}
