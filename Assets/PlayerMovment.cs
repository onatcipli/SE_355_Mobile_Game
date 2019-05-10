using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public Rigidbody rigidBody;
    public Vector3 horizontal;
    public Vector3 vertical;

    // Start is called before the first frame update
    void Start()
    {
        horizontal = new Vector3(40, 0, 0);
        vertical = new Vector3(0, 0, 40);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            StartCoroutine(moveForward());
        }

        if (Input.GetKeyDown("a"))
        {
            Debug.Log("a");
            StartCoroutine(changeRotation(-10));
        }

        if (Input.GetKeyDown("d"))
        {
            Debug.Log("d");
            StartCoroutine(changeRotation(10));
        }
    }


    IEnumerator moveForward()
    {
        for (int i = 0; i < 20; i++)
        {
            transform.Translate(0.05f, 0, 0);
            yield return new WaitForSeconds(0.05f);
        }

        yield break;
    }

    IEnumerator changeRotation(int rotate)
    {
        for (int i = 0; i < 9; i++)
        {
            transform.Rotate(0, rotate, 0);
            yield return new WaitForSeconds(0.05f);
        }

        yield break;
    }
}