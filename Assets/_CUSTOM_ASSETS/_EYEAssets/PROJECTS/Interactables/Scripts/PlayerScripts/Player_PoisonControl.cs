using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_PoisonControl : MonoBehaviour, IPoison
{
    AudioPlayer _audioPlayer;
    Player_Health _playerHealth;

//POISON
    public bool poisoned;
    public bool _poisoning;
    public float _poisonSpeed = 0.5f;
    public int _poisonPower = 1;


//PROPERTIES
    public bool Poisoned { get; set; }
    public float PoisonSpeed { get; set; }
    public int PoisonPower { get; set; }


//BUILT-IN FUNCTIONS
    void Start()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        _playerHealth = GetComponent<Player_Health>();
    }

    void Update()
    {
        if (Poisoned)
        {
            Debug.Log("Poisoned");
            if (_poisoning == false)
            {
                //repeat
                _poisoning = true;
                //reduce player health
                PlayerSuffersFromPoison();
                //wait for a couple of seconds
                StartCoroutine(PoisonTimer());
            }
        }
    }


//CORE FUNCTIONS
    public void PlayersPoisonControl(bool condition, float speed, int power)
    {
        Poisoned = condition;        
        PoisonSpeed = speed;
        PoisonPower = power;

        if (condition)
            _audioPlayer.PlayPoison();
        if (condition == false)
            _audioPlayer.PlayCure();
    }

    void PlayerSuffersFromPoison()
    {
        _playerHealth.Damage(PoisonPower);
    }


//COROUTINES
    IEnumerator PoisonTimer()
    {
        Debug.Log("Timer");
        yield return new WaitForSeconds(5);
        _poisoning = false;
    }
}
