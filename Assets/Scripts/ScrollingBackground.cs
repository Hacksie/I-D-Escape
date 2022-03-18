using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HackedDesign
{
    public class ScrollingBackground : MonoBehaviour
    {
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private float resetX = -17.0f;
        [SerializeField] private List<Sprite> backgroundSprites;
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void UpdateBehaviour()
        {
            transform.position = new Vector3(transform.position.x - ((gameSettings.baseSpeed + Game.Instance.Data.score / gameSettings.speedFactor) * Time.deltaTime), transform.position.y, transform.position.z);
            if(transform.position.x <= resetX)
            {
                transform.position = new Vector3(transform.position.x + (-3 * resetX), transform.position.y, transform.position.z);
                spriteRenderer.sprite = backgroundSprites[Random.Range(0, backgroundSprites.Count)];
            }
        }
    }
}