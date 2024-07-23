using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update

    private Text _lives;
    private Text _fruit;
    private PinkMan _player;
    
    void Start()
    {
        _fruit = GameObject.Find("Items_Text").GetComponent<Text>();
        _lives = GameObject.Find("Lives_Text").GetComponent<Text>();
        _player = GameObject.Find("PinkMan").GetComponent<PinkMan>();
    }

    // Update is called once per frame
    void Update()
    {
        _lives.text = $"x{_player.Lives.ToString()}";
        _lives.color = _player.Lives <= 1 ? Color.red : Color.white;
        _fruit.text = $"Items: {_player.ItemsCount.ToString()}";
    }
}
