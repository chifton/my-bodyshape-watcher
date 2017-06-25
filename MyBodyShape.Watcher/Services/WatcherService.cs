// ===============================
// *******************************
// The watcher service.
// ===============================
// *******************************

namespace MyBodyShape.Watcher.Services
{
    using MyBodyShape.Watcher.Configuration;
    using MyBodyShape.Watcher.Configuration.Impl;
    using Twilio;
    using Serilog;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Timers;
    using Twilio.Rest.Api.V2010.Account;
    using Twilio.Types;

    /// <summary>
    /// The watcher service.
    /// </summary>
    public class WatcherService
    {
        /// <summary>
        /// The bodyshape watcher configuration
        /// </summary>
        private static IBodyShapeWatcherConfiguration configuration;

        /// <summary>
        /// The logger.
        /// </summary>
        private static ILogger logger;

        /// <summary>
        /// The phone recipients.
        /// </summary>
        private static List<string> phoneRecipients;

        /// <summary>
        /// The database context.
        /// </summary>
        private static BodyShapeContext dbContext;

        /// <summary>
        /// The stored generations guid.
        /// </summary>
        private static List<Guid> storedGuids;

        /// <summary>
        /// The Start method.
        /// </summary>
        public void Start()
        {
            try
            {
                // Configuration
                configuration = GetBodyShapeConfiguration();
                phoneRecipients = new List<string>();
                foreach (var rec in configuration.Recipients)
                {
                    phoneRecipients.Add(((RecipientPhoneElementConfiguration)rec).Phone);
                }

                // Twilio SMS client
                TwilioClient.Init(configuration.SmsApiSid, configuration.SmsApiToken);

                // The stored generations guid
                storedGuids = new List<Guid>();

                // Logger
                var path = Path.Combine(configuration.FolderLog, "bodyshapeWatcher-{Date}.txt");
                logger = new LoggerConfiguration()
                    .WriteTo.RollingFile(path, shared: true)
                    .CreateLogger();

                logger.Information("****************************  START  ****************************");
                logger.Information("Getting watcher configuration...");

                // Database context
                dbContext = new BodyShapeContext();
                logger.Information("Database context instanciated...");

                // Store bases generation guids
                storedGuids = dbContext.Generations.Select(d => d.Id).ToList();
                logger.Information("Storing bases generation guids...");

                // Timer
                var timer = new Timer();
                timer.Interval = configuration.TimerInterval * 1000; // To milliseconds
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
                logger.Information("Timer created...");

                // Wait...
                logger.Information("Waiting for new BodyShape users generations...");
            }
            catch(Exception ex)
            {
                logger.Error($"An error occured\n\t{ ex }");
            }
        }

        /// <summary>
        /// The Stop method.
        /// </summary>
        public void Stop()
        {
            storedGuids = new List<Guid>();
        }

        /// <summary>
        /// The timer elapsed event
        /// </summary>
        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                var newGenerations = dbContext.Generations.Select(p => p.Id).ToList();
                var diffGenerations = newGenerations.Where(u => !storedGuids.Contains(u)).ToList();
                if (diffGenerations.Any())
                {
                    // Build the records
                    var records = new List<Generations>();
                    foreach (var changeId in diffGenerations)
                    {
                        records.Add(dbContext.Generations.FirstOrDefault(b => b.Id == changeId));
                    }
                    logger.Information($"{ diffGenerations.Count } new generations were detected...");

                    // Send notification
                    if (configuration.SmsEnabled)
                    {
                        var resultsString = string.Empty;
                        foreach (var gen in records)
                        {
                            resultsString += "\n- Height : " + gen.Height + "cm ; Expected weight : " + (gen.ExpectedWeight.HasValue ? (gen.ExpectedWeight + " kgs") : " none") + "; Generated weight : " + gen.GeneratedWeight + " kgs ; Error : " + (gen.ErrorPercent.HasValue ? (Math.Round(Math.Abs(gen.ErrorPercent.Value) * 100).ToString() + " %; Success : ") : " none; Success : ") + (gen.Success.HasValue ? (gen.Success.Value + ".") : " none.");
                        }
                        var content = "New generations were made on bodyshapetests.com. Below are the results :" + resultsString + "\nThank you.\nThe BodyShape watcher";

                        foreach (var phone in phoneRecipients)
                        {
                            var message = MessageResource.CreateAsync(to: new PhoneNumber(phone), from: new PhoneNumber(configuration.SmsApiNumber), body: content).Result;
                        }
                    }

                    // Update the guids
                    storedGuids = newGenerations;

                    // Waiting
                    logger.Information("Waiting for new BodyShape users generations...");
                }
            }
            catch(Exception ex)
            {
                logger.Error($"An error occured\n\t{ ex }");
            }
        }

        /// <summary>
        /// The get bodyshape configuration method.
        /// </summary>
        /// <returns></returns>
        private static BodyShapeWatcherConfigurationSection GetBodyShapeConfiguration()
        {
            try
            {
                var config = ConfigurationManager.GetSection("watcher") as BodyShapeWatcherConfigurationSection;
                return config;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occured during getting bodyshape watcher configuration.\t\n" + ex);
            }
        }
    }
}
