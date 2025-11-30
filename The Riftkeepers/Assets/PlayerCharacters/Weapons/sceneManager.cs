using UnityEngine;
using PurrNet;

public class sceneManager : NetworkBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private PlayerID player;
    public void remove()
    {
        player = networkManager.localPlayer;
        networkManager.playerModule.KickPlayer(player);
    }
}
