using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class Enemy : MonoBehaviour
{
    public int Hp;

    Vector3 pos;
    public float Max = 2.0f;
    public float speed = 3.0f;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        Vector3 objp = pos;
        objp.x = Max * Mathf.Sin(Time.time * speed);
        transform.position = objp;
    }
    public void OnDamage(int Dmg)
    {
        Hp -= Dmg;
        if(Hp <= 0)
        {

            Destroy(this.gameObject);
        }
    }
}
