using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class UpTrigger : MonoBehaviourPunCallbacks
{
    private bool _isAllowChange = false;
    private bool _isObjectTouch = false;
    private GameObject arrow;
    private void Start () {
        arrow = GameObject.FindGameObjectWithTag("Arrow");   
    }
    private void Update () {
        if(_isAllowChange && _isObjectTouch){
            if (photonView.IsMine) {
                arrow.SetActive(true);
                _isObjectTouch = false;
            }
        }

        if(!_isAllowChange && !_isObjectTouch) {
            if (photonView.IsMine) {
                arrow.SetActive(false);
                _isObjectTouch = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "DistanceCIrcle"){
            if (photonView.IsMine) {
                _isAllowChange = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //離れたオブジェクトのタグが"Player"のとき
        if(other.gameObject.tag == "DistanceCIrcle"){
            if (photonView.IsMine) {
                _isAllowChange = false;
            }
        }
    }
}