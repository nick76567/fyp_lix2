using UnityEngine;
using System.Collections;

public class player_attack : MonoBehaviour
{
    bool attack1State;
    bool defenseState;
    bool attack2State;
    private Animator anim; 

    // Use this for initialization
    void Awake()
    {
        // Set up references.
        anim = GetComponent<Animator>();
        attack1State = false;
        defenseState = false;
       
    }

    public void attack1() {

        if (attack1State == false)
        {
            attack1State = true;
        }
        else {
            attack1State = false;
        }
       
    }
    public void attack2()
    {

        if (attack2State == false)
        {
            attack2State = true;
        }
        else
        {
            attack2State = false;
        }

    }

    public void defense() {
        if (defenseState == false)
        {
            defenseState = true;
        }
        else
        {
            defenseState = false;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        // defense
        if (!anim.IsInTransition(0) && defenseState == true)
        {
            anim.SetTrigger("Burst");
            defenseState = false;
            return;
        }
        // Attack_1
        if (!anim.IsInTransition(0) && attack1State == true)
        {
            anim.SetTrigger("Attack_1");
            attack1State = false;
            return;
        }
        //attack_2
        if (!anim.IsInTransition(0) && attack2State == true)
        {
            anim.SetTrigger("Dead");
            attack2State = false;
            return;
        }

        /*
        // dead
        if (Input.GetButtonDown("Dead"))
        {
            anim.SetTrigger("Dead");
            return;
        }

        // damage
        if (Input.GetButtonDown("Damage"))
        {
            anim.SetTrigger("Damage");
            return;
        }

        // burst
        if (Input.GetButtonDown("Burst"))
        {
            anim.SetTrigger("Burst");
            return;
        }
        */


    }
}
