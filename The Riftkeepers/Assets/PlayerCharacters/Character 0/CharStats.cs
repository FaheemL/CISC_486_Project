using PurrNet;
using UnityEngine;
using UnityEngine.SceneManagement;
using PurrNet;


public class CharStats : EntityStat
{
    public int curXp = 0;
    public int nxtXp = 5;
    private int level = 1;
    private GameObject boss;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            SceneManager.LoadSceneAsync(0);
        }
    }

    public void updXp(int amount)
    {
        curXp += amount;
        if(curXp > nxtXp)
        {
            curXp = curXp - nxtXp;
            nxtXp = nxtXp * 2;
            level += 1;
        }
    }
}


