using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public GameObject enemyMarker;
    public bool isPast;
    public TeleportEnemyOnDamage tpScript;
    // Start is called before the first frame update
    void Start()
    {
        tpScript = enemyMarker.GetComponent<TeleportEnemyOnDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        isPast = tpScript.isPast;
        //Debug.Log("The enemy timeline is : " + tpScript.isPast);
        this.transform.position = enemyMarker.transform.position;
       
    }
}
