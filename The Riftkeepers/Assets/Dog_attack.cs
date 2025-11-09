using UnityEngine;

public class Dog_attack : MonoBehaviour
{
    public petStats dog;
    public Animator mAnimator;

    private bool active = false;
    private bool onCooldown = false;
    private float timerStart;
    public float cooldown;


    private void OnTriggerEnter(Collider other)
    {
        if (!active) return;

        if (other.CompareTag("Enemy") && !onCooldown)
        {
            other.GetComponent<enemyStats>().changeCHp(dog.offence.value);
            DeactivateHitbox();
            onCooldown = true;
            timerStart = Time.time;
            mAnimator.SetBool("isAttacking", true);
        }
    }

    public void ActivateHitbox() => active = true;
    public void DeactivateHitbox() => active = false;

    private void Update()
    {
        if (Time.time > timerStart + cooldown)
        {
            ActivateHitbox();
            mAnimator.SetBool("isAttacking", false);
        }
    }
}

