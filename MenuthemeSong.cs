using UnityEngine;

public class MenuthemeSong : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("MainMenu");
    }

    
}
