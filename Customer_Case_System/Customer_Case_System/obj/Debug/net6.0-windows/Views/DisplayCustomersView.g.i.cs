﻿#pragma checksum "..\..\..\..\Views\DisplayCustomersView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B9039303802CA5A44B09C991C6A9329BE51B7732"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Customer_Case_System.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Customer_Case_System.Views {
    
    
    /// <summary>
    /// DisplayCustomersView
    /// </summary>
    public partial class DisplayCustomersView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\Views\DisplayCustomersView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvAddresses;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Views\DisplayCustomersView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDisplayAddresses;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Views\DisplayCustomersView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDisplayCustomers;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Views\DisplayCustomersView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvDisplayCustomer;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Customer_Case_System;component/views/displaycustomersview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\DisplayCustomersView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lvAddresses = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.btnDisplayAddresses = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\Views\DisplayCustomersView.xaml"
            this.btnDisplayAddresses.Click += new System.Windows.RoutedEventHandler(this.btnDisplayAddresses_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnDisplayCustomers = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\..\Views\DisplayCustomersView.xaml"
            this.btnDisplayCustomers.Click += new System.Windows.RoutedEventHandler(this.btnDisplayCustomers_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lvDisplayCustomer = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

