using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public int x;
    public int y;
    public int z;

    public float xTrans;
    public float xFreq;
    
    private Vector3 startPosition;
    private float start;
    void Start()
    {
        startPosition = transform.position;
        start = Random.Range(0, 100);
    }

    void Update()
    {
        transform.Rotate(new Vector3(x, 0, 0) * Time.deltaTime);
        transform.Rotate(new Vector3(0, y, 0) * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, z) * Time.deltaTime);
        transform.position = startPosition + new Vector3(0, Mathf.Sin(Time.time * xFreq + start), 0) * xTrans;
    }
}
