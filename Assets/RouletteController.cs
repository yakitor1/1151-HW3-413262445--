using UnityEngine;
using UnityEngine.Audio;

using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float rotSpeed = 0;

    // 存放你的音訊來源與 4 秒的音樂檔
    public AudioSource audioSource;
    public AudioClip spinMusic;

    void Start()
    {
        Application.targetFrameRate = 60;

        // 遊戲一開始時，預先將音樂檔放入 AudioSource 中
        if (audioSource != null && spinMusic != null)
        {
            audioSource.clip = spinMusic;
        }
    }

    void Update()
    {
        // 偵測按下滑鼠，給予初始速度並開始播音樂
        if (Input.GetMouseButtonDown(0))
        {
            this.rotSpeed = 500;

            // 如果音樂還沒在播放，就開始播放
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        // 處理旋轉與速度衰減
        transform.Rotate(0, 0, this.rotSpeed);
        this.rotSpeed *= 0.975f;

        if(rotSpeed == 0.0f)
        {
            audioSource.Stop();
        }
    }
}
