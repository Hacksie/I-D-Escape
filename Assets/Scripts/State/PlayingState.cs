using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class PlayingState : IState
    {
        private PlayerController player;
        private UI.AbstractPresenter hudPresenter;
        private Pool pool;
        private List<ScrollingBackground> backgrounds;

        private float nextEnemySpawnTimer;
        private float nextLetterSpawnTimer;

        public PlayingState(PlayerController player, Pool pool, List<ScrollingBackground> backgrounds, UI.AbstractPresenter hudPresenter)
        {
            this.player = player;
            this.hudPresenter = hudPresenter;
            this.backgrounds = backgrounds;
            this.pool = pool;
        }

        public bool Playing => true;

        public void Begin()
        {
            hudPresenter.Show();
            nextEnemySpawnTimer = NextEnemySpawnTimer();
        }


        public void End()
        {

        }

        public void FixedUpdate()
        {

        }

        public void Start()
        {

        }

        public void Update()
        {
            Game.Instance.IncreaseScore(Game.Instance.Settings.baseScoreMultiple * Time.deltaTime);
            
            foreach(var background in backgrounds)
            {
                background.UpdateBehaviour();
            }
            player.UpdateBehaviour();
            pool.UpdateBehaviour();
            CheckEnemySpawn();
            CheckLetterSpawn();
            hudPresenter.Repaint();
        }

        private void CheckEnemySpawn()
        {
            if(Time.time > nextEnemySpawnTimer)
            {
                pool.SpawnEnemy();
                nextEnemySpawnTimer = NextEnemySpawnTimer();
            }
        }

        private void CheckLetterSpawn()
        {
            if(Time.time > nextLetterSpawnTimer)
            {
                pool.SpawnLetter();
                nextLetterSpawnTimer = NextLetterSpawnTimer();
            }
        }        

        private float NextEnemySpawnTimer()
        {
            return Time.time + Random.Range(Game.Instance.Settings.minSpawnTime, Game.Instance.Settings.maxSpawnTime);
        }

        private float NextLetterSpawnTimer()
        {
            return Time.time + Random.Range(Game.Instance.Settings.minLetterTime, Game.Instance.Settings.maxLetterTime);
        }        
    }
}