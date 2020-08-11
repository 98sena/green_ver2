using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;

public class Testing : MonoBehaviour
{
    [SerializeField]
    private UI_StatsRadarChart uiStatsRadarChart;
    DataStorage ds;

    private void Awake()
    {
        ds = FindObjectOfType<DataStorage>();
    }
    private void Start()
    {
        Stats stats = new Stats(ds.ballDistace, ds.BF, ds.LR, ds.hitCount/5.0f);

        uiStatsRadarChart.SetStats(stats);
        Debug.Log(uiStatsRadarChart.stats.GetStatAmountNormalized(Stats.Type.Distance));
        /*
        CMDebug.ButtonUI(new Vector2(100, 20), "ATK++", () => stats.IncreaseStatAmount(Stats.Type.Attack));
        CMDebug.ButtonUI(new Vector2(100, -20), "ATK--", () => stats.DecreaseStatAmount(Stats.Type.Attack));

        CMDebug.ButtonUI(new Vector2(200, 20), "DEF++", () => stats.IncreaseStatAmount(Stats.Type.Defence));
        CMDebug.ButtonUI(new Vector2(200, -20), "DEF--", () => stats.DecreaseStatAmount(Stats.Type.Defence));

        CMDebug.ButtonUI(new Vector2(300, 20), "SPD++", () => stats.IncreaseStatAmount(Stats.Type.Speed));
        CMDebug.ButtonUI(new Vector2(300, -20), "SPD--", () => stats.DecreaseStatAmount(Stats.Type.Speed));

        CMDebug.ButtonUI(new Vector2(400, 20), "MAN++", () => stats.IncreaseStatAmount(Stats.Type.Mana));
        CMDebug.ButtonUI(new Vector2(400, -20), "MAN--", () => stats.DecreaseStatAmount(Stats.Type.Mana));

        CMDebug.ButtonUI(new Vector2(500, 20), "HEL++", () => stats.IncreaseStatAmount(Stats.Type.Health));
        CMDebug.ButtonUI(new Vector2(500, -20), "HEL--", () => stats.DecreaseStatAmount(Stats.Type.Health));
        */
        Debug.Log("Distance: "+ds.ballDistace);
        Debug.Log("LR: "+ds.LR);
        Debug.Log("Bf: "+ds.BF);
        Debug.Log("hitCnt: "+ds.hitCount);
    }
}
