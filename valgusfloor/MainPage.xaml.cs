namespace valgusfloor;

public partial class MainPage : ContentPage
{
    private bool _isOn = false;
    private bool _redLightOn = false;
    private bool _yellowLightOn = false;
    private bool _greenLightOn = false;

    public MainPage()
    {
        InitializeComponent();

        // Добавляем жесты для каждой лампы
        RedLight.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(OnRedLightTapped) });
        YellowLight.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(OnYellowLightTapped) });
        GreenLight.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(OnGreenLightTapped) });
    }

    private void OnSwitchOnClicked(object sender, EventArgs e)
    {
        _isOn = true;
        StatusLabel.Text = "Светофор включен";
        ResetLights();
    }

    private void OnSwitchOffClicked(object sender, EventArgs e)
    {
        _isOn = false;
        StatusLabel.Text = "Светофор выключен";
        ResetLights();
    }

    private void ResetLights()
    {
        _redLightOn = false;
        _yellowLightOn = false;
        _greenLightOn = false;

        RedLight.BackgroundColor = Colors.Gray;
        YellowLight.BackgroundColor = Colors.Gray;
        GreenLight.BackgroundColor = Colors.Gray;
    }

    private void OnRedLightTapped()
    {
        if (_isOn)
        {
            _redLightOn = !_redLightOn;
            RedLight.BackgroundColor = _redLightOn ? Colors.Red : Colors.Gray;
            StatusLabel.Text = _redLightOn ? "Стой!" : "Светофор включен";
        }
        else
        {
            StatusLabel.Text = "Сначала включи светофор";
        }
    }

    private void OnYellowLightTapped()
    {
        if (_isOn)
        {
            _yellowLightOn = !_yellowLightOn;
            YellowLight.BackgroundColor = _yellowLightOn ? Colors.Yellow : Colors.Gray;
            StatusLabel.Text = _yellowLightOn ? "Жди..." : "Светофор включен";
        }
        else
        {
            StatusLabel.Text = "Сначала включи светофор";
        }
    }

    private void OnGreenLightTapped()
    {
        if (_isOn)
        {
            _greenLightOn = !_greenLightOn;
            GreenLight.BackgroundColor = _greenLightOn ? Colors.Green : Colors.Gray;
            StatusLabel.Text = _greenLightOn ? "Пошли" : "Светофор включен";
        }
        else
        {
            StatusLabel.Text = "Сначала включи светофор";
        }
    }

    // Новый метод для сброса всех огней
    private void OnResetButtonClicked(object sender, EventArgs e)
    {
        ResetLights();
        StatusLabel.Text = "Все огни сброшены";
    }
}
