using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GuidedBullet : PlayerBullet
{
    public Transform target;
    Rigidbody2D rb;

    public float rotation_speed;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(EnemyManager.Instance.enemys.Count >= 0)
        {
            List<Enemy> targets = EnemyManager.Instance.enemys.
            OrderByDescending(_ => Vector3.Distance(_.transform.position, transform.position)).ToList();
        }
    }
    void Update()
    {

        if (target != null)
        {
            transform.up = Vector3.MoveTowards(transform.up, (target.transform.position - transform.position).normalized, rotation_speed * Time.deltaTime);
        }
        /** 아래 코드는 업데이트시 유도탄 코드
         * List<Enemy> targets = EnemyManager.Instance.enemys.
            OrderByDescending(_ => Vector3.Distance(_.transform.position, transform.position)).ToList();
        _ = 변수 선언 , Vector3.Disntance(A,B) = A 와 B사이의 거리를 구함
        OrderByDescending , Linq 패키지의( 내림차순, 오름차순등 여러 알고리즘등을 하나로 가능하게 하는것) 내림차순으로, 정렬을 도와줌.
        target = targets[targets.Count - 1].transform;

        transform.up = Vector3.MoveTowards(transform.up,(target.transform.position - transform.position).normalized, rotation_speed * Time.deltaTime); **/

        rb.velocity = transform.up * speed;
    }
}
