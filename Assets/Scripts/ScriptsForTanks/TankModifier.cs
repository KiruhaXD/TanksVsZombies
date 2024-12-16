using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankModifier : MonoBehaviour
{
    /*public delegate void OnTankDamaged(int damageAmount);
    public static event OnTankDamaged TankDamagedEvent;*/

    public TMP_Text healthText;
    public int health = 100;

    public TMP_Text armorText;
    public int armor = 20;

    public TMP_Text powerText;
    public int power = 20;

    [SerializeField] public TMP_Text textEffectForUpdate;

    [SerializeField] private GameObject damageRedOverlay;

    public void TakeDamage(int damageCount) 
    {
        if (damageCount < 0)
            throw new ArgumentOutOfRangeException();

        if (armor > 0)
        {
            if (damageCount > armor)
            {
                damageCount -= armor;
                armor = 0;
            }

            else
            {
                armor -= damageCount;
                damageRedOverlay.SetActive(true);
                damageCount = 0;
            }
            armorText.text = armor.ToString();
        }

        RemoveHealth(damageCount);
        Died();

        StartCoroutine(DisableOverlayDamage());
    }

    public void Died() 
    {
        if (health <= 0)
        {
            health = 0;
            healthText.text = health.ToString();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddHealth(int value) 
    {
        health += value;
        UpdateUIHealth();
    }

    public void MultiplicationHealth(int value) 
    {
        health *= value;
        UpdateUIHealth();
    }

    public void DivisionHealth(int value) 
    {
        health /= value;
        UpdateUIHealth();
    }

    public void RemoveHealth(int value) 
    {
        health -= value;
        damageRedOverlay.SetActive(true);
        UpdateUIHealth();
    }

    public void AddArmor(int value) 
    {
        armor += value;
        UpdateUIArmor();
    }

    public void RemoveArmor(int value)
    {
        armor -= value;
        UpdateUIArmor();
    }

    public void AddPower(int value)   
    {
        power += value;
        UpdateUIPower(); 
    } 

    public void RemovePower(int value)
    {
        power -= value;
        UpdateUIPower();
    }

    public void UpdateUIHealth() => healthText.text = health.ToString();

    public void UpdateUIArmor() => armorText.text = armor.ToString();

    public void UpdateUIPower() => powerText.text = power.ToString();

    public IEnumerator DisableOverlayDamage() 
    {
        yield return new WaitForSeconds(1.5f);
        damageRedOverlay.SetActive(false);
    }
}
