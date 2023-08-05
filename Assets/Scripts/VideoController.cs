using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoController : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;

    void Start()
    {
        // Lấy component VideoPlayer của GameObject VideoPlayerObject
        //videoPlayer = GetComponent<VideoPlayer>();

        // Tham chiếu đến RawImage nếu bạn sử dụng RawImage để hiển thị video (nếu không, bỏ dòng này).
        //rawImage = GetComponent<RawImage>();

        // Gắn video vào RawImage (nếu không sử dụng RawImage, bỏ dòng này).
        videoPlayer.targetTexture = new RenderTexture((int)videoPlayer.width, (int)videoPlayer.height, 16);
        rawImage.texture = videoPlayer.targetTexture;

        // Bắt đầu chơi video
        videoPlayer.Play();
    }
}