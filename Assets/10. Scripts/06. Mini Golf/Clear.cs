using UnityEngine;

namespace Study3D.MiniGolf
{
    public class Clear : MonoBehaviour
    {
        [SerializeField] private GameObject canvas;

        private void OnTriggerEnter(Collider other)
        {
            GolfBall golfBall = other.GetComponent<GolfBall>();

            if (golfBall == null)
                return;

            canvas.SetActive(true);
        }
    }
}