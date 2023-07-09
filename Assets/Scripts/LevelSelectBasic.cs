using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class LevelSelectBasic : MonoBehaviour
{
    // Start is called before the first frame update
    public Color green;
    public Color beige;
    private int test;
    [SerializeField] GameObject[] playButtons;

    void Start()
    {
    }

    public void selectLevel(int levelIndex) {
        SceneManager.LoadScene(levelIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}