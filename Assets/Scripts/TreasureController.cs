using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour
{
    [SerializeField] Material[] _materials;
    [SerializeField] Vector3 _rotate = new Vector3(10, 0, 0);
    // Start is called before the first frame update

    float _nextTime = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotate * Time.deltaTime);

        if (_nextTime < Time.time)
        {
            _nextTime = Time.time + Random.Range(2, 5);

            int choosenMaterial = Random.Range(0, _materials.Length-1);

            GetComponent<MeshRenderer>().material = _materials[choosenMaterial];
        }
    }
}
