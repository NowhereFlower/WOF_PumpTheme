using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SBlade : MonoBehaviour
{
    [SerializeField] private bool isCutting = false;
    public float minCutting = 0.1f;
    private Rigidbody2D rb;
    private Vector2 previousPos;
    private Camera cam;
    private CircleCollider2D circleCollider;

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
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
        Vector2 newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPos;
        float velocity = (newPos - previousPos).magnitude / Time.deltaTime;
        if(velocity > minCutting)
        {
            //circleCollider.enabled = true;
        }
        else
        {
            //circleCollider.enabled = false;
        }
        previousPos = newPos;
    }
    private void Slicing()
    {
        isCutting = true;
        //circleCollider.enabled = false;
    }

    
    private void NotSlicing()
    {
        isCutting = false;
        //circleCollider.enabled = false;
    }

    
}
