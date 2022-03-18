using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign.UI
{
    public class GameOverPresenter : AbstractPresenter
    {
        [SerializeField] UnityEngine.UI.Text score;
        [SerializeField] UnityEngine.UI.Text hiscore;
        [SerializeField] List<Transform> letters;

        public override void Repaint()
        {
            score.text = "Score: " + Game.Instance.Data.score.ToString("N0");
            hiscore.text = "Top:   "+ Game.Instance.Data.hiscore.ToString("N0");
            for(int i = 0;i < 12; i++)
            {
                letters[i].gameObject.SetActive(Game.Instance.Data.letterScores[i]);
            }
        }

        public void Retry()
        {
            Game.Instance.SetPlaying();
        }
    }
}