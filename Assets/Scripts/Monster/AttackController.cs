using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    GameObject player;
    Animator anima;
    bool isAttackWait;
    bool isCheckPlayer;

    public float attackWaitTime;
    public int damage;

    void Start()
    {
        anima = GetComponent<Animator>();
    }

    void AttackCheck()
    {
        anima.Play("Action");
        if (isCheckPlayer)
        {
            Debug.Log("攻击命中");
            player.gameObject.GetComponent<PlayerInfo>().IncOrDecHP(-damage);
        }
        isAttackWait = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("检查碰撞");
        //Debug.Log(isAttack.ToString());

        if (!isAttackWait&&collision.tag == "Player")
        {
            isAttackWait = true;
            //Debug.Log("检测到敌人");
            Invoke("AttackCheck", attackWaitTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isCheckPlayer = true;
            player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isCheckPlayer = false;
        }
    }
}
