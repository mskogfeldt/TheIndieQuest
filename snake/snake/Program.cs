namespace Lecture
{
	class Program
	{
		/* static variables */

		static System.Random sv_random = new System.Random();

		static Settings sv_settings;

		public static int sv_width = 80;

		public static int sv_height = 20;

		static int sv_snake_head_x;

		static int sv_snake_head_y;

		static int sv_snake_tail_length;

		static System.Collections.Generic.List<int> sv_snake_tail_x = new System.Collections.Generic.List<int>();

		static System.Collections.Generic.List<int> sv_snake_tail_y = new System.Collections.Generic.List<int>();

		static int sv_snake_direction_x;

		static int sv_snake_direction_y;

		static int sv_apple_x;

		static int sv_apple_y;

		static bool sv_game_over;

		static System.Collections.Generic.List<Score> sv_scores = new System.Collections.Generic.List<Score>();

		/* static methods */

		static void Main(string[] args)
		{
			System.Console.CursorVisible = false;

			LoadSettings();

			//LoadHighscores();

			DrawMap();

			SpawnSnake();

			SpawnApple();

			sv_game_over = false;

			while (!sv_game_over)
			{
				MoveSnake();

				System.Threading.Thread.Sleep(1000 / sv_settings.fps);

				var _snake_direction_x = sv_snake_direction_x;

				var _snake_direction_y = sv_snake_direction_y;

				while (System.Console.KeyAvailable)
				{
					var _key = System.Console.ReadKey(true);

					switch (_key.Key)
					{
						case System.ConsoleKey.LeftArrow:
							{
								if (sv_snake_direction_x != 1)
								{
									_snake_direction_x = -1;

									_snake_direction_y = 0;
								}
							}
							break;
						case System.ConsoleKey.RightArrow:
							{
								if (sv_snake_direction_x != -1)
								{
									_snake_direction_x = 1;

									_snake_direction_y = 0;
								}
							}
							break;
						case System.ConsoleKey.UpArrow:
							{
								if (sv_snake_direction_y != 1)
								{
									_snake_direction_x = 0;

									_snake_direction_y = -1;
								}
							}
							break;
						case System.ConsoleKey.DownArrow:
							{
								if (sv_snake_direction_y != -1)
								{
									_snake_direction_x = 0;

									_snake_direction_y = 1;
								}
							}
							break;
					}
				}

				sv_snake_direction_x = _snake_direction_x;

				sv_snake_direction_y = _snake_direction_y;
			}

			DrawGameOver();

			DrawHighscores();

			SaveHighscores();

			SaveSettings();

			System.Console.ReadKey();
		}

		static void Draw(int pv_x, int pv_y, char pv_char, System.ConsoleColor pv_background, System.ConsoleColor pv_foreground)
		{
			var _x = System.Console.CursorLeft;

			var _y = System.Console.CursorTop;

			var _background = System.Console.BackgroundColor;

			var _foreground = System.Console.ForegroundColor;

			System.Console.CursorLeft = pv_x;

			System.Console.CursorTop = pv_y;

			System.Console.BackgroundColor = pv_background;

			System.Console.ForegroundColor = pv_foreground;

			System.Console.Write(pv_char);

			System.Console.ForegroundColor = _foreground;

			System.Console.BackgroundColor = _background;

			System.Console.CursorTop = _y;

			System.Console.CursorLeft = _x;
		}

		static void DrawMap()
		{
			System.Console.Clear();

			System.Console.WriteLine($"╔{"".PadRight(sv_width - 2, '═')}╗");

			for (var _i = 0; _i < sv_height - 2; ++_i)
			{
				System.Console.WriteLine($"║{"".PadRight(sv_width - 2, ' ')}║");
			}

			System.Console.WriteLine($"╚{"".PadRight(sv_width - 2, '═')}╝");
		}

		static void SpawnSnake()
		{
			var _x = sv_random.Next(2, sv_width - 2);

			var _y = sv_random.Next(2, sv_height - 2);

			var _diff_x = (sv_width / 2.0 - _x - 0.5) / (sv_width / 2.0);

			var _diff_y = (sv_height / 2.0 - _y - 0.5) / (sv_height / 2.0);

			sv_snake_direction_x = System.Math.Abs(_diff_y) < System.Math.Abs(_diff_x) ? System.Math.Sign(_diff_x) : 0;

			sv_snake_direction_y = System.Math.Abs(_diff_y) < System.Math.Abs(_diff_x) ? 0 : System.Math.Sign(_diff_y);

			for (var _i = 0; _i < 3; ++_i)
			{
				++sv_snake_tail_length;

				sv_snake_tail_x.Add(_x);

				sv_snake_tail_y.Add(_y);

				Draw(_x, _y, 'O', System.ConsoleColor.Black, System.ConsoleColor.Green);

				_x += sv_snake_direction_x;

				_y += sv_snake_direction_y;
			}

			sv_snake_head_x = _x;

			sv_snake_head_y = _y;

			Draw(_x, _y, '@', System.ConsoleColor.Black, System.ConsoleColor.Green);
		}

		static void SpawnApple()
		{
			while (true)
			{
				var _x = sv_random.Next(1, sv_width - 1);

				var _y = sv_random.Next(1, sv_height - 1);

				var _is_valid = true;

				if (sv_snake_head_x == _x && sv_snake_head_y == _y)
				{
					_is_valid = false;
				}

				for (var _i = 0; _i < sv_snake_tail_length; ++_i)
				{
					if (sv_snake_tail_x[_i] == _x && sv_snake_tail_y[_i] == _y)
					{
						_is_valid = false;
					}
				}

				if (!_is_valid)
				{
					continue;
				}

				Draw(_x, _y, '@', System.ConsoleColor.Black, System.ConsoleColor.Red);

				sv_apple_x = _x;

				sv_apple_y = _y;

				break;
			}
		}

		static void MoveSnake()
		{
			var _x = sv_snake_head_x + sv_snake_direction_x;

			var _y = sv_snake_head_y + sv_snake_direction_y;

			if (_x == 0 || _x == sv_width - 1 || _y == 0 || _y == sv_height - 1)
			{
				sv_game_over = true;

				return;
			}

			if (IsSnake(_x, _y))
			{
				sv_game_over = true;

				return;
			}

			sv_snake_tail_x.Add(sv_snake_head_x);

			sv_snake_tail_y.Add(sv_snake_head_y);

			Draw(sv_snake_head_x, sv_snake_head_y, 'O', System.ConsoleColor.Black, System.ConsoleColor.Green);

			sv_snake_head_x = _x;

			sv_snake_head_y = _y;

			Draw(sv_snake_head_x, sv_snake_head_y, '@', System.ConsoleColor.Black, System.ConsoleColor.Green);

			if (sv_apple_x == _x && sv_apple_y == _y)
			{
				++sv_snake_tail_length;

				SpawnApple();
			}
			else
			{
				Draw(sv_snake_tail_x[0], sv_snake_tail_y[0], ' ', System.ConsoleColor.Black, System.ConsoleColor.Black);

				sv_snake_tail_x.RemoveAt(0);

				sv_snake_tail_y.RemoveAt(0);
			}
		}

		static bool IsSnake(int pv_x, int pv_y)
		{
			if (sv_snake_head_x == pv_x && sv_snake_head_y == pv_y)
			{
				return true;
			}

			for (var _i = 0; _i < sv_snake_tail_length; ++_i)
			{
				if (sv_snake_tail_x[_i] == pv_x && sv_snake_tail_y[_i] == pv_y)
				{
					return true;
				}
			}

			return false;
		}

		static void DrawGameOver()
		{
			var _window = new GameOverWindow() { iv_width = sv_width, iv_height = sv_height / 2 };

			_window.Draw();

			string name = System.Console.ReadLine();

			sv_scores.Add(new Score() { iv_points = sv_snake_tail_length, iv_name = name });

			sv_scores.Sort();

			sv_scores.Reverse();
		}

		static void DrawHighscores()
		{
			System.Console.CursorLeft = sv_width / 4;

			System.Console.CursorTop = sv_height / 4;

			System.Console.Write($"╔{"".PadRight(sv_width / 2 - 2, '═')}╗");

			for (var _i = 0; _i < sv_height / 2 - 2; ++_i)
			{
				System.Console.CursorLeft = sv_width / 4;

				System.Console.CursorTop = sv_height / 4 + 1 + _i;

				System.Console.Write($"║{"".PadRight(sv_width / 2 - 2, ' ')}║");
			}

			System.Console.CursorLeft = sv_width / 4;

			System.Console.CursorTop = sv_height / 4 + 1 + (sv_height / 2 - 2);

			System.Console.Write($"╚{"".PadRight(sv_width / 2 - 2, '═')}╝");

			System.Console.CursorLeft = sv_width / 2 - 5;

			System.Console.CursorTop = sv_height / 2 - 4;

			System.Console.Write("HIGHSCORES");

			for (int i = 0; i < 5 && i < sv_scores.Count; i++)
			{
				System.Console.CursorLeft = sv_width / 2 - 5 - 2;

				System.Console.CursorTop = sv_height / 2 - 4 + 2 + i;

				System.Console.Write($"{sv_scores[i].iv_name.PadRight(8, ' ')}  {sv_scores[i].iv_points.ToString().PadLeft(4, ' ')}");
			}
		}

		static void LoadSettings()
		{
			if (System.IO.File.Exists("settings.xml"))
			{
				var _stream = System.IO.File.OpenRead("settings.xml");

				var _serializer = new System.Xml.Serialization.XmlSerializer(typeof(Settings));

				sv_settings = _serializer.Deserialize(_stream) as Settings;

				_stream.Close();
			}
			else
			{
				sv_settings = new Settings();
			}
		}

		static void SaveSettings()
		{
			var _stream = System.IO.File.OpenWrite("settings.xml");

			var _serializer = new System.Xml.Serialization.XmlSerializer(typeof(Settings));

			_serializer.Serialize(_stream, sv_settings);

			_stream.Close();
		}

		static void LoadHighscores()
		{
			var _stream = System.IO.File.OpenRead("highscores.xml");

			/*var _reader = new System.IO.StreamReader(_stream);

			var _scores = _reader.ReadToEnd().Trim().Split('\n');

			for (var _i = 0; _i < _scores.Length; ++_i)
			{
				var _score = _scores[_i].Split(';');

				sv_scores.Add(new Score() { iv_points = System.Int32.Parse(_score[0]), iv_name = _score[1] });
			}

			_reader.Close();*/

			var _serializer = new System.Xml.Serialization.XmlSerializer(typeof(System.Collections.Generic.List<Score>));

			sv_scores = _serializer.Deserialize(_stream) as System.Collections.Generic.List<Score>;

			_stream.Close();
		}

		static void SaveHighscores()
		{
			var _stream = System.IO.File.OpenWrite("highscores.xml");

			/*var _writer = new System.IO.StreamWriter(_stream);

			for (var _i = 0; _i < sv_scores.Count; ++_i)
			{
				_writer.Write($"{sv_scores[_i].iv_points};{sv_scores[_i].iv_name}\n");
			}

			_writer.Close();*/

			var _serializer = new System.Xml.Serialization.XmlSerializer(typeof(System.Collections.Generic.List<Score>));

			_serializer.Serialize(_stream, sv_scores);

			_stream.Close();
		}
	}

	[System.Serializable]
	public class Settings
	{
		/* instance variables */

		public int fps = 10;
	}

	[System.Serializable]
	public class Score : System.IComparable<Score>
	{
		/* instance variables */

		public int iv_points;

		public string iv_name;

		/* instance methods */

		public int CompareTo(Score pv_object)
		{
			return iv_points.CompareTo(pv_object.iv_points);
		}
	}

	public abstract class Window
	{
		/* instance variables */

		public int iv_width;

		public int iv_height;

		/* instance methods */

		public virtual void Draw()
		{
			System.Console.CursorLeft = Program.sv_width / 2 - iv_width / 2;

			System.Console.CursorTop = Program.sv_height / 2 - iv_height / 2;

			System.Console.Write($"╔{"".PadRight(iv_width - 2, '═')}╗");

			for (var _i = 0; _i < iv_height - 2; ++_i)
			{
				System.Console.CursorLeft = Program.sv_width / 2 - iv_width / 2;

				System.Console.CursorTop = Program.sv_height / 2 - iv_height / 2 + 1 + _i;

				System.Console.Write($"║{"".PadRight(iv_width - 2, ' ')}║");
			}

			System.Console.CursorLeft = Program.sv_width / 2 - iv_width / 2;

			System.Console.CursorTop = Program.sv_height / 2 - iv_height / 2 + 1 + (Program.sv_height / 2 - 2);

			System.Console.Write($"╚{"".PadRight(iv_width - 2, '═')}╝");
		}
	}

	public class GameOverWindow : Window
	{
		/* instance methods */

		public override void Draw()
		{
			base.Draw();

			System.Console.CursorLeft = Program.sv_width / 2 - 5;

			System.Console.CursorTop = Program.sv_height / 2 - 1;

			System.Console.Write("GAME  OVER");

			System.Console.CursorLeft = Program.sv_width / 2 - 5 - 4;

			System.Console.CursorTop = Program.sv_height / 2 - 1 + 2;

			System.Console.Write($"Enter your name: ");
		}
	}

	public interface IWindow
	{
		int GetX();
	}
}