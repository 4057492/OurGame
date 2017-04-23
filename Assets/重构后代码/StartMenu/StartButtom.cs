using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtom : MonoBehaviour {

    GameObject startButtom;

	// Use this for initialization
	void Start () {
        startButtom = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        GameObject.FindGameObjectWithTag("button").GetComponent<SpriteRenderer>().enabled = true;
        MyCamera.isFixing = true;
        SceneManager.LoadScene("PlayerScene", LoadSceneMode.Additive);
        SceneChanger.Change("标题界面", "C1S1", "不知道怎么了，我独自来到镇子外。", 3.5f,"BGM2",1,true,2);
        厨师.counter = 1;
    }
}
