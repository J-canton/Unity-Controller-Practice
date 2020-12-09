using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _playerHP = 100;
    public int PlayerHp {
        get
        {
            return _playerHP;
        } 
        set
        {
            _playerHP = value;
            if(value - _playerHP < 0)
            {
                _playerHP = 0;
            }
        }
    }
}
