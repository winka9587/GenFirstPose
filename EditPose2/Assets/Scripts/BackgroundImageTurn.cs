using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class BackgroundImageTurn : MonoBehaviour
{
    public GameObject frameIndexC;
    // 储存获取到的路径
    List<Texture2D> allTex2d;
    RawImage rawimage;
    public int frameIndex;
    public string filename;

    // Start is called before the first frame update
    void Start()
    {
        allTex2d = new List<Texture2D>();
        frameIndex = frameIndexC.GetComponent<ButtonController>().frameIndex_B;
        rawimage = this.GetComponent<RawImage>();//获取unity中的RawImage
        Load();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frameIndex = frameIndexC.GetComponent<ButtonController>().frameIndex_B;
        rawimage.texture = allTex2d[frameIndex];//显示图片
        //Debug.Log(allTex2d.Count);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (frameIndex < allTex2d.Count - 1)
            {
                frameIndex += 1;
                frameIndexC.GetComponent<ButtonController>().frameIndex_B = frameIndex;
            }
            //Debug.Log(frameIndexC.GetComponent<ButtonController>().frameIndex_B);
        }
        
        
    }

    void Load()
    {
        List<string> filePaths = new List<string>();
        string imgtype = "*.BMP|*.JPG|*.GIF|*.PNG|*.JPEG";
        string[] ImageType = imgtype.Split('|');
        for (int i = 0; i < ImageType.Length; i++)
        {
            //获取Application.dataPath文件夹下所有的图片路径  
            //string[] dirs = Directory.GetFiles((Application.dataPath + "/Picture/05_bunny_Circle_StaticCamera1"), ImageType[i]);
            //Debug.Log(Application.dataPath + filename);
            string[] dirs = Directory.GetFiles((Application.dataPath + filename), ImageType[i]);
            for (int j = 0; j < dirs.Length; j++)
            {
                filePaths.Add(dirs[j]);
            }
        }

        for (int i = 0; i < filePaths.Count; i++)
        {
            Texture2D tx = new Texture2D(100, 100);
            tx.LoadImage(getImageByte(filePaths[i]));
            allTex2d.Add(tx);
        }
       
        //Debug.Log(objectPoseList.Count);
    }

    private static byte[] getImageByte(string imagePath)
    {
        FileStream files = new FileStream(imagePath, FileMode.Open);
        byte[] imgByte = new byte[files.Length];
        files.Read(imgByte, 0, imgByte.Length);
        files.Close();
        return imgByte;
    }

}