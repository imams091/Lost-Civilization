using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    public Animator anim;
    public bool isAttacking = false;
    public static PlayerCombatController instance;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public Transform attackPoint;
    [SerializeField] public int attackDamage = 20;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Attack();
        }
    }

    public void Attack()
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {

            enemy.GetComponent<EnemyDamage>().TakeDamage(attackDamage);
        }

        if (!isAttacking)
            {
                isAttacking = true;
               
            }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
