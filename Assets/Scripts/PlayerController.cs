using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HackedDesign
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody2D rigidbody;
        [SerializeField] private LayerMask jumpMask;

        private bool isRunning = false;
        private bool isJumping = false;
        private bool isDead = false;

        void Awake()
        {
            if (animator == null)
            {
                animator = GetComponent<Animator>();
            }

            if (rigidbody == null)
            {
                rigidbody = GetComponent<Rigidbody2D>();
            }
        }

        public void OnJump(InputValue value)
        {
            if (Game.Instance.State.Playing && value.isPressed && !isJumping)
            {
                isJumping = true;
                rigidbody.AddForce(Vector2.up * gameSettings.jumpForce, ForceMode2D.Impulse);
                AudioManager.Instance.PlayJump();
            }
        }

        public void UpdateBehaviour()
        {
            isRunning = true;

            Animate();
        }

        public void Dead()
        {
            isDead = true;
            isRunning = false;
            isJumping = false;
            Animate();
        }

        public void Reset()
        {
            animator.Play("idle");
            isDead = false;
            isRunning = false;
            isJumping = false;

            Animate();
        }

        private void Animate()
        {
            animator.SetBool("isRunning", isRunning);
            animator.SetBool("isJumping", isJumping);
            animator.SetBool("isDead", isDead);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Level"))
            {
                isJumping = false;
            }
        }
    }
}