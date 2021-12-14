using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDistance : MonoBehaviour
{
    private Vector3 changer;
    private Vector3 me;

    void Start()
    {
        changer = GameObject.Find("panelChanger").transform.position;
        me = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        me = this.gameObject.transform.position;
        Debug.Log(changer.x - me.x);
    }
}