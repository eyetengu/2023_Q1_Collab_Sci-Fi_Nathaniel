using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Payload_Behavior : MonoBehaviour
{
    [Header("DAMAGE")]
    [SerializeField] int _damageStrength;

    [Header("TIMER")]
    [SerializeField] bool _timed;
    [SerializeField] float _timerDelay;
    SphereCollider _collider;
    [Header("VFX")]
    [SerializeField] GameObject _vfxExplosion;
    [Header("AUDIO")]
    AudioSource _audioSource;
    [SerializeField] AudioClip _explosionAudio;


    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _collider = GetComponent<SphereCollider>();
        _vfxExplosion.SetActive(false);

        if (_timed)
            StartCoroutine(ExplosiveTimer());
        //else
            //StartCoroutine(GrowthRingTimer());
    }

    void Detonate()
    {
        //audio explosion
        //vfx explosion
        //radius damage to surrounding area(spherecast?)
        _audioSource.PlayOneShot(_explosionAudio);        
        _vfxExplosion.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
            damageable.Damage(_damageStrength);
    }

    IEnumerator ExplosiveTimer()
    {
        yield return new WaitForSeconds(_timerDelay);
        Detonate();
    }

    IEnumerator GrowthRingTimer()
    {
        for (int i = 0; i < 10; i++)
        {
            _collider.radius+= 0.2f;
            yield return new WaitForSeconds(0.2f);                    
        }

        Detonate();
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
        //Destroy(gameObject, 1.0f);
    }
}
