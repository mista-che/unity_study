using UnityEngine;
using UnityEngine.Audio;

namespace CatGame // using namespaces here good because SoundManager tends to be a common class name in various games
{
    public class SoundManager : MonoBehaviour
    {
        AudioSource audio_source;
        public AudioClip jump_clip;
        public AudioClip intro_clip;
        public AudioClip play_clip;
        public AudioClip collision_clip;

        private void Start()
        {
            audio_source = GetComponent<AudioSource>();
        }

        public void SetBGMSound(string clip_name)
        {
            if (clip_name == "Intro")
                audio_source.clip = intro_clip;
            else if (clip_name == "Play")
                audio_source.clip = play_clip;

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

        public void OnColliderSound()
        {
            audio_source.PlayOneShot(collision_clip);
        }
    }

}
