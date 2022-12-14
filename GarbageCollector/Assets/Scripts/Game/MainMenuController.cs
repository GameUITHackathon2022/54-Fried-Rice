using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public static MainMenuController Instance { get; private set; }
    public Button startBtn, exitBtn;
    public Sprite startBtnHover, exitBtnHover;
    Sprite defaultStartBtnSprite, defaultExitBtnSprite;
    public GameObject blackScene;
    Animator blackSceneAnim, startBtnAnim, exitBtnAnim;

    public AudioClip buttonClip;
    AudioSource music;

    public ParticleSystem clickEffect;

    private void Awake()
    {
        Instance = this;
        music = gameObject.GetComponent<AudioSource>();
        blackSceneAnim = blackScene.GetComponent<Animator>();
        startBtnAnim = startBtn.GetComponent<Animator>();
        exitBtnAnim = exitBtn.GetComponent<Animator>();
    }
    void Start()
    {
        blackSceneAnim.Play("BlackSceneBegin");
        Time.timeScale = 1;
        defaultStartBtnSprite = startBtn.image.sprite;
        defaultExitBtnSprite = exitBtn.image.sprite;
        music.clip = buttonClip;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Hieu ung khi click chuot
        {
            music.Play();
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z += 10;
            Instantiate(clickEffect, mousePos, Quaternion.identity);
        }
    }
    public void onHoverStartBtn()
    {
        startBtnAnim.Play("BtnEnter");
        music.Play();
        startBtn.image.sprite = startBtnHover;
    }

    public void onExitStartBtn()
    {
        startBtnAnim.Play("BtnExit");
        startBtn.image.sprite = defaultStartBtnSprite;
    }

    public void onHoverExitBtn()
    {
        exitBtnAnim.Play("BtnEnter");
        music.Play();
        exitBtn.image.sprite = exitBtnHover;
    }
    public void onExitExitBtn()
    {
        exitBtnAnim.Play("BtnExit");
        exitBtn.image.sprite = defaultExitBtnSprite;
    }

    public void ExitBtn()
    {
        Debug.Log("Exit");
        Application.Quit();
    }    
    public void StartBtn()
    {
        blackSceneAnim.Play("BlackSceneEnd");
        Invoke("LoadGameScene", 1);
        //SceneManager.LoadScene(1);
    }

    void LoadGameScene()
    {
        Debug.Log("LoadScene");
        SceneManager.LoadScene(1);
    }
}
