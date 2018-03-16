using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    //Sound
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioSource bulletSource;

    [SerializeField]
    private AudioClip ballGoalSound;
    [SerializeField]
    private AudioClip ballKilledSound;
    [SerializeField]
    private AudioClip placePinSound;
    [SerializeField]
    private AudioClip bulletSound;


    #region Singleton
    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion  

    //Plays a sound when the ball reaches the end
    public void PlayBallGoalSound(){
        this.audioSource.clip = ballGoalSound;
        audioSource.Play();
    }

    //Plays a sound when the ball destroyed by pins
    public void PlayBallKilledSound() {
        this.audioSource.clip = ballKilledSound;
        audioSource.Play();
    }

    //Plays a sound when a pin is placed
    public void PlayPlacePinSound() {
        this.audioSource.clip = placePinSound;
        audioSource.Play();
    }

    //Plays a sound when a bullet is fired
    public void PlayBulletSound() {
        this.bulletSource.clip = bulletSound;
        bulletSource.Play();
    }
}
