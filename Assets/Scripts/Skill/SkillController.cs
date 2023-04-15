using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    Animator anima;
    bool isAttack;
    bool enable=false;
    public string bindButton;
    public int levelLimit;
    public int damage;
    public GameObject skillSlot;

    void Start()
    {
        anima = GetComponent<Animator>();
    }

    private void Update()
    {
        LevelCheck();
        if(enable)AttackCheck();
    }

    private void LevelCheck()
    {
        if (GameObject.Find("Player").GetComponent<PlayerInfo>().GetLevel()>=levelLimit)
        {
            enable = true;
            skillSlot.SetActive(true);
        }
    }

    private void AttackCheck()
    {
        if (Input.GetButtonDown(bindButton))
        {
            isAttack = true;
            anima.Play("Action");
        }
        if (Input.GetButtonUp(bindButton))
        {
            isAttack = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isAttack)
        {
            Debug.Log("检测敌人");
            if (collision.tag == "Monster")
            {
                Debug.Log("检测到敌人");
                collision.gameObject.GetComponent<MonsterInfo>().Hurt(5);
            }
        }
        isAttack = false;
    }
}
