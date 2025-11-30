using System.Runtime.CompilerServices;
using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using PurrNet;

public class EnemyManager : NetworkBehaviour
{


    public GameObject[] players;

    public GameObject spawnPoint;

    public GameObject enemy1;
    private float e1Delay = 3.5f;

    private Vector3 playerLoc;


    protected override void OnSpawned(bool asServer)
    {
        base.OnSpawned(asServer);

        enabled = isOwner;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerLoc = spawnPoint.transform.position;
        StartCoroutine(spawnEnemy(e1Delay, enemy1));

        
    }
    private void Update()
    {
        players = FindPlayers();
        if (players.Length > 0)
        {
            foreach (GameObject player in players)
            {
                playerLoc = player.transform.position;
                playerLoc = playerLoc + new Vector3(Random.Range(-13f, 13f), Random.Range(0f, 5f), Random.Range(-13f, 13f));
            }
        }
        
        
    }

    private IEnumerator spawnEnemy(float rate, GameObject enemy)
    {
        yield return new WaitForSeconds(rate);
        GameObject newEnemy = Instantiate(enemy, playerLoc, Quaternion.identity);
        StartCoroutine(spawnEnemy(rate, enemy));
    }

    GameObject[] FindPlayers()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        return players;
    } 
}
