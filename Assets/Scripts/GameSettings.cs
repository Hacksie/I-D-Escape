using UnityEngine;


namespace HackedDesign
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Escape/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        public float baseSpeed = 2.0f;
        public float jumpForce = 6.5f;
        public float baseScoreMultiple = 1.0f;
        public float minSpawnTime = 3.0f;
        public float maxSpawnTime = 8.0f;
        public float minLetterTime = 2.0f;
        public float maxLetterTime = 10.0f;
        public Vector2 spawnPosition = new Vector2(12.0f,0.75f);
        public float minLetterHeight = 0.75f;
        public float maxLetterHeight = 2.0f;
        public float speedFactor = 100.0f;
        public float letterScore = 25.0f;
        public float allLettersScore = 1000.0f;

    }
}