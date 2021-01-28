using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Log
{
    public static bool isShow = true;

    public static void Info(string text)
    {
        if (!isShow) return;
        Debug.Log(text);
    }

    public static void Error(string text)
    {
        if (!isShow) return;
        Debug.LogError(text);
    }

    public static void Warning(string text)
    {
        if (!isShow) return;
        Debug.LogWarning(text);
    }


}