using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AimTracker : MonoBehaviour
{
    //[SerializeField] private TowerBehaviour towerBehaviour;
    [SerializeField] private List<LineRenderer> lineRenderers;

    //[SerializeField] private Image aimImage;

    [SerializeField] private List<Outline> outlines;

    private int currentIndex;

    // доделать элемент наведения на врагов
    private void Start()
    {
        foreach(Outline outline in outlines)
            outline.OutlineWidth = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        LineRenderer lineRenderer = lineRenderers[currentIndex];
        Outline outline = other.GetComponent<Outline>();

        if (lineRenderer == other.CompareTag("Enemy"))
        {
            if (outline != null)
                outline.OutlineWidth = 5;
        }

        if (lineRenderer == other.CompareTag("Wall"))
        {
            if (outline != null) 
                outline.OutlineWidth = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        LineRenderer lineRenderer = lineRenderers[currentIndex];
        Outline outline = other.GetComponent<Outline>();

        if (lineRenderer == other.CompareTag("Enemy"))
        {
            if (outline != null)
                outline.OutlineWidth = 0;
        }
    }
}
 