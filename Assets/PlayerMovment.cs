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
            StartCoroutine(changeRotation(-1));
        }

        if (Input.GetKeyDown("d"))
        {
            StartCoroutine(changeRotation(1));
        }
    }


    IEnumerator moveForward()
    {
        for (int i = 0; i < 40; i++)
        {
            transform.Translate(0.05f, 0, 0);
            yield return new WaitForEndOfFrame();
        }

        yield break;
    }

    IEnumerator changeRotation(int rotate)
    {
        for (int i = 0; i < 90; i++)
        {
            transform.Rotate(0, rotate, 0);
            yield return new WaitForEndOfFrame();
        }

        yield break;
    }
}