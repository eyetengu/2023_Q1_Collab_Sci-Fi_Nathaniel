using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget_Ship : MonoBehaviour
{
    [Header("VFX")]
    [SerializeField] private GameObject[] _ricochets;
    [SerializeField] private GameObject[] _fires;

    [Header("HEALTH")]
    [SerializeField] private int health = 10;
    private GameObject _currentRicochet;

    public bool ConvoyTargetExhausted { get; set; }


    void Start()
    {
        ConvoyTargetExhausted = false;
        ExtinguishAllFires();
    }

    public void EnemyTargetStatus()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Projectile_Enemy")
        {
            ShowRandomRicochet();

            health--;
            
            if(health <= 0)
            {
                ConvoyTargetExhausted = true;
                
                foreach(var fire in _fires)                
                    fire.SetActive(true);                
            }
            
            else if(health < 3)
            {
                for(int i = 0; i < 2; i++)
                    _fires[i].SetActive(true);
            }

            else if(health <= 6)            
                _fires[0].SetActive(true);            
        }
    }

    void ShowRandomRicochet()
    {
        _currentRicochet = _ricochets[Random.Range(0, _ricochets.Length - 1)];
        _currentRicochet.SetActive(true);

        StartCoroutine(ResetRicochetTimer());
    }

    IEnumerator ResetRicochetTimer()
    {
        yield return new WaitForSeconds(0.1f);
        _currentRicochet.SetActive(false);
    }

    void ExtinguishAllFires()
    {
        foreach(var fire in _fires)        
            fire.SetActive(false);        
    }
}
