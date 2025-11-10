using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
using static UnityEngine.Rendering.DebugUI;

public class DogFollowPlayer : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    private Animator mAnimator;
    public Dog_attack hitbox;
    private float currentSpeed;
    private float aggroRng = 3f;
    public float stopDistance = 1.5f;
    private bool isAggroed = false;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;


        mAnimator = GetComponent<Animator>();
        if (hitbox == null)
            hitbox = GetComponentInChildren<Dog_attack>();
        
    }

    void Update()
    {
        currentSpeed = agent.velocity.magnitude;
        //Enemy attacking
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float closest = float.PositiveInfinity;
        GameObject closestEn = null;
        foreach (GameObject enemy in Enemies)
        {
            float dist = Vector3.Distance(enemy.transform.position, transform.position);

            if (dist < closest)
            {
                closest = dist;
                closestEn = enemy;
            }
        }
        

        if (!isAggroed && closest <= aggroRng)
        {
            isAggroed = true;

        }
      
        

        bool isMoving = false;
        bool isAttacking = false;

        
        if (isAggroed && (closestEn != null))
        {
            Vector3 direction = (closestEn.transform.position - transform.position);
            direction.y = 0;

            float distance = direction.magnitude;
            direction.Normalize();
            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5f * Time.deltaTime);
            }

            if (distance > stopDistance)
            {

                isMoving = true;
                hitbox?.DeactivateHitbox();
            }
            else
            {
                
                isAttacking = true;
                hitbox?.ActivateHitbox();
            }

            agent.SetDestination(closestEn.transform.position);

        }
        
        else
        {
            isAggroed = false;
            isMoving = false;
            isAttacking = false;
            hitbox?.DeactivateHitbox();
        }


        

        //Moving
        

        if (player != null && !isAggroed)
        {
            agent.SetDestination(player.position);
        }
        

        mAnimator.SetFloat("Speed", currentSpeed);
        mAnimator.SetBool("isAttacking", isAttacking);

    }
}