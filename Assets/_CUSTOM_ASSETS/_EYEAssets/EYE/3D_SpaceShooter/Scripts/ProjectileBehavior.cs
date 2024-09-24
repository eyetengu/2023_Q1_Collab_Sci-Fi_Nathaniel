using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    float _step;
    [SerializeField] float _speed = 5;
    float _speedMultiplier = 1;

    private void Start()
    {
        StartCoroutine(ProjectileTimer());
    }

    void Update()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;
        transform.Translate(new Vector3(0, 0, _step));
    }

    IEnumerator ProjectileTimer()
    {
        yield return new WaitForSeconds(4.0f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable _enemyDamage = other.GetComponent<IDamageable>();

        if(other.tag == "Enemy")
        {
            if (_enemyDamage != null)
                _enemyDamage.Damage(10);
            gameObject.SetActive(false);
        }
    }
}
