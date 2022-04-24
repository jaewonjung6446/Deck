using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;

    Transform tr;
    Rigidbody rb;

    float mov_horizon, mov_vertical, mov_jump;

    Vector3 mov_vec;
    Vector3 mov_vec_h;
    Vector3 mov_vec_v;

    bool is_jump = false;

    // Start is called before the first frame update
    void Start()
    {

        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        StartCoroutine("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(Enemy.transform.position);
        Walk();
        mov_jump = Input.GetAxis("Jump");
        if (mov_jump != 0 && !is_jump)
        {
            StartCoroutine(Jump());
        }
    }
    void Walk()
    {
        mov_horizon = Input.GetAxisRaw("Horizontal");
        mov_vertical = Input.GetAxisRaw("Vertical");
        mov_vec = new Vector3(mov_horizon, 0, mov_vertical).normalized;

        tr.Translate(mov_vec * Time.deltaTime);
    }
    IEnumerator Jump()
    {
        rb.AddForce(Vector3.up * 4, ForceMode.Impulse);
        is_jump = true;
        Debug.Log(true);
        Debug.Log(is_jump);
        Debug.Log("call");
        yield return new WaitForSecondsRealtime(0.5f);
    }
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("1");
        if (is_jump && other.gameObject.name == ("Floor"))
        {
            if (is_jump)
            {
                is_jump = false;
                Debug.Log(is_jump);
            }
        }
    }
}
