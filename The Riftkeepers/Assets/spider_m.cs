using UnityEngine;

public class spider_m : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    private Animator animator;

    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float rotationSpeed = 5f;

    [Header("Behavior Settings")]
    public float stopDistance = 1.5f;
    public float aggroRange = 8f;

    [Header("Optional Components")]
    public spider_hitbox hitbox;

    private bool isAggroed = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (hitbox == null)
            hitbox = GetComponentInChildren<spider_hitbox>();
    }

    void Update()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position);
        direction.y = 0;

        float distance = direction.magnitude;
        direction.Normalize();


        if (!isAggroed && distance <= aggroRange)
        {
            isAggroed = true;

        }


        bool isMoving = false;
        bool isAttacking = false;

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
            }
        }
        else
        {

            isMoving = false;
            isAttacking = false;
            hitbox?.DeactivateHitbox();
        }


        animator.SetBool("isRunning", isMoving);
        animator.SetBool("isAttacking", isAttacking);
    }
}
