using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class MainCameraController : MonoBehaviour
{
    Vector3 direction;
    float distance;
    Vector3 obj;
    private float OffsetX = 0;
    private float OffsetY = 0;
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("bunnyInWorld").GetComponent<Transform>().position;       

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameObject.activeSelf)
        {
            direction = (obj - this.transform.position).normalized;
            //滚轮实现缩放
            this.transform.position -= Input.GetAxis("Mouse ScrollWheel") * direction * 2;
            distance = Vector3.Distance(obj, this.transform.position);
            if (Input.GetMouseButton(1))
            {
                OffsetX = Input.GetAxis("Mouse X");//获取鼠标x轴的偏移量
                OffsetY = Input.GetAxis("Mouse Y");//获取鼠标y轴的偏移量

                this.transform.Translate(new Vector3(-OffsetX, -OffsetY, 0) * distance / 15, Space.Self);
            }
            else if (Input.GetMouseButton(0))
            {
                OffsetX = Input.GetAxis("Mouse X");//获取鼠标x轴的偏移量
                OffsetY = Input.GetAxis("Mouse Y");//获取鼠标y轴的偏移量

                this.transform.RotateAround(obj, Vector3.up, OffsetX);
                this.transform.RotateAround(obj, Vector3.forward, OffsetY);
            }
        }
    }

    IEnumerator OnMouseDown()
    {
        //将物体由世界坐标系转换为屏幕坐标系
        Vector3 screenSpace = Camera.main.WorldToScreenPoint(this.transform.position);//三维物体坐标转屏幕坐标
        Debug.Log(screenSpace);
        //完成两个步骤 1.由于鼠标的坐标系是2维，需要转换成3维的世界坐标系 
        //    //             2.只有3维坐标情况下才能来计算鼠标位置与物理的距离，offset即是距离
        //将鼠标屏幕坐标转为三维坐标，再算出物体位置与鼠标之间的距离
        Vector3 offset = this.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
        while (Input.GetMouseButton(0))
        {
            //得到现在鼠标的2维坐标系位置
            Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
            //将当前鼠标的2维位置转换成3维位置，再加上鼠标的移动量
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
            //curPosition就是物体应该的移动向量赋给transform的position属性
            transform.position = curPosition;
            yield return new WaitForFixedUpdate(); //这个很重要，循环执行
        }
    }
}
