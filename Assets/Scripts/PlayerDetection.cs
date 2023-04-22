using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public List<Collider2D> detectedPlayers = new List<Collider2D>();

    private Collider2D col;

    //玩家位置
    private float playerPositionX;
    //敌人位置
    private float selfPositionX;
    //敌人与玩家的相对位置
    private float distance;

    //敌人朝向
    private float selfDirection;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    playerPositionX = collision.gameObject.transform.position.x;

    //    selfPositionX = GetComponentInParent<Transform>().position.x;
    //    selfDirection = GetComponentInParent<Transform>().localScale.x;

    //    distance = selfPositionX - playerPositionX;
    //    Debug.Log(selfPositionX);
    //    if (detectedPlayers.Count == 0)
    //    {
    //        if (distance >= 0) //敌人在玩家右侧
    //        {
    //            if (selfDirection >= 0) //敌人冲右，背对玩家，需转身
    //            {
    //                detectedPlayers.Add(collision);
    //                Debug.Log("发现玩家");
    //                Debug.Log(playerPositionX);
    //            }
    //            else //敌人冲左，面对玩家，无需转身
    //            {

    //            }
    //        }
    //        else //敌人在玩家左侧
    //        {
    //            if (selfDirection >= 0) //敌人冲右，面对玩家，无需转身
    //            {

    //            }
    //            else //敌人冲左，被对玩家，需转身
    //            {
    //                detectedPlayers.Add(collision);
    //            }
    //        }
    //    }
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (detectedPlayers.Count != 0)
        //{
        //    detectedPlayers.Remove(collision);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
