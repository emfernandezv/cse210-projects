using System;
using System.Text;
using System.Threading;
public class Tools{
    public void Loader(int seconds){
        //EACH REPETITION HAS 20, SO 1 SECOND = 50 *20 = 1000
        //HAVING THIS MIND, I NEED TO MULTIPLY EACH SECOND BY 50
        var timing = seconds * 50;
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
		if (!Console.IsOutputRedirected) {
			ResetTimer();
		}
	}

	public void Report(double value) {
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