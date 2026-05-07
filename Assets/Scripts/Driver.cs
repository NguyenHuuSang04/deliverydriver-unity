using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 10f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount); // xoay quanh trục Z với tốc độ steerSpeed độ/giây
        transform.Translate(0, moveAmount, 0);// di chuyển theo trục Y local với độ moveSpeed đơn vị/giây
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Speed up")
        {
            moveSpeed = boostSpeed;
            Debug.Log("Chạy nhanh nè!!!");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
        Debug.Log("Chậm lại 1 chút thôi!!!");
    }
}
