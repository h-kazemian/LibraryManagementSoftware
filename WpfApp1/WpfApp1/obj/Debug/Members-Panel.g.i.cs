﻿#pragma checksum "..\..\Members-Panel.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "99FAF021C1D970DBCBEC1B362E4CA19E16BAF20E7A8D8A8E36FEA6DCE9AE8048"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
using WpfApp1;


namespace WpfApp1 {
    
    
    /// <summary>
    /// Members_Panel
    /// </summary>
    public partial class Members_Panel : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\Members-Panel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem MenuTab;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Members-Panel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MBooks;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Members-Panel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MyBooks;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Members-Panel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Subscription;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Members-Panel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MWallet;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Members-Panel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MEditInformation;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\Members-Panel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MExit;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/members-panel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Members-Panel.xaml"
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
            this.MenuTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 2:
            this.MBooks = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\Members-Panel.xaml"
            this.MBooks.Click += new System.Windows.RoutedEventHandler(this.Books_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MyBooks = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\Members-Panel.xaml"
            this.MyBooks.Click += new System.Windows.RoutedEventHandler(this.MyBooks_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Subscription = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\Members-Panel.xaml"
            this.Subscription.Click += new System.Windows.RoutedEventHandler(this.Subscription_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.MWallet = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\Members-Panel.xaml"
            this.MWallet.Click += new System.Windows.RoutedEventHandler(this.Wallet_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.MEditInformation = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\Members-Panel.xaml"
            this.MEditInformation.Click += new System.Windows.RoutedEventHandler(this.EditInformation_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.MExit = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\Members-Panel.xaml"
            this.MExit.Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

