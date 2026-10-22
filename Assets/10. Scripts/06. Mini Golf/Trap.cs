using UnityEngine;

namespace Study3D.MiniGolf
{
    public class RespawnTrigger : MonoBehaviour
    {
        [SerializeField] private float respawnDelay = 3f;

        private float contactTime;
        private bool isContacting;

        private void OnTriggerEnter(Collider other)
        {
            GolfBall golfBall = other.GetComponent<GolfBall>();

            if (golfBall == null)
                return;

            contactTime = 0f;
            isContacting = true;
        }

        private void OnTriggerStay(Collider other)
        {
            GolfBall golfBall = other.GetComponent<GolfBall>();

            if (golfBall == null || !isContacting)
                return;

            contactTime += Time.deltaTime;

            if (contactTime >= respawnDelay)
            {
                isContacting = false;
                golfBall.Respawn();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            GolfBall golfBall = other.GetComponent<GolfBall>();

            if (golfBall == null)
                return;

            isContacting = false;
            contactTime = 0f;
        }
    }
}
