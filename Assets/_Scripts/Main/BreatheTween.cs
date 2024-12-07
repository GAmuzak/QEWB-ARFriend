using DG.Tweening;
using UnityEngine;

namespace _Scripts.Main
{
    public class BreatheTween : MonoBehaviour
    {
        [SerializeField] private float minScale = 0.9f;
        [SerializeField] private float maxScale = 1.1f;
        [SerializeField] private float timeForOneLoop = 2f;
        [SerializeField] private Ease animType;

        private Vector3 originalScale;

        private void Start()
        {
            originalScale = transform.localScale; // Store the original scale of the object
            StartBreathing();
        }

        private void StartBreathing()
        {
            Vector3 targetMaxScale = originalScale * maxScale;
            Vector3 targetMinScale = originalScale * minScale;

            transform.DOScale(targetMaxScale, timeForOneLoop / 2)
                .SetEase(animType)
                .OnComplete(() =>
                {
                    transform.DOScale(targetMinScale, timeForOneLoop / 2)
                        .SetEase(animType)
                        .SetLoops(-1, LoopType.Yoyo);
                });
        }
    }
}