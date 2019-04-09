using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSetup : MonoBehaviour
{

    private PhotonView PV;
    public int characterValue, playerHealth, playerDmg;
    public GameObject myChar;
    public Camera mycam;
    public AudioListener myAL;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if(PV.IsMine)
        {
            PV.RPC("RPC_AddChar", RpcTarget.AllBuffered, PlayerInfo.Pi.mySelectedCharacter);
        } else
        {
            Destroy(myAL);
            Destroy(mycam);
        }
    }

    [PunRPC]
    void RPC_AddChar(int whichChar)
    {
        characterValue = whichChar;
        myChar = Instantiate(PlayerInfo.Pi.allChar[whichChar], transform.position, transform.rotation, transform);
    }
}
