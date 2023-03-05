using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }
}