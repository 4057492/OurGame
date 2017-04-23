using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrossInMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        CrossInCGSystem.isStart = true;
        SceneManager.UnloadSceneAsync("菜单界面");
    }
}
