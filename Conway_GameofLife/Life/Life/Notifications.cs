using System;
using System.Collections.Generic;
using System.Text;

namespace Life
{
    class Notifications
    {
        /// <summary>
        /// Get the current time for the game
        /// </summary>
        private static string GetRealTime
        {
            get
            {
                return DateTime.Now.ToString("[hh:mm:ss:ffff]");
            }
        }

        /// <summary>
        /// This method gives the type of notification in the settings of the game
        /// </summary>
        /// <param name="notification">Message reports type of notification</param>
        /// <param name="prefix">Type of notification that user wants</param>
        /// <param name="color">Choose the color for the notification</param>
        public static void NotificationType(string notification, string prefix = null,
            ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{GetRealTime}" +
                $"{(prefix != null ? $" {prefix}: " : " ")}{notification}");

            // After 
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Notification for success in the game
        /// </summary>
        /// <param name="notification">Message from the settings</param>
        public static void Success(string notification)
        {
            NotificationType(notification, "Success", ConsoleColor.Green);
        }

        /// <summary>
        /// Notification for errors in game
        /// </summary>
        /// <param name="notification">Message from the setting</param>
        public static void Error(string notification)
        {
            NotificationType(notification, "Error", ConsoleColor.Red);
        }

        /// <summary>
        /// Notification for changing values from command line arguments
        /// </summary>
        /// <param name="notification">New values for setting</param>
        public static void Changing(string notification)
        {
            NotificationType(notification, "Changing", ConsoleColor.Cyan);
        }
    }
}
