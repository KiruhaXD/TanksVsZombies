using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GateArmor : MonoBehaviour
{
    public MoveReloading canMove;

    [SerializeField] private int armorValue;
    [SerializeField] private GateAppereance gateAppereance;
    [SerializeField] private GameObject updatingEffect;
    [SerializeField] private Transform player;
    [SerializeField] private TankModifier tankModifier;
    [SerializeField] private List<UpdateTanksView> tanksView;
    [SerializeField] private TankController controller;

    [SerializeField] private Image imageForNameArmor;

    private void OnValidate()
    {
        gateAppereance.UpdateVisual(armorValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        tankModifier = other.attachedRigidbody.GetComponent<TankModifier>();
        if (tankModifier != null)
        {
            if (gateAppereance.upgrade && armorValue > 0)
            {
                tankModifier.AddArmor(armorValue);
                AddChangeArmorView(imageForNameArmor.name);
            }

            else if (gateAppereance.downgrade && armorValue < 0)
            {
                int absoluteArmorValue = Mathf.Abs(armorValue); // Используем абсолютное значение для удаления брони, это нужно для правильной обработки отрицательного значения
                tankModifier.RemoveArmor(absoluteArmorValue);     
                RemoveChangeArmorView(imageForNameArmor.name);
            }

            if (tankModifier.armor < 0) tankModifier.armor = 0;
            tankModifier.UpdateUIArmor();
        }

        if (other.gameObject.tag == "Player") 
        {
            canMove.CantMove(controller.textForReloadMovement);

            controller.canMove = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canMove.CanMove(controller.textForReloadMovement);

            controller.canMove = true;

            Destroy(gameObject);
            GameObject effect = Instantiate(updatingEffect, player.transform.position, Quaternion.identity);
            Destroy(effect, 2.5f);
        }
    }

    public void AddChangeArmorView(string imageName) 
    {
        foreach (UpdateTanksView view in tanksView) 
        {
            switch (imageName)
            {
                case "Image (TowerTree)":
                    view.armorViewForTowerFromTree.SetActive(true);
                    break;

                case "Image (TowerScrapMetal)":
                    view.armorViewForTowerFromScrapMetal.SetActive(true);
                    break;

                case "Image (TrackTree)":
                    view.armorViewForTrackFromTree.SetActive(true);
                    break;

                case "Image (TrackScrapMetal)":
                    view.armorViewForTrackFromScrapMetal.SetActive(true);
                    break;

                case "Image (BodyTree)":
                    view.armorViewForBodyFromTree.SetActive(true);
                    break;

                case "Image (BodyScrapMetal)":
                    view.armorViewForBodyFromScrapMetal.SetActive(true);
                    break;
            }
        }
        
    }

    public void RemoveChangeArmorView(string imageName) 
    {
        foreach (UpdateTanksView view in tanksView)
        {
            switch (imageName)
            {
                case "Image (TowerTree)":
                    view.armorViewForTowerFromTree.SetActive(false);  
                    break;

                case "Image (TowerScrapMetal)":
                    view.armorViewForTowerFromScrapMetal.SetActive(false);
                    break;

                case "Image (TrackTree)":
                    view.armorViewForTrackFromTree.SetActive(false);
                    break;

                case "Image (TrackScrapMetal)":
                    view.armorViewForTrackFromScrapMetal.SetActive(false);
                    break;

                case "Image (BodyTree)":
                    view.armorViewForBodyFromTree.SetActive(false);
                    break;

                case "Image (BodyScrapMetal)":
                    view.armorViewForBodyFromScrapMetal.SetActive(false);
                    break;
            }
        }
    }
}
