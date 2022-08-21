using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject bgc1;
    public GameObject bgc2;
    public int flag;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.GetComponent<Camera>().enabled=false;
        camera1.GetComponent<Camera>().enabled = true;
        camera2.GetComponent<Camera>().enabled = false;
        bgc1.SetActive(true);
        bgc2.SetActive(false);
        flag = 1;
      
        Vector3 c1 = camera1.transform.forward;
        Vector3 c2 = camera2.transform.forward;
        //Debug.Log(c1);
        //Debug.Log(c2);
        float angle = Mathf.Acos(Vector3.Dot(c1, c2));
        //Debug.Log(angle);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    Debug.Log(flag);
        //    flag = (flag + 1) % 3;
        //    switch (flag)
        //    {
        //        case 0:
        //            mainCamera.GetComponent<Camera>().enabled = true;
        //            camera1.GetComponent<Camera>().enabled = false;
        //            camera2.GetComponent<Camera>().enabled = false;
        //            bgc1.SetActive(false);
        //            bgc2.SetActive(false);
        //            break;
        //        case 1:
        //            mainCamera.GetComponent<Camera>().enabled = false;
        //            camera1.GetComponent<Camera>().enabled = true;
        //            camera2.GetComponent<Camera>().enabled = false;
        //            bgc1.SetActive(true);
        //            bgc2.SetActive(false);
        //            break;
        //        case 2:
        //            mainCamera.GetComponent<Camera>().enabled = false;
        //            camera1.GetComponent<Camera>().enabled = false;
        //            camera2.GetComponent<Camera>().enabled = true;
        //            bgc1.SetActive(false);
        //            bgc2.SetActive(true);
        //            break;
        //    }
        //}
    }
}
