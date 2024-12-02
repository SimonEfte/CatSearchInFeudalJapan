using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    public void Start()
    {
       /* AchClear("ach_noHints");

        AchClear("cat1");
        AchClear("cat2");
        AchClear("cat3");
        AchClear("cat4");
        AchClear("cat5");
        AchClear("cat6");
        AchClear("cat7");
        AchClear("cat8");
        AchClear("cat9");
        AchClear("cat10");
        AchClear("cat11");
        AchClear("cat12");
        AchClear("cat13");
        AchClear("cat14");
        AchClear("cat15");
        AchClear("cat16");
        AchClear("cat17");
        AchClear("cat18");
        AchClear("cat19");
        AchClear("cat20");
        AchClear("cat21");
        AchClear("cat22");
        AchClear("cat23");
        AchClear("cat24");
        AchClear("cat25");
        AchClear("cat26");
        AchClear("cat27");
        AchClear("cat28");
        AchClear("cat29");
        AchClear("cat30");
        AchClear("cat31");
        AchClear("cat32");
        AchClear("cat33");
        AchClear("cat34");
        AchClear("cat35");
        AchClear("cat36");
        AchClear("cat37");
        AchClear("cat38");
        AchClear("cat39");
        AchClear("cat40");
        AchClear("cat41");
        AchClear("cat42");
        AchClear("cat43");
        AchClear("cat44");
        AchClear("cat45");
        AchClear("cat46");
        AchClear("cat47");
        AchClear("cat48");
        AchClear("cat49");
        AchClear("cat50");
        AchClear("cat51");
        AchClear("cat52");
        AchClear("cat53");
        AchClear("cat54");
        AchClear("cat55");
        AchClear("cat56");
        AchClear("cat57");
        AchClear("cat58");
        AchClear("cat59");
        AchClear("cat60");
        AchClear("cat61");
        AchClear("cat62");
        AchClear("cat63");
        AchClear("cat64");
        AchClear("cat65");
        AchClear("cat66");
        AchClear("cat67");
        AchClear("cat68");
        AchClear("cat69");
        AchClear("cat70");
        AchClear("cat72");
        AchClear("cat74");
        AchClear("cat76");
        AchClear("cat78");
        AchClear("cat80");
        AchClear("cat83");
        AchClear("cat86");
        AchClear("cat89");
        AchClear("cat93");
        AchClear("cat96");
        AchClear("cat100");
        AchClear("cat103");
        AchClear("cat106");
        AchClear("cat110");
        AchClear("cat114");
        AchClear("cat118");
        AchClear("cat122");
        AchClear("cat127");
        AchClear("cat132");

        AchClear("katana1");
        AchClear("katana3");
        AchClear("katana5");
        AchClear("katana7");
        AchClear("katana10");

        AchClear("catSamurai1");
        AchClear("catSamurai2");
        AchClear("catSamurai3");
        AchClear("catSamurai4");
        AchClear("catSamurai5");
       */
    }

    public void CheckAchievements()
    {
        if (CatsAndKatanasFound.catsFountCount >= 131 && CatsAndKatanasFound.katanasFoundCount >= 10 && CatsAndKatanasFound.samuraiCatsFoundCount >= 5 && CatsAndKatanasFound.hintsUsed == 0) { FindCats("ach_noHints"); }

        if (CatsAndKatanasFound.catsFountCount == 1) { FindCats("cat1"); }
        if (CatsAndKatanasFound.catsFountCount == 2) { FindCats("cat2"); }
        if (CatsAndKatanasFound.catsFountCount == 3) { FindCats("cat3"); }
        if (CatsAndKatanasFound.catsFountCount == 4) { FindCats("cat4"); }
        if (CatsAndKatanasFound.catsFountCount == 5) { FindCats("cat5"); }
        if (CatsAndKatanasFound.catsFountCount == 6) { FindCats("cat6"); }
        if (CatsAndKatanasFound.catsFountCount == 7) { FindCats("cat7"); }
        if (CatsAndKatanasFound.catsFountCount == 8) { FindCats("cat8"); }
        if (CatsAndKatanasFound.catsFountCount == 9) { FindCats("cat9"); }
        if (CatsAndKatanasFound.catsFountCount == 10) { FindCats("cat10"); }
        if (CatsAndKatanasFound.catsFountCount == 11) { FindCats("cat11"); }
        if (CatsAndKatanasFound.catsFountCount == 12) { FindCats("cat12"); }
        if (CatsAndKatanasFound.catsFountCount == 13) { FindCats("cat13"); }
        if (CatsAndKatanasFound.catsFountCount == 14) { FindCats("cat14"); }
        if (CatsAndKatanasFound.catsFountCount == 15) { FindCats("cat15"); }
        if (CatsAndKatanasFound.catsFountCount == 16) { FindCats("cat16"); }
        if (CatsAndKatanasFound.catsFountCount == 17) { FindCats("cat17"); }
        if (CatsAndKatanasFound.catsFountCount == 18) { FindCats("cat18"); }
        if (CatsAndKatanasFound.catsFountCount == 19) { FindCats("cat19"); }
        if (CatsAndKatanasFound.catsFountCount == 20) { FindCats("cat20"); }
        if (CatsAndKatanasFound.catsFountCount == 21) { FindCats("cat21"); }
        if (CatsAndKatanasFound.catsFountCount == 22) { FindCats("cat22"); }
        if (CatsAndKatanasFound.catsFountCount == 23) { FindCats("cat23"); }
        if (CatsAndKatanasFound.catsFountCount == 24) { FindCats("cat24"); }
        if (CatsAndKatanasFound.catsFountCount == 25) { FindCats("cat25"); }
        if (CatsAndKatanasFound.catsFountCount == 26) { FindCats("cat26"); }
        if (CatsAndKatanasFound.catsFountCount == 27) { FindCats("cat27"); }
        if (CatsAndKatanasFound.catsFountCount == 28) { FindCats("cat28"); }
        if (CatsAndKatanasFound.catsFountCount == 29) { FindCats("cat29"); }
        if (CatsAndKatanasFound.catsFountCount == 30) { FindCats("cat30"); }
        if (CatsAndKatanasFound.catsFountCount == 31) { FindCats("cat31"); }
        if (CatsAndKatanasFound.catsFountCount == 32) { FindCats("cat32"); }
        if (CatsAndKatanasFound.catsFountCount == 33) { FindCats("cat33"); }
        if (CatsAndKatanasFound.catsFountCount == 34) { FindCats("cat34"); }
        if (CatsAndKatanasFound.catsFountCount == 35) { FindCats("cat35"); }
        if (CatsAndKatanasFound.catsFountCount == 36) { FindCats("cat36"); }
        if (CatsAndKatanasFound.catsFountCount == 37) { FindCats("cat37"); }
        if (CatsAndKatanasFound.catsFountCount == 38) { FindCats("cat38"); }
        if (CatsAndKatanasFound.catsFountCount == 39) { FindCats("cat39"); }
        if (CatsAndKatanasFound.catsFountCount == 40) { FindCats("cat40"); }
        if (CatsAndKatanasFound.catsFountCount == 41) { FindCats("cat41"); }
        if (CatsAndKatanasFound.catsFountCount == 42) { FindCats("cat42"); }
        if (CatsAndKatanasFound.catsFountCount == 43) { FindCats("cat43"); }
        if (CatsAndKatanasFound.catsFountCount == 44) { FindCats("cat44"); }
        if (CatsAndKatanasFound.catsFountCount == 45) { FindCats("cat45"); }
        if (CatsAndKatanasFound.catsFountCount == 46) { FindCats("cat46"); }
        if (CatsAndKatanasFound.catsFountCount == 47) { FindCats("cat47"); }
        if (CatsAndKatanasFound.catsFountCount == 48) { FindCats("cat48"); }
        if (CatsAndKatanasFound.catsFountCount == 49) { FindCats("cat49"); }
        if (CatsAndKatanasFound.catsFountCount == 50) { FindCats("cat50"); }
        if (CatsAndKatanasFound.catsFountCount == 51) { FindCats("cat51"); }
        if (CatsAndKatanasFound.catsFountCount == 52) { FindCats("cat52"); }
        if (CatsAndKatanasFound.catsFountCount == 53) { FindCats("cat53"); }
        if (CatsAndKatanasFound.catsFountCount == 54) { FindCats("cat54"); }
        if (CatsAndKatanasFound.catsFountCount == 55) { FindCats("cat55"); }
        if (CatsAndKatanasFound.catsFountCount == 56) { FindCats("cat56"); }
        if (CatsAndKatanasFound.catsFountCount == 57) { FindCats("cat57"); }
        if (CatsAndKatanasFound.catsFountCount == 58) { FindCats("cat58"); }
        if (CatsAndKatanasFound.catsFountCount == 59) { FindCats("cat59"); }
        if (CatsAndKatanasFound.catsFountCount == 60) { FindCats("cat60"); }
        if (CatsAndKatanasFound.catsFountCount == 61) { FindCats("cat61"); }
        if (CatsAndKatanasFound.catsFountCount == 62) { FindCats("cat62"); }
        if (CatsAndKatanasFound.catsFountCount == 63) { FindCats("cat63"); }
        if (CatsAndKatanasFound.catsFountCount == 64) { FindCats("cat64"); }
        if (CatsAndKatanasFound.catsFountCount == 65) { FindCats("cat65"); }
        if (CatsAndKatanasFound.catsFountCount == 66) { FindCats("cat66"); }
        if (CatsAndKatanasFound.catsFountCount == 67) { FindCats("cat67"); }
        if (CatsAndKatanasFound.catsFountCount == 68) { FindCats("cat68"); }
        if (CatsAndKatanasFound.catsFountCount == 69) { FindCats("cat69"); }
        if (CatsAndKatanasFound.catsFountCount == 70) { FindCats("cat70"); }
        if (CatsAndKatanasFound.catsFountCount == 72) { FindCats("cat72"); }
        if (CatsAndKatanasFound.catsFountCount == 74) { FindCats("cat74"); }
        if (CatsAndKatanasFound.catsFountCount == 76) { FindCats("cat76"); }
        if (CatsAndKatanasFound.catsFountCount == 78) { FindCats("cat78"); }
        if (CatsAndKatanasFound.catsFountCount == 80) { FindCats("cat80"); }
        if (CatsAndKatanasFound.catsFountCount == 83) { FindCats("cat83"); }
        if (CatsAndKatanasFound.catsFountCount == 86) { FindCats("cat86"); }
        if (CatsAndKatanasFound.catsFountCount == 89) { FindCats("cat89"); }
        if (CatsAndKatanasFound.catsFountCount == 93) { FindCats("cat93"); }
        if (CatsAndKatanasFound.catsFountCount == 96) { FindCats("cat96"); }
        if (CatsAndKatanasFound.catsFountCount == 100) { FindCats("cat100"); }
        if (CatsAndKatanasFound.catsFountCount == 103) { FindCats("cat103"); }
        if (CatsAndKatanasFound.catsFountCount == 106) { FindCats("cat106"); }
        if (CatsAndKatanasFound.catsFountCount == 110) { FindCats("cat110"); }
        if (CatsAndKatanasFound.catsFountCount == 114) { FindCats("cat114"); }
        if (CatsAndKatanasFound.catsFountCount == 118) { FindCats("cat118"); }
        if (CatsAndKatanasFound.catsFountCount == 122) { FindCats("cat122"); }
        if (CatsAndKatanasFound.catsFountCount == 127) { FindCats("cat127"); }
        if (CatsAndKatanasFound.catsFountCount == 131) { FindCats("cat132"); }

        if(CatsAndKatanasFound.katanasFoundCount == 1) { FindCats("katana1"); }
        if (CatsAndKatanasFound.katanasFoundCount == 3) { FindCats("katana3"); }
        if (CatsAndKatanasFound.katanasFoundCount == 5) { FindCats("katana5"); }
        if (CatsAndKatanasFound.katanasFoundCount == 7) { FindCats("katana7"); }
        if (CatsAndKatanasFound.katanasFoundCount == 10) { FindCats("katana10"); }

        if(CatsAndKatanasFound.samuraiCatsFoundCount == 1) { FindCats("catSamurai1"); }
        if (CatsAndKatanasFound.samuraiCatsFoundCount == 2) { FindCats("catSamurai2"); }
        if (CatsAndKatanasFound.samuraiCatsFoundCount == 3) { FindCats("catSamurai3"); }
        if (CatsAndKatanasFound.samuraiCatsFoundCount == 4) { FindCats("catSamurai4"); }
        if (CatsAndKatanasFound.samuraiCatsFoundCount == 5) { FindCats("catSamurai5"); }
    }

    public void FindCats(string achID)
    {
        var ach = new Steamworks.Data.Achievement(achID);
        if (ach.State == false) { ach.Trigger(); }
    }

    public void AchClear(string achID)
    {
        var ach = new Steamworks.Data.Achievement(achID);
        ach.Clear();
    }
}
