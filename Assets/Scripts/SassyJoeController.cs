using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SassyJoeController : MonoBehaviour
{
    [SerializeField] Transform[] _waitpoints;
    int _waitPoint = 0;
    NavMeshAgent _navAgent;
    float _nextTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (_waitpoints == null || _waitpoints.Length == 0) {
            GameObject[] treasures = GameObject.FindGameObjectsWithTag("Treasure");

            _waitpoints = new Transform[treasures.Length];

            int i = 0;
            foreach (GameObject treasure in treasures)
            {
                _waitpoints[i] = treasure.transform;
                i++;
            }
        }

        _navAgent = GetComponent<NavMeshAgent>();
        _navAgent.speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (_nextTime < Time.time)
        {
            _nextTime = Time.time + Random.Range(4, 8);

            int choosen = Random.Range(0, _waitpoints.Length - 1);

            _navAgent.destination = _waitpoints[choosen].position;
        }
    }
}
