using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControllerUI : MonoBehaviour
{
    [Header("панели в канвасе")]
    [SerializeField]
    private GameObject startPanel;

    [SerializeField]
    private GameObject endpanel;
    [Header("Игрок")]
    [SerializeField]
    private GameObject player;

    void Start()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        player.GetComponent<MovementSrc>().enabled = false;
        player.GetComponent<HitControll>().enabled = false;

    }
    public void StartGame()
    {
        Time.timeScale = 1;
        startPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<MovementSrc>().enabled = true;
        player.GetComponent<HitControll>().enabled = true;
    }

    void Update()
    {
        GameObject[] allObjectDestroy = GameObject.FindGameObjectsWithTag("destroyObject");
        Debug.Log(allObjectDestroy.Length);
        if (allObjectDestroy.Length == 0)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            player.GetComponent<MovementSrc>().enabled = false;
            player.GetComponent<HitControll>().enabled = false;
            endpanel.SetActive(true);
        }
    }


    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }
}
