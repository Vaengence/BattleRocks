using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

[RequireComponent(typeof(AudioSource))]

public class _MusicManager : MonoBehaviour {

    private static _MusicManager _instance;                                  // - Internal GameManager reference.
    public static _MusicManager instance                                     // - External GameManager reference for all other scenes.
    #region MusicManager instance.       
    {
        get
        {
            if (_instance != null)                                           // - If _instance not null.
            {
                return _instance;                                           // - Return current _instance.
            }
            else                                                            // - Else (if _instance not null).
            {
                GameObject musicManager = new GameObject("MusicManager");     // - Set gameMnager as a new GameObject called GameManager.
                _instance = musicManager.AddComponent<_MusicManager>();       // - Add GameManager script to that new GameObject _instance.
                return _instance;                                           // - Return that new instance of GameManager as _instance.
            }
        }
    }
    #endregion  

    public AudioClip[] MusicFiles;
    public AudioClip[] SoundFiles;
    private AudioSource MasterAudioStream;
    private bool FadeOut;
    private float MusicVolume;

    public enum TypesOfMusic
    {
        GENERAL_BACKGROUND = 0,
        BATTLE_SCENE = 1,
        CUSTOM = 2
    }

    public enum TypesOfSounds
    {
        BUTTON_CLICK = 0,
        BATTLE_WIN = 1,
        BATTLE_LOSE = 2
    }

    private TypesOfMusic AudioTransition;

    TypesOfMusic MusicMaster;
    //TypesOfSounds SoundMaster;

    Dictionary<int, AudioClip> MusicLookUp = new Dictionary<int, AudioClip>();
    Dictionary<int, AudioClip> SoundLookUp = new Dictionary<int, AudioClip>();

    void Awake()
    {
        // Set _instance as this script.
        if (_instance != this)                                   // - If _instance isnt this GameManager.
        {
            if (_instance == null)                               // - If no _instance of GameManager.
            {
                _instance = this;                               // - Set _instance to this GameManager.
            }
            else                                                // - If one already exists.
            {
                Destroy(gameObject);                            // - Destory this extra one.
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < MusicFiles.Length; i++)
        {
            MusicLookUp.Add(i, MusicFiles[i]);
        }

        for (int i = 0; i < SoundFiles.Length; i++)
        {
            SoundLookUp.Add(i, SoundFiles[i]);
        }


        MasterAudioStream = GetComponent<AudioSource>();
        MusicMaster = TypesOfMusic.GENERAL_BACKGROUND;
        MasterAudioStream.clip = MusicLookUp[(int)MusicMaster];
        MasterAudioStream.Play();
        
	}

	// Update is called once per frame
	void Update ()
    {
        if (FadeOut == true && MusicMaster != AudioTransition)
        {
            MusicFade();
        }
        else
        {
            if (FadeOut == true && MusicMaster == AudioTransition)
            {
                MusicGrow();
            }
        }
	    
	}

    public void ChangeMusic(TypesOfMusic NewMusic)
    {
        if (MusicMaster == NewMusic)
        {
            return;
        }
        else
        {
            AudioTransition = NewMusic;
            this.FadeOut = true;
        }

    }

    void MusicFade()
    {
        if (MasterAudioStream.volume >= 0.0f)
        {
            float CurrentVolume = MasterAudioStream.volume;
            CurrentVolume -= 1.0f * Time.deltaTime;

            if (CurrentVolume < 0.0f)
            {
                MusicMaster = AudioTransition;
            }
            else
            {
                MasterAudioStream.volume = CurrentVolume;
            }
        }
    }


    void MusicGrow()
    {
        if (MasterAudioStream.clip != MusicLookUp[(int)MusicMaster])
        {
            MasterAudioStream.Stop();
            MasterAudioStream.clip = MusicLookUp[(int)MusicMaster];
            MasterAudioStream.Play();
            MasterAudioStream.volume = 0.0f;
        }

        if (MasterAudioStream.volume <= 1.0f)
        {
            float CurrentVolume = MasterAudioStream.volume;
            CurrentVolume += 0.5f * Time.deltaTime;

            if (CurrentVolume > 1.0f)
            {
                FadeOut = false;
            }
            else
            {
                MasterAudioStream.volume = CurrentVolume;
            }
        }

    }
}
