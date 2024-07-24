using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Text _fruit;
    // Start is called before the first frame update

    private Text _lives;
    private PinkMan _player;

    private void Start()
    {
        _fruit = GameObject.Find("Items_Text").GetComponent<Text>();
        _lives = GameObject.Find("Lives_Text").GetComponent<Text>();
        _player = GameObject.Find("PinkMan").GetComponent<PinkMan>();
    }

    // Update is called once per frame
    private void Update()
    {
        _lives.text = $"x{_player.Lives.ToString()}";
        _lives.color = _player.Lives <= 1 ? Color.red : Color.white;
        _fruit.text = $"Items: {_player.ItemsCount.ToString()}";
    }
}