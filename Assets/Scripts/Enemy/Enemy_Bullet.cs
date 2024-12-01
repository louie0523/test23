using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float Bullet_Speed = 10.0f;
    public int BulletHow = 3;
    public float AngleDiffrent = 30.0f;

    public float lastShotTime = 0f;
    public float fireRate = 0.5f;

    void Update() {
        if (Time.time- lastShotTime >= fireRate) { 
            lastShotTime = Time.time;

            for (int i = 0; i < BulletHow; i++) {
                float angle = (i-((BulletHow-1) / 2.0f)) * AngleDiffrent; //총알 위치 균동하게 배치하는 코드
                GameObject Bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
                Bullet.transform.Rotate(0, 0, angle);
                Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(-transform.up * Bullet_Speed, ForceMode2D.Impulse);

                StartCoroutine(Delay(Bullet, 1.0f));
            }
        }
        // StartCoroutine(Delay(Bullet, 1.0f));
    }

    IEnumerator Delay(GameObject bullet, float time) {
        yield return new WaitForSeconds(time);
        Destroy(bullet);
    }
}
