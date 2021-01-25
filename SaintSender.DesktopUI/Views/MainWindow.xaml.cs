﻿using System;
using SaintSender.DesktopUI.ViewModels;
using SaintSender.DesktopUI.Views;
using System.Windows;
using SaintSender.Core.Models;

namespace SaintSender.DesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _vm;
        private Account _account;

        public MainWindow()
        {
            // set DataContext to the ViewModel object
            _vm = new MainWindowViewModel();
            LoginProcedure();
            InitializeComponent();
        }

        private void LoginProcedure()
        {
            if (Account.SavedCredentialsFound())
            {
                Account account = Account.LoadCredentials();
                if (!account.RememberUserCredentials)
                {
                    AskForLogin();
                }
            }
            else
            {
                AskForLogin();
            }
        }

        private void AskForLogin()
        {
            new LoginWindow().ShowDialog();
        }

        private void GreetBtn_Click(object sender, RoutedEventArgs e)
        {
            // dispatch user interaction to view model
            _vm.Greet();
        }
    }
}