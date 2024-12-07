using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private bool isEnabled = true;
    [SerializeField] private Transform cam;

    private void OnEnable()
    {
        if (cam != null) return;
        if (Camera.main == null) return;
        cam = Camera.main.transform;
    }

    private void LateUpdate()
    {
        if (!isEnabled) return;
        if(cam == null) Debug.LogWarning("Camera transform not assigned!!");
        else
        {
            Vector3 directionToCamera = cam.position - transform.position;
            directionToCamera.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
            transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y + 90, 0);
            float heightDifference = cam.position.y - transform.position.y;
            float zRotation = Mathf.Atan2(heightDifference, directionToCamera.magnitude) * Mathf.Rad2Deg;

            float clampedZRotation = Mathf.Clamp(zRotation, -20, 20);

            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, -clampedZRotation);
        }
    }
}