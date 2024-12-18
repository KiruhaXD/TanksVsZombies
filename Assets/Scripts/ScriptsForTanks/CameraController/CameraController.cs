using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    public Vector3 offset;

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
