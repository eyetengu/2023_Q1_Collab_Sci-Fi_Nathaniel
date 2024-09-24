using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRIGGER_Explosion : MonoBehaviour
{
    [Header("CONDITIONS")]
    [SerializeField] bool _explosion;
    [SerializeField] bool _proximity;
    [SerializeField] bool _remoteDetonate;
    [SerializeField] bool _timed;

    [Header("FLOAT VALUES")]
    [SerializeField] float _damage;
    [SerializeField] float _hideDelay;

    [Header("AUDIO CLIPS")]
    [SerializeField] AudioClip _explosionAudio;
    [SerializeField] AudioClip _tickingAudio;
    AudioSource _audioSource;

    [Header("EXPLOSION VFX")]
    [SerializeField] GameObject _explosionPrefab;

    [SerializeField] float _explosionSize = 5.0f;


//BUILT-IN FUNCTIONS
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        EstablishExplosiveParameters();
    }

    void Update()
    {
        if (_timed)
        {
            _audioSource.loop = true;
            _audioSource.PlayOneShot(_tickingAudio);
        }
         else if(_timed == false)
        {
            _audioSource.loop = false;
        }   
            
    }

//EXPLOSION FUNCTIONS
    void EstablishExplosiveParameters()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {        
        if(other.tag == "Player")
        {
            var damageable = other.GetComponent<IDamageable>();

            if (_proximity)
            {
                if (damageable != null)
                    damageable.Damage(10);
                EnableExplosion(); 
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            EnableExplosion();
        }
    }

    void EnableExplosion()
    {
        //vfx
        var explosionVFX = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        explosionVFX.transform.localScale = Vector3.one * _explosionSize;

        //audio
        _audioSource.PlayOneShot(_explosionAudio);
    }

    IEnumerator HideGameObject()
    {
        yield return new WaitForSeconds(_hideDelay);
        this.gameObject.SetActive(false);
    }
}
