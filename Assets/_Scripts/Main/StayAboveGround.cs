using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace _Scripts.Main
{
    public class StayAboveGround : MonoBehaviour
    {
        [SerializeField] private ARPlaneManager planeManager;
        [SerializeField] private float heightOffset = 0.1f; // Height above the plane.

        private void OnEnable()
        {
            if (planeManager != null) planeManager.planesChanged += OnPlanesChanged;
        }

        private void OnDisable()
        {
            if (planeManager != null) planeManager.planesChanged -= OnPlanesChanged;
        }

        private void OnPlanesChanged(ARPlanesChangedEventArgs args)
        {
            if (planeManager.trackables.count > 0)
            {
                foreach (var plane in planeManager.trackables)
                {
                    if (plane == null || !plane.gameObject.activeSelf) continue;

                    float planeHeight = plane.center.y;

                    Vector3 objectPosition = transform.position;
                    if (objectPosition.y < planeHeight + heightOffset)
                    {
                        objectPosition.y = planeHeight + heightOffset;
                        transform.position = objectPosition;
                    }
                }
            }
        }
    }
}