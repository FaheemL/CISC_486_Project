using UnityEngine;

public class Dog_attack : MonoBehaviour
{
    public petStats dog;
    

    private bool active;
    


    private void OnTriggerEnter(Collider other)
    {
        if (!active) return;

        if (other.CompareTag("Enemy") )
        {
            other.GetComponent<enemyStats>().changeCHp(dog.offence.value);

            
            Debug.Log("Dog hit the enemy!");
        }
    }

    public void ActivateHitbox() => active = true;
    public void DeactivateHitbox() => active = false;

   
}

