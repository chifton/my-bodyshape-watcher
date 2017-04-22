// ===============================
// *******************************
// The recipient phone collection configuration class.
// ===============================
// *******************************

namespace MyBodyShape.Watcher.Configuration.Impl
{
    using System;
    using System.Configuration;

    /// <summary>
    /// The recipient phone collection configuration class.
    /// </summary>
    public class RecipientPhoneCollectionConfiguration : ConfigurationElementCollection
    {
        /// <summary>
        /// The create new element method.
        /// </summary>
        protected override ConfigurationElement CreateNewElement()
        {
            return new RecipientPhoneElementConfiguration();
        }

        /// <summary>
        /// The get element key method.
        /// </summary>
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((RecipientPhoneElementConfiguration) element).Phone;
        }
    }
}
