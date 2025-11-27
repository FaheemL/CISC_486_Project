using System.Runtime.CompilerServices;
using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EnemyManager : MonoBehaviour
{


    public GameObject player;

    public GameObject enemy1;
    private float e1Delay = 3.5f;

    private Vector3 playerLoc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerLoc = player.transform.position;
        StartCoroutine(spawnEnemy(e1Delay, enemy1));

        
    }
    private void Update()
    {
        playerLoc = player.transform.position;
        playerLoc = playerLoc + new Vector3(Random.Range(-13f, 13f), Random.Range(0f, 5f), Random.Range(-13f, 13f));
    }

    private IEnumerator spawnEnemy(float rate, GameObject enemy)
    {
        yield return new WaitForSeconds(rate);
        GameObject newEnemy = Instantiate(enemy, playerLoc, Quaternion.identity);
        StartCoroutine(spawnEnemy(rate, enemy));
    }
}
