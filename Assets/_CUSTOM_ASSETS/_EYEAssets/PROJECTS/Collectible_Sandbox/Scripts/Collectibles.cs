using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    /// <summary>
    /// Collectibles ought to have the ability to be picked up, send a sound to the audio manager 
    /// additonlly they may add value to experience, gold, health or score
    /// This collectible script should have the option to choose which value type is to be added(or a combination thereof)
    /// We will use delegates/EVENTS to communicate with other scripts when values are to be adjusted.
    /// 
    /// NEGATIVE EFFECTS can be achieved by using negative values for the _valueAmount
    /// An example could be a pit trap that takes away health or a dumb book that removes experience
    /// 
    /// it may be that they may not offer any of those but instead added to inventory as an item that can be used, sold or traded
    /// or added to an inventory.
    /// </summary>


    //DELEGATES & EVENTS
    public delegate void AddExperience(float amount);
    public static event AddExperience addingExperience;

    public delegate void AddGold(float amount);
    public static event AddGold addingGold;

    public delegate void AddHealth(float amount);
    public static event AddHealth addingHealth;

    public delegate void AddScore(float amount);
    public static event AddScore addingScore;

    public delegate void PlayCollectibleAudio(AudioClip clip);
    public static event PlayCollectibleAudio playCollectibleAudio;


//FIELDS
    [Header("VALUES ADDED")]
    [SerializeField] float _valueAmount;
    [SerializeField] bool _experience;
    [SerializeField] bool _gold;
    [SerializeField] bool _health;
    [SerializeField] bool _score;

    [Header("COLLECTIBLE MOVEMENT")]
    [SerializeField] bool _isRotating;
    [SerializeField] bool _isbouncing;
    //[SerializeField] bool _isHovering;

    [Header("ROTATION VALUES")]
    [SerializeField] float yRotation = 0.2f;
    //[SerializeField] float xRotation = 0.2f;
    //[SerializeField] float zRotation = 0.2f;

    [Header("MOVEMENT VALUES")]
    [SerializeField] float _maxYSpeed;
    bool _changeDirection;
    [SerializeField] bool _isBouncing;
    [SerializeField] bool _isMovingUp;
    [SerializeField] float _moveDelay = 0.3f;
    int _moveMultiplier = 1;

    [Header("AUDIO CLIPS")]
    [SerializeField] AudioClip[] _collectibleSounds;
    [SerializeField] int _collectibleAudioID;
    [SerializeField] bool _useAudio;

    [SerializeField] bool _oneTimeUse;


    string _collectibleType;
    bool _itemAcquired;


//BUILT-IN FUNCTIONS
    void Start()
    {
        
    }

    void Update()
    {
        if (_isRotating)
            RotateCollectible();

        if (_isBouncing)
            MoveCollectible();
    }


//MOVEMENT FUNCTIONS
    void RotateCollectible()
    {
        transform.Rotate(0, yRotation, 0);
    }

    void MoveCollectible()
    {
        if (_changeDirection == false)
        {
            _changeDirection = true;
            StartCoroutine(ChangeDirectionTimer());
        }
        
        if (_isMovingUp)
            _moveMultiplier = 1;
        else
            _moveMultiplier = -1;

        transform.Translate(new Vector3(0, _maxYSpeed * _moveMultiplier * Time.deltaTime, 0));
    }

//TRIGGER FUNCTIONS
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && _itemAcquired == false)
        {
            _itemAcquired = true;

            if (_experience)
            {
                if (addingExperience != null)
                {
                    addingExperience(_valueAmount);
                    _collectibleType = "Experience";
                    _collectibleAudioID = 0;
                }
            }
            else if (_gold)
            {
                if (addingGold != null)
                {
                    addingGold(_valueAmount);
                    _collectibleType = "Gold";
                    _collectibleAudioID = 1;
                }
            }
            else if (_health)
            {
                if (addingHealth != null)
                {
                    addingHealth(_valueAmount);
                    _collectibleType = "Health";
                    _collectibleAudioID = 2;
                }
            }
            else if (_score)
            {
                if (addingScore != null)
                {
                    addingScore(_valueAmount);
                    _collectibleType = "Experience";
                    _collectibleAudioID = 3;
                }
            }

            if (playCollectibleAudio != null && _useAudio)
                playCollectibleAudio(_collectibleSounds[_collectibleAudioID]);

            //Debug.Log($"{_collectibleType} increased by {_valueAmount}");
            //Debug.Log($"Playing Audio Clip: {_collectibleSounds[_collectibleAudioID]}" );
            if(_oneTimeUse)
                Destroy(gameObject, 1.25f);                
        }
    }


//COROUTINES
    IEnumerator ChangeDirectionTimer()
    {
        yield return new WaitForSeconds(_moveDelay);
        _isMovingUp = !_isMovingUp;
        _changeDirection = false;
    }
}
