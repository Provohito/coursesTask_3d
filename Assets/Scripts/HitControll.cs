using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitControll : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabBullet;

    [SerializeField]
    private Transform pointToHit;

    [SerializeField]
    private float shootForce;

    [SerializeField]
    float rechargeTime;

    float shootTimer;
    void Start()
    {

    }
    void Update()
    {
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer < 0)
                shootTimer = 0;
            
        }

        if (Input.GetMouseButtonDown(0) && !IsRecharge)
        {
            Rigidbody _rgBodyBullet = Instantiate(prefabBullet).GetComponent<Rigidbody>();
            _rgBodyBullet.transform.position = pointToHit.position;
            _rgBodyBullet.transform.rotation = pointToHit.rotation; 

            _rgBodyBullet.AddForce(_rgBodyBullet.transform.forward * shootForce, ForceMode.Impulse);
            shootTimer = rechargeTime;
            StartCoroutine(DestroyObject(_rgBodyBullet.gameObject));
            
        }
    }

    bool IsRecharge => shootTimer > 0;

    IEnumerator DestroyObject(GameObject value)
    {
        yield return new WaitForSeconds(2f);
        Destroy(value);
    }

}
