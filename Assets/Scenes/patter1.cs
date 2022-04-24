using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patter1 : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject Enemy;

    Transform tr;
    Rigidbody rb;

    float sin_a;
    float sin_b;
    float time;

    Pooling pool;

    // Start is called before the first frame update
    void Start()
    {
        tr = transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        time =+ Time.time;
        if(time >= 1.0f)
        {
            Debug.Log("16");
            Pattern1();
        }
    }
    void Pattern1()
    {
        for(int i = 0; i < 10; i++)
        {
            sin_a = Mathf.Sin(360/10*i);
            sin_b = Mathf.Cos(360 / 10 * i);
            Vector3 gen_position = Enemy.transform.position + new Vector3(sin_a * 10, 0, sin_b * 10);
            pool.Get(bullet, gen_position);
        }
    }
}
