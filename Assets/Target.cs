using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public MeshRenderer mesh;

    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        mesh.enabled = true;

        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trigger : " + levelManager.didPlayerWon);
            levelManager.didPlayerWon = true;
            //TODO: implement here 
            Debug.Log("Trigger : " + levelManager.didPlayerWon);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trigger : " + levelManager.didPlayerWon);
            levelManager.didPlayerWon = true;
            //TODO: implement here 
            Debug.Log("Trigger : " + levelManager.didPlayerWon);
        }
    }
}