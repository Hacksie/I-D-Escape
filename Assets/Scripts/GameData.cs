using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HackedDesign
{
    [System.Serializable]
    public class GameData 
    {
        public float score = 0;
        public float hiscore = 0;
        public bool[] letterScores = new bool[12];
        

        public void Reset(GameSettings settings)
        {
            score = 0;
            for(int i = 0; i < 12; i++)
            {
                letterScores[i] = false;
            }
        }
    }
}