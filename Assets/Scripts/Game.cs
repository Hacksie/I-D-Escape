using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameSettings settings;
        [SerializeField] private PlayerController player = null;
        [SerializeField] private Pool pool = null;
        [SerializeField] private List<ScrollingBackground> backgrounds;
        [Header("Data")]
        [SerializeField] private GameData data;
        [Header("UI")]
        [SerializeField] private UI.HudPresenter hudCanvas = null;
        [SerializeField] private UI.GameOverPresenter gameOverCanvas = null;

        public static Game Instance { get; private set; }
        public PlayerController Player { get => player; set => player = value; }
        public GameData Data { get => data; set => data = value; }
        public GameSettings Settings { get => settings; set => settings = value; }

        private IState state = new EmptyState();

        public IState State
        {
            get
            {
                return state;
            }
            private set
            {
                state.End();
                state = value;
                state.Begin();
            }
        }

        Game() => Instance = this;

        void Start()
        {
            Reset();
            HideAllUI();
            SetPlaying();
        }

        void Update() => state.Update();
        void FixedUpdate() => state.FixedUpdate();

        public void SetPlaying() => State = new PlayingState(Player, pool, backgrounds, hudCanvas);
        public void SetGameOver() => State = new GameOverState(Player, pool, gameOverCanvas);

        public void IncreaseScore(float amount)
        {
            Data.score += amount;
            if(Data.score > Data.hiscore)
            {
                Data.hiscore = Data.score;
            }
        }

        public void Reset()
        {
            Data.Reset(settings);
            Player.Reset();
            pool.Reset();
        }

        private void HideAllUI()
        {
            hudCanvas.Hide();
            gameOverCanvas.Hide();
        }
    }
}