using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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

        while (_numberEnemy > _countEnemy)
        {
            Transform target = _positionSpavns[Random.Range(minNumberPosition,maxNumberPosition)];

            Instantiate(_enemy, target.position, Quaternion.identity);

            yield return new WaitForSeconds(_timeBetweenAppearance);
            _countEnemy++;

            Debug.Log(Time.deltaTime);
        }
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
