using UnityEngine;

public class spider_m : MonoBehaviour
{
    [Header("References")]
    
    private Animator animator;
    private GameObject cloPl;

    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float rotationSpeed = 5f;

    [Header("Behavior Settings")]
    public float stopDistance = 1.5f;
    public float aggroRange = 8f;

    [Header("Optional Components")]
    public spider_hitbox hitbox;

    private bool isAggroed = false;

    private float delay = 1.5f;
    private float cooldown = 0;


    void Start()
    {
        animator = GetComponent<Animator>();
        if (hitbox == null)
            hitbox = GetComponentInChildren<spider_hitbox>();
    }

    void Update()
    {
        bool isMoving = false;
        bool isAttacking = false;

        float distance = FindClosestPlayer();
        if (cloPl != null)
        {
            Vector3 direction = (cloPl.transform.position - transform.position);
            direction.y = 0;

            direction.Normalize();


            if (!isAggroed && distance <= aggroRange)
            {
                isAggroed = true;

            }




            if (isAggroed)
            {

                if (direction != Vector3.zero)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
                }

                if (distance > stopDistance)
                {

                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    isMoving = true;
                    hitbox?.DeactivateHitbox();
                }
                else
                {

                    isAttacking = true;
                    hitbox?.ActivateHitbox();
                    if (Time.time > cooldown)
                    {
                        cloPl.GetComponent<CharStats>().changeCHp(-GetComponent<enemyStats>().offence.value);
                        cooldown = Time.time + delay;
                    }

                }
            }
            else
            {

                isMoving = false;
                isAttacking = false;
                hitbox?.DeactivateHitbox();
            }


        }
        


        animator.SetBool("isRunning", isMoving);
        animator.SetBool("isAttacking", isAttacking);
    }


    float FindClosestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject result = null;
        float resDist = float.MaxValue;
        float dist = float.MaxValue;
        if (players.Length > 0)
        {
            foreach (GameObject player in players)
            {
                dist = Vector3.Distance(player.transform.position, transform.position);
                if (dist < resDist)
                {
                    result = player;
                    resDist = dist;
                }
            }
            cloPl = result;
        }

        else
        {
            cloPl = null;
        }
        return dist;
    }

}
