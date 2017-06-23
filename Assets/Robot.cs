using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {

    GameObject robot_obj;

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
    }

    public IEnumerator Forward(int mstime)
    {
        robot_obj.transform.Translate(robot_obj.transform.forward * Time.deltaTime);
        yield return new WaitForSeconds(mstime);
    }

    public void Backward(int mstime)
    {

    }

    public void Left(int mstime)
    {

    }

    public void Right(int mstime)
    {

    }
}
