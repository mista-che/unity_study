using TMPro;
using UnityEngine;

namespace CatGame
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] SoundManager sound_manager;
        [SerializeField] TextMeshProUGUI playtime_tmpro;
        [SerializeField] TextMeshProUGUI score_tmpro;


        [SerializeField] private int fruit_score_value = 1;
        [SerializeField] private int win_condition_score = 10;

        [SerializeField] private float timer = 0f;
        private static int score = 0;
        public static bool is_playing;

        private void Start()
        {
            sound_manager.SetBGMSound("Intro");
        }

        private void Update()
        {
            if (is_playing)
            {
                timer += Time.deltaTime;
                playtime_tmpro.text = string.Format("Time: {0:F0}", timer);
            }
            if (score <= win_condition_score)
                score_tmpro.text = $"{score}";
        }

        public void ResetPlayUI()
        {
            timer = 0f;
            score = 0;
        }

        public void AddScore()
        {
            score += fruit_score_value;
        }

        public int GetScore()
        {
            return score;
        }

        public int GetWinConditionScore()
        {
            return win_condition_score;
        }
    }
}
