using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public GameObject video_panel;
    public VideoClip[] video_clips;

    public VideoPlayer video_player;

    private void Start()
    {
        video_player = GetComponent<VideoPlayer>();
    }

    public void PlayVideo(bool is_happy)
    {
        video_panel.SetActive(true);

        var clip_to_play = is_happy ? video_clips[0] : video_clips[1]; // 0 = happy, 1 = angry

        video_player.clip = clip_to_play;
        video_player.Play();
    }
}
