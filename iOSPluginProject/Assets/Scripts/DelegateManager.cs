using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using AOT;
using System;

public class DelegateManager : MonoBehaviour
{
    public static DelegateManager delegateManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void Awake()
    {
        SendDelegates();
        Debug.Log("잔송");
    }
    
    public void SendDelegates()
    {
       SendTestActionCallBack(ReceiveTestAction_Unity);
      SendTestMessageCallBack(ReceiveTestMessage_Unity);
    }

    delegate void receiveTestAction();
    [DllImport("__Internal")]
    private extern static void SendTestActionCallBack(receiveTestAction callback);
    [MonoPInvokeCallback(typeof(receiveTestAction))]
    public static void ReceiveTestAction_Unity()
    {
        Debug.Log("TestAction!");
        Debug.Log("신호수신");
    }

    delegate void receiveMessageAction(string text);
    [DllImport("__Internal")]
    private extern static void SendTestMessageCallBack(receiveMessageAction callback);
    [MonoPInvokeCallback(typeof(receiveMessageAction))]
    public static void ReceiveTestMessage_Unity(string text)
    {
        Debug.Log("TestMessage!");
        Debug.Log(text);
    }
}
