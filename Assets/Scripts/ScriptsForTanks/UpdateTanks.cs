using TMPro;
using UnityEngine;

public class UpdateTanks : MonoBehaviour
{
    [SerializeField] private TankModifier tankModifier;

    [SerializeField] private Shop shop;

    public void UpdateCharacteristicsTanksHealth() 
    {
        tankModifier.health += shop.tanks[shop.index].health;
        tankModifier.UpdateUIHealth();
    }

    public void UpdateCharacteristicsTanksArmor() 
    { 
        tankModifier.armor += shop.tanks[shop.index].armor;
        tankModifier.UpdateUIArmor();
    }

    public void UpdateCharacteristicsTanksPower()
    {  
        tankModifier.power += shop.tanks[shop.index].power;
        tankModifier.UpdateUIPower();
    }

    public void BaseCharacteristics()
    {
        tankModifier.health = 100;
        tankModifier.armor = 20;
        tankModifier.power = 20;
        UpdateBaseCharacterictics();
    }

    public void UpdateBaseCharacterictics() 
    {
        tankModifier.UpdateUIHealth();
        tankModifier.UpdateUIArmor();
        tankModifier.UpdateUIPower();
    }
}
