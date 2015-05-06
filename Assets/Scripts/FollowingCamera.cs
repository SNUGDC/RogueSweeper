using UnityEngine;
using System.Collections;

namespace RogueSweeper
{
    public class FollowingCamera : MonoBehaviour
    {

        public Transform Target = null;

        public float Coefficient = 0.5f;

        private Transform Mine;

        void Awake()
        {
            Mine = GetComponent<Transform>();
        }

        void Update()
        {
            if (Target == null)
            {
                return;
            }

            Vector2 mine = Mine.position;
            Vector2 target = Target.position;
            Vector2 newpos = target * Coefficient + mine * (1 - Coefficient);

            Target.position = new Vector3(newpos.x, newpos.y, Target.position.z);
        }
    }
}