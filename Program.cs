using System;
using Gtk;

static class ProjectedRaisesGUI
{
    static void Main()
    {
        Application.Init();

        // new window
        var window = new Window("projected increase");
        window.SetDefaultSize(300, 150);
        window.DeleteEvent += delegate { Application.Quit(); };

        // Layout
        var vbox = new Box(Orientation.Vertical, 5);
        var input_label = new Label("enter salary:");
        var salary_entry = new Entry();
        var calculate_button = new Button("calculate new salary");
        var result_label = new Label();

        // Add widgets
        vbox.PackStart(input_label, false, false, 5);
        vbox.PackStart(salary_entry, false, false, 5);
        vbox.PackStart(calculate_button, false, false, 5);
        vbox.PackStart(result_label, false, false, 5);
        window.Add(vbox);

        // button click functionality
        calculate_button.Clicked += (sender, e) =>
        {
            if (double.TryParse(salary_entry.Text, out double salary))
            {
                // Calculate the projected salary
                double projectedSalary = salary * 1.04;
                result_label.Text = $"next year salary: ${projectedSalary:F2} (4% increase) (get that bread)";
            }
            else
            {
                result_label.Text = "you get paid like that? try entering a dollar amount.";
            }
        };

        // Show widgets
        window.ShowAll();

        Application.Run();
    }
}

