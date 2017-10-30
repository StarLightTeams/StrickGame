using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player  {

    //玩家序号
    public int playerNo;
    //玩家名字
    public string playerName;
    //玩家登陆密码(游客密码默认为1)
    public string password = "1";
    //玩家房卡
    public int playerCard;
    //玩家道具
    public Dictionary<string, int> djmap;
    //玩家登录状态【0.未登录 1.游客登录 2.qq登录 3.微信登录】
    public int loginState = 0;

    public Player()
    {

    }

    public Player(string playerName)
    {
        this.playerName = playerName;
    }

    public Player(string playerName, string password)
    {
        this.playerName = playerName;
        this.password = password;
    }

    public Player(string playerName, string password, int loginState)
    {
        this.playerName = playerName;
        this.password = password;
        this.loginState = loginState;
    }

    public int getLoginState()
    {
        return loginState;
    }

    public void setLoginState(int loginState)
    {
        this.loginState = loginState;
    }

    public int getPlayerNo()
    {
        return playerNo;
    }
    public void setPlayerNo(int playerNo)
    {
        this.playerNo = playerNo;
    }
    public string getPlayerName()
    {
        return playerName;
    }
    public void setPlayerName(string playerName)
    {
        this.playerName = playerName;
    }
    public string getPassword()
    {
        return password;
    }
    public void setPassword(string password)
    {
        this.password = password;
    }
    public int getPlayerCard()
    {
        return playerCard;
    }
    public void setPlayerCard(int playerCard)
    {
        this.playerCard = playerCard;
    }
    public Dictionary<string, int> getDjmap()
    {
        return djmap;
    }
    public void setDjmap(Dictionary<string, int> djmap)
    {
        this.djmap = djmap;
    }

    public string tostring()
    {
        return "Player [playerNo=" + playerNo + ", playerName=" + playerName + ", password=" + password
                + ", playerCard=" + playerCard + ", djmap=" + djmap + ", loginState=" + loginState + "]";
    }
}
