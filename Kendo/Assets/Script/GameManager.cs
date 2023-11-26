using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player1Move P1;
    public Player2Move P2;

    public GameObject Kaisi;
    
    
    void Start()
    {
        StartCoroutine(GameStart());

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        //
        SceneManager.LoadScene("Battle");
        
    }

    IEnumerator GameStart(){

        Kaisi.gameObject.SetActive (true);

        yield return new WaitForSeconds(2);

        Kaisi.gameObject.SetActive (false);
        P1.gameObject.SetActive (true);
        P2.gameObject.SetActive (true);

    }


}
