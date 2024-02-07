using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonsScript : MonoBehaviour
{
    public void ButtonPlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
