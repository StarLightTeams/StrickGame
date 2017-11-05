using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info  :UnityEngine.Object{

    public string headInfo;
    public string dataInfo;

    public Info()
    {

    }

    public Info(string headInfo)
    {
        this.headInfo = headInfo;
    }

    public Info(string headInfo, string dataInfo)
    {
        this.headInfo = headInfo;
        this.dataInfo = dataInfo;
    }
    public string getHeadInfo()
    {
        return headInfo;
    }
    public void setHeadInfo(string headInfo)
    {
        this.headInfo = headInfo;
    }
    public string getDataInfo()
    {
        return dataInfo;
    }
    public void setDataInfo(string dataInfo)
    {
        this.dataInfo = dataInfo;
    }
  
    public string toString()
    {
        return "ErrorInfo [headInfo=" + headInfo + ", dataInfo=" + dataInfo + "]";
    }

}
