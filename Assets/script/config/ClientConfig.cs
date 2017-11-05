using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientConfig  {

    public static String serviceHost = "127.0.0.1";
    public static int servicePort = 10020;

    //屏幕宽度
    public static  int WIDTH = 800;
    //屏幕高度
    public static  int HEIGHT = 500;
    //屏幕初始出现位置
    public static  int STARTX = 10;
    public static  int STARTY = 10;

    //登录成功
    public static  int loginInSuccess = 1;
    //登录失败
    public static  int loginInError = 2;

    //退出登录成功
    public static  int loginOutSuccess = 3;
    //退出登录失败
    public static  int loginOutError = 4;

    //注册成功
    public static  int registerSuccess = 5;
    //注册失败
    public static final int registerError = 6;

    //玩家登录类型(0游客  1QQ 2微信)
    public static  int weChat = 2;
    public static  int QQ = 1;
    public static  int Guest = 0;

    //游客获取名字
    public static  int guestNameSuccess = 7;
}
