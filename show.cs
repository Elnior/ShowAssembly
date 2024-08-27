using Shower;
using System;
using System.IO;
using System.Drawing;
using Shower.Handlers;
using System.Reflection;
using System.Collections;
using Shower.IconStoraged;
using System.Windows.Forms;
using System.Runtime.InteropServices;
// Assembly type: EXE
// Assembly Data:
[assembly: AssemblyTitle("Show Assembly")]
[assembly: AssemblyDescription("Show Assembly EXE and DLL")]
[assembly: AssemblyProduct("Show Assembly")]
[assembly: AssemblyCopyright("Elnior Loreh")]
[assembly: AssemblyTrademark("Show Assembly")]
[assembly: AssemblyCompany("Oxoh")]
[assembly: AssemblyConfiguration("None")]
[assembly: AssemblyVersion("1.0.0.0")]

namespace Shower
{
	public enum NotifyType : byte
	{
		Info,
		Warn,
		Question,
		Error,
		Stop

	}
	internal sealed class ViewAssembly : Form
	{
		public static FontFamily FIRST = FontFamily.GenericMonospace;
		public static FontFamily SECOND = FontFamily.GenericSerif;

		public Button loadAssemblyButton;
		public string dirActual;
		public Graphics graphyInterface;
		public ViewAssembly (string text, Icon data)
		{
			this.dirActual = Directory.GetCurrentDirectory();
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
			this.AutoSize = false;
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
		public static DialogResult Notifying (NotifyType nType, string title, string message)
		{
			DialogResult repply = DialogResult.None;
			if (nType == NotifyType.Info)
				// Info..
				repply = MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

			else if (nType == NotifyType.Warn)
				// Warn..
				repply = MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);

			else if (nType == NotifyType.Question)
				// Question..
				repply = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			else if (nType == NotifyType.Stop)
			// Stop..
			repply = MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Stop);

			else 
			 	// Error..
				repply = MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

			return repply;
		}
		public void OnClick (object originator, EventArgs Arguments)
		{
			Graphics graphy = this.graphyInterface;
			// control.
			Button control = this.loadAssemblyButton;
			control.Hide();
			control = new Button();

			control.Text = "<<Back";
			control.Font = new Font(FIRST, Single.Parse("20"));
			
			SizeF measure = graphy.MeasureString(control.Text + "W", control.Font);
			/* Static Styles */
			// Box Properties:
			control.BackColor = Color.White;
			control.ForeColor = Color.Black;
			control.Padding = new Padding(0, 0, 0, 0);
			control.Margin = new Padding(0, 0, 0, 0);
			// Using Cursor:
			control.UseWaitCursor = false;	

			control.Width = (int)measure.Width + 1;
			control.Height = (int)measure.Height + 5;
			// Position:
			control.Top = 10;
			control.Left = 10;

			this.Text = "Select file";
			this.Controls.Add(control);

			int down = control.Height + 10 + control.Top;

			ArrayList labelsInserted = new ArrayList();
			EventHandler delegation = delegate(object of, EventArgs evArgs) {};

			delegation = delegate (object obj, EventArgs details) 
			{
				Label elementClicked = (Label)obj;
				string partialDir = elementClicked.Text;
				foreach (Label label in labelsInserted)
				{
					label.Dispose();
					this.Controls.Remove(label);
				}
				// tengo que lograr hacer pruebas de acceso para evitar excepciones. (Logrado!)
				if (this.dirActual == "")
				{
					if (Directory.Exists(partialDir))
					{
						this.Controls.Add(control);
						this.dirActual = partialDir;
						labelsInserted = With.setContext(this, down, delegation);
					}
					else 
					{
						string[] logicalDrives = Directory.GetLogicalDrives();
						labelsInserted = With.setContext(this, down, delegation, logicalDrives);	
						Notifying(NotifyType.Warn, "Warning:", "The " + partialDir + " Drive is not found!");
					}
				}
				else 
				{
					if (elementClicked.BackColor == Color.Green)
					{
						string completePath = "";
						if (this.dirActual[this.dirActual.Length-1]== '\\')
							completePath = this.dirActual + partialDir;
						else
							completePath = this.dirActual + "\\" + partialDir;
						this.dirActual = completePath;
					}
					else 
					{
						string completePath = "";
						if (this.dirActual[this.dirActual.Length-1]== '\\')
							completePath = this.dirActual + partialDir;
						else
							completePath = this.dirActual + "\\" + partialDir;
						
						if (File.Exists(completePath)) 
							viewAll(completePath, partialDir);
						else 
							Notifying(NotifyType.Stop, "Read Message:", partialDir + " does not exist");
					}
					labelsInserted = With.setContext(this, down, delegation);
				}
			};

			labelsInserted = With.setContext(this, down, delegation);

			control.Click += delegate (object Gn, EventArgs EvArg)
			{
				DirectoryInfo parent = Directory.GetParent(this.dirActual);
				if (parent != null) 
				{
					string next = parent.FullName;
					foreach (Label label in labelsInserted)
					{
						label.Dispose();
						this.Controls.Remove(label);
					}
					this.dirActual = next;

					labelsInserted = With.setContext(this, down, delegation);
				}
				else
				{
					this.Controls.Remove(control);
					this.dirActual = "";
					string[] logicalDrives = Directory.GetLogicalDrives();

					foreach (Label label in labelsInserted)
					{
						label.Dispose();
						this.Controls.Remove(label);
					}

					labelsInserted = With.setContext(this, down, delegation, logicalDrives);	
				}
			};
		}

		public static void OnClosingEvent (object Originator, FormClosingEventArgs args)
		{
			DialogResult result;
			result = Notifying(NotifyType.Question, "Question:", "Do you want close?");
			if (result == DialogResult.Yes)
				args.Cancel = false;
			else
				args.Cancel = true;
		}
		public static void viewAll (string path, string name)
		{
			try 
			{
				Assembly assem = Assembly.LoadFrom(path);
				Console.WriteLine(name + " a valid assembly");
				/*foreach (var element in assem.GetTypes()) 
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
				}*/
			}
			catch (Exception anyException)
			{
				if (anyException is BadImageFormatException)
					Notifying(NotifyType.Error, "Error:", "\'" + name + "\' file is not a valid assembly");
				else if (anyException is FileLoadException)
					Notifying(NotifyType.Stop, "Falied Load:", "The \'" + name + "\' file cannot be loaded because it is in use by another process.");
				else 
					Notifying(NotifyType.Stop, "Falied:", "An error occurred while inspecting the \'" + name + "\' file.");
			}
		}
		static int Main (params string[] Args)
		{
			try 
			{
				ViewAssembly see;
				MemoryStream created;
				
				Console.ForegroundColor = ConsoleColor.Yellow;
				created = new MemoryStream(IconSaved.getData());
				
				see = new ViewAssembly("Show Assembly: ", new Icon(created));
				see.graphyInterface = see.CreateGraphics();

				// Add Events Managers
				// see.FormClosing += new FormClosingEventHandler(OnClosingEvent);
				
				Button button = see.loadAssemblyButton;
				// the Click event.
				button.Click += new EventHandler(see.OnClick);
				
				button.Text = "Load Assembly";
				button.Font = new Font(SECOND, Single.Parse("20"));
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
				SizeF measure = see.graphyInterface.MeasureString(button.Text + "W", button.Font);
				
				RefreshStyles(see, measure);

				see.Resize += delegate (object origin, EventArgs args)
				{
					RefreshStyles(see, measure);
				};				
				Application.Run(see);
				// ShowMembers( typeof(File) );
				// Console.WriteLine();
			}
			catch (Exception exception)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				MessageBox.Show("Success Error (0x0001): Checkout source..");
				Console.WriteLine("Success Error (0x0001): " + exception);
			}
			finally 
			{
				Console.ResetColor();
			}			
			return 0;
		}
		static void ShowMembers<TSelected> ()
		{
			MemberInfo[] members;
			members = typeof(TSelected).GetProperties();

			Console.ForegroundColor = ConsoleColor.Cyan;
			foreach (MemberInfo member in members)
				Console.WriteLine("\r\n" + member);

			Console.ResetColor();
		}
		static void ShowMembers (Type selected)
		{
			MemberInfo[] members;
			// members = selected.GetMembers(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			members = selected.GetMembers();


			Console.ForegroundColor = ConsoleColor.Cyan;
			foreach (MemberInfo member in members)
				Console.WriteLine("\r\n" + member);

			Console.ResetColor();
		}
	}
}