using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHeartUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _heartBar;

    [SerializeField]
    private List<Image> _heartList = new List<Image>();
    [SerializeField]
    private Player _player;
    [SerializeField]
    private Sprite _fullHeart;
    [SerializeField]
    private Sprite _emptyHeart;

    

    public void GetDamage(int damage)
    {
        if(_player.Health >= 0)
        {
            _heartList[_player.Health].sprite = _emptyHeart;
        }
    }

    public void Heal()
    {
        _heartList[_player.Health].sprite = _fullHeart;
        _player.Health += 1;
    }


}
