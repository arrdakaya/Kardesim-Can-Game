using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.Collections;
using System.Collections.Generic;

public class Video : MonoBehaviour
{

    VideoPlayer video;
    public Animator transitionAnim;
    public string sceneName;

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;


    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        StartCoroutine(LoadScene());    //the scene that you want to load after the video has ended.
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);

    }

}