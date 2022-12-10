
namespace AdventOfCode.Day10
{
	public class Crt : IDisposable
	{
		private int _spritePosition = 1;
		private int _pixelPositionRow = 0;
		private int _pixelPositionColumn = 0;
		private char[,] _screen = new char[6,40];
		public Crt() 
		{
			Registry.GetInstance().OnRegistryUpdated += Crt_OnRegistryUpdated;
			ClockCircuit.GetInstance().OnCycle += Crt_OnCycle;
		}

		public void Print()
		{
			for (var row = 0; row < 6; row++)
			{
				for (var column = 0; column < 39; column++)
				{
					Console.Write(_screen[row, column]);
				}
				Console.WriteLine();
			}
		}

		private void Crt_OnRegistryUpdated(object? sender, RegistryUpdatedEventArgs e)
		{
			_spritePosition = e.X;
		}

		private void Crt_OnCycle(object? sender, EventArgs e)
		{
			Draw();
		}

		private void Draw()
		{
			var toDraw = '.';
			if (_spritePosition == _pixelPositionColumn || _spritePosition - 1 == _pixelPositionColumn || _spritePosition + 1 == _pixelPositionColumn)
			{
				toDraw = '#';
			}
			_screen[_pixelPositionRow, _pixelPositionColumn] = toDraw;
			_pixelPositionColumn++;
			if (_pixelPositionColumn > 39)
			{
				_pixelPositionColumn= 0;
				_pixelPositionRow++;
			}
		}

		public void Dispose()
		{
			ClockCircuit.GetInstance().OnCycle -= Crt_OnCycle;
			Registry.GetInstance().OnRegistryUpdated -= Crt_OnRegistryUpdated;
		}
	}
}