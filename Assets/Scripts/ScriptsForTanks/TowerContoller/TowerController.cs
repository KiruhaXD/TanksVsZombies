using RimuruDev;
using UnityEngine;


public class TowerController : MainTowerController
{
    private void Update()
    {
        if (detector.CurrentDeviceType == CurrentDeviceType.WebPC /*!IsMobileDevice()*/) 
        {
            float hor = Input.GetAxis("HorizontalTower");

            float rotateTower = hor * speedRotateTower * Time.deltaTime;

            // для данной модели у нас стоит направление forward,
            // т.к у нас изначально моделька стоит под углом 90 градусов и башня крутилась неверно когда я использовал направление Vector3.forward
            // ТУТ у меня соотвествует направление башни нажатию нужных клавиш влево и вправо
            tower.Rotate(-Vector3.forward, rotateTower);

            if (Input.GetKeyDown(KeyCode.Space) && !isReloading && detector.CurrentDeviceType == CurrentDeviceType.WebPC /*!IsMobileDevice()*/)
            {
                towerBehaviour.Shoot();
            }
        }

        else if (detector.CurrentDeviceType == CurrentDeviceType.WebMobile /*IsMobileDevice()*/) 
        {
            float hor = joystickTowards.Horizontal;

            float rotateTower = hor * speedRotateTower * Time.deltaTime;

            // для данной модели у нас стоит направление forward,
            // т.к у нас изначально моделька стоит под углом 90 градусов и башня крутилась неверно когда я использовал направление Vector3.forward
            // ТУТ у меня соотвествует направление башни нажатию нужных клавиш влево и вправо
            tower.Rotate(-Vector3.forward, rotateTower);

            if (joystickFire.Horizontal != 0 || joystickFire.Vertical != 0 && !isReloading && detector.CurrentDeviceType == CurrentDeviceType.WebMobile /*IsMobileDevice()*/)
            {
                towerBehaviour.Shoot();
            }
        }
    }
}
