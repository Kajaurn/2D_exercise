using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public List<Collider2D> detectedPlayers = new List<Collider2D>();

    private Collider2D col;

    //���λ��
    private float playerPositionX;
    //����λ��
    private float selfPositionX;
    //��������ҵ����λ��
    private float distance;

    //���˳���
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
    //        if (distance >= 0) //����������Ҳ�
    //        {
    //            if (selfDirection >= 0) //���˳��ң�������ң���ת��
    //            {
    //                detectedPlayers.Add(collision);
    //                Debug.Log("�������");
    //                Debug.Log(playerPositionX);
    //            }
    //            else //���˳��������ң�����ת��
    //            {

    //            }
    //        }
    //        else //������������
    //        {
    //            if (selfDirection >= 0) //���˳��ң������ң�����ת��
    //            {

    //            }
    //            else //���˳��󣬱�����ң���ת��
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
