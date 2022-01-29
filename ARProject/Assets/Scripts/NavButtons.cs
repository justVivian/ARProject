using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class NavButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnPointerUp(PointerEventData eventData){
        Debug.Log("CALLED");
    }

    public void ExitButton(){
        Application.Quit();
        Debug.Log("Game Close");
    }

    public void BackButton(){
        SceneManager.LoadScene("MainMenu");
    }
}
