using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {

    GameObject robot_obj;
    bool isMoving = false;

    // Use this for initialization
    void Start() {
        robot_obj = GameObject.FindGameObjectWithTag("robot");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(Forward(3));
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(Left(20));
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(Left(20));
        }
    }

    public IEnumerator Forward(int mstime)
    {
        if (isMoving)
        {
            yield break; ///exit if this is still running
        }
        isMoving = true;
        float counter = 0;
        while (counter < mstime)
        {
            counter += Time.deltaTime;
            robot_obj.transform.Translate(robot_obj.transform.forward * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
    }

    public IEnumerator Backward(int mstime)
    {
        if (isMoving)
        {
            yield break; ///exit if this is still running
        }
        isMoving = true;
        float counter = 0;
        while (counter < mstime)
        {
            counter += Time.deltaTime;
            robot_obj.transform.Translate(robot_obj.transform.forward * -Time.deltaTime);
            yield return null;
        }
        isMoving = false;
    }

    public IEnumerator Left(int mstime)
    {
        if (isMoving)
        {
            yield break; ///exit if this is still running
        }
        isMoving = true;
        float counter = 0;
        while (counter < mstime)
        {
            counter += Time.deltaTime;
            robot_obj.transform.Rotate(Vector3.up * -Time.deltaTime);
            yield return null;
        }
        isMoving = false;
    }

    public IEnumerator Right(int mstime)
    {
        if (isMoving)
        {
            yield break; ///exit if this is still running
        }
        isMoving = true;
        float counter = 0;
        while (counter < mstime)
        {
            counter += Time.deltaTime;
            robot_obj.transform.Rotate(Vector3.up * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
    }

    public IEnumerator Init()
    {
        yield return StartCoroutine(Forward(3));

    }
}
