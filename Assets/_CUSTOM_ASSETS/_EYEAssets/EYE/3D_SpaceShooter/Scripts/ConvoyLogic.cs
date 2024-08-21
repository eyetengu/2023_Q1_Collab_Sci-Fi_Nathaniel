using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvoyLogic : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyTargets = new List<GameObject>();
    private GameManager _gameManager;
    private int demerits;
    [SerializeField] private GameObject _destructionFX;
    bool _isConvoyDestroyed;


    private void Start()
    {
        _gameManager= GameManager.Instance;
        _destructionFX.SetActive(false);
    }

    void FixedUpdate()
    {
        List<GameObject> targets = new List<GameObject>();
        foreach (var target in _enemyTargets)
        {
            var targetScript = target.GetComponent<EnemyTarget_Ship>();

            if (targetScript != null)
            {
                if (targetScript.ConvoyTargetExhausted == false)
                {
                    targets.Add(target);
                }
            }
        }
        
        int numberOfTargets = targets.Count;

        if (numberOfTargets <= 0)
        {
            _isConvoyDestroyed= true;
            _gameManager.Died = true;
            _destructionFX.SetActive(true);
        }
    }
}
