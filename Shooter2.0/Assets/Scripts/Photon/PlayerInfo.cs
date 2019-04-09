using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{

    public static PlayerInfo Pi;
    public int mySelectedCharacter;
    public GameObject[] allChar;

    private void OnEnable()
    {
        if (PlayerInfo.Pi == null)
        {
            PlayerInfo.Pi = this;
        } else
        {
            if(PlayerInfo.Pi != this)
            {
                Destroy(PlayerInfo.Pi.gameObject);
                PlayerInfo.Pi = this;
            }
        }

        DontDestroyOnLoad(this.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("MyCharacter"))
        {
            mySelectedCharacter = PlayerPrefs.GetInt("MyCharacter");

        }
        else
        {
            mySelectedCharacter = 0;
            PlayerPrefs.SetInt("MyCharacter", mySelectedCharacter);
        }
    }

}
