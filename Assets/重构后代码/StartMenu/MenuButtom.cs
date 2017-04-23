using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtom : MonoBehaviour {
    private void OnMouseDown()
    {
        CrossInCGSystem.isStart = false;
        SceneManager.LoadScene("菜单界面", LoadSceneMode.Additive);
    }
}
