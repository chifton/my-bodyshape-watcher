// ===============================
// *******************************
// The recipient phone element configuration class.
// ===============================
// *******************************

namespace MyBodyShape.Watcher.Configuration.Impl
{
    using System.Configuration;

    /// <summary>
    /// The recipient phone element configuration class.
    /// </summary>
    public class RecipientPhoneElementConfiguration : ConfigurationElement
    {
        /// <summary>
        /// The phone.
        /// </summary>
        [ConfigurationProperty(PropertyNames.Phone, IsRequired = true)]
        public string Phone
        {
            get
            {
                return (string)this[PropertyNames.Phone];
            }
            set
            {
                this[PropertyNames.Phone] = value;
            }
        }

        /// <summary>
        /// The property names.
        /// </summary>
        public static class PropertyNames
        {
            /// <summary>
            /// The phone attribute.
            /// </summary>
            public const string Phone = "phone";
        }
    }
}