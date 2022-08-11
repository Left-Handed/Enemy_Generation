using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _positionSpavn;
    [SerializeField] private float _timeBetweenAppearance = 2f;
    [SerializeField] private int _numberEnemy = 5;

    private Transform[] _positionSpavns;
    private int _countEnemy = 0;


    private void Start()
    {
        GetPositions();
        StartCoroutine(EnemyDrop());
    }

    private IEnumerator EnemyDrop()
    {
        int minNumberPosition = 1;
        int maxNumberPosition = _positionSpavns.Length;

        var _waitForSeconds = new WaitForSeconds(_timeBetweenAppearance);

        for (int i = 0; i < _numberEnemy; i++)
        {
            Transform target = _positionSpavns[Random.Range(minNumberPosition, maxNumberPosition)];

            Instantiate(_enemy, target.position, Quaternion.identity);
            Debug.Log(Time.deltaTime);

            yield return _waitForSeconds;
        }

        _countEnemy++;
    }

    private void GetPositions()
    {
        _positionSpavns = new Transform[_positionSpavn.childCount];

        for (int i = 0; i < _positionSpavn.childCount; i++)
        {
            _positionSpavns[i] = _positionSpavn.GetChild(i);
        }
    }

}
