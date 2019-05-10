using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Text levelText;

    public Text timeText;

    public Camera camera;

    public Button startButton;

    public GameObject startButtonGameObj;

    public GameObject showWinText;

    public GameObject topView;

    public GameObject powView;

    public bool pow = false;

    private int top;

    private List<Vector3> _spawnPoints;

    public GameObject target;

    public GameObject targetInstance;

    public bool didPlayerWon = false;

    public Text remainTime;

    public Button nextLevel;

    public Transform playerStartPoint;

    public Transform player;

    public int currentLevel = 0;

    public int levelTime;

    public PlayerMovment _playerMovment;

    public int remaingTime;


    // Start is called before the first frame update
    void Start()
    {
        showWinText.SetActive(false);
        didPlayerWon = false;
        startButton.onClick.AddListener(handleOnclick);
        changeCameraPosition(topView);
        currentLevel = 0;
        levelTime = RemoteConfigManager.levelTime;
        remaingTime = RemoteConfigManager.remaingTime;
        Debug.Log(remaingTime);
    }


    void spawnTargets()
    {
        _spawnPoints = new List<Vector3>();

        GameObject[] objs = GameObject.FindGameObjectsWithTag("spawnPoint");

        foreach (GameObject obj in objs)
        {
            _spawnPoints.Add(obj.GetComponent<Transform>().position);
        }

        top = _spawnPoints.Count;

        createTarget(top);
    }

    void createTarget(int topVal)
    {
        targetInstance = Instantiate(target, _spawnPoints.ElementAt(Random.Range(0, topVal)), Quaternion.identity);
    }

    private void Update()
    {
        if (pow == true)
        {
            changeCameraPosition(powView);
            _playerMovment.enabled = true;
        }

        if (pow == false)
        {
            _playerMovment.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            spawnTargets();
        }
    }

    void handleOnclick()
    {
        StartCoroutine(clickHandle());
    }

    IEnumerator clickHandle()
    {
        Destroy(targetInstance);
        startButtonGameObj.SetActive(false);
        showWinText.SetActive(false);
        didPlayerWon = false;
        player.position = playerStartPoint.position;
        player.rotation = playerStartPoint.rotation;
//        var startPoint = playerStartPoint.transform;
//
//        transform.Translate(startPoint.position.x, startPoint.position.y, startPoint.position.z);


        spawnTargets();

        for (int i = remaingTime; i >= 0; i--)
        {
            remainTime.text = i.ToString();
            if (i == 0) remainTime.text = "";
            yield return new WaitForSeconds(1);
        }

        Debug.Log("start button worked");
        startButtonGameObj.SetActive(false);
        Debug.Log("Start button enabled false");

        StartCoroutine(manageHighLevelContext(currentLevel));
//        StartCoroutine(manageLevel());
        targetInstance.GetComponent<Target>().mesh.enabled = false;
        yield break;
    }

    void changeCameraPosition(GameObject obj)
    {
        camera.transform.position = obj.transform.position;
        camera.transform.rotation = obj.transform.rotation;
    }

    IEnumerator manageLevel()
    {
        for (int j = 0; j < levelTime; j++)
        {
            pow = true;
            timeText.text = j.ToString();

            Debug.Log(didPlayerWon);

            if (didPlayerWon == false)
            {
                yield return new WaitForSeconds(1);
            }
            else
            {
                showWinText.SetActive(true);
                yield break;
            }
        }
    }

    IEnumerator manageHighLevelContext(int level)
    {
        for (int i = 0; i < 10; i++)
        {
            levelText.text = "level " + level.ToString() + ":";

            level++;
            currentLevel = level;

            yield return StartCoroutine(manageLevel());

            if (didPlayerWon == false)
            {
                startButtonGameObj.SetActive(true);

                pow = false;

                targetInstance.GetComponent<Target>().mesh.enabled = true;

//                Destroy(targetInstance);

                changeCameraPosition(topView);

                showWinText.SetActive(false);

                currentLevel = 0;

                yield break;
            }
            else
            {
                startButtonGameObj.SetActive(true);

                pow = false;

                Destroy(targetInstance);

                changeCameraPosition(topView);

                showWinText.SetActive(true);

                yield return StartCoroutine(manageNextLevel());
            }
        }
    }

    IEnumerator manageNextLevel()
    {
        while (pow == false)
        {
            yield return new WaitForEndOfFrame();
        }

        yield break;
    }

    void setActiveDidPlayerWon(bool cc)
    {
        didPlayerWon = cc;
    }
}