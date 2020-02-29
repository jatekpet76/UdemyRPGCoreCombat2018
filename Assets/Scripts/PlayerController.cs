using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 4f;

    NavMeshAgent _nav;

    void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        _nav.speed = _speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                _nav.destination = hit.point;

            }
        }
    }
}
