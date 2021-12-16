using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Kick : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Kick")) {
            Debug.Log("キックしました");
            if (!photonView.IsMine)
            {
                // PhotonNetwork.CloseConnection(Player )
            }
        }    
    }
}
