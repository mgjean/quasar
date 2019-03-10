﻿using System;
using System.Windows;
using System.Windows.Controls;
using Dynamo.Wpf.Extensions;

namespace QuasarExtension
{
    public class QuasarExtension : IViewExtension
    {
        private MenuItem Quasar;
        private MenuItem NodesInGraph;


        public void Dispose() { }

        public void Startup(ViewStartupParams startup)
        {
            
        }

        public void Loaded(ViewLoadedParams loaded)
        {
            Quasar = new MenuItem { Header = "Quasar" };
            NodesInGraph = new MenuItem { Header = "Nodes In Graph" };
            NodesInGraph.Click += (sender, args) =>
            {
                var viewModel = new QuasarWindowViewModel(loaded);
                var window = new QuasarWindow
                {
                    MainGrid = { DataContext = viewModel },
                    Owner = loaded.DynamoWindow
                };
                window.Left = window.Owner.Left + 300;
                window.Top = window.Owner.Top + 250;
                window.Show();
            };
            Quasar.Items.Add(NodesInGraph);
            loaded.dynamoMenu.Items.Add(Quasar);
        }
        public void Shutdown() { }

        public string UniqueId
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }
        public string Name
        {
            get
            {
                return "Quasar Extension";
            }
        }

    }
}