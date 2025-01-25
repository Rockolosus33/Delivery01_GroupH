using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, 0, playerTransform.position.z - 10f);
    }
}
