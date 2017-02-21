using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Death : MonoBehaviour {

    Health health;

    void Start()
    {
        health = GetComponent<Health>();
        health.onDeath += Health_onDeath;
        health.onDamage += Health_onDamage;
    }

    private void Health_onDamage(float amount)
    {
        Debug.Log("Health: " + health.healthPercent);
    }

    private void Health_onDeath()
    {
        //screenshake
        Debug.Log(transform.name + " has died");
        Destroy(transform.root.gameObject);
        health.onDeath -= Health_onDeath;
    }
}
