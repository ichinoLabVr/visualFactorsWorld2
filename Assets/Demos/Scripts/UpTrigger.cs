using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class UpTrigger : MonoBehaviourPunCallbacks
{
    private bool _isAllowChange = false;
    private bool _isObjectTouch = false;
    private string arrowName;
    private GameObject arrow;
    private void Start () {
       
    }
    private void Update () {
        if(_isAllowChange && _isObjectTouch){
            if (photonView.IsMine) {
                arrow = GameObject.Find(arrowName);
                Renderer rend = arrow.GetComponentInChildren<Renderer>();
                Debug.Log(rend);
                rend.enabled = true;
                Debug.Log(arrow);
                _isObjectTouch = false;
            }
        }

        if(!_isAllowChange && !_isObjectTouch) {
            if (photonView.IsMine) {
                arrow = GameObject.Find(arrowName);
                Debug.Log(arrow);
                _isObjectTouch = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Arrow"){
            if (photonView.IsMine) {
                _isAllowChange = true;
                arrowName = other.gameObject.name;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //離れたオブジェクトのタグが"Player"のとき
        if(other.gameObject.tag == "Arrow"){
            if (photonView.IsMine) {
                _isAllowChange = false;
                arrowName = other.gameObject.name;
            }
        }
    }
}