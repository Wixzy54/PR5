using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfDynamicControls
{
    public partial class MainWindow : Window
    {
        private List<UIElement> _controls;

        public MainWindow()
        {
            InitializeComponent();
            _controls = new List<UIElement>();
            MouseRightButtonDown += OnMouseRightButtonDown;
        }

        private void OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (UIElement control in _controls)
            {
                MainGrid.Children.Remove(control);
            }
            _controls.Clear();
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(MainGrid);
            if (e.Source == MainGrid)
            {
                if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                {
                    TextBox textBox = new TextBox();
                    textBox.Width = 100;
                    textBox.Margin = new Thickness(position.X, position.Y, 0, 0);
                    MainGrid.Children.Add(textBox);
                    _controls.Add(textBox);
                }
                else
                {
                    Button button = new Button();
                    button.Content = "Button";
                    button.Width = 100;
                    button.Margin = new Thickness(position.X, position.Y, 0, 0);
                    MainGrid.Children.Add(button);
                    _controls.Add(button);
                }
            }
        }
    }
}