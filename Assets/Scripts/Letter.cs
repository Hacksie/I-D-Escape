using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Letter : MonoBehaviour
    {
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private char letter;
        [SerializeField] private List<int> position;

        // Update is called once per frame
        public void UpdateBehaviour()
        {
            transform.position = new Vector3(transform.position.x - ((gameSettings.baseSpeed + Game.Instance.Data.score / gameSettings.speedFactor) * Time.deltaTime), transform.position.y, transform.position.z);
        }

        public void Reset()
        {

        }

        private void Animate()
        {

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                UpdateLetterScore();
                UpdateFullLetterScore();
                gameObject.SetActive(false);
            }
        }

        private void UpdateLetterScore()
        {
            AudioManager.Instance.PlayLetterCollect();
            Game.Instance.IncreaseScore(gameSettings.letterScore);
            foreach (int v in position)
            {
                if (!Game.Instance.Data.letterScores[v])
                {
                    Game.Instance.Data.letterScores[v] = true;
                    
                    break;
                }
            }
        }

        private void UpdateFullLetterScore()
        {
            bool flag = true;
            for(int i = 0;i < 12; i++)
            {
                if(!Game.Instance.Data.letterScores[i])
                {
                    flag = false;
                    break;
                }
            }

            if(flag)
            {
                Game.Instance.IncreaseScore(gameSettings.allLettersScore);
                AudioManager.Instance.PlayPhraseCollect();
                ResetLetterScores();
            }
        }

        private void ResetLetterScores()
        {
            for(int i = 0;i < 12; i++)
            {
                Game.Instance.Data.letterScores[i] = false;
            }
        }
    }
}