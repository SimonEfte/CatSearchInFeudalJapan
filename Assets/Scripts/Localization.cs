using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class Localization : MonoBehaviour
{
    public TextMeshProUGUI UI_START, UI_RESET, UI_RESET_SETTINGS, UI_WISHTORESET, UI_OPTIONS, UI_OPTIONSETTINGS, UI_EXIT, UI_EXITOPTIONS, UI_FULLSCREEN, UI_ON, UI_OFF, UI_F_ON, UI_F_OFF, UI_RESET_NO, UI_RESET_YES, UI_UI, UI_CONGRATS, UI_COMPLETION;
    public TextMeshProUGUI UI_THANKSOFRPLAYING, UI_MAINMENU;

    public TMP_FontAsset englishFontChangaOutline, englishFontChanga, japaneseFont, koreanFont, chineseFont;

    public int language;
    public TMP_Dropdown languageDropdown;

    void Start()
    {
        languageDropdown.onValueChanged.AddListener(OnLanguageDropdownChange);

        if (PlayerPrefs.HasKey("languageSelect"))
        {
            language = PlayerPrefs.GetInt("languageSelect");
        }

        if (language == 1) { EnglishLanguage(); languageDropdown.value = 0; }
        if (language == 2) { RussianLanguage(); languageDropdown.value = 1; }
        if (language == 3) { JapaneseLanguage(); languageDropdown.value = 2; }
        if (language == 4) { KoreanLanguage(); languageDropdown.value = 3; }
        if (language == 5) { SimplifiedChineseLanguage(); languageDropdown.value = 4; }
        if (language == 6) { GermanLanguage(); languageDropdown.value = 5; }
        if (language == 7) { FrenchLanguage(); languageDropdown.value = 6; }
        if (language == 8) { SpanishLanguage(); languageDropdown.value = 7; }
        if (language == 9) { PortugueseLanguage(); languageDropdown.value = 8; }
        if (language == 10) { PolishLanguage(); languageDropdown.value = 9; }
        if (language == 11) { ItalianLanguage(); languageDropdown.value = 10; }
        if (language == 12) { TurkishLanguage(); languageDropdown.value = 11; }


        if (!PlayerPrefs.HasKey("languageSelect"))
        {
            // Determine the user's culture
            CultureInfo userCulture = CultureInfo.CurrentCulture;
            RegionInfo region = new RegionInfo(userCulture.Name);

            // Use the region name to set the language
            string regionName = region.Name;

            // Set language based on region
            SetLanguageByRegion(regionName);
        }
    }

    private void OnLanguageDropdownChange(int index)
    {
        // Determine the selected language based on the index
        string selectedLanguage = GetLanguageByIndex(index);

        // Call the corresponding method for the selected language
        SetLanguage(selectedLanguage);
    }

    #region Set language by region
    void SetLanguageByRegion(string regionName)
    {
        switch (regionName)
        {
            case "US":
            case "CA":
                SetLanguage("English"); languageDropdown.value = 0;
                break;
            case "RU":
                SetLanguage("Russian"); languageDropdown.value = 1;
                break;
            case "JP":
                SetLanguage("Japanese"); languageDropdown.value = 2;
                break;
            case "KR":
                SetLanguage("Korean"); languageDropdown.value = 3;
                break;
            case "CN":
                SetLanguage("Simplified Chinese"); languageDropdown.value = 4;
                break;
            case "DE":
                SetLanguage("German"); languageDropdown.value = 5;
                break;
            case "FR":
                SetLanguage("French"); languageDropdown.value = 6;
                break;
            case "ES":
                SetLanguage("Spanish - Spain"); languageDropdown.value = 7;
                break;
            case "BR":
                SetLanguage("Portuguese - Brazil"); languageDropdown.value = 8;
                break;
            case "PL":
                SetLanguage("Polish"); languageDropdown.value = 9;
                break;
            case "IT":
                SetLanguage("Italian"); languageDropdown.value = 10;
                break;
            case "TR":
                SetLanguage("Turkish"); languageDropdown.value = 11;
                break;
            // Add more cases for other regions as needed

            default:
                // Set a default language if none of the cases match
                SetLanguage("English"); languageDropdown.value = 0;
                break;
        }
    }
    #endregion

    private void SetLanguage(string language)
    {
        // Implement your logic to set the language here
        // You can have separate methods for each language setting
        switch (language)
        {
            case "English":
                EnglishLanguage(); 
                break;
            case "Russian":
                RussianLanguage(); 
                break;
            case "Japanese":
                JapaneseLanguage();
                break;
            case "Korean":
                KoreanLanguage();
                break;
            case "Simplified Chinese":
                SimplifiedChineseLanguage();
                break;
            case "German":
                GermanLanguage();
                break;
            case "French":
                FrenchLanguage();
                break;
            case "Spanish - Spain":
                SpanishLanguage();
                break;
            case "Portuguese - Brazil":
                PortugueseLanguage();
                break;
            case "Polish":
                PolishLanguage();
                break;
            case "Italian":
                ItalianLanguage();
                break;
            case "Turkish":
                TurkishLanguage();
                break;
            default:
                break;
        }
    }

    private string GetLanguageByIndex(int index)
    {
        string[] languages = { "English", "Russian", "Japanese", "Korean", "Simplified Chinese", "German", "French", "Spanish - Spain", "Portuguese - Brazil", "Polish", "Italian", "Turkish" };
        return languages[index];
    }

    //1
    #region english
    public void EnglishLanguage()
    {
        language = 1;
        PlayerPrefs.SetInt("languageSelect", language);

        //Start screen
        UI_START.text = "PLAY"; UI_START.fontSize = 37; UI_START.font = englishFontChangaOutline;
        UI_RESET.text = "RESET"; UI_RESET.fontSize = 37; UI_RESET.font = englishFontChangaOutline;
        UI_OPTIONS.text = "SETTINGS"; UI_OPTIONS.fontSize = 37; UI_OPTIONS.font = englishFontChangaOutline;
        UI_EXIT.text = "EXIT"; UI_EXIT.fontSize = 37; UI_EXIT.font = englishFontChangaOutline;

        //Inside Options
        UI_MAINMENU.text = "MAIN MENU"; UI_MAINMENU.fontSize = 40; UI_MAINMENU.font = englishFontChangaOutline;
        UI_OPTIONSETTINGS.text = "SETTINGS"; UI_OPTIONSETTINGS.fontSize = 36; UI_OPTIONSETTINGS.font = englishFontChanga;
        UI_FULLSCREEN.text = "FULLSCREEN"; UI_FULLSCREEN.fontSize = 24; UI_FULLSCREEN.font = englishFontChanga;
        UI_RESET_SETTINGS.text = "RESET"; UI_RESET_SETTINGS.fontSize = 40; UI_RESET_SETTINGS.font = englishFontChanga;
        UI_EXITOPTIONS.text = "EXIT GAME"; UI_EXITOPTIONS.fontSize = 45; UI_EXITOPTIONS.font = englishFontChanga;
        UI_UI.text = "SHOW UI"; UI_UI.fontSize = 45; UI_UI.font = englishFontChanga;
        UI_ON.text = "ON"; UI_ON.fontSize = 32; UI_ON.font = englishFontChanga;
        UI_OFF.text = "OFF"; UI_OFF.fontSize = 32; UI_OFF.font = englishFontChanga;
        UI_F_ON.text = "ON"; UI_F_ON.fontSize = 32; UI_F_ON.font = englishFontChanga;
        UI_F_OFF.text = "OFF"; UI_F_OFF.fontSize = 32; UI_F_OFF.font = englishFontChanga;

        //WishToReset?
        UI_WISHTORESET.text = "RESET?"; UI_WISHTORESET.fontSize = 45; UI_WISHTORESET.font = englishFontChanga;
        UI_RESET_NO.text = "NO"; UI_RESET_NO.fontSize = 35; UI_RESET_NO.font = englishFontChanga;
        UI_RESET_YES.text = "YES"; UI_RESET_YES.fontSize = 35; UI_RESET_YES.font = englishFontChanga;

        //100%Completion
        UI_CONGRATS.text = "CONGRATS"; UI_CONGRATS.fontSize = 35; UI_CONGRATS.font = englishFontChanga;
        UI_COMPLETION.text = "100% COMPLETION"; UI_COMPLETION.fontSize = 16; UI_COMPLETION.font = englishFontChanga;
        UI_THANKSOFRPLAYING.text = "THANKS FOR PLAYING!"; UI_THANKSOFRPLAYING.fontSize = 15; UI_THANKSOFRPLAYING.font = englishFontChanga;
    }
    #endregion

    //2
    #region russian
    public void RussianLanguage()
    {
        language = 2;
        PlayerPrefs.SetInt("languageSelect", language);

        //Start screen
        UI_START.text = "НАЧАЛО"; UI_START.fontSize = 28; UI_START.font = chineseFont;
        UI_RESET.text = "СБРОС"; UI_RESET.fontSize = 28; UI_RESET.font = chineseFont;
        UI_OPTIONS.text = "ОПЦИИ"; UI_OPTIONS.fontSize = 28; UI_OPTIONS.font = chineseFont;
        UI_EXIT.text = "ПОКИДАТЬ"; UI_EXIT.fontSize = 28; UI_EXIT.font = chineseFont;

        //Inside Options
        UI_MAINMENU.text = "Главное меню"; UI_MAINMENU.fontSize = 29; UI_MAINMENU.font = chineseFont;
        UI_OPTIONSETTINGS.text = "ПАРАМЕТРЫ"; UI_OPTIONSETTINGS.fontSize = 36; UI_OPTIONSETTINGS.font = chineseFont;
        UI_FULLSCREEN.text = "ПОЛНОЭКРАННЫЙ РЕЖИМ"; UI_FULLSCREEN.fontSize = 15; UI_FULLSCREEN.font = chineseFont;
        UI_RESET_SETTINGS.text = "ПАРАМЕТРЫ"; UI_RESET_SETTINGS.fontSize = 40; UI_RESET_SETTINGS.font = chineseFont;
        UI_EXITOPTIONS.text = "ВЫХОД"; UI_EXITOPTIONS.fontSize = 45; UI_EXITOPTIONS.font = chineseFont;
        UI_UI.text = "ИНТЕРФЕЙС"; UI_UI.fontSize = 22; UI_UI.font = chineseFont;
        UI_ON.text = "НА"; UI_ON.fontSize = 32; UI_ON.font = chineseFont;
        UI_OFF.text = "ОТ"; UI_OFF.fontSize = 22; UI_OFF.font = chineseFont;
        UI_F_ON.text = "НА"; UI_F_ON.fontSize = 32; UI_F_ON.font = chineseFont;
        UI_F_OFF.text = "ОТ"; UI_F_OFF.fontSize = 22; UI_F_OFF.font = chineseFont;

        //WishToReset?
        UI_WISHTORESET.text = "СБРОСИТЬ?"; UI_WISHTORESET.fontSize = 35; UI_WISHTORESET.font = chineseFont;
        UI_RESET_NO.text = "НЕТ"; UI_RESET_NO.fontSize = 35; UI_RESET_NO.font = chineseFont;
        UI_RESET_YES.text = "ДА"; UI_RESET_YES.fontSize = 35; UI_RESET_YES.font = chineseFont;

        //100%Completion
        UI_CONGRATS.text = "поздравляю!"; UI_CONGRATS.fontSize = 25; UI_CONGRATS.font = chineseFont;
        UI_COMPLETION.text = "100% ЗАВЕРШЕНИЕ!"; UI_COMPLETION.fontSize = 16; UI_COMPLETION.font = chineseFont;
        UI_THANKSOFRPLAYING.text = "СПАСИБО ЗА ИГРУ"; UI_THANKSOFRPLAYING.fontSize = 15; UI_THANKSOFRPLAYING.font = chineseFont;
    }
    #endregion

    //3
    #region japanese
    public void JapaneseLanguage()
    {
        language = 3;
        PlayerPrefs.SetInt("languageSelect", language);
        //Start screen
        UI_START.text = "スタート"; UI_START.fontSize = 28; UI_START.font = japaneseFont;
        UI_RESET.text = "リセット"; UI_RESET.fontSize = 28; UI_RESET.font = japaneseFont;
        UI_OPTIONS.text = "設定"; UI_OPTIONS.fontSize = 28; UI_OPTIONS.font = japaneseFont;
        UI_EXIT.text = "終了"; UI_EXIT.fontSize = 28; UI_EXIT.font = japaneseFont;

        //Inside Options
        UI_MAINMENU.text = "メインメニュー"; UI_MAINMENU.fontSize = 40; UI_MAINMENU.font = japaneseFont;
        UI_OPTIONSETTINGS.text = "オプション"; UI_OPTIONSETTINGS.fontSize = 36; UI_OPTIONSETTINGS.font = japaneseFont;
        UI_FULLSCREEN.text = "フルスクリーン"; UI_FULLSCREEN.fontSize = 19; UI_FULLSCREEN.font = japaneseFont;
        UI_RESET_SETTINGS.text = "設定"; UI_RESET_SETTINGS.fontSize = 40; UI_RESET_SETTINGS.font = japaneseFont;
        UI_EXITOPTIONS.text = "終了"; UI_EXITOPTIONS.fontSize = 45; UI_EXITOPTIONS.font = japaneseFont;
        UI_UI.text = "UI"; UI_UI.fontSize = 45; UI_UI.font = japaneseFont;
        UI_ON.text = "オン"; UI_ON.fontSize = 28; UI_ON.font = japaneseFont;
        UI_OFF.text = "オフ"; UI_OFF.fontSize = 28; UI_OFF.font = japaneseFont;
        UI_F_ON.text = "オン"; UI_F_ON.fontSize = 28; UI_F_ON.font = japaneseFont;
        UI_F_OFF.text = "オフ"; UI_F_OFF.fontSize = 28; UI_F_OFF.font = japaneseFont;

        //WishToReset?
        UI_WISHTORESET.text = "リセット？"; UI_WISHTORESET.fontSize = 25; UI_WISHTORESET.font = japaneseFont;
        UI_RESET_NO.text = "いいえ"; UI_RESET_NO.fontSize = 28; UI_RESET_NO.font = japaneseFont;
        UI_RESET_YES.text = "はい"; UI_RESET_YES.fontSize = 35; UI_RESET_YES.font = japaneseFont;

        //100%Completion
        UI_CONGRATS.text = "おめでとう！"; UI_CONGRATS.fontSize = 20; UI_CONGRATS.font = japaneseFont;
        UI_COMPLETION.text = "100％完成！"; UI_COMPLETION.fontSize = 16; UI_COMPLETION.font = japaneseFont;
        UI_THANKSOFRPLAYING.text = "遊んでくれてありがとう！"; UI_THANKSOFRPLAYING.fontSize = 10; UI_THANKSOFRPLAYING.font = japaneseFont;
    }
    #endregion

    //4
    #region korean
    public void KoreanLanguage()
    {
        language = 4;
        PlayerPrefs.SetInt("languageSelect", language);

        //Start screen
        UI_START.text = "시작"; UI_START.fontSize = 28; UI_START.font = koreanFont;
        UI_RESET.text = "재설정"; UI_RESET.fontSize = 28; UI_RESET.font = koreanFont;
        UI_OPTIONS.text = "설정"; UI_OPTIONS.fontSize = 28; UI_OPTIONS.font = koreanFont;
        UI_EXIT.text = "종료"; UI_EXIT.fontSize = 28; UI_EXIT.font = koreanFont;

        //Inside Options
        UI_MAINMENU.text = "메인"; UI_MAINMENU.fontSize = 40; UI_MAINMENU.font = koreanFont;
        UI_OPTIONSETTINGS.text = "설정"; UI_OPTIONSETTINGS.fontSize = 36; UI_OPTIONSETTINGS.font = koreanFont;
        UI_FULLSCREEN.text = "전체 화면"; UI_FULLSCREEN.fontSize = 24; UI_FULLSCREEN.font = koreanFont;
        UI_RESET_SETTINGS.text = "재설정"; UI_RESET_SETTINGS.fontSize = 40; UI_RESET_SETTINGS.font = koreanFont;
        UI_EXITOPTIONS.text = "종료"; UI_EXITOPTIONS.fontSize = 45; UI_EXITOPTIONS.font = koreanFont;
        UI_UI.text = "UI"; UI_UI.fontSize = 45; UI_UI.font = koreanFont;
        UI_ON.text = "시작"; UI_ON.fontSize = 32; UI_ON.font = koreanFont;
        UI_OFF.text = "꺼짐"; UI_OFF.fontSize = 32; UI_OFF.font = koreanFont;
        UI_F_ON.text = "시작"; UI_F_ON.fontSize = 32; UI_F_ON.font = koreanFont;
        UI_F_OFF.text = "꺼짐"; UI_F_OFF.fontSize = 32; UI_F_OFF.font = koreanFont;

        //WishToReset?
        UI_WISHTORESET.text = "재설정 하시겠습니까?"; UI_WISHTORESET.fontSize = 27; UI_WISHTORESET.font = koreanFont;
        UI_RESET_NO.text = "아니요"; UI_RESET_NO.fontSize = 25; UI_RESET_NO.font = koreanFont;
        UI_RESET_YES.text = "예"; UI_RESET_YES.fontSize = 35; UI_RESET_YES.font = koreanFont;

        //100%Completion
        UI_CONGRATS.text = "축하해!"; UI_CONGRATS.fontSize = 30; UI_CONGRATS.font = koreanFont;
        UI_COMPLETION.text = "100%!"; UI_COMPLETION.fontSize = 16; UI_COMPLETION.font = koreanFont;
        UI_THANKSOFRPLAYING.text = "재생 주셔서 감사합니다"; UI_THANKSOFRPLAYING.fontSize = 11; UI_THANKSOFRPLAYING.font = koreanFont;
    }
    #endregion

    //5
    #region simplified_chinese
    public void SimplifiedChineseLanguage()
    {
        language = 5;
        PlayerPrefs.SetInt("languageSelect", language);

        //Start screen
        UI_START.text = "开始"; UI_START.fontSize = 28; UI_START.font = chineseFont;
        UI_RESET.text = "重置"; UI_RESET.fontSize = 28; UI_RESET.font = chineseFont;
        UI_OPTIONS.text = "设置"; UI_OPTIONS.fontSize = 28; UI_OPTIONS.font = chineseFont;
        UI_EXIT.text = "退出"; UI_EXIT.fontSize = 28; UI_EXIT.font = chineseFont;

        //Inside Options
        UI_MAINMENU.text = "主菜单"; UI_MAINMENU.fontSize = 40; UI_MAINMENU.font = chineseFont;
        UI_OPTIONSETTINGS.text = "设置"; UI_OPTIONSETTINGS.fontSize = 36; UI_OPTIONSETTINGS.font = chineseFont;
        UI_FULLSCREEN.text = "全屏"; UI_FULLSCREEN.fontSize = 24; UI_FULLSCREEN.font = chineseFont;
        UI_RESET_SETTINGS.text = "重置"; UI_RESET_SETTINGS.fontSize = 40; UI_RESET_SETTINGS.font = chineseFont;
        UI_EXITOPTIONS.text = "退出"; UI_EXITOPTIONS.fontSize = 45; UI_EXITOPTIONS.font = chineseFont;
        UI_UI.text = "界面"; UI_UI.fontSize = 45; UI_UI.font = chineseFont;
        UI_ON.text = "上"; UI_ON.fontSize = 32; UI_ON.font = chineseFont;
        UI_OFF.text = "关"; UI_OFF.fontSize = 32; UI_OFF.font = chineseFont;
        UI_F_ON.text = "上"; UI_F_ON.fontSize = 32; UI_F_ON.font = chineseFont;
        UI_F_OFF.text = "关"; UI_F_OFF.fontSize = 32; UI_F_OFF.font = chineseFont;

        //WishToReset?
        UI_WISHTORESET.text = "重置？"; UI_WISHTORESET.fontSize = 45; UI_WISHTORESET.font = chineseFont;
        UI_RESET_NO.text = "否"; UI_RESET_NO.fontSize = 35; UI_RESET_NO.font = chineseFont;
        UI_RESET_YES.text = "是"; UI_RESET_YES.fontSize = 35; UI_RESET_YES.font = chineseFont;

        //100%Completion
        UI_CONGRATS.text = "   恭喜！"; UI_CONGRATS.fontSize = 29; UI_CONGRATS.font = chineseFont;
        UI_COMPLETION.text = "100%完成！"; UI_COMPLETION.fontSize = 16; UI_COMPLETION.font = chineseFont;
        UI_THANKSOFRPLAYING.text = "谢谢你的演奏"; UI_THANKSOFRPLAYING.fontSize = 15; UI_THANKSOFRPLAYING.font = chineseFont;
    }
    #endregion

    //6
    #region german
    public void GermanLanguage()
    {
        language = 6;
        PlayerPrefs.SetInt("languageSelect", language);

        //Start screen
        UI_START.text = "BEGINNEN"; UI_START.fontSize = 28; UI_START.font = koreanFont;
        UI_RESET.text = "ZURÜCKSETZEN"; UI_RESET.fontSize = 28; UI_RESET.font = koreanFont;
        UI_OPTIONS.text = "EINSTELLUNG"; UI_OPTIONS.fontSize = 28; UI_OPTIONS.font = koreanFont;
        UI_EXIT.text = "AUSFAHRT"; UI_EXIT.fontSize = 28; UI_EXIT.font = koreanFont;

        //Inside Options
        UI_MAINMENU.text = "HAUPTMENÜ"; UI_MAINMENU.fontSize = 40; UI_MAINMENU.font = koreanFont;
        UI_OPTIONSETTINGS.text = "EINSTELLUNG"; UI_OPTIONSETTINGS.fontSize = 36; UI_OPTIONSETTINGS.font = koreanFont;
        UI_FULLSCREEN.text = "VOLLBILD"; UI_FULLSCREEN.fontSize = 24; UI_FULLSCREEN.font = koreanFont;
        UI_RESET_SETTINGS.text = "ZURÜCKSETZEN"; UI_RESET_SETTINGS.fontSize = 24; UI_RESET_SETTINGS.font = koreanFont;
        UI_EXITOPTIONS.text = "BEENDEN"; UI_EXITOPTIONS.fontSize = 45; UI_EXITOPTIONS.font = koreanFont;
        UI_UI.text = "BENUTZEROBERFLÄCHE"; UI_UI.fontSize = 21; UI_UI.font = koreanFont;
        UI_ON.text = "AUF"; UI_ON.fontSize = 32; UI_ON.font = koreanFont;
        UI_OFF.text = "OFF"; UI_OFF.fontSize = 32; UI_OFF.font = koreanFont;
        UI_F_ON.text = "AUF"; UI_F_ON.fontSize = 32; UI_F_ON.font = koreanFont;
        UI_F_OFF.text = "OFF"; UI_F_OFF.fontSize = 32; UI_F_OFF.font = koreanFont;

        //WishToReset?
        UI_WISHTORESET.text = "ZURÜCKSETZEN?"; UI_WISHTORESET.fontSize = 30; UI_WISHTORESET.font = koreanFont;
        UI_RESET_NO.text = "NEIN"; UI_RESET_NO.fontSize = 35; UI_RESET_NO.font = koreanFont;
        UI_RESET_YES.text = "JA"; UI_RESET_YES.fontSize = 35; UI_RESET_YES.font = koreanFont;

        //100%Completion
        UI_CONGRATS.text = "GLÜCKWUNSCH!"; UI_CONGRATS.fontSize = 25; UI_CONGRATS.font = koreanFont;
        UI_COMPLETION.text = "100% FERTIGSTELLUNG!"; UI_COMPLETION.fontSize = 16; UI_COMPLETION.font = koreanFont;
        UI_THANKSOFRPLAYING.text = "DANKE FÜRS SPIELEN"; UI_THANKSOFRPLAYING.fontSize = 15; UI_THANKSOFRPLAYING.font = koreanFont;
    }
    #endregion

    //7
    #region french
    public void FrenchLanguage()
    {
        language = 7;
        PlayerPrefs.SetInt("languageSelect", language);

        //Start screen
        UI_START.text = "DÉMARRER"; UI_START.fontSize = 28; UI_START.font = koreanFont;
        UI_RESET.text = "RÉINITIALISER"; UI_RESET.fontSize = 28; UI_RESET.font = koreanFont;
        UI_OPTIONS.text = "OPTIONS"; UI_OPTIONS.fontSize = 28; UI_OPTIONS.font = koreanFont;
        UI_EXIT.text = "QUITTER"; UI_EXIT.fontSize = 28; UI_EXIT.font = koreanFont;

        //Inside Options
        UI_MAINMENU.text = "MENU PRINCIPAL"; UI_MAINMENU.fontSize = 26; UI_MAINMENU.font = koreanFont;
        UI_OPTIONSETTINGS.text = "PARAMÈTRES"; UI_OPTIONSETTINGS.fontSize = 36; UI_OPTIONSETTINGS.font = koreanFont;
        UI_FULLSCREEN.text = "PLEIN ÉCRAN"; UI_FULLSCREEN.fontSize = 24; UI_FULLSCREEN.font = koreanFont;
        UI_RESET_SETTINGS.text = "PARAMÈTRES"; UI_RESET_SETTINGS.fontSize = 26; UI_RESET_SETTINGS.font = koreanFont;
        UI_EXITOPTIONS.text = "QUITTER"; UI_EXITOPTIONS.fontSize = 45; UI_EXITOPTIONS.font = koreanFont;
        UI_UI.text = "INTERFACE UTILISATEUR"; UI_UI.fontSize = 20; UI_UI.font = koreanFont;
        UI_ON.text = "SUR"; UI_ON.fontSize = 20; UI_ON.font = koreanFont;
        UI_OFF.text = "ÉTEINT"; UI_OFF.fontSize = 13; UI_OFF.font = koreanFont;
        UI_F_ON.text = "SUR"; UI_F_ON.fontSize = 20; UI_F_ON.font = koreanFont;
        UI_F_OFF.text = "ÉTEINT"; UI_F_OFF.fontSize = 13; UI_F_OFF.font = koreanFont;

        //WishToReset?
        UI_WISHTORESET.text = "RÉINITIALISER ?"; UI_WISHTORESET.fontSize = 30; UI_WISHTORESET.font = koreanFont;
        UI_RESET_NO.text = "NON"; UI_RESET_NO.fontSize = 35; UI_RESET_NO.font = koreanFont;
        UI_RESET_YES.text = "OUI"; UI_RESET_YES.fontSize = 35; UI_RESET_YES.font = koreanFont;

        //100%Completion
        UI_CONGRATS.text = "FÉLICITATIONS!"; UI_CONGRATS.fontSize = 24; UI_CONGRATS.font = koreanFont;
        UI_COMPLETION.text = "ACHÈVEMENT À 100%!"; UI_COMPLETION.fontSize = 16; UI_COMPLETION.font = koreanFont;
        UI_THANKSOFRPLAYING.text = "MERCI D'AVOIR JOUÉ"; UI_THANKSOFRPLAYING.fontSize = 15; UI_THANKSOFRPLAYING.font = koreanFont;
    }
    #endregion

    //8
    #region spanish
    public void SpanishLanguage()
    {
        language = 8;
        PlayerPrefs.SetInt("languageSelect", language);

        //Start screen
        UI_START.text = "INICIO"; UI_START.fontSize = 28; UI_START.font = koreanFont;
        UI_RESET.text = "RESTABLECER"; UI_RESET.fontSize = 28; UI_RESET.font = koreanFont;
        UI_OPTIONS.text = "AJUSTES"; UI_OPTIONS.fontSize = 28; UI_OPTIONS.font = koreanFont;
        UI_EXIT.text = "SALIDA"; UI_EXIT.fontSize = 28; UI_EXIT.font = koreanFont;

        //Inside Options
        UI_MAINMENU.text = "MENÚ PRINCIPAL"; UI_MAINMENU.fontSize = 27; UI_MAINMENU.font = koreanFont;
        UI_OPTIONSETTINGS.text = "AJUSTES"; UI_OPTIONSETTINGS.fontSize = 36; UI_OPTIONSETTINGS.font = koreanFont;
        UI_FULLSCREEN.text = "PANTALLA COMPLETA"; UI_FULLSCREEN.fontSize = 15; UI_FULLSCREEN.font = koreanFont;
        UI_RESET_SETTINGS.text = "RESTABLECER"; UI_RESET_SETTINGS.fontSize = 30; UI_RESET_SETTINGS.font = koreanFont;
        UI_EXITOPTIONS.text = "SALIR"; UI_EXITOPTIONS.fontSize = 45; UI_EXITOPTIONS.font = koreanFont;
        UI_UI.text = "INTERFAZ DE USUARIO"; UI_UI.fontSize = 20; UI_UI.font = koreanFont;
        UI_ON.text = "EN"; UI_ON.fontSize = 12; UI_ON.font = koreanFont;
        UI_OFF.text = "APAGADO"; UI_OFF.fontSize = 15; UI_OFF.font = koreanFont;
        UI_F_ON.text = "EN"; UI_F_ON.fontSize = 12; UI_F_ON.font = koreanFont;
        UI_F_OFF.text = "APAGADO"; UI_F_OFF.fontSize = 15; UI_F_OFF.font = koreanFont;

        //WishToReset?
        UI_WISHTORESET.text = "RESTABLECER?"; UI_WISHTORESET.fontSize = 28; UI_WISHTORESET.font = koreanFont;
        UI_RESET_NO.text = "NO"; UI_RESET_NO.fontSize = 35; UI_RESET_NO.font = koreanFont;
        UI_RESET_YES.text = "SÍ"; UI_RESET_YES.fontSize = 35; UI_RESET_YES.font = koreanFont;

        //100%Completion
        UI_CONGRATS.text = "FELICIDADES!"; UI_CONGRATS.fontSize = 29; UI_CONGRATS.font = koreanFont;
        UI_COMPLETION.text = "100% DE FINALIZACIÓN!"; UI_COMPLETION.fontSize = 16; UI_COMPLETION.font = koreanFont;
        UI_THANKSOFRPLAYING.text = "GRACIAS POR JUGAR"; UI_THANKSOFRPLAYING.fontSize = 15; UI_THANKSOFRPLAYING.font = koreanFont;
    }
    #endregion

    //9
    #region portuguese
    public void PortugueseLanguage()
    {
        language = 9;
        PlayerPrefs.SetInt("languageSelect", language);

        //Start screen
        UI_START.text = "START"; UI_START.fontSize = 28; UI_START.font = koreanFont;
        UI_RESET.text = "RESET"; UI_RESET.fontSize = 28; UI_RESET.font = koreanFont;
        UI_OPTIONS.text = "Configurações"; UI_OPTIONS.fontSize = 28; UI_OPTIONS.font = koreanFont;
        UI_EXIT.text = "Saída"; UI_EXIT.fontSize = 28; UI_EXIT.font = koreanFont;

        //Inside Options
        UI_MAINMENU.text = "MENU PRINCIPAL"; UI_MAINMENU.fontSize = 27; UI_MAINMENU.font = koreanFont;
        UI_OPTIONSETTINGS.text = "Configurações"; UI_OPTIONSETTINGS.fontSize = 36; UI_OPTIONSETTINGS.font = koreanFont;
        UI_FULLSCREEN.text = "TELA CHEIA"; UI_FULLSCREEN.fontSize = 24; UI_FULLSCREEN.font = koreanFont;
        UI_RESET_SETTINGS.text = "RESET"; UI_RESET_SETTINGS.fontSize = 40; UI_RESET_SETTINGS.font = koreanFont;
        UI_EXITOPTIONS.text = "SAIR"; UI_EXITOPTIONS.fontSize = 45; UI_EXITOPTIONS.font = koreanFont;
        UI_UI.text = "INTERFACE DO USUÁRIO"; UI_UI.fontSize = 15; UI_UI.font = koreanFont;
        UI_ON.text = "ON"; UI_ON.fontSize = 14; UI_ON.font = koreanFont;
        UI_OFF.text = "OFF"; UI_OFF.fontSize = 13; UI_OFF.font = koreanFont;
        UI_F_ON.text = "ON"; UI_F_ON.fontSize = 14; UI_F_ON.font = koreanFont;
        UI_F_OFF.text = "OFF"; UI_F_OFF.fontSize = 13; UI_F_OFF.font = koreanFont;

        //WishToReset?
        UI_WISHTORESET.text = "RESET?"; UI_WISHTORESET.fontSize = 45; UI_WISHTORESET.font = koreanFont;
        UI_RESET_NO.text = "NÃO"; UI_RESET_NO.fontSize = 35; UI_RESET_NO.font = koreanFont;
        UI_RESET_YES.text = "SIM"; UI_RESET_YES.fontSize = 35; UI_RESET_YES.font = koreanFont;

        //100%Completion
        UI_CONGRATS.text = "Parabéns!"; UI_CONGRATS.fontSize = 35; UI_CONGRATS.font = koreanFont;
        UI_COMPLETION.text = "100 % de conclusão!"; UI_COMPLETION.fontSize = 16; UI_COMPLETION.font = koreanFont;
        UI_THANKSOFRPLAYING.text = "OBRIGADO POR JOGAR"; UI_THANKSOFRPLAYING.fontSize = 15; UI_THANKSOFRPLAYING.font = koreanFont;
    }
    #endregion

    //10
    #region polish
    public void PolishLanguage()
    {
        language = 10;
        PlayerPrefs.SetInt("languageSelect", language);

        //Start screen
        UI_START.text = "START"; UI_START.fontSize = 28; UI_START.font = koreanFont;
        UI_RESET.text = "RESETUJ"; UI_RESET.fontSize = 28; UI_RESET.font = koreanFont;
        UI_OPTIONS.text = "Ustawienia"; UI_OPTIONS.fontSize = 28; UI_OPTIONS.font = koreanFont;
        UI_EXIT.text = "WYJDZ"; UI_EXIT.fontSize = 28; UI_EXIT.font = koreanFont;

        //Inside Options
        UI_MAINMENU.text = "MENU GLÓWNE"; UI_MAINMENU.fontSize = 28; UI_MAINMENU.font = koreanFont;
        UI_OPTIONSETTINGS.text = "Ustawienia"; UI_OPTIONSETTINGS.fontSize = 36; UI_OPTIONSETTINGS.font = koreanFont;
        UI_FULLSCREEN.text = "Pelny ekran"; UI_FULLSCREEN.fontSize = 19; UI_FULLSCREEN.font = koreanFont;
        UI_RESET_SETTINGS.text = "RESETUJ"; UI_RESET_SETTINGS.fontSize = 40; UI_RESET_SETTINGS.font = koreanFont;
        UI_EXITOPTIONS.text = "WYJDZ"; UI_EXITOPTIONS.fontSize = 45; UI_EXITOPTIONS.font = koreanFont;
        UI_UI.text = "INTERFEJS"; UI_UI.fontSize = 31; UI_UI.font = koreanFont;
        UI_ON.text = "ON"; UI_ON.fontSize = 32; UI_ON.font = koreanFont;
        UI_OFF.text = "OFF"; UI_OFF.fontSize = 29; UI_OFF.font = koreanFont;
        UI_F_ON.text = "ON"; UI_F_ON.fontSize = 32; UI_F_ON.font = koreanFont;
        UI_F_OFF.text = "OFF"; UI_F_OFF.fontSize = 29; UI_F_OFF.font = koreanFont;

        //WishToReset?
        UI_WISHTORESET.text = "RESETOWAC?"; UI_WISHTORESET.fontSize = 40; UI_WISHTORESET.font = koreanFont;
        UI_RESET_NO.text = "NIE"; UI_RESET_NO.fontSize = 35; UI_RESET_NO.font = koreanFont;
        UI_RESET_YES.text = "TAK"; UI_RESET_YES.fontSize = 35; UI_RESET_YES.font = koreanFont;

        //100%Completion
        UI_CONGRATS.text = "Gratulacje!"; UI_CONGRATS.fontSize = 35; UI_CONGRATS.font = koreanFont;
        UI_COMPLETION.text = "100% Ukonczenie!"; UI_COMPLETION.fontSize = 16; UI_COMPLETION.font = koreanFont;
        UI_THANKSOFRPLAYING.text = "DZIEKI ZA GRE"; UI_THANKSOFRPLAYING.fontSize = 15; UI_THANKSOFRPLAYING.font = koreanFont;
    }
    #endregion

    //11
    #region italian
    public void ItalianLanguage()
    {
        language = 11;
        PlayerPrefs.SetInt("languageSelect", language);

        //Start screen
        UI_START.text = "Inizia"; UI_START.fontSize = 28; UI_START.font = koreanFont;
        UI_RESET.text = "RESET"; UI_RESET.fontSize = 28; UI_RESET.font = koreanFont;
        UI_OPTIONS.text = "IMPOSTAZIONI"; UI_OPTIONS.fontSize = 28; UI_OPTIONS.font = koreanFont;
        UI_EXIT.text = "USCITA"; UI_EXIT.fontSize = 28; UI_EXIT.font = koreanFont;

        //Inside Options
        UI_MAINMENU.text = "MENU PRINCIPALE"; UI_MAINMENU.fontSize = 26; UI_MAINMENU.font = koreanFont;
        UI_OPTIONSETTINGS.text = "IMPOSTAZIONI"; UI_OPTIONSETTINGS.fontSize = 36; UI_OPTIONSETTINGS.font = koreanFont;
        UI_FULLSCREEN.text = "SCHERMO INTERO"; UI_FULLSCREEN.fontSize = 17; UI_FULLSCREEN.font = koreanFont;
        UI_RESET_SETTINGS.text = "RESET"; UI_RESET_SETTINGS.fontSize = 40; UI_RESET_SETTINGS.font = koreanFont;
        UI_EXITOPTIONS.text = "ESCI"; UI_EXITOPTIONS.fontSize = 45; UI_EXITOPTIONS.font = koreanFont;
        UI_UI.text = "UI"; UI_UI.fontSize = 21; UI_UI.font = koreanFont;
        UI_ON.text = "SU"; UI_ON.fontSize = 19; UI_ON.font = koreanFont;
        UI_OFF.text = "FUORI"; UI_OFF.fontSize = 18; UI_OFF.font = koreanFont;
        UI_F_ON.text = "SU"; UI_F_ON.fontSize = 19; UI_F_ON.font = koreanFont;
        UI_F_OFF.text = "FUORI"; UI_F_OFF.fontSize = 18; UI_F_OFF.font = koreanFont;

        //WishToReset?
        UI_WISHTORESET.text = "RESET?"; UI_WISHTORESET.fontSize = 45; UI_WISHTORESET.font = koreanFont;
        UI_RESET_NO.text = "NO"; UI_RESET_NO.fontSize = 35; UI_RESET_NO.font = koreanFont;
        UI_RESET_YES.text = "SI"; UI_RESET_YES.fontSize = 35; UI_RESET_YES.font = koreanFont;

        //100%Completion
        UI_CONGRATS.text = "CONGRATULAZIONI!"; UI_CONGRATS.fontSize = 19; UI_CONGRATS.font = koreanFont;
        UI_COMPLETION.text = "COMPLETAMENTO AL 100%!"; UI_COMPLETION.fontSize = 16; UI_COMPLETION.font = koreanFont;
        UI_THANKSOFRPLAYING.text = "GRAZIE PER AVER GIOCATO"; UI_THANKSOFRPLAYING.fontSize = 12; UI_THANKSOFRPLAYING.font = koreanFont;
    }
    #endregion

    //12
    #region turkish
    public void TurkishLanguage()
    {
        language = 12;
        PlayerPrefs.SetInt("languageSelect", language);

        //Start screen
        UI_START.text = "OYNA"; UI_START.fontSize = 28; UI_START.font = koreanFont;
        UI_RESET.text = "SIFIRLA"; UI_RESET.fontSize = 28; UI_RESET.font = koreanFont;
        UI_OPTIONS.text = "AYARLAR"; UI_OPTIONS.fontSize = 28; UI_OPTIONS.font = koreanFont;
        UI_EXIT.text = "ÇIKIS"; UI_EXIT.fontSize = 28; UI_EXIT.font = koreanFont;

        //Inside Options
        UI_MAINMENU.text = "ANA MENÜ"; UI_MAINMENU.fontSize = 40; UI_MAINMENU.font = koreanFont;
        UI_OPTIONSETTINGS.text = "AYARLAR"; UI_OPTIONSETTINGS.fontSize = 36; UI_OPTIONSETTINGS.font = koreanFont;
        UI_FULLSCREEN.text = "TAM EKRAN"; UI_FULLSCREEN.fontSize = 24; UI_FULLSCREEN.font = koreanFont;
        UI_RESET_SETTINGS.text = "SIFIRLA"; UI_RESET_SETTINGS.fontSize = 40; UI_RESET_SETTINGS.font = koreanFont;
        UI_EXITOPTIONS.text = "ÇIKIS"; UI_EXITOPTIONS.fontSize = 45; UI_EXITOPTIONS.font = koreanFont;
        UI_UI.text = "KULLANICI ARAYÜZÜ"; UI_UI.fontSize = 21; UI_UI.font = koreanFont;
        UI_ON.text = "AÇIK"; UI_ON.fontSize = 25; UI_ON.font = koreanFont;
        UI_OFF.text = "KAPALI"; UI_OFF.fontSize = 21; UI_OFF.font = koreanFont;
        UI_F_ON.text = "AÇIK"; UI_F_ON.fontSize = 25; UI_F_ON.font = koreanFont;
        UI_F_OFF.text = "KAPALI"; UI_F_OFF.fontSize = 21; UI_F_OFF.font = koreanFont;

        //WishToReset?
        UI_WISHTORESET.text = "SIFIRLAMAK ISTIYOR MUSUNUZ?"; UI_WISHTORESET.fontSize = 15; UI_WISHTORESET.font = koreanFont;
        UI_RESET_NO.text = "HAYIR"; UI_RESET_NO.fontSize = 35; UI_RESET_NO.font = koreanFont;
        UI_RESET_YES.text = "EVET"; UI_RESET_YES.fontSize = 35; UI_RESET_YES.font = koreanFont;

        //100%Completion
        UI_CONGRATS.text = "TEBRIKLER"; UI_CONGRATS.fontSize = 35; UI_CONGRATS.font = koreanFont;
        UI_COMPLETION.text = "100% TAMAMLANMA"; UI_COMPLETION.fontSize = 16; UI_COMPLETION.font = koreanFont;
        UI_THANKSOFRPLAYING.text = "OYUN OYNADIGINIZ IÇIN TESEKKÜRLER!"; UI_THANKSOFRPLAYING.fontSize = 9; UI_THANKSOFRPLAYING.font = koreanFont;
    }
    #endregion
}
