using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace MTWPToolkit.Controls {
    /// <summary>
    /// Add DataRequest event ，when LonglistSelector scroll to end
    /// raise DataRequeset event to notifity load next page data
    /// </summary>
    public class MTLonglistselector : LongListSelector {
        private const int Offset = 2;

        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register("IsLoading", typeof(bool), typeof(MTLonglistselector),
                new PropertyMetadata(default(bool)));

        public MTLonglistselector() {
            ItemRealized += OnItemRealized;
        }

        public bool IsLoading {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        public event EventHandler DataRequest;

        protected virtual void OnDataRequest() {
            EventHandler handler = DataRequest;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void OnItemRealized(object sender, ItemRealizationEventArgs itemRealizationEventArgs) {
            if (!IsLoading && ItemsSource != null && ItemsSource.Count >= Offset) {
                if (itemRealizationEventArgs.ItemKind == LongListSelectorItemKind.Item) {
                    object offsetItem = ItemsSource[ItemsSource.Count - Offset];
                    if ((itemRealizationEventArgs.Container.Content == offsetItem)) {
                        OnDataRequest();
                    }
                }
            }
        }
    }
}