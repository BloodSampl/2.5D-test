using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody rb;
    private BoxCollider boxCollider;
    private Keyboard keyboard;
    private Vector3 dir;

    [SerializeField]
    private Transform spriteTransform;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        keyboard = Keyboard.current;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dir = Vector3.zero;

        if (keyboard.aKey.IsPressed())
        {
            dir.x = -1;
            spriteTransform.localScale = new Vector3(-1, 1, 1);
        }
        if (keyboard.dKey.IsPressed())
        {
            dir.x = 1;
            spriteTransform.localScale = new Vector3(1, 1, 1);
        }
        if (keyboard.wKey.IsPressed()) dir.z =  1;
        if (keyboard.sKey.IsPressed()) dir.z = -1;

        rb.linearVelocity = new Vector3(dir.x * speed, rb.linearVelocity.y, dir.z * speed);
    }
}
