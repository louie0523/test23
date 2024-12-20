using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    public float speed;

    [SerializeField] GameObject playerBulletAPrefab;
    [SerializeField] GameObject playerBulletBPrefab;
    [SerializeField] GameObject guidedBulletPrefab;
    bool canShoot = true;
    public int power = 1;
    public float shootDelay;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        Move();
    }
    void Move()
    {
        float input_x = Input.GetAxisRaw("Horizontal");
        float input_y = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(input_x, input_y, 0).normalized;

        transform.position += dir * speed * Time.deltaTime;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if(pos.x > 1) { pos.x = 1; }
        if(pos.x < 0) { pos.x = 0; }
        if(pos.y > 1) { pos.y = 1; }
        if(pos.y < 0) { pos.y = 0; }
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        if(Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
        {
            animator.SetInteger("Move", (int)input_x);
        }
    }
    void Shoot()
    {
        if (!Input.GetKey(KeyCode.Z)) { return; }
        if (!canShoot) { return; }

        canShoot = false;
        StartCoroutine(ShootDelay());

        switch (power)
        {
            case 1:
                {
                    GameObject bulletA = Instantiate(playerBulletAPrefab);
                    GameObject bulletB = Instantiate(playerBulletAPrefab);
                    bulletA.transform.position = transform.position + Vector3.right * 0.1f;
                    bulletB.transform.position = transform.position + Vector3.left * 0.1f;
                    bulletA.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                    bulletB.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                    break;
                }
            case 2:
                {
                    GameObject bulletA = Instantiate(playerBulletAPrefab);
                    GameObject bulletB = Instantiate(playerBulletAPrefab);
                    GameObject bulletC = Instantiate(playerBulletBPrefab);
                    bulletA.transform.position = transform.position + Vector3.right * 0.2f;
                    bulletB.transform.position = transform.position + Vector3.left * 0.2f;
                    bulletC.transform.position = transform.position;
                    bulletA.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                    bulletB.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                    bulletC.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                    break;
                }
            case 3:
                {
                    break;
                }
        }
    }
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
}
