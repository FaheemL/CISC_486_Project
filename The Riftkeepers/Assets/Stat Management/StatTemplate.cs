using UnityEngine;

public class StatTemplate : ScriptableObject
{

    public int health = 100;
    public int offence = 10;


}

public class EntityStat : MonoBehaviour
{
    private StatTemplate stats;

    public Stat health;
    public int currentHealth;
    public Stat offence;
    public bool dead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = new Stat(stats.health);
        offence = new Stat(stats.offence);

        currentHealth = health.getModifiedStat();

    }

    public void changeCHp(int amount)
    {
        if (amount > 0)
        {
            currentHealth += amount;

            if (currentHealth > health.getModifiedStat())
            {
                currentHealth = health.getModifiedStat();
            }
        }

        else
        {
            currentHealth -= amount;

            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
        }

        if (currentHealth == 0)
        {
            dead = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}