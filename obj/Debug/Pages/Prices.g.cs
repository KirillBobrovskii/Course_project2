﻿#pragma checksum "..\..\..\Pages\Prices.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0CC19C5D483E82431CA4B314148DB53EBBD17BBACD887D97F59D77C43C60738D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Wpf_DataBase_Hostel_App.Pages;


namespace Wpf_DataBase_Hostel_App.Pages {
    
    
    /// <summary>
    /// Prices
    /// </summary>
    public partial class Prices : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 20 "..\..\..\Pages\Prices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition PricesGridSplitter;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Pages\Prices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition PricesColumnChange;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Pages\Prices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox PricesFilterComboBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Pages\Prices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PricesFilterTextBox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Pages\Prices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PricesGrid;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Pages\Prices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PricesLabel;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Pages\Prices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PriceSum;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Pages\Prices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker PriceDate;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Pages\Prices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PricesCommit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Wpf_DataBase_Hostel_App;component/pages/prices.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Prices.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\Pages\Prices.xaml"
            ((Wpf_DataBase_Hostel_App.Pages.Prices)(target)).Loaded += new System.Windows.RoutedEventHandler(this.PricesPage_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PricesGridSplitter = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 3:
            this.PricesColumnChange = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 4:
            
            #line 27 "..\..\..\Pages\Prices.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PricesAddButton);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 28 "..\..\..\Pages\Prices.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PricesCopyButton);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 29 "..\..\..\Pages\Prices.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PricesEditButton);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 30 "..\..\..\Pages\Prices.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PricesDeleteButton);
            
            #line default
            #line hidden
            return;
            case 8:
            this.PricesFilterComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.PricesFilterTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\..\Pages\Prices.xaml"
            this.PricesFilterTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.PricesFilterTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.PricesGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 13:
            this.PricesLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.PriceSum = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            this.PriceDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 16:
            this.PricesCommit = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\Pages\Prices.xaml"
            this.PricesCommit.Click += new System.Windows.RoutedEventHandler(this.PricesCommitButton);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 71 "..\..\..\Pages\Prices.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PricesRollbackButton);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 11:
            
            #line 45 "..\..\..\Pages\Prices.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PricesEditButton);
            
            #line default
            #line hidden
            break;
            case 12:
            
            #line 46 "..\..\..\Pages\Prices.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PricesDeleteButton);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

