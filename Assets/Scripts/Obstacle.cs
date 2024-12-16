using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject effectExplosionObstacle;

    [SerializeField] private TankModifier modifier; 

    [SerializeField] private TMP_Text textDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            modifier.TakeDamage(Int32.Parse(textDamage.text));
            GameObject effect = Instantiate(effectExplosionObstacle, obstacle.transform.position, transform.rotation);
            Destroy(obstacle);
        }
    }
}
