using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform player;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;
    }

}
