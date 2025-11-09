using UnityEngine;
using UnityEngine.AI;

public class DogFollowPlayer : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    public Animator mAnimator;

    private float currentSpeed; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

        currentSpeed = agent.velocity.magnitude;

        if (player != null)
        {
            agent.SetDestination(player.position);
        }

        mAnimator.SetFloat("Speed", currentSpeed);
        
    }
}