using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : GenericSingleton<AudioController>
{
    #region Private variable
    private AudioSource _source;
    [SerializeField] private List<AudioClip> _audios;
    #endregion

    #region Public variable

    #endregion

    #region Unity Methods
    private void Awake()
    {
        if(Instance == this)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _source = GetComponent<AudioSource>();
    }
    #endregion

    #region Own Methods
    public void PlayAudio(int number)
    {
        _source.clip = _audios[number];
        _source.Play();
    }
    #endregion

}
