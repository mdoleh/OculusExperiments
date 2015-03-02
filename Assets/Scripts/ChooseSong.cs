using UnityEngine;
using System.Collections;

public class ChooseSong : MonoBehaviour {

    private void Awake()
    {
        var audioList = GameObject.Find("Music").GetComponentsInChildren<AudioSource>();
        ChooseRandomSong(audioList);
    }

    private void ChooseRandomSong(AudioSource[] audioList)
    {
        int index = UnityEngine.Random.Range(0, audioList.Length);
        Analyzer.audioSource = audioList[index];
    }
}
