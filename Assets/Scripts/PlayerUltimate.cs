using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayerUltimate : MonoBehaviour {

    [SerializeField] GameObject canvas;
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] VideoClip clip;

    private void OnCollisionEnter(Collision collision) {
        GameObject obj = collision.gameObject;
        if(obj.name == "Phylosophy_Ball") {
            Time.timeScale = 0;
            videoPlayer.clip = clip;
            canvas.SetActive(true);
            videoPlayer.Play();
            videoPlayer.loopPointReached += OnVideoFinished;
        }
    }

    private void OnVideoFinished(UnityEngine.Video.VideoPlayer vp) {
        canvas.SetActive(false);
        Time.timeScale = 1;

        Player[] players = FindObjectsOfType<Player>();
        foreach(Player player in players) {
            if(player != this.gameObject.GetComponent<Player>()) {
                player.score = -1;
            }
        }
    }
}
