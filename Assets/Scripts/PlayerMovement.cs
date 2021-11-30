using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float playerSpeed = 5;

    public bool mouseMove = true;
    public Vector3 mousePos;
//------------------------------------------------

    void Start()
    {
        
    }


    void Update()
    {
        LocatePointer();
        Move();
    }

    public void LocatePointer()
    {
        mousePos = Input.mousePosition;

    }

    public void Move()
    {
        Vector3 offset = new Vector3(-3, -3, 0);

        if (mouseMove)
        {
            Vector3 playerPos = mousePos + offset;
            transform.position = playerPos * playerSpeed * Time.deltaTime;

        }
    }

}
