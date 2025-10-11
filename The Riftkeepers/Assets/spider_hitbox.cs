using UnityEngine;

public class spider_hitbox : MonoBehaviour
{
    private bool active = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!active) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("Spider hit the player!");
            // Example: if your player has a health script:
            // other.GetComponent<PlayerHealth>()?.TakeDamage(10);
        }
    }

    public void ActivateHitbox() => active = true;
    public void DeactivateHitbox() => active = false;
}
