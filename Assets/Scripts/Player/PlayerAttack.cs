using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;

    private bool isArmed;
    private float attackRate = 2f;
    private float nextAttack = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeWeaponVisibility();
        }

        if (Time.time > nextAttack)
        {
            if (isArmed && Input.GetKeyDown(KeyCode.X))
            {
                Attack();
            }
        }
    }

    private void ChangeWeaponVisibility()
    {
        isArmed = !isArmed;
        animator.SetBool(Consts.IsArmed, isArmed);
    }

    private void Attack()
    {
        animator.SetTrigger(Consts.Attack);
        nextAttack = Time.time + 1f / attackRate;
    }
}
