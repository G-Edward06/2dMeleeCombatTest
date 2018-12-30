using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region PUBLIC_VAR
    #endregion
    #region PRIVATE_VAR
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius;
    [SerializeField] private float movementSpeed;
    [SerializeField] private int damage;
    private Animator anim;
    private bool damageMode;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // 如果点击了鼠标左键，播放攻击动画
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }

        //检查attackPoint和damagemaker是否处于活动状态
        //if (attackPoint.gameObject.active == true && damageMode == false)
        //{
        //    damageMode = true;
        //    Collider2D[] hittedObjects = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius);
        //    if (hittedObjects.Length > 0)
        //    {
        //        for (int i = 0; i < hittedObjects.Length; i++)
        //        {
        //            if (hittedObjects[i].gameObject != gameObject)
        //            {
        //                EnemyMovement enemy = hittedObjects[i].gameObject.GetComponent<EnemyMovement>();
        //                if (enemy != null)
        //                {
        //                    enemy.health -= damage;
        //                }
        //            }
        //        }
        //    }
        //}
        //else if (attackPoint.gameObject.active == false && damageMode == true)
        //{
        //    damageMode = false;
        //}

        // 检查水平轴
        float movement = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        // 如果movement不等于0，这表示玩家按下了A或D，所以停止空闲动画，否则停止奔跑动画
        if (movement != 0 && anim.GetCurrentAnimatorStateInfo(0).IsName("Attacking") == false)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);
            // 如果movement值大于0，这表示玩家对象向右移动，所以将玩家对象向右转并进行移动
            if (movement > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.Translate(transform.right * movement);
            }
            else if (movement < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.Translate(transform.right * movement);
            }
        }
        else if (movement == 0 && anim.GetCurrentAnimatorStateInfo(0).IsName("Attacking") == false)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", true);
        }

        
    }
}
