using UnityEngine;

namespace HackedDesign
{
    public class GameOverState : IState
    {
        private PlayerController player;
        private Pool pool;
        private UI.AbstractPresenter gameOverPresenter;

        public GameOverState(PlayerController player, Pool pool, UI.AbstractPresenter gameOverPresenter)
        {
            this.player = player;
            this.pool = pool;
            this.gameOverPresenter = gameOverPresenter;
        }

        public bool Playing => false;

        public void Begin()
        {
            this.pool.Reset();
            this.player.Dead();
            this.gameOverPresenter.Show();
            this.gameOverPresenter.Repaint();
        }

        public void End()
        {
            Game.Instance.Reset();
            this.gameOverPresenter.Hide();
        }

        public void FixedUpdate()
        {
            
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            
        }
    }
}