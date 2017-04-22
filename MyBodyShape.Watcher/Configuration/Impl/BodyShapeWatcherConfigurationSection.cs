// ===============================
// *******************************
// The bodyshape watcher configuration section class.
// ===============================
// *******************************

namespace MyBodyShape.Watcher.Configuration.Impl
{
    using System;
    using System.Configuration;

    /// <summary>
    /// The bodyshape configuration section class.
    /// </summary>
    public class BodyShapeWatcherConfigurationSection : ConfigurationSection, IBodyShapeWatcherConfiguration
    {
        /// <summary>
        /// The logs folder.
        /// </summary>
        [ConfigurationProperty(PropertyNames.FolderLog, IsRequired = true)]
        public string FolderLog
        {
            get
            {
                return this[PropertyNames.FolderLog].ToString();
            }
            set
            {
                this[PropertyNames.FolderLog] = value;
            }
        }

        /// <summary>
        /// The timer interval.
        /// </summary>
        [ConfigurationProperty(PropertyNames.TimerInterval, IsRequired = true)]
        public int TimerInterval
        {
            get
            {
                return Convert.ToInt32(this[PropertyNames.TimerInterval].ToString());
            }
            set
            {
                this[PropertyNames.TimerInterval] = value;
            }
        }

        /// <summary>
        /// The sms enabled boolean.
        /// </summary>
        [ConfigurationProperty(PropertyNames.SmsEnabled, IsRequired = true)]
        public bool SmsEnabled
        {
            get
            {
                return Convert.ToBoolean(this[PropertyNames.SmsEnabled]);
            }
            set
            {
                this[PropertyNames.SmsEnabled] = value;
            }
        }

        /// <summary>
        /// The SMS Api Sid.
        /// </summary>
        [ConfigurationProperty(PropertyNames.SmsApiSid, IsRequired = true)]
        public string SmsApiSid
        {
            get
            {
                return this[PropertyNames.SmsApiSid].ToString();
            }
            set
            {
                this[PropertyNames.SmsApiSid] = value;
            }
        }

        /// <summary>
        /// The SMS Api token.
        /// </summary>
        [ConfigurationProperty(PropertyNames.SmsApiToken, IsRequired = true)]
        public string SmsApiToken
        {
            get
            {
                return this[PropertyNames.SmsApiToken].ToString();
            }
            set
            {
                this[PropertyNames.SmsApiToken] = value;
            }
        }

        /// <summary>
        /// The SMS Api number.
        /// </summary>
        [ConfigurationProperty(PropertyNames.SmsApiNumber, IsRequired = true)]
        public string SmsApiNumber
        {
            get
            {
                return this[PropertyNames.SmsApiNumber].ToString();
            }
            set
            {
                this[PropertyNames.SmsApiNumber] = value;
            }
        }

        /// <summary>
        /// The phone numbers.
        /// </summary>
        [ConfigurationProperty(PropertyNames.Recipients, IsRequired = true)]
        [ConfigurationCollection(typeof(RecipientPhoneCollectionConfiguration), AddItemName = PropertyNames.Recipient)]
        public RecipientPhoneCollectionConfiguration Recipients
        {
            get
            {
                RecipientPhoneCollectionConfiguration recipientsCollection =
                (RecipientPhoneCollectionConfiguration)base[PropertyNames.Recipients];

                return recipientsCollection;
            }
            set
            {
                RecipientPhoneCollectionConfiguration recipients = value;
            }
        }

        /// <summary>
        /// The property names.
        /// </summary>
        public static class PropertyNames
        {
            /// <summary>
            /// The logs folder.
            /// </summary>
            public const string FolderLog = "folderlog";

            /// <summary>
            /// The timer interval.
            /// </summary>
            public const string TimerInterval = "timerinterval";

            /// <summary>
            /// The sms enabled boolean.
            /// </summary>
            public const string SmsEnabled = "smsenabled";

            /// <summary>
            /// The SMS Api Sid.
            /// </summary>
            public const string SmsApiSid = "smsapisid";

            /// <summary>
            /// The SMS Api token.
            /// </summary>
            public const string SmsApiToken = "smsapitoken";

            /// <summary>
            /// The SMS Api number.
            /// </summary>
            public const string SmsApiNumber = "smsapinumber";

            /// <summary>
            /// The recipients phones.
            /// </summary>
            public const string Recipients = "recipients";

            /// <summary>
            /// The recipient phone.
            /// </summary>
            public const string Recipient = "recipient";
        }
    }
}
