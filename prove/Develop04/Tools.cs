using System;
using System.Text;
using System.Threading;
public class Tools{

    private List<string> _reflectPrompts = new List<string>();
    private List<string> _reflectQuestions = new List<string>();
    private List<string> _listingPrompts = new List<string>();
    private List<string> _description = new List<string>();
    private int _currentAnimationFrame;
   

    public Tools(){
        //DESCRIPTIONS
        _description.Add("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
        _description.Add("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        _description.Add("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        //POPULATING THE REFLECTION PROMPTS
        _reflectPrompts.Add("Think of a time when you stood up for someone else.");
        _reflectPrompts.Add("Think of a time when you did something really difficult.");
        _reflectPrompts.Add("Think of a time when you helped someone in need.");
        _reflectPrompts.Add("Think of a time when you did something truly selfless.");

        //POPULATING THE REFLECTION QUESTION
        _reflectQuestions.Add("Why was this experience meaningful to you?");
        _reflectQuestions.Add("Have you ever done anything like this before?");
        _reflectQuestions.Add("How did you get started?");
        _reflectQuestions.Add("How did you feel when it was complete?");
        _reflectQuestions.Add("What made this time different than other times when you were not as successful?");
        _reflectQuestions.Add("What is your favorite thing about this experience?");
        _reflectQuestions.Add("What could you learn from this experience that applies to other situations?");
        _reflectQuestions.Add("What did you learn about yourself through this experience?");
        _reflectQuestions.Add("How can you keep this experience in mind in the future?");
        
        //POPULATING THE LISTING PROMPTS
        _listingPrompts.Add("Who are people that you appreciate?");
        _listingPrompts.Add("What are personal strengths of yours?");
        _listingPrompts.Add("Who are people that you have helped this week?");
        _listingPrompts.Add("When have you felt the Holy Ghost this month?");
        _listingPrompts.Add("Who are some of your personal heroes?");
    }

    public string Randomizer(int opc){
        Random rnd = new Random();
        List<string> listA = new List<string>();
        switch (opc){
           case 1: 
            listA = _reflectPrompts; 
            break;
           case 2: 
            listA = _reflectQuestions;
            break;
           case 3: 
            listA = _listingPrompts;
            break;
        }
        int index  = rnd.Next(0, listA.Count());
        //RETURNING THE STRING VALUE OF THE LIST FOR THE RANDOM INDEX
        return listA[index];
    }

    public string description(int opc){
        return _description[opc];
    }

    public void spinner(int repeat){
        for(int e=0;e<= repeat;e++){
            try {
                char[] spinner = new char[] { '|', '/', '-', '\\' };

                Console.WriteLine("");
                bool oldCursorVisibility = Console.CursorVisible;
                Console.CursorVisible = false;

                int spinnerCount = 0;
                int dotCount = 0;
                int dotPause = 0;

                // Account for scrolling behavior at bottom of screen
                var fudge = (Console.BufferHeight - Console.CursorTop == 1) ? 0 : 1;
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - fudge);

                for(int i=0;i<=8;i++)
                {
                    string spinnerText = string.Empty;
                    spinnerText = spinnerText.PadRight(dotCount, '.');
                    spinnerText = spinnerText.PadRight(4, ' ');
                    spinnerText += spinner[spinnerCount];

                    int x = Console.CursorLeft;
                    int y = Console.CursorTop;

                    Console.CursorLeft = (x - 5) >= 0 ? x - 5 : x;
                    Console.Write(spinnerText);

                    if (++spinnerCount > 3){
                        spinnerCount = 0;
                    }
                    if (++dotPause == 2)
                    {
                        dotPause = 0;
                        if (++dotCount == 4)
                            dotCount = 0;
                    }

                    Thread.Sleep(100);
                }

                var left = Console.CursorLeft;
                Console.CursorLeft = (left - 5) >= 0 ? left - 5 : left;
                Console.CursorVisible = oldCursorVisibility;
            } catch (Exception){
                Console.WriteLine("done");                   
            }   
        } 
    }

    public void Loader(int time){
        var timing = time * 50;
        using (var progress = new ProgressBar()) {
			for (int i = 0; i <= timing; i++) {
				progress.Report((double) i / timing);
				Thread.Sleep(20);
			}
		}
    }
}

public class ProgressBar : IDisposable, IProgress<double> {
	private const int blockCount = 10;
	private readonly TimeSpan animationInterval = TimeSpan.FromSeconds(1.0 / 8);
	private const string animation = @"|/-\";

	private readonly Timer timer;

	private double currentProgress = 0;
	private string currentText = string.Empty;
	private bool disposed = false;
	private int animationIndex = 0;

	public ProgressBar() {
		timer = new Timer(TimerHandler);

		// A progress bar is only for temporary display in a console window.
		// If the console output is redirected to a file, draw nothing.
		// Otherwise, we'll end up with a lot of garbage in the target file.
		if (!Console.IsOutputRedirected) {
			ResetTimer();
		}
	}

	public void Report(double value) {
		// Make sure value is in [0..1] range
		value = Math.Max(0, Math.Min(1, value));
		Interlocked.Exchange(ref currentProgress, value);
	}

	private void TimerHandler(object state) {
		lock (timer) {
			if (disposed) return;

			int progressBlockCount = (int) (currentProgress * blockCount);
			int percent = (int) (currentProgress * 100);
			string text = string.Format("[{0}{1}] {2,3}% {3}",
				new string('#', progressBlockCount), new string('-', blockCount - progressBlockCount),
				percent,
				animation[animationIndex++ % animation.Length]);
			UpdateText(text);

			ResetTimer();
		}
	}

	private void UpdateText(string text) {
		// Get length of common portion
		int commonPrefixLength = 0;
		int commonLength = Math.Min(currentText.Length, text.Length);
		while (commonPrefixLength < commonLength && text[commonPrefixLength] == currentText[commonPrefixLength]) {
			commonPrefixLength++;
		}

		// Backtrack to the first differing character
		StringBuilder outputBuilder = new StringBuilder();
		outputBuilder.Append('\b', currentText.Length - commonPrefixLength);

		// Output new suffix
		outputBuilder.Append(text.Substring(commonPrefixLength));

		// If the new text is shorter than the old one: delete overlapping characters
		int overlapCount = currentText.Length - text.Length;
		if (overlapCount > 0) {
			outputBuilder.Append(' ', overlapCount);
			outputBuilder.Append('\b', overlapCount);
		}

		Console.Write(outputBuilder);
		currentText = text;
	}

	private void ResetTimer() {
		timer.Change(animationInterval, TimeSpan.FromMilliseconds(-1));
	}

	public void Dispose() {
		lock (timer) {
			disposed = true;
			UpdateText(string.Empty);
		}
	}

}