using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CatGame
{
    public class UIManager : MonoBehaviour
    {
        public GameController game_controller;

        public GameObject play_object;
        public GameObject play_screen;

        public GameObject intro_screen;
        public GameObject video_panel;

        public Button start_button;
        public Button restart_button;

        public TMP_InputField input_field;
        public TextMeshProUGUI cat_nametag;

        public SoundManager sound_manager;

        void Awake()
        {
            intro_screen.SetActive(true);
            play_object.SetActive(false);
            play_screen.SetActive(false);
        }

        void Start()
        {
            start_button.onClick.AddListener(OnStartButton);
            restart_button.onClick.AddListener(OnRestartButton);
        }

        public void OnStartButton()
        {
            bool input_empty = input_field.text == "";

            if (input_empty)
                Debug.Log("No text entered.");
            else
            {
                cat_nametag.text = input_field.text;
                sound_manager.SetBGMSound("Play");

                GameController.is_playing = true;

                play_object.SetActive(true);
                play_screen.SetActive(true);
                intro_screen.SetActive(false);
            }
        }

        public void OnRestartButton()
        {
            game_controller.ResetPlayUI();
            GameController.is_playing = true;

            play_object.SetActive(true);
            play_screen.SetActive(true);
            video_panel.SetActive(false);

            sound_manager.SetBGMSound("Play");
        }
    }
}