using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Contracts;
using NLog;
using yesmarket.Initialisation;

namespace Domain
{
    public class NotificationRequestConsumer : IInitialiser, INotificationRequestConsumer
    {
        private readonly ILogger _logger;
        //private readonly IEnumerable<INotifier> _notifiers;

        private readonly BlockingCollection<KeyValuePair<Guid, Payload>> _payloads =
            new BlockingCollection<KeyValuePair<Guid, Payload>>();

        public NotificationRequestConsumer(
            ILogger logger
            //,IEnumerable<INotifier> notifiers
            )
        {
            _logger = logger;
            //_notifiers = notifiers;
        }

        public void Initialise()
        {
            Task.Factory.StartNew(
                async () => { await StartConsuming(); },
                TaskCreationOptions.LongRunning);
        }

        public void QueueNotificationRequest(Guid notificationId, Payload payload)
        {
            _payloads.TryAdd(new KeyValuePair<Guid, Payload>(notificationId, payload));
        }

        public async Task StartConsuming()
        {
            //var throttler = new SemaphoreSlim(3, 3);
            //foreach (var keyValuePair in _payloads.GetConsumingEnumerable())
            //{
            //    await throttler.WaitAsync();
            //    var notificationId = keyValuePair.Key;
            //    var payload = keyValuePair.Value;
            //    //the semaphore will take care of asyncrony;
            //    // ReSharper disable once CSharpWarnings::CS4014
            //    Task.Factory.StartNew(
            //        async () =>
            //        {
            //            try
            //            {
            //                var notifier =
            //                    _notifiers.Where(
            //                        notifier1 =>
            //                            notifier1.GetType() == typeof (INotifier<>).MakeGenericType(payload.GetType()));

            //                if (notifier != null)
            //                {
            //                    try
            //                    {
            //                        await notifier.Notify(notificationId, payload);
            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        _logger.ErrorException(ex.Message, ex);
            //                    }
            //                }
            //                else
            //                {
            //                    _logger.Warn(
            //                        "Failed to locate a notifier instance that matches the specified payload type.");
            //                }
            //            }
            //            finally
            //            {
            //                throttler.Release();
            //            }
            //        });
            //}
        }
    }
}