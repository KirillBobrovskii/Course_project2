﻿#pragma checksum "..\..\..\Pages\Pays.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C4ACA07AA44B633078929CA827E8BCACAE5390D9FDECBD4AADB5CB22FD318491"
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
    /// Pays
    /// </summary>
    public partial class Pays : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 20 "..\..\..\Pages\Pays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition PaysGridSplitter;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Pages\Pays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition PaysColumnChange;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Pages\Pays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox PaysFilterComboBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Pages\Pays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PaysFilterTextBox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Pages\Pays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PaysGrid;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Pages\Pays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PaysLabel;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Pages\Pays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox StudentsPay;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\Pages\Pays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Pay;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\Pages\Pays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker PayDate;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\Pages\Pays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PaysCommit;
        
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
            System.Uri resourceLocater = new System.Uri("/Wpf_DataBase_Hostel_App;component/pages/pays.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Pays.xaml"
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
            
            #line 9 "..\..\..\Pages\Pays.xaml"
            ((Wpf_DataBase_Hostel_App.Pages.Pays)(target)).Loaded += new System.Windows.RoutedEventHandler(this.PaysPage_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PaysGridSplitter = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 3:
            this.PaysColumnChange = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 4:
            
            #line 27 "..\..\..\Pages\Pays.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PaysAddButton);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 28 "..\..\..\Pages\Pays.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PaysCopyButton);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 29 "..\..\..\Pages\Pays.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PaysEditButton);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 30 "..\..\..\Pages\Pays.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PaysDeleteButton);
            
            #line default
            #line hidden
            return;
            case 8:
            this.PaysFilterComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.PaysFilterTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\..\Pages\Pays.xaml"
            this.PaysFilterTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.PaysFilterTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.PaysGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 13:
            this.PaysLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.StudentsPay = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 15:
            this.Pay = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.PayDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 17:
            this.PaysCommit = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\..\Pages\Pays.xaml"
            this.PaysCommit.Click += new System.Windows.RoutedEventHandler(this.PaysCommitButton);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 94 "..\..\..\Pages\Pays.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PaysRollbackButton);
            
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
            
            #line 48 "..\..\..\Pages\Pays.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PaysEditButton);
            
            #line default
            #line hidden
            break;
            case 12:
            
            #line 49 "..\..\..\Pages\Pays.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PaysDeleteButton);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

