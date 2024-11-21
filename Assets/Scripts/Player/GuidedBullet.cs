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
        /** �Ʒ� �ڵ�� ������Ʈ�� ����ź �ڵ�
         * List<Enemy> targets = EnemyManager.Instance.enemys.
            OrderByDescending(_ => Vector3.Distance(_.transform.position, transform.position)).ToList();
        _ = ���� ���� , Vector3.Disntance(A,B) = A �� B������ �Ÿ��� ����
        OrderByDescending , Linq ��Ű����( ��������, ���������� ���� �˰������ �ϳ��� �����ϰ� �ϴ°�) ������������, ������ ������.
        target = targets[targets.Count - 1].transform;

        transform.up = Vector3.MoveTowards(transform.up,(target.transform.position - transform.position).normalized, rotation_speed * Time.deltaTime); **/

        rb.velocity = transform.up * speed;
    }
}
