using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class UpTrigger : MonoBehaviourPunCallbacks
{
    private bool _isAllowChange = false;
    private bool _isObjectTouch = false;
    private string panelChangerName;
    private GameObject panel;

    private Vector3 panelSize;
    private void Start () {
       panel = GameObject.Find("panel");
       Debug.Log(panel.transform.localScale);
    }
    private void Update () {
        if(_isAllowChange && _isObjectTouch){
            if (photonView.IsMine) {
                panelSize = panel.transform.localScale;
                panelSize.x = panelSize.x +4;
                panel.transform.localScale = panelSize;
                _isObjectTouch = false;
            }
        }

        if(!_isAllowChange && !_isObjectTouch) {
            if (photonView.IsMine) {
                
                _isObjectTouch = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "panelChanger"){
            if (photonView.IsMine) {
                _isAllowChange = true;
                panelChangerName = other.gameObject.name;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //離れたオブジェクトのタグが"Player"のとき
        if(other.gameObject.tag == "panelChanger"){
            if (photonView.IsMine) {
                _isAllowChange = false;
                panelChangerName = other.gameObject.name;
            }
        }
    }
}