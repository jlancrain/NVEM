using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Threading;

namespace ShortsCombinator.Common
{
    /// <summary>
    /// Represents a ThreadSafe Data Collection that provides change notifications
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ThreadSafeObservableCollection<T> : ObservableCollection<T>
    {
        public override event NotifyCollectionChangedEventHandler CollectionChanged;

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            try
            {
                NotifyCollectionChangedEventHandler CollectionChanged = this.CollectionChanged;
                if (CollectionChanged != null)
                {
                    foreach (NotifyCollectionChangedEventHandler handler in CollectionChanged.GetInvocationList())
                    {
                        DispatcherObject dispObj = handler.Target as DispatcherObject;
                        if (dispObj != null)
                        {
                            Dispatcher dispatcher = dispObj.Dispatcher;
                            if (dispatcher != null && !dispatcher.CheckAccess())
                            {
                                dispatcher.BeginInvoke(
                                    (Action)(() => handler.Invoke(this,
                                        new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))),
                                    DispatcherPriority.DataBind);
                                continue;
                            }
                        }
                        handler.Invoke(this, e);
                    }
                }
            }
            catch (Exception ex)
            {
                var exception = ex;
            }

        }
    }
}
