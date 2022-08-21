using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject bgc1;
    public GameObject bgc2;
    public int flag;
    public int frameIndex_B = 0;

    public Button m_Button;
    public Text m_Text;
    List<string> buttonName;
    bool stop = true;

    void Start()
    {
        mainCamera.GetComponent<Camera>().enabled = false;
        camera1.GetComponent<Camera>().enabled = true;
        camera2.GetComponent<Camera>().enabled = false;
        bgc1.SetActive(true);
        bgc2.SetActive(false);
        flag = 1;

        buttonName = new List<string>();
        buttonName.Add("MainCamera");
        buttonName.Add("Camera1");
        buttonName.Add("Camera2");
        m_Text.text = buttonName[flag];
        m_Button.onClick.AddListener(CameraEvent);
    }

    void FixedUpdate()
    {
        if (!stop && frameIndex_B < 1000)
        {
            frameIndex_B++;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            stop = !stop;
        }
    }

    public void CameraEvent()
    {
        flag = (flag + 1) % 3;
        m_Text.text = buttonName[flag];
        switch (flag)
        {
            case 0:
                mainCamera.GetComponent<Camera>().enabled = true;
                camera1.GetComponent<Camera>().enabled = false;
                camera2.GetComponent<Camera>().enabled = false;
                bgc1.SetActive(false);
                bgc2.SetActive(false);
                break;
            case 1:
                mainCamera.GetComponent<Camera>().enabled = false;
                camera1.GetComponent<Camera>().enabled = true;
                camera2.GetComponent<Camera>().enabled = false;
                bgc1.SetActive(true);
                bgc2.SetActive(false);
                break;
            case 2:
                mainCamera.GetComponent<Camera>().enabled = false;
                camera1.GetComponent<Camera>().enabled = false;
                camera2.GetComponent<Camera>().enabled = true;
                bgc1.SetActive(false);
                bgc2.SetActive(true);
                break;
        }
    }

}
