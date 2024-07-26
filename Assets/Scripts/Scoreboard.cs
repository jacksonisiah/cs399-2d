using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    private readonly string _tag = "Scoreboard";
    private PinkMan _player;
    private TMP_Text _sbItems;
    private TMP_Text _sbLives;
    private TMP_Text _sbTime;

    private GameObject[] _scoreboardObjs;

    // Start is called before the first frame update
    private Button sbBtnNextLevel;

    private void Start()
    {
        _player = GameObject.Find("PinkMan").GetComponent<PinkMan>();
        _scoreboardObjs = GameObject.FindGameObjectsWithTag(_tag);
        _sbItems = GameObject.Find("sbItems").GetComponent<TMP_Text>();
        _sbLives = GameObject.Find("sbLives").GetComponent<TMP_Text>();
        _sbTime = GameObject.Find("sbTime").GetComponent<TMP_Text>();
        Toggle();
    }

    private void Toggle()
    {
        _sbLives.text = $"Lives Lost: {_player.LivesLost}";
        _sbItems.text = $"Items Collected: {_player.ItemsCount}";
        var t = TimeSpan.FromSeconds(Time.timeSinceLevelLoad);
        _sbTime.text = $"Time: {t.Minutes:D2}:{t.Seconds:D2}";

        var state = !_scoreboardObjs[0].activeSelf;
        foreach (var obj in _scoreboardObjs)
            obj.SetActive(!obj.activeSelf);

        Debug.Log($"Scoreboard: Set {string.Join(", ", _scoreboardObjs.Select(obj => obj.name).ToList())} " +
                  $"{(state ? "active" : "inactive")}");
    }
}