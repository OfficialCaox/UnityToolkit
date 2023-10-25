using UnityEngine;
using System;


public class Ex : MonoBehaviour
{
    public void Start()
    {
        LocalPushManager.SendNotification("테스트알림입니다", "", DateTime.Now.AddSeconds(30));
    }
}