using System;
using Shower;
using System.IO;
using Shower.Utils;
using System.Drawing;
using Shower.Handlers;
using System.Collections;
using System.Windows.Forms;

namespace Shower.Handlers 
{
	internal static class With
	{
		public static int setNext (ref int pos, ViewAssembly form, int defaultTop, ArrayList list, EventHandler clickHandler, EventHandler previousHandler, string[][] Elements)
		{
			int down = defaultTop;
			// dir
			Label label = new Label();
			label.Text = form.dirActual;
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("20"));
			SizeF measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font);
			label.Top = down;
			label.Left = 5;
			label.Width = (int)measure.Width;
			label.Height = (int)measure.Height + 1;


			label.Padding = new Padding(0, 0, 0, 0);
			label.Margin = new Padding(0, 0, 0, 0);
			label.ForeColor = Color.Yellow;
			label.BackColor = Color.Gray;

			form.Controls.Add(label);
			list.Add(label);
			// Element for previous
			down = label.Height + 10 + label.Top; 
			label = new Label();
			label.Click += previousHandler;
			label.Text = "Previous";
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("20"));
			measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font);
			label.Top = down;
			label.Left = 10;
			label.Width = (int)measure.Width;
			label.Height = (int)measure.Height + 1;


			label.Padding = new Padding(0, 0, 0, 0);
			label.Margin = new Padding(0, 0, 0, 0);
			label.ForeColor = Color.White;
			label.BackColor = Color.Blue;

			form.Controls.Add(label);
			list.Add(label);

			string[] files = Elements[0],
				directories = Elements[1];

			byte admisible = 255;
			int index = 0;

			down = label.Height + 10 + label.Top;

			while (index < (int)admisible && pos < files.Length)
			{
					label = new Label(); // declared 
				label.Click += clickHandler;
				label.Text = NameProccessor.getName(files[pos++]);
				label.Font = new Font(ViewAssembly.FIRST, Single.Parse("18"));
					measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font); // declared 
				label.Top = down;
				label.Left = 10;
				label.Width = (int)measure.Width;
				label.Height = (int)measure.Height + 1;


				label.Padding = new Padding(0, 0, 0, 0);
				label.Margin = new Padding(0, 0, 0, 0);
				label.ForeColor = Color.White;
				label.BackColor = Color.Purple;
				down = label.Height + 10 + label.Top;
				form.Controls.Add(label);
				list.Add(label);
				index++;
			}
			int pos2 = 0;
			while (index < (int)admisible && pos2 < directories.Length)
			{
				label = new Label(); // declared 
				label.Click += clickHandler;
				label.Text = NameProccessor.getName(directories[pos2++]);
				label.Font = new Font(ViewAssembly.FIRST, Single.Parse("18"));
					measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font); // declared 
				label.Top = down;
				label.Left = 10;
				label.Width = (int)measure.Width;
				label.Height = (int)measure.Height + 1;

				label.Padding = new Padding(0, 0, 0, 0);
				label.Margin = new Padding(0, 0, 0, 0);
				label.ForeColor = Color.White;
				label.BackColor = Color.Green;
				down = label.Height + 10 + label.Top;
				form.Controls.Add(label);
				list.Add(label);
				pos++;
				index++;
			}
			return down;
		}
		public static int setPrevious (ref int pos, ViewAssembly form, int defaultTop, ArrayList list, EventHandler clickHandler, EventHandler previousHandler, string[][] Elements)
		{

			int down = defaultTop;
			// dir
			Label label = new Label();
			label.Text = form.dirActual;
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("20"));
			SizeF measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font);
			label.Top = down;
			label.Left = 5;
			label.Width = (int)measure.Width;
			label.Height = (int)measure.Height + 1;


			label.Padding = new Padding(0, 0, 0, 0);
			label.Margin = new Padding(0, 0, 0, 0);
			label.ForeColor = Color.Yellow;
			label.BackColor = Color.Gray;

			form.Controls.Add(label);
			list.Add(label);

			if (pos > 0)
			{
				// Element for previous
				down = label.Height + 10 + label.Top; 
				label = new Label();
				label.Click += previousHandler;
				label.Text = "Previous";
				label.Font = new Font(ViewAssembly.SECOND, Single.Parse("20"));
				measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font);
				label.Top = down;
				label.Left = 10;
				label.Width = (int)measure.Width;
				label.Height = (int)measure.Height + 1;


				label.Padding = new Padding(0, 0, 0, 0);
				label.Margin = new Padding(0, 0, 0, 0);
				label.ForeColor = Color.White;
				label.BackColor = Color.Blue;

				form.Controls.Add(label);
				list.Add(label);	
			}
			else {}
			
			string[] files = Elements[0],
				directories = Elements[1];

			byte admisible = 255;
			int index = 0;

			down = label.Height + 10 + label.Top;

			while (index < (int)admisible && pos < files.Length)
			{
					label = new Label(); // declared 
				label.Click += clickHandler;
				label.Text = NameProccessor.getName(files[pos++]);
				label.Font = new Font(ViewAssembly.FIRST, Single.Parse("18"));
					measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font); // declared 
				label.Top = down;
				label.Left = 10;
				label.Width = (int)measure.Width;
				label.Height = (int)measure.Height + 1;


				label.Padding = new Padding(0, 0, 0, 0);
				label.Margin = new Padding(0, 0, 0, 0);
				label.ForeColor = Color.White;
				label.BackColor = Color.Purple;
				down = label.Height + 10 + label.Top;
				form.Controls.Add(label);
				list.Add(label);
				index++;
			}
			int pos2 = 0;
			while (index < (int)admisible && pos2 < directories.Length)
			{
				label = new Label(); // declared 
				label.Click += clickHandler;
				label.Text = NameProccessor.getName(directories[pos2++]);
				label.Font = new Font(ViewAssembly.FIRST, Single.Parse("18"));
					measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font); // declared 
				label.Top = down;
				label.Left = 10;
				label.Width = (int)measure.Width;
				label.Height = (int)measure.Height + 1;

				label.Padding = new Padding(0, 0, 0, 0);
				label.Margin = new Padding(0, 0, 0, 0);
				label.ForeColor = Color.White;
				label.BackColor = Color.Green;
				down = label.Height + 10 + label.Top;
				form.Controls.Add(label);
				list.Add(label);
				pos++;
				index++;
			}
			return down;
		}
		public static ArrayList setContext (ViewAssembly form, int defaultTop, EventHandler clickHandler)
		{
			// the all labels.
			ArrayList All;
			All = new ArrayList();

			int down = defaultTop;

			Label label = new Label();
			label.Text = form.dirActual;
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("20"));
			SizeF measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font);
			label.Top = down;
			label.Left = 5;
			label.Width = (int)measure.Width;
			label.Height = (int)measure.Height + 1;


			label.Padding = new Padding(0, 0, 0, 0);
			label.Margin = new Padding(0, 0, 0, 0);
			label.ForeColor = Color.Yellow;
			label.BackColor = Color.Gray;

			form.Controls.Add(label);
			All.Add(label);

			down = label.Height + 10 + label.Top;
			
			string[] files, directories;

			try 
			{
				files = Directory.GetFiles(form.dirActual);
				directories = Directory.GetDirectories(form.dirActual);
			}
			catch (Exception anyException)
			{
				label = new Label(); // declared 
				label.Text = "Access denied!";
				label.Font = new Font(ViewAssembly.FIRST, Single.Parse("18"));
					measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font); // declared 
				label.Top = down;
				label.Left = 8;
				label.Width = (int)measure.Width;
				label.Height = (int)measure.Height + 1;


				label.Padding = new Padding(0, 0, 0, 0);
				label.Margin = new Padding(0, 0, 0, 0);
				label.ForeColor = Color.White;
				label.BackColor = Color.Red;
				down = label.Height + 10 + label.Top;
				form.Controls.Add(label);
				All.Add(label);
				
				ViewAssembly.Notifying(NotifyType.Error, "Error:", anyException.Message);
				return All;
			}

			byte admisible = 255;

			int index = 0;
			if (index != (files.Length + directories.Length))
			{
				while (index < (int)admisible && index < files.Length)
				{
						label = new Label(); // declared 
					label.Click += clickHandler;
					label.Text = NameProccessor.getName(files[index]);
					label.Font = new Font(ViewAssembly.FIRST, Single.Parse("18"));
						measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font); // declared 
					label.Top = down;
					label.Left = 10;
					label.Width = (int)measure.Width;
					label.Height = (int)measure.Height + 1;


					label.Padding = new Padding(0, 0, 0, 0);
					label.Margin = new Padding(0, 0, 0, 0);
					label.ForeColor = Color.White;
					label.BackColor = Color.Purple;
					down = label.Height + 10 + label.Top;
					form.Controls.Add(label);
					All.Add(label);
					index++;
				}
				int pos2 = 0;
				while (index < (int)admisible && pos2 < directories.Length)
				{
					label = new Label(); // declared 
					label.Click += clickHandler;
					label.Text = NameProccessor.getName(directories[pos2++]);
					label.Font = new Font(ViewAssembly.FIRST, Single.Parse("18"));
						measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font); // declared 
					label.Top = down;
					label.Left = 10;
					label.Width = (int)measure.Width;
					label.Height = (int)measure.Height + 1;

					label.Padding = new Padding(0, 0, 0, 0);
					label.Margin = new Padding(0, 0, 0, 0);
					label.ForeColor = Color.White;
					label.BackColor = Color.Green;
					down = label.Height + 10 + label.Top;
					form.Controls.Add(label);
					All.Add(label);
					index++;
				}
				if ((files.Length + directories.Length) > 255)
				{
					// inializing...
					EventHandler nextHandler = delegate (object ORG, EventArgs ARG){},
					previousHandler = delegate (object ORG, EventArgs ARG){};

					previousHandler = delegate (object ORG, EventArgs ARG)
					{
						index -= 1;
						foreach (Label element in All)
						{
							element.Dispose();
							form.Controls.Remove(element);
							index--;
						}
						All.Clear();
						for (byte i = 0; (i < 255 && index > 0); i++)
							index--;

						down = setPrevious(ref index, form, defaultTop, All, clickHandler, previousHandler, new string[][]
						{
							files,
							directories
						});

						int calculated = (files.Length + directories.Length - index);
						if (calculated != 0) 
						{
							label = new Label(); // declared 
							label.Click += nextHandler;
							label.Text = "Next";
							label.Font = new Font(ViewAssembly.SECOND, Single.Parse("18"));
								measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font); // declared 
							label.Top = down;
							label.Left = 10;
							label.Width = (int)measure.Width;
							label.Height = (int)measure.Height + 1;

							label.Padding = new Padding(0, 0, 0, 0);
							label.Margin = new Padding(0, 0, 0, 0);
							label.ForeColor = Color.White;
							label.BackColor = Color.Blue;
							form.Controls.Add(label);
							All.Add(label);
						}
						else {}
					};
					
					nextHandler = delegate (object ORG, EventArgs ARG)
					{
						foreach (Label element in All)
						{
							element.Dispose();
							form.Controls.Remove(element);
						}
						All.Clear();
						down = setNext(ref index, form, defaultTop, All, clickHandler, previousHandler, new string[][]
						{
							files,
							directories
						});

						int calculated = (files.Length + directories.Length - index);
						if (calculated != 0) 
						{
							label = new Label(); // declared 
							label.Click += nextHandler;
							label.Text = "Next";
							label.Font = new Font(ViewAssembly.SECOND, Single.Parse("18"));
								measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font); // declared 
							label.Top = down;
							label.Left = 10;
							label.Width = (int)measure.Width;
							label.Height = (int)measure.Height + 1;

							label.Padding = new Padding(0, 0, 0, 0);
							label.Margin = new Padding(0, 0, 0, 0);
							label.ForeColor = Color.White;
							label.BackColor = Color.Blue;
							form.Controls.Add(label);
							All.Add(label);
						}
					};

					label = new Label(); // declared 
					label.Click += nextHandler;
					label.Text = "Next";
					label.Font = new Font(ViewAssembly.SECOND, Single.Parse("18"));
						measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font); // declared 
					label.Top = down;
					label.Left = 10;
					label.Width = (int)measure.Width;
					label.Height = (int)measure.Height + 1;

					label.Padding = new Padding(0, 0, 0, 0);
					label.Margin = new Padding(0, 0, 0, 0);
					label.ForeColor = Color.White;
					label.BackColor = Color.Blue;
					form.Controls.Add(label);
					All.Add(label);
				}
			}
			else 
			{
				label = new Label(); // declared 
					label.Text = "There are no elements.";
					label.Font = new Font(ViewAssembly.FIRST, Single.Parse("18"));
						measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font); // declared 
					label.Top = down;
					label.Left = 10;
					label.Width = (int)measure.Width;
					label.Height = (int)measure.Height + 1;

					label.Padding = new Padding(0, 0, 0, 0);
					label.Margin = new Padding(0, 0, 0, 0);
					label.ForeColor = Color.Gray;
					label.BackColor = Color.Transparent;
					form.Controls.Add(label);
					All.Add(label);
			}
			return All;
		}
		public static ArrayList setContext (ViewAssembly form, int down, EventHandler clickHandler, string[] drives)
		{
			// the all labels.
			ArrayList All;
			All = new ArrayList();

			Label label = new Label();
			label.Text = ">> Drives:";
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("20"));
			SizeF measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font);
			label.Top = down;
			label.Left = 5;
			label.Width = (int)measure.Width;
			label.Height = (int)measure.Height + 1;

			label.Padding = new Padding(0, 0, 0, 0);
			label.Margin = new Padding(0, 0, 0, 0);
			label.ForeColor = Color.Red;
			label.BackColor = Color.Yellow;

			form.Controls.Add(label);
			All.Add(label);

			down = label.Height + 10 + label.Top;

			int index = 0;
			while (index < drives.Length)
			{
					label = new Label(); // declared 
				label.Text = drives[index];
				label.Click += clickHandler;
				label.Font = new Font(ViewAssembly.FIRST, Single.Parse("19"));
					measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font); // declared 
				label.Top = down;
				label.Left = 10;
				label.Width = (int)measure.Width;
				label.Height = (int)measure.Height + 1;

					label.Padding = new Padding(0, 0, 0, 0);
					label.Margin = new Padding(0, 0, 0, 0);
					label.ForeColor = Color.Cyan;
					label.BackColor = Color.Gray;
					down = label.Height + 10 + label.Top;
					form.Controls.Add(label);
					All.Add(label);
					index++;
			}
			// Mensaje atrevido:
			if (drives.Length >= 500)
				ViewAssembly.Notifying(NotifyType.Stop, "Es demaciado:", "¡Hay demaciados volumenes!");
			return All;
		}
	}
}