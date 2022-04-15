using ReactiveUI;

namespace Lab4.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		string output = "";
		string first;
		string second;
		string Operator = "";
		RomanNumberExtend num = new RomanNumberExtend("XIV");

		public MainWindowViewModel()
		{
			OnClickValue = ReactiveCommand.Create<string, string>((str) => Output += str);
			OnClickOper = ReactiveCommand.Create<string, string>((str) => Output = str);
		}

		public string Output
		{
			set
			{
				if ((value == "+" || value == "-" || value == "*" || value == "/") && Operator == "")
				{
					first = output;
					Operator = value;
					this.RaiseAndSetIfChanged(ref output, "");
				}
				else if (value == "=" && Operator != "")
				{
					second = output;
					var a = new RomanNumberExtend(first);
					var b = new RomanNumberExtend(second);


					switch (Operator)
					{
						case ("+"):
							value = (a + b).ToString();
							break;
						case ("-"):
							value = (a - b).ToString();
							break;
						case ("*"):
							value = (a * b).ToString();
							break;
						case ("/"):
							value = (a / b).ToString();
							break;
					}
					Operator = "";
					this.RaiseAndSetIfChanged(ref output, value);
				}
				else if ((value == "+" || value == "-" || value == "*" || value == "/") && Operator != "")
				{
					second = output;
					var a = new RomanNumberExtend(first);
					var b = new RomanNumberExtend(second);
					var O = value;

					switch (Operator)
					{
						case ("+"):
							first = (a + b).ToString();
							break;
						case ("-"):
							first = (a - b).ToString();
							break;
						case ("*"):
							first = (a * b).ToString();
							break;
						case ("/"):
							first = (a / b).ToString();
							break;
					}
					Operator = O;
					this.RaiseAndSetIfChanged(ref output, "");
				}
				else
					this.RaiseAndSetIfChanged(ref output, value);
			}
			get
			{
				return output;
			}
		}
		public ReactiveCommand<string, string> OnClickValue { get; }
		public ReactiveCommand<string, string> OnClickOper { get; }
	}

}