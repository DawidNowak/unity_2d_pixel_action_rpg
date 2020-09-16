using System;
using UnityEngine;
using UnityEngine.UI;

public class StatsMenu : MonoBehaviour
{
    private StatisticsSystem statisticsSystem;
    private int initStr, initInt, initVit, initStatsToSpend;
    private int stre, inte, vita, statsLeft;

    public Button StrUp;
    public Button StrDown;
    public Button IntUp;
    public Button IntDown;
    public Button VitUp;
    public Button VitDown;

    public PixelFontMerger StrValue;
    public PixelFontMerger IntValue;
    public PixelFontMerger VitValue;

    public PixelFontMerger StatsLeftText;

    void Awake()
    {
        statisticsSystem = FindObjectOfType<GameManager>().GetStatisticsSystem();
        statisticsSystem.OnStatsToSpendChanged += StatisticsSystem_OnStatsToSpendChanged;

        StrUp.onClick.AddListener(AddStr);
        StrDown.onClick.AddListener(SubStr);
        IntUp.onClick.AddListener(AddInt);
        IntDown.onClick.AddListener(SubInt);
        VitUp.onClick.AddListener(AddVit);
        VitDown.onClick.AddListener(SubVit);
    }

    void OnEnable()
    {
        initStr = statisticsSystem.Strength.CurrentValue;
        initInt = statisticsSystem.Intelligence.CurrentValue;
        initVit = statisticsSystem.Vitality.CurrentValue;
        initStatsToSpend = statisticsSystem.StatsToSpend;
        statsLeft = initStatsToSpend;
        stre = initStr;
        inte = initInt;
        vita = initVit;

        StrValue.SetText(initStr.ToString());
        IntValue.SetText(initInt.ToString());
        VitValue.SetText(initVit.ToString());

        StatisticsSystem_OnStatsToSpendChanged(null, EventArgs.Empty);
    }

    private void StatisticsSystem_OnStatsToSpendChanged(object sender, EventArgs e)
    {
        StatsLeftText.SetText($"{statisticsSystem.StatsToSpend}");
        if (statisticsSystem.StatsToSpend > 0)
        {
            StrUp.gameObject.SetActive(true);
            IntUp.gameObject.SetActive(true);
            VitUp.gameObject.SetActive(true);
        }
        else
        {
            StrUp.gameObject.SetActive(false);
            IntUp.gameObject.SetActive(false);
            VitUp.gameObject.SetActive(false);
        }

        StrDown.gameObject.SetActive(initStr < stre);
        IntDown.gameObject.SetActive(initInt < inte);
        VitDown.gameObject.SetActive(initVit < vita);
    }

    private void AddStr()
    {
        stre++;
        StrValue.SetText(stre.ToString());
        SubstractOneStat();
    }

    private void AddInt()
    {
        inte++;
        IntValue.SetText(inte.ToString());
        SubstractOneStat();
    }

    private void AddVit()
    {
        vita++;
        VitValue.SetText(vita.ToString());
        SubstractOneStat();
    }

    private void SubStr()
    {
        stre--;
        StrValue.SetText(stre.ToString());
        AddOneStat();
    }

    private void SubInt()
    {
        inte--;
        IntValue.SetText(inte.ToString());
        AddOneStat();
    }

    private void SubVit()
    {
        vita--;
        VitValue.SetText(vita.ToString());
        AddOneStat();
    }

    private void SubstractOneStat()
    {
        statsLeft--;
        statisticsSystem.SetStatsToSpend(statsLeft);
    }

    private void AddOneStat()
    {
        statsLeft++;
        statisticsSystem.SetStatsToSpend(statsLeft);
    }
}
