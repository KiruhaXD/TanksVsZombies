using UnityEngine;

public class BarrelRecoil : MonoBehaviour
{
    //[SerializeField] private Transform weapon;
    [SerializeField] private Animator animator;
    [SerializeField] private TowerBehaviour towerBehaviour;

    private void Update()
    {
        if (towerBehaviour.isReloading == false)
            StartPositionBarrelRecoil();

        else if (towerBehaviour.isReloading == true)
            FinalPositionBarrelRecoil();
    }

    public void StartPositionBarrelRecoil()
    {
        animator.SetBool("isBarrelRecoil", false);
    }

    public void FinalPositionBarrelRecoil()
    {
        animator.SetBool("isBarrelRecoil", true);
    }
}
