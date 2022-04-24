using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    [SerializeField] 
    private Camera Camera;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject Enemy;

    Vector3 player_pos;
    Vector3 enemy_pos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player_pos = Player.transform.position;
        enemy_pos = Enemy.transform.position;
        Camera.main.transform.position = new Vector3(0,5,0) + player_pos - (enemy_pos - player_pos);
        Camera.transform.LookAt(enemy_pos);
    }
}
