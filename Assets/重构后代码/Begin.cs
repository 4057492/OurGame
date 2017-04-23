using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour {

    public Flash flash;
    public GameObject sky;
    public GameObject black;
    public GameObject logo;
    public GameObject background;
    public GameObject bug;
    public GameObject titleScene1;
    public GameObject titleScene2;
    public GameObject titleScene3;
    public GameObject titleScene4;
    public GameObject titleScene5;
    public GameObject titleScene6;
    public GameObject titleScene7;
    public float speed;
    static public bool pass = false;
    Transform trans;
    // Use this for initialization
    void Start () {
        MyCamera.isFixing = false;
        Camera.main.transform.position = Vector3.back*10;
        StartCoroutine(begin());
    }
	
	// Update is called once per frame
	void Update () {
        if(trans!=null)trans.position += new Vector3(-speed, 0, 0);
        if (Input.GetKeyDown(KeyCode.Escape)||pass)
        {
            CameraEffectChange.ChangeEffect(1);
            Begin.pass = false;
            StopAllCoroutines();
            标题.isStart = true;
            SceneManager.LoadScene("标题界面", LoadSceneMode.Additive);
            AudioSystem.current.BGMSource.Stop();
            AudioSystem.ChangeBGM("BGM1", 1);
            SceneManager.UnloadSceneAsync("片头");
            MouseIcon.Change(1);
        }
	}

    IEnumerator begin()
    {
        Cursor.visible = false;
        MouseIcon.Change(0);
        CameraEffectChange.ChangeEffect(0);
        GameObject.FindGameObjectWithTag("button").GetComponent<SpriteRenderer>().enabled = false;
        Fade.Hide(logo);
        yield return new WaitForSeconds(1f);
        Fade.FadeIn(logo, 1f);
        yield return new WaitForSeconds(4f);
        Fade.Disappear(background, 3);
        yield return new WaitForSeconds(3f);
        Fade.Disappear(logo, 3);
        yield return new WaitForSeconds(3f);



        AudioSystem.ChangeBGM("BGM0",0,false);
        CameraEffectChange.ChangeEffect(1);
        float t = 2.725f;
        yield return Words1();//第一句话
        yield return new WaitForSeconds(9.24f);
        yield return flash.flash1();//闪烁
        sky.SetActive(true);//天空
        Fade.FadeIn(sky, 1f);
        yield return new WaitForSeconds(2.05f);
        Fade.FadeOut(sky, 2);//天空消失
        yield return new WaitForSeconds(3);
        yield return Words2();
        yield return new WaitForSeconds(5.5f);
        SceneManager.LoadScene("PlayerScene", LoadSceneMode.Additive);
        titleScene1.SetActive(true);
        Fade.FadeIn(titleScene1);
        放动画.isMove = true;
        trans = titleScene1.transform;
        yield return new WaitForSeconds(t);
        Fade.Disappear(titleScene1);
        titleScene2.SetActive(true);
        Fade.FadeIn(titleScene2);
        trans = titleScene2.transform;
        yield return new WaitForSeconds(t);
        Fade.Disappear(titleScene2);
        titleScene3.SetActive(true);
        Fade.FadeIn(titleScene3);
        trans = titleScene3.transform;
        yield return new WaitForSeconds(t);
        Fade.Disappear(titleScene3);
        titleScene4.SetActive(true);
        Fade.FadeIn(titleScene4);
        trans = titleScene4.transform;
        yield return new WaitForSeconds(t);
        Fade.Disappear(titleScene4);
        titleScene5.SetActive(true);
        Fade.FadeIn(titleScene5);
        trans = titleScene5.transform;
        yield return new WaitForSeconds(t);
        Fade.Disappear(titleScene5);
        titleScene6.SetActive(true);
        Fade.FadeIn(titleScene6);
        trans = titleScene6.transform;
        yield return new WaitForSeconds(t);
        Fade.Disappear(titleScene6);
        titleScene7.SetActive(true);
        Fade.FadeIn(titleScene7);
        trans = titleScene7.transform;
        yield return new WaitForSeconds(t);
        放动画.isMove = false;
        Fade.FadeOut(titleScene7, 1);
        Fade.FadeOut(Player.current.gameObject,1);
        yield return new WaitForSeconds(2);
        SceneManager.UnloadSceneAsync("PlayerScene");
        titleScene7.SetActive(false);
        yield return Words3();
        yield return new WaitForSeconds(3);
        yield return Words4();
        yield return new WaitForSeconds(7);
        标题.isStart = true;
        SceneManager.LoadScene("标题界面", LoadSceneMode.Additive);
        AudioSystem.ChangeBGM("BGM1",7);
        SceneManager.UnloadSceneAsync("片头");
        MouseIcon.Change(1);
    }

    public IEnumerator Words1()
    {
        yield return new WaitForSeconds(2.8f);
        SubtitleSystem.ShowSpecialSubtitle("人们都喜欢和平美好的生活", 4f);
    }

    public IEnumerator Words2()
    {
        yield return 0;
        SubtitleSystem.ShowSpecialSubtitle("没有担忧、没有痛苦、没有离别", 4.5f);
    }

    public IEnumerator Words3()
    {
        yield return new WaitForSeconds(1);
        SubtitleSystem.ShowSpecialSubtitle("就像我所拥有的那样", 3f);
    }

    public IEnumerator Words4()
    {
        yield return new WaitForSeconds(1);
        SubtitleSystem.ShowSpecialSubtitle("直到······", 4f);
    }
}
