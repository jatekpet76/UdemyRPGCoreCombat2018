using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour
{
    [SerializeField] Vector3 _rotate = new Vector3(10, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotate * Time.deltaTime);
    }
}
