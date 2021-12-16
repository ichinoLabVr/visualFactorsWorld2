using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.Video;
using UnityEngine.Audio;
using System;
public class CreateSP : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    // AudioSource audioSource;
    GameObject Efbj;
    public GameObject[] Efbjs;
    float ObjY = 0.5f; //SPの高さ
    int RoomNum;
    public override void OnJoinedRoom()
    {
        //リソースのSPを指定
        Efbj = (GameObject)Resources.Load("panelChanger");
        RoomNum = PhotonNetwork.CurrentRoom.PlayerCount;
        Debug.Log("現在 " + RoomNum + "名");

        //作成するSPの数を配列で指定
        Efbjs = new GameObject[RoomNum];

        //SP生成
        GenerationSpeaker(RoomNum);
    }



    // 他プレイヤーがルームへ参加した時に呼ばれるコールバック
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        RoomNum = PhotonNetwork.CurrentRoom.PlayerCount;
        Debug.Log("現在 " + RoomNum + "名");

        //作成するSPの数を変更するため配列の要素数を変更する
        Array.Resize(ref Efbjs, RoomNum);

        //SP生成
        GenerationSpeaker(RoomNum);
    }

    // 他プレイヤーがルームから退出した時に呼ばれるコールバック
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        RoomNum = PhotonNetwork.CurrentRoom.PlayerCount;
        Debug.Log("現在 " + RoomNum + "名 1人退出");
    }

    // Update is called once per frame
    void Update()
    {
    }
    void GenerationSpeaker(int Createnum)
    {
        //生成する列の数
        int line = (Createnum / 8) + 1;

        for (int i = 0; i < line; i++)
        {
            for (int j = 0; (j < 8) && (Createnum > j); j++)
            {
                if (Efbjs[(i * 8) + j] == null)
                {
                    if (i % 2 == 0)
                    {
                        Efbjs[(i * 8) + j] = Instantiate(Efbj, new Vector3(-5.0f + (i * 1.5f), ObjY, -4.9f + j * 1.5f), Quaternion.identity);
                        Efbjs[j + (8 * i)].name = "panelChanger" + (j + (8 * i)+1);
                    }
                    else if (i % 2 == 1)
                    {
                        Efbjs[(i * 8) + j] = Instantiate(Efbj, new Vector3(-5.0f + (i * 1.5f), ObjY, -5.5f + j * 1.5f), Quaternion.identity);
                        Efbjs[j + (8 * i)].name = "panelChanger" + (j + (8 * i)+1);
                    }
                }
            }
            Createnum -= 8;
        }
    }
}