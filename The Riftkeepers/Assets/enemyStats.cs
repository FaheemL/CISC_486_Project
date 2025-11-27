using UnityEditor.SceneManagement;
using UnityEngine;

public class enemyStats : EntityStat
{
    private GameObject lstHitBy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.dead)
        {
            lstHitBy.GetComponent<CharStats>().updXp(2);
            Destroy(gameObject);
            
        }
    }

    public void updLstHitBy(GameObject entity)
    {
        lstHitBy = entity;
    }
}
