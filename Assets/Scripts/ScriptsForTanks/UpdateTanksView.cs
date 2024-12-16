using System.Collections.Generic;
using UnityEngine;

public class UpdateTanksView : MonoBehaviour
{
    [Header("Armor Track")]
    public GameObject armorViewForTrackFromTree;
    public GameObject armorViewForTrackFromScrapMetal;

    [Header("Armor Tower")]
    public GameObject armorViewForTowerFromTree;
    public GameObject armorViewForTowerFromScrapMetal;

    [Header("Armor Body")]
    public GameObject armorViewForBodyFromTree;
    public GameObject armorViewForBodyFromScrapMetal;

    private void Start()
    {
        armorViewForTrackFromTree.SetActive(false);
        armorViewForTrackFromScrapMetal.SetActive(false);

        armorViewForTowerFromTree.SetActive(false);
        armorViewForTowerFromScrapMetal.SetActive(false);

        armorViewForBodyFromTree.SetActive(false);
        armorViewForBodyFromScrapMetal.SetActive(false);

    }


}
