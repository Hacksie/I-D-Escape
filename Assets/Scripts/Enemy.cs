using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private Animator animator;

        bool isRunning = false;

        void Awake()
        {
            if (animator == null)
            {
                animator = GetComponent<Animator>();
            }

        }

        // Update is called once per frame
        public void UpdateBehaviour()
        {
            isRunning = true;

            transform.position = new Vector3(transform.position.x - (((gameSettings.baseSpeed + Game.Instance.Data.score / gameSettings.speedFactor) + 1.0f) * Time.deltaTime), transform.position.y, transform.position.z);
            Animate();
        }

        public void Reset()
        {
            isRunning = false;
        }

        private void Animate()
        {
            if (animator)
            {
                animator.SetBool("isRunning", isRunning);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.collider.CompareTag("Player"))
            {
                AudioManager.Instance.PlayDead();
                Game.Instance.SetGameOver();
            }
        }
    }
}