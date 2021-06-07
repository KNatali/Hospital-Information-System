using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS
{
    public class ToolTipBehavior
    {
        public static Boolean GetIsToolTipEnabled(FrameworkElement obj)
        {
            return (Boolean)obj.GetValue(ToolTipEnabledProperty);
        }

        public static void SetToolTipEnabled(FrameworkElement obj, Boolean value)
        {
            obj.SetValue(ToolTipEnabledProperty, value);
        }

        public static readonly DependencyProperty ToolTipEnabledProperty = DependencyProperty.RegisterAttached(
            "IsToolTipEnabled",
            typeof(Boolean),
            typeof(ToolTipBehavior),
            new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.Inherits, (sender, e) =>
            {
                FrameworkElement element = sender as FrameworkElement;
                if (element != null)
                {
                    element.SetValue(ToolTipService.IsEnabledProperty, e.NewValue);
                }
            }));
    }
}

