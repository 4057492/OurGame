using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInformation : MonoBehaviour {
    public string subtitle00;
    public float time00;
    public string subtitle01;
    public float time01;
    public string subtitle02;
    public float time02;
    public string subtitle03;
    public float time03;
    int currentSub = 0;
    int SubNum = 3;
    bool isJustNormal = true;
    // Use this for initialization
    void Awake()
    {
        FixSubNum();
        GetComponent<BoxCollider>().center -= new Vector3(0, 0, GetComponent<BoxCollider>().center.z);
        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        if (spr != null) transform.position -= new Vector3(0,0,transform.position.z-7)+ spr.sortingOrder * new Vector3(0, 0, 1);//根据物体渲染顺序修正碰撞箱位置
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0) || (isJustNormal && Input.GetMouseButtonUp(1) && Camera.main.ScreenToWorldPoint(Input.mousePosition).y > 0))
        {
            AudioSystem.current.Play("调查");
            switch (currentSub)
            {
                case 0: SubtitleSystem.ShowSubtitle(subtitle00, time00); break;
                case 1: SubtitleSystem.ShowSubtitle(subtitle01, time01); break;
                case 2: SubtitleSystem.ShowSubtitle(subtitle02, time02); break;
                case 3: SubtitleSystem.ShowSubtitle(subtitle03, time03); break;
            }
            if (SubNum != 0)
            {
                currentSub++;
                if (currentSub > SubNum) currentSub = 1;
            }
        }
    }
    public void Set(string s0,float t0, string s1, float t1, string s2, float t2, string s3, float t3)
    {
        subtitle00 = s0;
        time00 = t0;
        subtitle01 = s1;
        time01 = t1;
        subtitle02 = s2;
        time02 = t2;
        subtitle03 = s3;
        time03 = t3;
        FixSubNum();
    }
    public void IamSpeacial()
    {
        isJustNormal = false;
    }
    void FixSubNum()
    {
        SubNum = 3;
        if (subtitle03 == "")
        {
            SubNum = 2;
        }
        if (subtitle02 == "")
        {
            SubNum = 1;
        }
        if (subtitle01 == "")
        {
            SubNum = 0;
        }
        currentSub = 0;
    }
}
