using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public GameObject prefHpBar;
    public GameObject canvas;

    public string enemyName;
    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public int atkSpeed;

    RectTransform hpBar;
    Image nowHpBar;

    public float height = 1.7f;

    // Start is called before the first frame update
    void Start()
    {
        hpBar = Instantiate(prefHpBar, canvas.transform).GetComponent<RectTransform>();
        if(name.Equals("Enemy")) {
            SetEnemyStatus("Enemy", 100, 10, 1);
        }
        nowHpBar = hpBar.transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // canvas의 render mode가 overlay여야 정상작동!
        Vector3 _hpBarPos = Camera.main.WorldToScreenPoint(
                new Vector3(transform.position.x, transform.position.y + height, 0)
            );
        hpBar.position = _hpBarPos;
        nowHpBar.fillAmount = (float)nowHp / (float)maxHp;
    }

    private void SetEnemyStatus(string _enemyName, int _maxHp, int _atkDmg, int _atkSpeed) {
        enemyName = _enemyName;
        maxHp = _maxHp;
        nowHp = _maxHp;
        atkDmg = _atkDmg;
        atkSpeed = _atkSpeed;
    }

    public Sword_Man sword_man;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            if(sword_man.attacked) {
                nowHp -= sword_man.atkDmg;
                Debug.Log(nowHp);
                sword_man.attacked = false;
                if(nowHp <= 0) {
                    Destroy(gameObject);
                    Destroy(hpBar.gameObject);
                }
            }
        }
    }
}
