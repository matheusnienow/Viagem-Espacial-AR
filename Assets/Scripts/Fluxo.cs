using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fluxo : MonoBehaviour
{

    public void CarregarSistemaSolar()
    {
        Debug.Log("CarregarSistemaSolar");
        SceneManager.LoadScene("_SolarSystem");
    }

    public void CarregarFasesDaLua()
    {
        Debug.Log("CarregarFasesDaLua");
        SceneManager.LoadScene("_MoonPhases");
    }
}
