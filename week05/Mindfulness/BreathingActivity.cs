public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by guiding your breathing.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.Write("\nBreathe in... ");
            ShowCountDown(4);

            Console.Write("\nBreathe out... ");
            ShowCountDown(4);
        }

        DisplayEndingMessage();
    }
}