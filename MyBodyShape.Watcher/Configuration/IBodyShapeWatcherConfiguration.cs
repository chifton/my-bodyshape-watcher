// ===============================
// *******************************
// The bodyshape watcher configuration interface.
// ===============================
// *******************************

namespace MyBodyShape.Watcher.Configuration
{
    using MyBodyShape.Watcher.Configuration.Impl;

    /// <summary>
    /// The bodyshape watcher configuration interface.
    /// </summary>
    public interface IBodyShapeWatcherConfiguration
    {
        /// <summary>
        /// The folder log.
        /// </summary>
        string FolderLog { get; set; }

        /// <summary>
        /// The timer interval.
        /// </summary>
        int TimerInterval { get; set; }

        /// <summary>
        /// The sms enabled boolean.
        /// </summary>
        bool SmsEnabled { get; set; }

        /// <summary>
        /// The SMS Api Sid.
        /// </summary>
        string SmsApiSid { get; set; }

        /// <summary>
        /// The SMS Api token.
        /// </summary>
        string SmsApiToken { get; set; }

        /// <summary>
        /// The SMS Api number.
        /// </summary>
        string SmsApiNumber { get; set; }

        /// <summary>
        /// The phone recipients.
        /// </summary>
        RecipientPhoneCollectionConfiguration Recipients { get; set; }
    }
}
