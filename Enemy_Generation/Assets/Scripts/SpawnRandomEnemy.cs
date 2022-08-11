using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomEnemy : MonoBehaviour
{
    
    [SerializeField] private Transform _positionSpavn;
    [SerializeField] private float _timeBetweenAppearance = 2f;
    [SerializeField] private int _numberEnemy = 5;

    private WaitForSeconds _waitForSeconds;
    private Transform[] _positionSpavns;
    private GameObject _enemy;
    private int _countEnemy = 0;


    private void Start()
    {
        _enemy = Instantiate(Resources.Load("Enemy_Dexeased", typeof(GameObject))) as GameObject;
        _waitForSeconds = new WaitForSeconds(_timeBetweenAppearance);

        GetPositions();
        StartCoroutine(EnemyDrop());
    }

    private IEnumerator EnemyDrop()
    {
        int minNumberPosition = 1;
        int maxNumberPosition = _positionSpavns.Length;


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
