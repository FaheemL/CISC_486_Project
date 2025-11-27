using UnityEngine;

public class StatTemplate : ScriptableObject
{

    public int health = 100;
    public int offence = 0;
    


}

public class EntityStat : MonoBehaviour
{
    private StatTemplate stats;

    public Stat health;
    public int currentHealth;
    public Stat offence;
    public bool dead = false;
    public bool imortal = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = new Stat(stats.health);
        offence = new Stat(stats.offence);

        currentHealth = health.getModifiedStat();

    }

    public void changeCHp(int amount)
    {
        currentHealth += amount;

        if (amount > 0)
        {

            if (currentHealth > health.getModifiedStat())
            {
                currentHealth = health.getModifiedStat();
                Debug.Log("Is at full health");
            }
        }

        else
        {

            if (currentHealth < 0)
            {
                currentHealth = 0;
                Debug.Log("CHp reached 0");
            }
        }

        if (currentHealth == 0 && !imortal)
        {
            dead = true;
            Debug.Log("Is dead");
        }

        
    }

    // Update is called once per frame
    void Update()
    {

    }
}