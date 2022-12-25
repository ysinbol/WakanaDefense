using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        // 左右の移動
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal * speed * Time.deltaTime, 0, 0);

        // 上下の移動
        float vertical = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, vertical * speed * Time.deltaTime, 0);
    }
}