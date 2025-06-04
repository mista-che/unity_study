using UnityEngine;

namespace Cat // using namespaces here good because SoundManager tends to be a common class name in various games
{
    public class SoundManager : MonoBehaviour
    {
        AudioSource audio_source;
        public AudioClip jump_clip;
        public AudioClip bgm_clip;

        private void Start()
        {
            audio_source = GetComponent<AudioSource>();
            SetBGMSound();
        }

        public void SetBGMSound()
        {
            audio_source.clip = bgm_clip;

            // settings
            audio_source.playOnAwake = true;
            audio_source.loop = true;
            audio_source.volume = 0.3f;
            audio_source.Play();

            /* AudioSource controls. Stop plays from beginning, pause plays from paused point.
             * audio_source.Play();
             * audio_source.Stop();
             * audio_source.Pause();
             */
        }      

        public void OnJumpSound()
        {
            audio_source.PlayOneShot(jump_clip); // this oneshot doesn't interfere with the continuous BGM despite using the exact same AudioSource object.
            // can't call Stop() or Pause() on PlayOneShot() sounds.
        }
    }

}
