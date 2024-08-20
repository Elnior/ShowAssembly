using System;
using System.IO;
using IconStoraged;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
// Assembly type: EXE
// Assembly Data:
[assembly: AssemblyTitle("Show Assembly")]
// [assembly: AssemblyKeyFile("key.snk")]
[assembly: AssemblyDescription("Show Assembly EXE and DLL")]
[assembly: AssemblyProduct("Show Assembly")]
[assembly: AssemblyCopyright("Elnior Loreh")]
[assembly: AssemblyTrademark("Show Assembly")]
[assembly: AssemblyCompany("Oxoh")]
[assembly: AssemblyConfiguration("None")]
[assembly: AssemblyVersion("1.0.0.0")]

namespace Shower
{
	internal sealed class ViewAssembly : Form
	{
		static FontFamily FIRST = FontFamily.Families[0];
		static FontFamily SECOND = FontFamily.Families[3];

		public Button loadAssemblyButton;
		public ViewAssembly (string text, Icon data)
		{
			this.Text = text;
			// Styles.
			this.Icon = data;
			//    BackColor and ForeColor
			this.BackColor = Color.Black;
			this.ForeColor = Color.White;

			this.MinimumSize = new Size(300, 400);
			// States
			this.ShowIcon = true;
			this.AllowTransparency = true;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.ShowInTaskbar = true;
			this.ControlBox = true;
			this.MaximizeBox = true;
			this.TopLevel = true;
			// Box Styles
			this.Margin = new Padding(0, 0, 0, 0);
			this.Padding = new Padding(0, 0, 0, 0);
			// the load assembly button
			this.loadAssemblyButton = new Button();

		}
		public static void RefreshStyles (ViewAssembly seeActual, SizeF measure)
		{
			Button button = seeActual.loadAssemblyButton;
			// button styles:
			button.Width = (int)measure.Width + 1;
			button.Height = (int)measure.Height + 5;
			// Position:
			button.Top = 10;
			button.Left = (seeActual.Width - button.Width)/2;
		}
		public  static void OnClick (object origin, EventArgs details)
		{
			Button control = (Button)origin;
			// control.
			Form form = control.FindForm();
			form.Controls.Remove(control);
			Console.WriteLine("Removed!");
			
		}
		public static void OnClosingEvent (object Originator, FormClosingEventArgs args)
		{
			DialogResult result;
			result = MessageBox.Show("Do you want close?", "Question:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			
			if (result == DialogResult.Yes)
				args.Cancel = false;
			else
				args.Cancel = true;

		}
		public static void viewAll (Assembly assem)
		{
			foreach (var element in assem.GetTypes()) 
				{
					Console.ForegroundColor = ConsoleColor.Green;

					string typeName = "Type : ";
					if (element.IsClass)
					{
						if (element.IsAbstract)
							typeName = "Abstract Class -> \u0020";
						else 
							typeName = "Class -> \u0020";
					}
					else if (element.IsInterface)
							typeName = "Interface -> \u0020";

					else if (element.IsEnum)
							typeName = "Enumeration -> \u0020";
					Console.Write(typeName);
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine(element + ":");

					MemberInfo[][] upScale;
					upScale = new MemberInfo[][]
					{
						element.GetMembers(BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod | BindingFlags.CreateInstance | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.ExactBinding | BindingFlags.SuppressChangeType | BindingFlags.OptionalParamBinding | BindingFlags.IgnoreReturn),
						element.GetMembers()
					};

					string allPosibles;
					allPosibles = "";

					foreach(MemberInfo[] members in upScale) 
					{
						foreach(MemberInfo actual in members) 
						{
							string ev;
							ev = actual.ToString();
							if (allPosibles.IndexOf(ev) == -1)
								allPosibles += ev + ",";
						}
					}
					string[] Posibles = allPosibles.Split(',');

					Console.ForegroundColor = ConsoleColor.Cyan;
					
					foreach (string posible in Posibles)
						Console.WriteLine("\u0020\u0020\u0020" + posible);

				}
		}
		internal static int Main (params string[] Args)
		{
			try 
			{
				ViewAssembly see;
				MemoryStream created;
				Graphics graphyCreated;
				
				Console.ForegroundColor = ConsoleColor.Yellow;
				created = new MemoryStream(IconSaved.getData());
				
				see = new ViewAssembly("Show Assembly", new Icon(created));
				graphyCreated = see.CreateGraphics();

				// Add Events Managers
				// see.FormClosing += new FormClosingEventHandler(OnClosingEvent);
				
				Button button = see.loadAssemblyButton;
				// the Click event.
				// button.Click += new EventHandler(OnClick);
				
				button.Text = "Load Assembly";
				button.Font = new Font(FIRST, Single.Parse("20"));
				/* Static Styles */
				// Box Properties:
				button.BackColor = Color.Green;
				button.ForeColor = Color.White;
				button.Padding = new Padding(0, 0, 0, 0);
				button.Margin = new Padding(0, 0, 0, 0);
				// Using Cursor:
				button.UseWaitCursor = false;				
				see.Controls.Add(button);
				// Dinamic Styles
				SizeF measure = graphyCreated.MeasureString(button.Text + "W", button.Font);
				
				RefreshStyles(see, measure);


				see.Resize += delegate (object origin, EventArgs args)
				{
					RefreshStyles(see, measure);
				};

				// ShowMembers<SizeF>();
				Application.Run(see);
				
			}
			catch (Exception exception)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Success Error (0x0001): " + exception);
			}
			finally 
			{
				Console.ResetColor();
			}			
			return Args.Length;
		}
		static void ShowMembers<TSelected> ()
		{
			MemberInfo[] members;
			members = typeof(TSelected).GetMembers();

			Console.ForegroundColor = ConsoleColor.Cyan;
			foreach (MemberInfo member in members)
				Console.WriteLine("\r\n" + member);

			Console.ResetColor();
		}
		static void ShowMembers (Type selected)
		{
			MemberInfo[] members;
			members = selected.GetMembers(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

			Console.ForegroundColor = ConsoleColor.Cyan;
			foreach (MemberInfo member in members)
				Console.WriteLine("\r\n" + member);

			Console.ResetColor();
		}
	}
}

