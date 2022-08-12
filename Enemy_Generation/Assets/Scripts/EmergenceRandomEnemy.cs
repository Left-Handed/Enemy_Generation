using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergenceRandomEnemy : MonoBehaviour
{
    
    [SerializeField] private Transform _positionSpavn;
    [SerializeField] private float _delay = 2f;
    [SerializeField] private int _amount = 5;
    [SerializeField] private Enemy _enemy;

    private Transform[] _positionSpavns;

    private void Start()
    {
        SeparatePositions();
        StartCoroutine(EnemyDrop());
    }

    private IEnumerator EnemyDrop()
    {
        int minNumberPosition = 1;
        int maxNumberPosition = _positionSpavns.Length;
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

        for (int i = 0; i < _amount; i++)
        {
            Transform target = _positionSpavns[Random.Range(minNumberPosition, maxNumberPosition)];

            Instantiate(_enemy, target.position, Quaternion.identity);
            Debug.Log(Time.deltaTime);

            yield return waitForSeconds;
        }
    }

    private void SeparatePositions()
    {
        _positionSpavns = new Transform[_positionSpavn.childCount];

        for (int i = 0; i < _positionSpavn.childCount; i++)
        {
            _positionSpavns[i] = _positionSpavn.GetChild(i);
        }
    }
}
