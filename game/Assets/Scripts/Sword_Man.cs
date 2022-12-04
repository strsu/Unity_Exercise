using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword_Man : MonoBehaviour
{
    Animator animator;

    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public float atkSpeed = 1;
    public bool attacked = false;
    public Image nowHpBar;

    // Start is called before the first frame update
    void Start()
    {

        maxHp = 100;
        nowHp = 80;
        atkDmg = 10;

        transform.position = new Vector3(0,0,0);
        animator = GetComponent<Animator>();
        SetAttackSpeed(1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        nowHpBar.fillAmount = (float)nowHp / (float)maxHp;

        if(Input.GetKey(KeyCode.RightArrow)) {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("moving", true);
            transform.Translate(Vector3.right * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.localScale = new Vector3(1,1,1);
            animator.SetBool("moving", true);
            transform.Translate(Vector3.left * Time.deltaTime);
        } else{
            animator.SetBool("moving", false);
        }

        if(Input.GetKeyDown(KeyCode.A) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
            animator.SetTrigger("attack");
        }
    }

    void AttackTrue() {
        attacked = true;
    }

    void AttackFalse() {
        attacked = false;
    }

    void SetAttackSpeed(float speed) {
        animator.SetFloat("attackSpeed", speed);
        atkSpeed = speed;
    }
}
