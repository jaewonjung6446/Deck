using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pooling : MonoBehaviour
{
    [SerializeField] private GameObject enemy_monster;
    [SerializeField] private GameObject enemy_bullet;

    Queue<GameObject> monster;
    Queue<GameObject> bullet;

    int monster_gen_num = 300;
    int bullet_gen_num = 300;

    Vector3 gen_pos = Vector3.zero;

    public Action<GameObject> Des;
    public Action<GameObject,Vector3> Get;

    // Start is called before the first frame update
    private void Awake()
    {
        StartPool();
    }

    void Start()
    {
        Des = (GameObject des) => { DesPool(des); };
        Get = (GameObject getpool, Vector3 gen_pos) => { GetPool(getpool, gen_pos); };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartPool(int bullet_gen_num)
    {
        for (int i = 0; i < bullet_gen_num; i++)
        {
            GameObject m_b = GameObject.Instantiate(enemy_bullet);
            Debug.Log(m_b.name);
            bullet.Enqueue(m_b);
            m_b.SetActive(false);
            Debug.Log("bullet gen start");
        }
    }
    void GetPool(GameObject getpool, Vector3 gen_pos)
    {
        GameObject bu_gen = monster.Dequeue();
        bu_gen.transform.position = gen_pos;
    }
    void DesPool(GameObject despool)
    {
        switch (despool.name)
        {
            case "Monster":
                despool.SetActive(false);
                monster.Enqueue(despool);
                break;
            case "Bullet":
                despool.SetActive(false);
                bullet.Enqueue(despool);
                break;
        }
    }
}
