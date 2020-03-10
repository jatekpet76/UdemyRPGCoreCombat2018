using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField] float _speed = 3;
    Vector3 _startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var zPos = Input.GetAxis("Vertical");
        var xPos = Input.GetAxis("Horizontal");
        var pos = transform.position;

        transform.position = new Vector3(pos.x + (xPos * _speed * Time.deltaTime), pos.y, pos.z + (zPos * _speed * Time.deltaTime));
    }
}
