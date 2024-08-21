using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour, IActorTemplate
{
    [SerializeField] private float _speed;
    private float _step;


    private void Start()
    {
        StartCoroutine(HideTimer());
    }


    void Update()
    {
        _step = _speed * Time.deltaTime;
        transform.Translate(new Vector3(0, 0, _step));
    }

    IEnumerator HideTimer()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }

    public int SendDamage()
    {
        return 0;
    }

    public void TakeDamage(int incomingDamage)
    {

    }

    public void Die()
    {

    }

    public void ActorStats(SOActorModel actorModel)
    {

    }
}
