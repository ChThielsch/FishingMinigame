using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    /// <summary>
    /// The main audio source
    /// </summary>
    private AudioSource m_audioSource;

    /// <summary>
    /// The list of audio clips to be played next
    /// </summary>
    private List<AudioClip> m_audioQueue;

    /// <summary>
    /// The current index of the audio source
    /// </summary>
    private int index = 0;

    [Tooltip("Fades the previous song to the next one")]
    public bool m_crossFade;

    //Show only if m_crossFade = true
    [Tooltip("The amount of time (in seconds) songs will take to fade")]
    [Range(1,12)]
    public int m_corssFadeTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_audioSource.isPlaying)
        {
            m_audioSource.clip = m_audioQueue[index];
            index += 1;
        }
    }

    /// <summary>
    /// Plays an audio clip from the main Source
    /// </summary>
    /// <param name="_audioClip"></param>
    public void Play(AudioClip _audioClip)
    {
        m_audioSource.PlayOneShot(_audioClip);
    }

    /// <summary>
    /// Adds a secondary source which plays the audio clip
    /// </summary>
    /// <param name="_audioClip"></param>
    public void playOneShot(AudioClip _audioClip)
    {
        AudioSource tmpAudioSource = gameObject.AddComponent<AudioSource>();
        tmpAudioSource.PlayOneShot(_audioClip);
        Destroy(tmpAudioSource,_audioClip.length);
    }

    /// <summary>
    /// Adds a secondary source which plays the audio clip with given volume
    /// </summary>
    /// <param name="_audioClip"></param>
    /// <param name="_volumeScale"></param>
    public void playOneShot(AudioClip _audioClip, float _volumeScale)
    {
        AudioSource tmpAudioSource = gameObject.AddComponent<AudioSource>();
        tmpAudioSource.PlayOneShot(_audioClip, _volumeScale);
        Destroy(tmpAudioSource, _audioClip.length);
    }

    /// <summary>
    /// Adds the audio Clip the the current queue of the main source
    /// </summary>
    /// <param name="_audioClip"></param>
    public void addQueue(AudioClip _audioClip)
    {
        m_audioQueue.Add(_audioClip);
    }

    /// <summary>
    /// Adds the audio Clip to the next index of the main source
    /// </summary>
    /// <param name="_audioClip"></param>
    public void playNext(AudioClip _audioClip)
    {
        m_audioQueue.Insert(index+1,_audioClip);
    }

    /// <summary>
    /// Adds the audio Clip the the given index of the main source
    /// </summary>
    /// <param name="_audioClip"></param>
    /// <param name="_index"></param>
    public void addAtIndex(AudioClip _audioClip,int _index)
    {
        m_audioQueue.Insert(_index,_audioClip);
    }

    /// <summary>
    /// Clears the queue of the main source
    /// </summary>
    public void ClearQueue()
    {
        m_audioQueue.Clear();
    }

    /// <summary>
    /// Removes the last audio clip from the queue of the main source
    /// </summary>
    public void removeLast()
    {
        m_audioQueue.RemoveAt(m_audioQueue.Count);
    }

    /// <summary>
    /// Removes the next audio clip from the queue of the main source
    /// </summary>
    public void removeNext()
    {
        m_audioQueue.RemoveAt(index+1);
    }

    /// <summary>
    /// Removes the audio source at the given index of the main source
    /// </summary>
    /// <param name="_index"></param>
    public void removeAtIndex(int _index)
    {
        m_audioQueue.RemoveAt(_index);
    }

    /// <summary>
    /// Finds the index of the audio source in the queue of the main source. Returns 0 if not given
    /// </summary>
    /// <param name="_audioClip"></param>
    /// <returns></returns>
    public int findIndex(AudioClip _audioClip)
    {
        return m_audioQueue.IndexOf(_audioClip);
    }
}
