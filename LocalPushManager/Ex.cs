using UnityEngine;
using System;


public class Ex : MonoBehaviour
{
    public void Start()
    {
        LocalPushManager.SendNotification("�׽�Ʈ�˸��Դϴ�", "", DateTime.Now.AddSeconds(30));
    }
}