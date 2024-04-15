using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public void On2PMode(){
        SceneManager.LoadScene("2PlayerMode");
    }

    public void On3PMode(){
        SceneManager.LoadScene("3PlayerMode");
    }

    public void On4PMode(){
        SceneManager.LoadScene("4PlayerMode");
    }
   
}
