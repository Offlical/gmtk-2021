using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioClip clip;
    public AudioSource source;
    public float volume = 0.5f;

    private static int instanceID = -1;
    private void Awake()
    {
        if (instanceID == -1)
            instanceID = gameObject.GetInstanceID();
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();

        source.loop = true;
        source.clip = clip;
        source.volume = volume;
        source.Play();
    }
}
