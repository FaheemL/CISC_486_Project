using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.LowLevel;
using static UnityEngine.GraphicsBuffer;

public class orb_controller : MonoBehaviour
{
    private GameObject cloEn; //closest enemy


    public GameObject orb;
    public GameObject player;
    public GameObject beam;
    
    private float dist;
    public int range = 10;

    public float cooldown = 2f;
    private float firePerm = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = FindClosestEnemy();
        if (cloEn != null)
        {
            orb.transform.LookAt(cloEn.transform.position);
            orb.transform.Rotate(-90,0,0);
            
            if(dist <= range)
            {
                beam.SetActive(true);

                if(Time.time > firePerm)
                {
                    Attacking(cloEn);
                    firePerm = Time.time + cooldown;
                }
            }
            else
            {
                beam.SetActive(false);
            }
        }
        else
        {
            beam.SetActive(false);
        }

        




    }


    
    

    float FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject result = null;
        float resDist = float.MaxValue;
        float dist = float.MaxValue;
        if (enemies.Length > 0)
        {
            foreach (GameObject enemy in enemies)
            {
                dist = Vector3.Distance(enemy.transform.position, orb.transform.position);
                if (dist < resDist)
                {
                    result = enemy;
                    resDist = dist;
                }
            }
            cloEn = result;
        }

        else
        {
            cloEn = null;
        }
        return dist;
    }

    void Attacking(GameObject enemy)
    {
        enemy.GetComponent<enemyStats>().changeCHp(-player.GetComponent<CharStats>().offence.value);
        enemy.GetComponent<enemyStats>().updLstHitBy(player);
    }
}
