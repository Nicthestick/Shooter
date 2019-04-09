using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
   public void OnClickCharacterPick(int whichChar)
    {
        if (PlayerInfo.Pi != null)
        {
            PlayerInfo.Pi.mySelectedCharacter = whichChar;
            PlayerPrefs.SetInt("MyCharacter", whichChar);
        }
    }
}
