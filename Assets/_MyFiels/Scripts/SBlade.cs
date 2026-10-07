using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SBlade : MonoBehaviour
{
    [SerializeField] private bool isCutting = false;

    Rigidbody2D rb;
    
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Slicing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            NotSlicing();
        }

        if(isCutting == true)
        {
            CutUpdate();
        }
    }

    private void CutUpdate()
    {
        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    //Slicing 
    private void Slicing()
    {
        isCutting = true;
    }

    
    private void NotSlicing()
    {
        isCutting = false;
    }

    
}
