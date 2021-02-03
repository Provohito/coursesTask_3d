using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitControll : MonoBehaviour
{
    [Header("Объекты и параметры")]
    [SerializeField]
    private GameObject prefabBullet;

    [SerializeField]
    private Transform pointToHit;

    [SerializeField]
    private float shootForce;

    [SerializeField]
    float rechargeTime;

    [Header("Звук")]
    [SerializeField]
    private AudioClip shootSound;

    AudioSource sourceSound;

    float shootTimer;
    void Start()
    {
        sourceSound = GetComponent<AudioSource>();
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
            
            sourceSound.PlayOneShot(shootSound);
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
