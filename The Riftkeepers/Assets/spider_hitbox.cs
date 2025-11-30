using UnityEngine;

public class spider_hitbox : MonoBehaviour
{
    private bool active = false;
    private float delay = 1.5f;
    private float cooldown = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (!active) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("Spider hit the player!");
            if (Time.time > cooldown)
            {
                other.GetComponent<CharStats>().changeCHp(-GetComponentInParent<enemyStats>().offence.value);

                cooldown = Time.time + delay;


            }




            // Example: if your player has a health script:
            // other.GetComponent<PlayerHealth>()?.TakeDamage(10);
        }
    }

    public void ActivateHitbox() => active = true;
    public void DeactivateHitbox() => active = false;
}
