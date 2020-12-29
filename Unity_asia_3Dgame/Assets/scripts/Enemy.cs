using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0, 30)]
    public float speed = 3;
    [Header("停止距離"), Range(0, 10)]
    public float stopDistance = 2.5f;
    [Header("攻擊間隔"), Range(0, 10)]
    public float cd = 3f;


    private Transform Player;
    private NavMeshAgent nav;
    private Animator ani;
    private float timer;

    private void Awake()
    {
        Player = GameObject.Find("角色").transform;
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();

        nav.speed = speed;
        nav.stoppingDistance = stopDistance;
    }
    private void Update()
    {
        Track();
        attack1();
    }

    private void attack1() 
    {
        if (nav.remainingDistance<stopDistance)
        {
            timer+=Time.deltaTime;

            Vector3 pos = Player.position;
            pos.y = transform.position.y;
            transform.LookAt(pos);

            if (timer>=cd)
            {
                ani.SetTrigger("attack1");
                timer = 0;
            }
        }

        
    }

    private void Track() 
    {
        nav.SetDestination(Player.position);
        ani.SetBool("run", nav.remainingDistance > stopDistance);
    }

}
