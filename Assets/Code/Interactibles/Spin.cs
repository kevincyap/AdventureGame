using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public int x;
    public int y;
    public int z;

    void Update()
    {
        transform.Rotate(new Vector3(x, 0, 0) * Time.deltaTime);
        transform.Rotate(new Vector3(0, y, 0) * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, z) * Time.deltaTime);
    }
}
