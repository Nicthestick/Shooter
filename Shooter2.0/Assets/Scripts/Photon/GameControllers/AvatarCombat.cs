using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarCombat : MonoBehaviour
{

    private PhotonView PV;
    private AvatarSetup avatarsetup;
    public Transform rayOrigin;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        avatarsetup = GetComponent<AvatarSetup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PV.IsMine)
        {
            return;
        }

        PV.RPC("RPC_shooting", RpcTarget.All);
    }

    [PunRPC]
    void RPC_shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin.position, rayOrigin.TransformDirection(Vector3.forward), out hit, 1000))
            {
                Debug.DrawRay(rayOrigin.position, rayOrigin.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                Debug.Log("Hit");
                if (hit.transform.tag == "Avatar")
                {
                    hit.transform.gameObject.GetComponent<AvatarSetup>().playerHealth -= avatarsetup.playerDmg;
                }
            }
            else
            {
                Debug.DrawRay(rayOrigin.position, rayOrigin.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("No Hit");
            }
        }
    }
}
