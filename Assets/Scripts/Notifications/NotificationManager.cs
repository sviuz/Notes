using System;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

namespace Notifications {
  public class NotificationManager : MonoBehaviour {
    private static readonly List<string> HandledIds = new List<string>();

    private const string CHANNEL_ID = "notify_daily_reminder";
    private const string ICON_SMALL = "notify_icon_small"; //this is setup under Project Settings -> Mobile Notifications
    private const string ICON_LARGE = "notify_icon_large"; //this is setup under Project Settings -> Mobile Notifications
    private const string CHANNEL_TITLE = "Daily Reminders";
    private const string CHANNEL_DESCRIPTION = "Get daily updates to see anything you missed.";


    private void Start() {
      Debug.Log("NotificationManager: Start");


      //always remove any currently displayed notifications
      Unity.Notifications.Android.AndroidNotificationCenter.CancelAllDisplayedNotifications();


      //check if this was openened from a notification click
      var notificationIntentData = AndroidNotificationCenter.GetLastNotificationIntent();

      //this is just for debugging purposes
      if (notificationIntentData != null) {
        Debug.Log("notification_intent_data.Id: " + notificationIntentData.Id);
        Debug.Log("notification_intent_data.Channel: " + notificationIntentData.Channel);
        Debug.Log("notification_intent_data.Notification: " + notificationIntentData.Notification);
      }


      //if the notification intent is not null and we have not already seen this notification id, do something
      //using a static List to store already handled notification ids
      if (notificationIntentData != null &&
          NotificationManager.HandledIds.Contains(notificationIntentData.Id.ToString()) == false) {
        NotificationManager.HandledIds.Add(notificationIntentData.Id.ToString());

        //this logic assumes only one type of notification is shown
        //show high scores when the user clicks the notification                
        UnityEngine.SceneManagement.SceneManager.LoadScene("HighScores");
        return;
      } else {
        Debug.Log("notification_intent_data is null or already handled");
      }


      //dont do anything further if the user has disabled notifications
      //this assumes you have additional ui to enabled/disable this preference
      var allowNotifications = PlayerPrefs.GetString("notifications");

      if (allowNotifications?.ToLower() == "false") {
        Debug.Log("Notifications Disabled");
        return;
      }


      this.Setup_Notifications();
    }


    internal void Setup_Notifications() {
      Debug.Log("NotificationsManager: Setup_Notifications");


      //initialize the channel
      this.Initialize();


      //schedule the next notification
      this.Schedule_Daily_Reminder();
    }


    void Initialize() {
      Debug.Log("NotificationManager: Initialize");

      //you could create platform specific logic, for now, we will just do Android
      //#if UNITY_ANDROID || UNITY_EDITOR            
      //            this.Initialize_Android();
      //#elif UNITY_IPHONE
      //#endif            


      //add our channel
      //a channel can be used by more than one notification
      //you do not have to check if the channel is already created, Android OS will take care of that logic
      var androidChannel = new AndroidNotificationChannel(CHANNEL_ID, CHANNEL_TITLE,
        CHANNEL_DESCRIPTION, Importance.Default);
      AndroidNotificationCenter.RegisterNotificationChannel(androidChannel);
    }


    void Schedule_Daily_Reminder() {
      Debug.Log("NotificationManager: Schedule_Daily_Reminder");


      //since this is the only notification I have, I will cancel any currently pending notifications
      //if I create more types of notifications, additional logic will be needed
      AndroidNotificationCenter.CancelAllScheduledNotifications();


      //create new schedule
      string title = "We Miss You!";
      string body = "Come Back! Come Back! Come Back!";

      //show at the specified time - 10:30 AM
      //you could also always set this a certain amount of hours ahead, since this code resets the schedule, this could be used to prompt the user to play again if they haven't played in a while
      DateTime deliveryTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 30, 0);

      if (deliveryTime < DateTime.Now) {
        //if in the past (ex: this code runs at 11:00 AM), push delivery date forward 1 day
        deliveryTime = deliveryTime.AddDays(1);
      } else if ((deliveryTime - DateTime.Now).TotalHours <= 0) {
        //optional
        //if too close to current time (<= 4 hours away), push delivery date forward 1 day
        deliveryTime = deliveryTime.AddDays(1);
      }

      Debug.Log("Delivery Time: " + deliveryTime.ToString());


      //you currently do not need the notification id
      //if you had multiple notifications, you could store this and use it to cancel a specific notification
      var scheduledNotificationID = Unity.Notifications.Android.AndroidNotificationCenter.SendNotification(
        new Unity.Notifications.Android.AndroidNotification() {
          Title = title,
          Text = body,
          FireTime = deliveryTime,
          SmallIcon = ICON_SMALL,
          LargeIcon = ICON_LARGE
        }, CHANNEL_ID);
    }
  }
}