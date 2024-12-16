using RimuruDev;
using UnityEngine;

public class UpdateTowerController : MainTowerController
{
    private void Update()
    {
        if (detector.CurrentDeviceType == CurrentDeviceType.WebPC /*!IsMobileDevice()*/)
        {
            float hor = Input.GetAxis("HorizontalTower");

            float rotateTower = hor * speedRotateTower * Time.deltaTime;

            // ��� ������ ������ � ��� ����� ����������� forward,
            // �.� � ��� ���������� �������� ����� ��� ����� 90 �������� � ����� ��������� ������� ����� � ����������� ����������� Vector3.up
            // ��� � ���� ������������ ����������� ����� ������� ������ ������ ����� � ������(��� ������)
            tower.Rotate(Vector3.up, rotateTower);

            if (Input.GetKeyDown(KeyCode.Space) && !isReloading && detector.CurrentDeviceType == CurrentDeviceType.WebPC /*!IsMobileDevice()*/)
            {
                towerBehaviour.Shoot();
            }
        }

        else if (detector.CurrentDeviceType == CurrentDeviceType.WebMobile /*IsMobileDevice()*/)
        {
            float hor = joystickTowards.Horizontal;

            float rotateTower = hor * speedRotateTower * Time.deltaTime;

            // ��� ������ ������ � ��� ����� ����������� forward,
            // �.� � ��� ���������� �������� ����� ��� ����� 90 �������� � ����� ��������� ������� ����� � ����������� ����������� Vector3.up
            // ��� � ���� ������������ ����������� ����� ������� ������ ������ ����� � ������(��� ������)
            tower.Rotate(Vector3.up, rotateTower);

            if (joystickFire.Horizontal != 0 || joystickFire.Vertical != 0 && !isReloading && detector.CurrentDeviceType == CurrentDeviceType.WebMobile /*IsMobileDevice()*/)
            {
                towerBehaviour.Shoot();
            }
        }
    }
}
