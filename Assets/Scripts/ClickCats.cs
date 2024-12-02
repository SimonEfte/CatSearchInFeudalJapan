using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCats : MonoBehaviour
{
    public void ClickCat()
    {
        if (Settings.isInMainMenu == false || Settings.isInSettings == false)
        {
            CatsAndKatanasFound catsFoundScript = GetComponent<CatsAndKatanasFound>();

            if (catsFoundScript != null)
            {
                // Find the index of the current GameObject in the array
                int index = System.Array.IndexOf(catsFoundScript.catsFound, gameObject);

                if (index != -1)
                {
                    Debug.Log("Index of this GameObject: " + index);
                }
                else
                {
                    Debug.LogError("This GameObject is not in the array!");
                }
            }
            else
            {
                Debug.LogError("YourOtherScript is not found on the cat GameObject!");
            }
        }
    }
}
