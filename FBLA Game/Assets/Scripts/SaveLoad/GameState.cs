using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GameState
{
    public List<List<string>> leaderboard;

    public GameState(List<List<string>> _leaderboard)
    {
        leaderboard = _leaderboard;
    }
}
