using UnityEngine;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    [SerializeField] private List<AudioClip> playlist;
    [SerializeField] private AudioSource audioSource;
    private int currentTrack = 0;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            PlayTrack(currentTrack);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            NextTrack();
        }
    }

    void PlayTrack(int index)
    {
        if (playlist.Count == 0) return;

        audioSource.clip = playlist[index];
        audioSource.Play();
    }

    void NextTrack()
    {
        currentTrack++;

        if (currentTrack >= playlist.Count)
            currentTrack = 0;

        PlayTrack(currentTrack);
    }
}
