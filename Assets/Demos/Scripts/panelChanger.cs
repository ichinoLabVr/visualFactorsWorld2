using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class panelChanger : MonoBehaviourPunCallbacks
{
    private Rigidbody rb;
    private Vector3 changer;
    private Vector3 me;
    private float disx;
    private float disz;
    private GameObject panel;

    private Vector3 panelSize;
    private Vector3 panelPos;
    private int RoomNum;

    void Start()
    {
        RoomNum = PhotonNetwork.CurrentRoom.PlayerCount;
        changer = GameObject.Find($"panelChanger{RoomNum}").transform.position;
        me = this.gameObject.transform.position;
        panel = GameObject.Find("panel");
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // rb = this.GetComponent<Rigidbody>();
        if (photonView.IsMine) {
            if (!rb.IsSleeping())
            {
                me = this.gameObject.transform.position;
                disx = changer.x - me.x;
                disz = changer.z - me.z;
                Debug.Log(disx); // max -12.42459
                Debug.Log(disz); // max -15.55573 右に行くとマイナス 左に行くとプラス
                panelSize = panel.transform.localScale; //パネルサイズ取得
                panelPos = panel.transform.localPosition; //パネルポジション取得　右は-小さい(max -8.26) 左は-大きい(max -24.5)
                Debug.Log(panel.transform.localScale); //(9.0, 5.1, 0.2)
                Debug.Log(panelPos.z);
                panelSize.x = 9f - Mathf.Abs(disx*0.5f);
                panelSize.y = 5.1f - Mathf.Abs(disx*0.284375f);
                panelPos.z = disz;
                panel.transform.localScale = panelSize;
                panel.transform.localPosition = panelPos;
            }
        }
    }
}
