using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SassyJoeController : MonoBehaviour
{
    [SerializeField] Transform[] _waitpoints;
    int _waitPoint = 0;

    private Animator _animator;
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

        _animator = GetComponent<Animator>();

        _navAgent = GetComponent<NavMeshAgent>();
        _navAgent.speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        HandleWaitPoint();


        // For Gravity RigidBody has velocity but it should Kinematic?  (_navAgent.velocity.x > 0 || _navAgent.velocity.z > 0)
        // Sometimes working but not every time :(  !_navAgent.isStopped
        // !!! When it rotating then it could not play the HumanoidRun animation. Why?
        _animator.SetBool("isRunning", !_navAgent.isStopped);
    }

    private void HandleWaitPoint()
    {
        if (_nextTime < Time.time)
        {
            NextWaitPoint();
        }
        else
        {
            WaitPointTooClose();
        }
    }

    private void WaitPointTooClose()
    {
        var distance = Vector3.Distance(transform.position, _navAgent.destination);

        if (distance < 3 && !_navAgent.isStopped)
        {
            _navAgent.isStopped = true;
        }
    }

    private void NextWaitPoint()
    {
        _nextTime = Time.time + Random.Range(4, 8);

        int choosen = Random.Range(0, _waitpoints.Length - 1);

        _navAgent.destination = _waitpoints[choosen].position;
        _navAgent.isStopped = false;
    }
}
