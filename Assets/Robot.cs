using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Robot : MonoBehaviour {

    GameObject robot_obj;
    bool isMoving = false;
    float speedForward;
    float speedBackward;
    float speedLeft;
    float speedRight;
    int initStatus;

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
            StartCoroutine(Init());
        }
    }

    public IEnumerator Forward(int mstime)
    {
        if (isMoving)
        {
            yield break; ///exit if this is still running
        }
        Debug.Log("Forward");
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
        Debug.Log("Back");
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
        //calculate moving speed
        Vector3 initPosition, nextPosition, firstVector, secondVector;
        initPosition = robot_obj.transform.position;
        yield return StartCoroutine(Forward(3));
        nextPosition = robot_obj.transform.position;
        //speedForward = Vector3.Distance(initPosition, nextPosition) / 3;
        speedForward = (float)Math.Sqrt(Math.Pow(initPosition.x - nextPosition.x, 2) + Math.Pow(initPosition.z - nextPosition.z, 2)) / 3;
        initPosition = robot_obj.transform.position;
        yield return StartCoroutine(Backward(2));
        nextPosition = robot_obj.transform.position;
        //speedBackward = Vector3.Distance(initPosition, nextPosition) / 2;
        speedBackward = (float)Math.Sqrt(Math.Pow(initPosition.x - nextPosition.x, 2) + Math.Pow(initPosition.z - nextPosition.z, 2)) / 2;

        // calculate rotation speed
        firstVector = nextPosition;
        yield return StartCoroutine(Left(5));
        yield return StartCoroutine(Forward(3));
        secondVector = robot_obj.transform.position;
        float scalar = firstVector.x * secondVector.x + firstVector.z * secondVector.z;
        float moduleFirst = (float)Math.Sqrt(Math.Pow(firstVector.x, 2)+Math.Pow(firstVector.z, 2));
        float moduleSecond = (float)Math.Sqrt(Math.Pow(secondVector.x, 2) + Math.Pow(secondVector.z, 2));
        float angleLeft = (float)Math.Acos(scalar / (moduleFirst * moduleSecond));
        Debug.Log(angleLeft);

        yield return StartCoroutine(Right(5));
        yield return StartCoroutine(Forward(3));
    }

    public IEnumerator Waiting(int mstime)
    {
        yield return new WaitForSeconds(mstime);
    }
}
