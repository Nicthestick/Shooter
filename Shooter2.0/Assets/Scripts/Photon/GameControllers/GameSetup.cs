using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSetup : MonoBehaviour
{

    public static GameSetup GS;

    public Transform[] spawnPoints;

    private void OnEnable()
    {
        if(GameSetup.GS == null)
        {
            GameSetup.GS = this; 
        }
    }

    public void DisconnectedPlayer()
    {
        StartCoroutine(DisconnectedAndLoad());
    }
    
    IEnumerator DisconnectedAndLoad()
    {
        PhotonNetwork.Disconnect();
        while(PhotonNetwork.IsConnected)
            yield return null;
        SceneManager.LoadScene(0);
    }
}
