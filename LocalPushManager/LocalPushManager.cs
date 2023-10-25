using UnityEngine;
using System;
using Unity.VisualScripting;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#elif UNITY_IOS
using Unity.Notifications.iOS;
#endif


public class LocalPushManager : MonoBehaviour
{
    public static void SendNotification(string title, string explain, DateTime time)
    {
        try
        {
#if UNITY_ANDROID
            var notification = new AndroidNotification();
            notification.Title = title;
            notification.Text = explain;
            notification.FireTime = time;

            notification.SmallIcon = "icon_1";
            notification.LargeIcon = "icon_0";
            notification.ShowInForeground = false;
            string channelId = "my_channel_id";

            AndroidNotificationCenter.SendNotification(notification, channelId);
#elif UNITY_IOS
        var timeTrigger = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = time - DateTime.Now,
            Repeats = false
        };

        var notification = new iOSNotification()
        {
            Identifier = "_notification",
            Title = title,
            Body = explain,
            //Subtitle = explain,
            ShowInForeground = false,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "category_a",
            ThreadIdentifier = "thread1",
            Trigger = timeTrigger,
        };

        iOSNotificationCenter.ScheduleNotification(notification);
#endif
        }
        catch (Exception e)
        {
            LogManager.AddErrorText(e.ToString());
        }
    }

    public static void CancelAllNotifications()
    {
#if UNITY_ANDROID
        AndroidNotificationCenter.CancelAllNotifications();
#elif UNITY_IOS
        iOSNotificationCenter.RemoveAllScheduledNotifications();
#endif
    }
}