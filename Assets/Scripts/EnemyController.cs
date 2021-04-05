using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float lookRadius;
    [SerializeField] private Transform target;

    private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    public const float TurnTime = 5f;

    private Vector3 currentPosition;
    private Vector3 lastPosition;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        currentPosition = transform.position;
        if (currentPosition != lastPosition)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        lastPosition = currentPosition;

        float distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distanceToTarget <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hurtable")
        {
            Destroy(gameObject);
        }
    }
}
