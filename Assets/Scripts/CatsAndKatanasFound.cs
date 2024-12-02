using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class CatsAndKatanasFound : MonoBehaviour
{
    public TextMeshProUGUI catsFoundCountText, katanasFoundText, samuraiCatsFoundText;
    public TextMeshProUGUI hintsText;

    public static int catsFountCount, hintsCount, hintsUsed, katanasFoundCount, samuraiCatsFoundCount;

    public int[] savedCatsFound = new int[131];
    public GameObject[] catsFound = new GameObject[131];
    public int[] savedKatanasFound = new int[10];
    public GameObject[] katanasFound = new GameObject[10];
    public int[] savedSamuraiCatsFound = new int[5];
    public GameObject[] samuraiKatsFound = new GameObject[5];

    void Start()
    {
        randomRange = 3;
        arrowSpeed = 8;
        isInWinScreen = false;

        katanasFoundCount = PlayerPrefs.GetInt("savedKatanasFound");
        samuraiCatsFoundCount = PlayerPrefs.GetInt("savedSamuraiCatsFound");
        catsFountCount = PlayerPrefs.GetInt("savedCatsFoundCount");
        hintsCount = PlayerPrefs.GetInt("savedHints");
        hintsUsed = PlayerPrefs.GetInt("savedHintsUsed");

        samuraiCatsFoundText.text = samuraiCatsFoundCount + "/5";
        katanasFoundText.text = katanasFoundCount + "/10";
        catsFoundCountText.text = catsFountCount + "/131";
        hintsText.text = hintsCount + "";

        for (int i = 0; i < 131; i++)
        {
            savedCatsFound[i] = PlayerPrefs.GetInt("savedCat" + (i + 1));

            //Debug.Log("saveCat" + (i + 1) + "=" + savedCatsFound[i]);
            if (savedCatsFound[i] == 1)
            {
                SetImageAlphaToOne(catsFound[i].GetComponent<Image>());
                SetButtonInactive(catsFound[i].GetComponent<Button>());
            }
        }

        for (int i = 0; i < 10; i++)
        {
            savedKatanasFound[i] = PlayerPrefs.GetInt("savedKatana" + (i + 1));

            //Debug.Log("saveCat" + (i + 1) + "=" + savedCatsFound[i]);
            if (savedKatanasFound[i] == 1)
            {
                SetImageAlphaToOne(katanasFound[i].GetComponent<Image>());
                SetButtonInactive(katanasFound[i].GetComponent<Button>());
            }
        }

        for (int i = 0; i < 5; i++)
        {
            savedSamuraiCatsFound[i] = PlayerPrefs.GetInt("savedSamurai" + (i + 1));

            //Debug.Log("saveCat" + (i + 1) + "=" + savedCatsFound[i]);
            if (savedSamuraiCatsFound[i] == 1)
            {
                SetImageAlphaToOne(samuraiKatsFound[i].GetComponent<Image>());
                SetButtonInactive(samuraiKatsFound[i].GetComponent<Button>());
            }
        }
    }

    #region Clicked Cats
    public void ClickCat(GameObject clickedCat)
    {
        if (Settings.isInMainMenu == false || Settings.isInSettings == false)
        {
            // Find the index of the clickedCat in the catFound array
            int catIndex = Array.IndexOf(catsFound, clickedCat);
            SetImageAlphaToOne(clickedCat.GetComponent<Image>());
            SetButtonInactive(clickedCat.GetComponent<Button>());

            // Check if the cat was found in the array
            if (catIndex != -1)
            {
                savedCatsFound[catIndex] = 1;

                PlayerPrefs.SetInt("savedCat" + (catIndex + 1), savedCatsFound[catIndex]);
                //Debug.Log("Clicked cat index: " + "savedCat" + (catIndex + 1));
            }
            else
            {
                // The clicked cat was not found in the array
                Debug.LogError("Clicked cat not found in the array");
            }

            FindObjectOfType<AudioManager>().Play("ClickCat");

            Invoke("MeowSounds", 0.2f);

            catsFountCount += 1;
            catsFoundCountText.text = catsFountCount + "/131";
            PlayerPrefs.SetInt("savedCatsFoundCount", catsFountCount);

            arrow.SetActive(false);
            hintCircle.SetActive(false);
            blockHints.SetActive(false);

            StopCoroutine();
            CheckAchievements();
            CheckWin();
        }
    }
    #endregion

    #region Click Samurai cats
    public void ClickSamurai(GameObject clickedSamurai)
    {
        if (Settings.isInMainMenu == false || Settings.isInSettings == false)
        {
            int samuraiIndex = Array.IndexOf(samuraiKatsFound, clickedSamurai);
            SetImageAlphaToOne(clickedSamurai.GetComponent<Image>());
            SetButtonInactive(clickedSamurai.GetComponent<Button>());

            // Check if the cat was found in the array
            if (samuraiIndex != -1)
            {
                savedSamuraiCatsFound[samuraiIndex] = 1;

                PlayerPrefs.SetInt("savedSamurai" + (samuraiIndex + 1), savedSamuraiCatsFound[samuraiIndex]);
                //Debug.Log("Clicked cat index: " + "savedCat" + (catIndex + 1));
            }
            else
            {
                // The clicked cat was not found in the array
                Debug.LogError("Samurai cat not found in the array");
            }

            hintsCount += 1;
            PlayerPrefs.SetInt("savedHints", hintsCount);
            hintsText.text = "" + hintsCount;

            FindObjectOfType<AudioManager>().Play("ClickCat");

            Invoke("MeowSounds", 0.2f);

            samuraiCatsFoundCount += 1;
            samuraiCatsFoundText.text = samuraiCatsFoundCount + "/5";
            PlayerPrefs.SetInt("savedSamuraiCatsFound", samuraiCatsFoundCount);

            arrow.SetActive(false);
            hintCircle.SetActive(false);
            blockHints.SetActive(false);

            StopCoroutine();
            CheckAchievements();
            CheckWin();
        }
    }
    #endregion

    #region Click Katana
    public void ClickKatanas(GameObject clickedKatana)
    {
        if (Settings.isInMainMenu == false || Settings.isInSettings == false)
        {
            int katanaIndex = Array.IndexOf(katanasFound, clickedKatana);
            SetImageAlphaToOne(clickedKatana.GetComponent<Image>());
            SetButtonInactive(clickedKatana.GetComponent<Button>());

            // Check if the cat was found in the array
            if (katanaIndex != -1)
            {
                savedKatanasFound[katanaIndex] = 1;

                PlayerPrefs.SetInt("savedKatana" + (katanaIndex + 1), savedKatanasFound[katanaIndex]);
                //Debug.Log("Clicked cat index: " + "savedCat" + (catIndex + 1));
            }
            else
            {
                // The clicked cat was not found in the array
                Debug.LogError("Katana not found in the array");
            }

            hintsCount += 1;
            PlayerPrefs.SetInt("savedHints", hintsCount);
            hintsText.text = "" + hintsCount;

            FindObjectOfType<AudioManager>().Play("Katana");

            katanasFoundCount += 1;
            katanasFoundText.text = katanasFoundCount + "/10";
            PlayerPrefs.SetInt("savedKatanasFound", katanasFoundCount);

            arrow.SetActive(false);
            hintCircle.SetActive(false);
            blockHints.SetActive(false);

            StopCoroutine();
            CheckAchievements();
            CheckWin();
        }
    }
    #endregion

    public void StopCoroutine()
    {
        if (moveArrowCourine != null) { StopCoroutine(moveArrowCourine); moveArrowCourine = null; }
        if (waitCircleCoroutine != null) { StopCoroutine(waitCircleCoroutine); waitCircleCoroutine = null; }

        arrow.SetActive(false);
        hintCircle.SetActive(false);
        blockHints.SetActive(false);
    }

    public void SetImageAlphaToOne(Image image)
    {
        Color currentColor = image.color;
        currentColor.a = 1f;
        image.color = currentColor;
    }

    public void SetButtonInactive(Button button)
    {
        button.interactable = false;
    }

    public int meowNumber;
    public void MeowSounds()
    {
        int random;

        do
        {
            random = UnityEngine.Random.Range(1, 11);
            if(random == meowNumber) {  }

        } while (random == meowNumber);

        meowNumber = random;
        //Debug.Log(meowNumber);
        if (random == 1) { FindObjectOfType<AudioManager>().Play("Meow1"); meowNumber = random; }
        if (random == 2) { FindObjectOfType<AudioManager>().Play("Meow2"); meowNumber = random; }
        if (random == 3) { FindObjectOfType<AudioManager>().Play("Meow3"); meowNumber = random; }
        if (random == 4) { FindObjectOfType<AudioManager>().Play("Meow4"); meowNumber = random; }
        if (random == 5) { FindObjectOfType<AudioManager>().Play("Meow5"); meowNumber = random; }
        if (random == 6) { FindObjectOfType<AudioManager>().Play("Meow7"); meowNumber = random; }
        if (random == 7) { FindObjectOfType<AudioManager>().Play("Meow8"); meowNumber = random; }
        if (random == 8) { FindObjectOfType<AudioManager>().Play("Meow9"); meowNumber = random; }
        if (random == 9) { FindObjectOfType<AudioManager>().Play("Meow10"); meowNumber = random; }
        if (random == 10) { FindObjectOfType<AudioManager>().Play("Meow11"); meowNumber = random; }
    }

    #region Hints
    //Hints
    public GameObject hintCircle;
    public GameObject blockHints;
    public GameObject arrow;
    public float arrowSpeed = 3f;
    public Transform arrowSpawnPoint;
    public float randomRange;
    public bool noMoreCats, noMoreSamurai;
    public void useHint()
    {
        if (hintsCount == 0) { FindObjectOfType<AudioManager>().Play("NoHints"); }

        if (hintsCount > 0)
        {
            hintsUsed += 1;
            PlayerPrefs.SetInt("savedHintsUsed", hintsUsed);
            FindObjectOfType<AudioManager>().Play("Click");
            hintsCount -= 1;
            hintsText.text = "" + hintsCount;
            PlayerPrefs.SetInt("savedHints", hintsCount);
            blockHints.SetActive(true);
            List<int> inactiveIndices = new List<int>();

            for (int i = 0; i < catsFound.Length; i++)
            {
                Image catImage = catsFound[i].GetComponent<Image>();
                if (catImage != null && catImage.color.a == 0f)
                {
                    inactiveIndices.Add(i);
                    noMoreCats = false;
                }
            }

            if (inactiveIndices.Count == 0)
            {
                for (int i = 0; i < samuraiKatsFound.Length; i++)
                {
                    Image catImage = samuraiKatsFound[i].GetComponent<Image>();
                    if (catImage != null && catImage.color.a == 0f)
                    {
                        inactiveIndices.Add(i);
                        noMoreCats = true;
                    }
                }
            }


            if (inactiveIndices.Count == 0)
            {

                for (int i = 0; i < katanasFound.Length; i++)
                {
                    Image katanaImage = katanasFound[i].GetComponent<Image>();
                    if (katanaImage != null && katanaImage.color.a == 0f)
                    {
                        inactiveIndices.Add(i);
                        noMoreCats = false;
                        noMoreSamurai = true;
                    }
                }
            }

            if (inactiveIndices.Count == 0)
            {
                return;
            }

            int randomIndex = inactiveIndices[UnityEngine.Random.Range(0, inactiveIndices.Count)];
            if (noMoreCats == false)
            {
                Vector3 position = catsFound[randomIndex].transform.position;
                position.x += UnityEngine.Random.Range(-randomRange, randomRange);
                position.y += UnityEngine.Random.Range(-randomRange, randomRange);

                hintCircle.transform.position = position;
            }

            if (noMoreCats == true)
            {
                Vector3 position = samuraiKatsFound[randomIndex].transform.position;
                position.x += UnityEngine.Random.Range(-randomRange, randomRange);
                position.y += UnityEngine.Random.Range(-randomRange, randomRange);

                hintCircle.transform.position = position;
            }

            if (noMoreSamurai == true)
            {
                Vector3 position = katanasFound[randomIndex].transform.position;
                position.x += UnityEngine.Random.Range(-randomRange, randomRange);
                position.y += UnityEngine.Random.Range(-randomRange, randomRange);

                hintCircle.transform.position = position;
            }

            hintCircle.SetActive(true);
            //Debug.Log(hintCircle.activeInHierarchy);

            // Set arrow active and move it towards hintCircle
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(3f, -3f, 0f);
            mousePos.z = 0f;
            arrow.transform.position = mousePos;

            Vector3 direction = hintCircle.transform.position - arrow.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            arrow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            arrow.SetActive(true);
            moveArrowCourine = StartCoroutine(MoveArrow(arrow, hintCircle.transform.position));

            waitCircleCoroutine = StartCoroutine(waitCircle());
        }

    }

    public Coroutine waitCircleCoroutine, moveArrowCourine;
    IEnumerator waitCircle()
    {
        yield return new WaitForSeconds(12);
        blockHints.SetActive(false);
        hintCircle.SetActive(false);
        arrow.SetActive(false);
    }

    IEnumerator MoveArrow(GameObject arrow, Vector3 targetPos)
    {
        while (Vector3.Distance(arrow.transform.position, targetPos) > 1.3f)
        {
            arrow.transform.position = Vector3.MoveTowards(arrow.transform.position, targetPos, arrowSpeed * Time.deltaTime);
            yield return null;
        }

        // Set arrow inactive when it reaches the hintCircle
        arrow.SetActive(false);
    }
    #endregion

    public Achievements achScripts;
    public void CheckAchievements()
    {
        achScripts.CheckAchievements();
    }

    public void ResetGame()
    {
        hintsUsed = 0;
        catsFountCount = 0;
        hintsCount = 0;
        katanasFoundCount = 0;
        samuraiCatsFoundCount = 0;
        hintsText.text = "" + hintsCount;
        catsFoundCountText.text = catsFountCount + "/131";
        katanasFoundText.text = katanasFoundCount + "/10";
        samuraiCatsFoundText.text = samuraiCatsFoundCount + "/5";

        PlayerPrefs.SetInt("savedCatsFoundCount", catsFountCount);
        PlayerPrefs.SetInt("savedHintsUsed", hintsUsed);
        PlayerPrefs.SetInt("savedSamuraiCatsFound", samuraiCatsFoundCount);
        PlayerPrefs.SetInt("savedHints", hintsCount);
        PlayerPrefs.SetInt("savedKatanasFound", katanasFoundCount);

        for (int i = 0; i < catsFound.Length; i++)
        {
            Image catImage = catsFound[i].GetComponent<Image>();
            SetAlphaTo0(catImage);
            SetButtonActive(catImage.gameObject.GetComponent<Button>());
        }

        for (int i = 0; i < katanasFound.Length; i++)
        {
            Image katanaImage = katanasFound[i].GetComponent<Image>();
            SetAlphaTo0(katanaImage);
            SetButtonActive(katanaImage.gameObject.GetComponent<Button>());
        }

        for (int i = 0; i < samuraiKatsFound.Length; i++)
        {
            Image samuraiImage = samuraiKatsFound[i].GetComponent<Image>();
            SetAlphaTo0(samuraiImage);
            SetButtonActive(samuraiImage.gameObject.GetComponent<Button>());
        }

        for (int i = 0; i < 131; i++)
        {
            savedCatsFound[i] = 0;

            PlayerPrefs.SetInt("savedCat" + (i + 1), savedCatsFound[i]);
            //Debug.Log("saveCat " + (i + 1));
        }

        for (int i = 0; i < 10; i++)
        {
            savedKatanasFound[i] = 0;

            PlayerPrefs.SetInt("savedKatana" + (i + 1), savedKatanasFound[i]);
        }

        for (int i = 0; i < 5; i++)
        {
            savedSamuraiCatsFound[i] = 0;

            PlayerPrefs.SetInt("savedSamurai" + (i + 1), savedSamuraiCatsFound[i]);
        }
    }

    public void SetAlphaTo0(Image image)
    {
        Color currentColor = image.color;
        currentColor.a = 0f;
        image.color = currentColor;
    }

    public void SetButtonActive(Button button)
    {
        button.interactable = true;
    }

    public GameObject winScreen, winSCreenUIElements;

    #region Win
    public void CheckWin()
    {
        if (catsFountCount > 130 && katanasFoundCount > 9 && samuraiCatsFoundCount > 4)
        {
            StartCoroutine(WinAnim());
        }
    }

    public static bool isInWinScreen;
    IEnumerator WinAnim()
    {
        isInWinScreen = true;
        FindObjectOfType<AudioManager>().Play("win1");
        yield return new WaitForSeconds(1f);
        winScreen.SetActive(true);
        winScreen.GetComponent<Animation>().Play("winAnim");
        FindObjectOfType<AudioManager>().Play("win2");
        yield return new WaitForSeconds(0.333f);
        winSCreenUIElements.SetActive(true);
        winScreen.GetComponent<Animation>().Play("winWave");
    }

    public void CloseWin()
    {
        isInWinScreen = false;
        FindObjectOfType<AudioManager>().Play("Click");
        winScreen.SetActive(false);
        winSCreenUIElements.SetActive(false);
    }
    #endregion

    public void Temp()
    {
        /*
        #region Res Stuff
        if ((Screen.width == 1920 && Screen.height == 1080) || (Screen.width == 2560 && Screen.height == 1440) || (Screen.width == 1366 && Screen.height == 768) || (Screen.width == 3840 && Screen.height == 2160) || (Screen.width == 2560 && Screen.height == 1600))
        {
            is1920 = true; cam.orthographicSize = 31f; maxCamSize = 31f;
        }
        else
        {
            is1920 = false; cam.orthographicSize = 22.2f; maxCamSize = 22.2f;
        }
        #endregion




        #region Res Stuff
        if (Settings.changeRes == true)
        {
            cam.transform.position = new Vector3(0, 0, -10f);
            cam.transform.localScale = new Vector3();
            //textTesting.text = Settings.width + " + " + Settings.height;

            if (is1920 == false)
            {
                if (Settings.width == 2560 && Settings.height == 1080)
                {
                    maxCamSize = 25f;
                }
                else if (Settings.width == 2560 && Settings.height == 1440)
                {
                    maxCamSize = 25f;
                }
                else if (Settings.width == 2560 && Settings.height == 1600)
                {
                    maxCamSize = 32f;
                }
                else if (Settings.width == 3840 && Settings.height == 1440)
                {
                    maxCamSize = 22.2f;
                }
                else if (Settings.width == 3840 && Settings.height == 2160)
                {
                    maxCamSize = 32f;
                }
                else if (Settings.width == 3840 && Settings.height == 2400)
                {
                    maxCamSize = 32f;
                }
                else if (Settings.width == 3440 && Settings.height == 1440)
                {
                    maxCamSize = 24.4f;
                }
                else
                {
                    maxCamSize = 32f;
                }

                cam.orthographicSize = 16f;
            }
            else
            {
                if (Settings.width == 2560 && Settings.height == 1080)// not 1920
                {
                    maxCamSize = 25f; cam.orthographicSize = 25f;
                }
                else if (Settings.width == 2560 && Settings.height == 1440)
                {
                    maxCamSize = 25f; cam.orthographicSize = 25f;
                }
                else if (Settings.width == 2560 && Settings.height == 1600)
                {
                    maxCamSize = 25f; cam.orthographicSize = 25f;
                }
                else if (Settings.width == 3840 && Settings.height == 1440)// not 1920
                {
                    maxCamSize = 16f; cam.orthographicSize = 16f;
                }
                else if (Settings.width == 3840 && Settings.height == 2160)
                {
                    maxCamSize = 16f; cam.orthographicSize = 16f;
                }
                else if (Settings.width == 3840 && Settings.height == 2400)
                {
                    maxCamSize = 16f; cam.orthographicSize = 16f;
                }
                else if (Settings.width == 3440 && Settings.height == 1440)// not 1920
                {
                    maxCamSize = 16f; cam.orthographicSize = 16f;
                }
                else
                {
                    maxCamSize = 32f; cam.orthographicSize = 32f;
                }
            }
            Settings.changeRes = false;
        }
        #endregion
        */


    }
}
