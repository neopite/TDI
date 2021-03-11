using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillReward : MonoBehaviour
{
    [SerializeField]private int _moneyReward;
    [SerializeField]private int _scoreReward;

    public int MoneyReward => _moneyReward;
    public int ScoreReward => _scoreReward;
}
