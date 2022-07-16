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

    [SerializeField] private AudioSource attacksfx1;
    [SerializeField] private AudioSource attacksfx2;
    [SerializeField] private AudioSource attacksfx3;

    public Analog script;


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

            //script.speed = 0;
        }
      
    }

    private void atksfx1()
    {
       
            attacksfx1.Play();
        
        
    }

    private void atksfx2()
    {
       
            attacksfx2.Play();
        
    }
    private void atksfx3()
    {
        
            attacksfx3.Play();
        
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
