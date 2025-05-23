using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;


// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;
    
    

    public void NewColorSelected(Color color)
    {
        MainManager.Instance.teamColor = color;
            
        Debug.Log("color Set");
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;

        ColorPicker.SelectColor(MainManager.Instance.teamColor);
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

   
    public void QuitGame()
    {
        MainManager.Instance.SaveColor(); 
        if(EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
            Application.Quit();
        }
        
    }

    public void SaveColorClicked()
    {
        MainManager.Instance.SaveColor();
    }

    public void LoadColorClicked()
    {
        MainManager.Instance.LoadColor();
        ColorPicker.SelectColor(MainManager.Instance.teamColor);
    }
    


}
