using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

namespace HackedDesign
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] private List<Enemy> enemyPrefabs;
        [SerializeField] private List<Letter> letterPrefabs;
        [SerializeField] private Transform parent;
        [SerializeField] private Vector2 spawnPosition;
        

        private List<Enemy> enemySpawns = new List<Enemy>();
        private List<Letter> letterSpawns = new List<Letter>();

        public void Reset()
        {
            for(int i = 0; i < parent.childCount; i++)
            {
                parent.GetChild(i).gameObject.SetActive(false);
                Destroy(parent.GetChild(i).gameObject);
            }
            enemySpawns.Clear();
            letterSpawns.Clear();
        }

        public void SpawnEnemy()
        {
            var go = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], Game.Instance.Settings.spawnPosition, Quaternion.identity, parent);
            var enemy = go.GetComponent<Enemy>();
            enemySpawns.Add(enemy);
        }

        public void SpawnLetter()
        {
            var yOffset = Random.Range(Game.Instance.Settings.minLetterHeight, Game.Instance.Settings.maxLetterHeight);
            var pos = new Vector2(Game.Instance.Settings.spawnPosition.x, Game.Instance.Settings.spawnPosition.y + yOffset);
            var go = Instantiate(letterPrefabs[Random.Range(0, letterPrefabs.Count)], pos, Quaternion.identity, parent);
            var letter = go.GetComponent<Letter>();
            letterSpawns.Add(letter);
        }        

        public void UpdateBehaviour()
        {
            foreach(var enemy in enemySpawns)
            {
                if(enemy.gameObject.activeInHierarchy)
                {
                    enemy.UpdateBehaviour();
                }
            }

            foreach(var letter in letterSpawns)
            {
                if(letter.gameObject.activeInHierarchy)
                {
                    letter.UpdateBehaviour();
                }
            }            
        }
    }
}