using System;
using System.IO;
using Shower.See;
using Shower.Utils;
using System.Drawing;
using Shower.Handlers;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using System.Threading.Tasks;

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

			down = label.Height + 10 + label.Top; 
			form.Controls.Add(label);
			list.Add(label);

			string[] files = Elements[0],
				directories = Elements[1];

			label = new Label();
			label.Text = "File\\s: " + files.Length + " Directorie\\s: " + directories.Length;
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("20"));
			 measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font);
			label.Top = down;
			label.Left = 5;
			label.Width = (int)measure.Width;
			label.Height = (int)measure.Height + 1;

			label.Padding = new Padding(0, 0, 0, 0);
			label.Margin = new Padding(0, 0, 0, 0);
			label.ForeColor = Color.Cyan;
			label.BackColor = Color.Transparent;

			form.Controls.Add(label);
			list.Add(label);

			down = label.Height + 10 + label.Top;

			// Element for previous
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

			byte admisible = 255;
			int index = 0;

			down = label.Height + 10 + label.Top;

			while (index < (int)admisible && pos < files.Length)
			{
					label = new Label(); // declared 
				label.Click += clickHandler;
				label.Text = NameProcessor.getName(files[pos++]);
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
				label.Text = NameProcessor.getName(directories[pos2++]);
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
		public static int setNext (ref int pos, SeeMore form, int defaultTop, ArrayList list, EventHandler previousHandler)
		{
			int down = defaultTop;
			// Element for previous
			Label label = new Label();
			label.Click += previousHandler;
			label.Text = "Previous";
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("20"));
			SizeF measure = form.UIface.MeasureString(label.Text + "W", label.Font);
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

			AssemblyName[] Names = form.Names;

			byte admisible = 150;
			int index = 0;

			down = label.Height + 10 + label.Top;

			while (index < (int)admisible && pos < Names.Length)
			{
					label = new Label(); // declared 
				label.Text = "> " + Names[pos++].Name;
				label.Font = new Font(ViewAssembly.FIRST, Single.Parse("18"));
					measure = form.UIface.MeasureString(label.Text + "W", label.Font); // declared 
				label.Top = down;
				label.Left = 10;
				label.Width = (int)measure.Width;
				label.Height = (int)measure.Height + 1;

				label.Padding = new Padding(0, 0, 0, 0);
				label.Margin = new Padding(0, 0, 0, 0);
				label.ForeColor = Color.Green;
				label.BackColor = Color.Transparent;
				down = label.Height + 10 + label.Top;
				form.Controls.Add(label);
				list.Add(label);
				index++;
			}
			return down;
		}
		public static int setNext (EventHandler previousHandler, ref int pos, SeeMore form, int defaultTop, ArrayList list)
		{
			int down = defaultTop;
			// Element for previous
			Label label = new Label();
			label.Click += previousHandler;
			label.Text = "Previous";
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("20"));
			SizeF measure = form.UIface.MeasureString(label.Text + "W", label.Font);
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

			byte admisible = 165;
			int index = 0, separate = 0;

			down = label.Height + 10 + label.Top;

			while (index < (int)admisible && pos < form.types.Length)
				{
					Type element = form.types[pos++];

					string typeName = "Type ->";
					if (element.IsClass)
					{
						if (element.IsAbstract)
							typeName = "Abstract Class ->";
						else 
							typeName = "Class ->";
					}
					else if (element.IsInterface)
							typeName = "Interface ->";

					else if (element.IsEnum)
							typeName = "Enumeration ->";
					label = new Label(); // declared 
					label.Text = typeName;
					label.Font = new Font(ViewAssembly.FIRST, Single.Parse("18"));
						measure = form.UIface.MeasureString(label.Text + "W", label.Font); // declared 
					label.Top = down;
					label.Left = 10;
					label.Width = (int)measure.Width;
					label.Height = (int)measure.Height + 1;
					label.Padding = new Padding(0, 0, 0, 0);
					label.Margin = new Padding(0, 0, 0, 0);
					label.ForeColor = Color.Purple;
					label.BackColor = Color.Transparent;
					separate = label.Left + label.Width;
					form.Controls.Add(label);
					list.Add(label);
					// declaring element.
					label = new Label(); // declared 
					label.Text = element.ToString();
					label.Font = new Font(ViewAssembly.FIRST, Single.Parse("18"));
						measure = form.UIface.MeasureString(label.Text + "W", label.Font); // declared 
					label.Top = down;
					label.Left = separate;
					label.Width = (int)measure.Width;
					label.Height = (int)measure.Height + 1;
					label.Padding = new Padding(0, 0, 0, 0);
					label.Margin = new Padding(0, 0, 0, 0);
					label.ForeColor = Color.Cyan;
					label.BackColor = Color.Transparent;
					down = label.Height + 10 + label.Top;
					index++;
					form.Controls.Add(label);
					list.Add(label);
				}
			return down;
		}
		public static int setPrevious (EventHandler previousHandler, ref int pos, SeeMore form, int defaultTop, ArrayList list)
		{
			int down = defaultTop;
			Label label = new Label();
			SizeF measure;

			if (pos > 0)
			{
				// Element for previous
				label = new Label();
				label.Click += previousHandler;
				label.Text = "Previous";
				label.Font = new Font(ViewAssembly.SECOND, Single.Parse("20"));
				measure = form.UIface.MeasureString(label.Text + "W", label.Font);
				label.Top = down;
				label.Left = 10;
				label.Width = (int)measure.Width;
				label.Height = (int)measure.Height + 1;

				label.Padding = new Padding(0, 0, 0, 0);
				label.Margin = new Padding(0, 0, 0, 0);
				label.ForeColor = Color.White;
				label.BackColor = Color.Blue;
				down = label.Height + 10 + label.Top;
				form.Controls.Add(label);
				list.Add(label);
			}
			else {}

			byte admisible = 165;
			int index = 0, separate = 0;


			while (index < (int)admisible && pos < form.types.Length)
				{
					Type element = form.types[pos++];

					string typeName = "Type ->";
					if (element.IsClass)
					{
						if (element.IsAbstract)
							typeName = "Abstract Class ->";
						else 
							typeName = "Class ->";
					}
					else if (element.IsInterface)
							typeName = "Interface ->";

					else if (element.IsEnum)
							typeName = "Enumeration ->";
					label = new Label(); // declared 
					label.Text = typeName;
					label.Font = new Font(ViewAssembly.FIRST, Single.Parse("18"));
						measure = form.UIface.MeasureString(label.Text + "W", label.Font); // declared 
					label.Top = down;
					label.Left = 10;
					label.Width = (int)measure.Width;
					label.Height = (int)measure.Height + 1;
					label.Padding = new Padding(0, 0, 0, 0);
					label.Margin = new Padding(0, 0, 0, 0);
					label.ForeColor = Color.Purple;
					label.BackColor = Color.Transparent;
					separate = label.Left + label.Width;
					form.Controls.Add(label);
					list.Add(label);
					// declaring element.
					label = new Label(); // declared 
					label.Text = element.ToString();
					label.Font = new Font(ViewAssembly.FIRST, Single.Parse("18"));
						measure = form.UIface.MeasureString(label.Text + "W", label.Font); // declared 
					label.Top = down;
					label.Left = separate;
					label.Width = (int)measure.Width;
					label.Height = (int)measure.Height + 1;
					label.Padding = new Padding(0, 0, 0, 0);
					label.Margin = new Padding(0, 0, 0, 0);
					label.ForeColor = Color.Cyan;
					label.BackColor = Color.Transparent;
					down = label.Height + 10 + label.Top;
					index++;
					form.Controls.Add(label);
					list.Add(label);
				}
			return down;
		}
		public static int setPrevious (ref int pos, SeeMore form, int defaultTop, ArrayList list, EventHandler previousHandler)
		{
			// initializing
			int down = defaultTop;
			Label label = new Label();
			SizeF measure;

			if (pos > 0)
			{
				// Element for previous
				label = new Label();
				label.Click += previousHandler;
				label.Text = "Previous";
				label.Font = new Font(ViewAssembly.SECOND, Single.Parse("20"));
				measure = form.UIface.MeasureString(label.Text + "W", label.Font);
				label.Top = down;
				label.Left = 10;
				label.Width = (int)measure.Width;
				label.Height = (int)measure.Height + 1;

				label.Padding = new Padding(0, 0, 0, 0);
				label.Margin = new Padding(0, 0, 0, 0);
				label.ForeColor = Color.White;
				label.BackColor = Color.Blue;

				down = label.Height + 10 + label.Top;
				form.Controls.Add(label);
				list.Add(label);	
			}
			else {}
			
			AssemblyName[] Names = form.Names;

			byte admisible = 150;
			int index = 0;

			while (index < (int)admisible && pos < Names.Length)
			{
					label = new Label(); // declared 
				label.Text = "> " + Names[pos++].Name;
				label.Font = new Font(ViewAssembly.FIRST, Single.Parse("18"));
					measure = form.UIface.MeasureString(label.Text + "W", label.Font); // declared 
				label.Top = down;
				label.Left = 10;
				label.Width = (int)measure.Width;
				label.Height = (int)measure.Height + 1;

				label.Padding = new Padding(0, 0, 0, 0);
				label.Margin = new Padding(0, 0, 0, 0);
				label.ForeColor = Color.Green;
				label.BackColor = Color.Transparent;
				down = label.Height + 10 + label.Top;
				form.Controls.Add(label);
				list.Add(label);
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

			down = label.Height + 10 + label.Top;
			form.Controls.Add(label);
			list.Add(label);
			
			
			string[] files = Elements[0],
				directories = Elements[1];

			label = new Label();
			label.Text = "File\\s: " + files.Length + " Directorie\\s: " + directories.Length;
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("20"));
			 measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font);
			label.Top = down;
			label.Left = 5;
			label.Width = (int)measure.Width;
			label.Height = (int)measure.Height + 1;

			label.Padding = new Padding(0, 0, 0, 0);
			label.Margin = new Padding(0, 0, 0, 0);
			label.ForeColor = Color.Cyan;
			label.BackColor = Color.Transparent;

			form.Controls.Add(label);
			list.Add(label);

			down = label.Height + 10 + label.Top;

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

			byte admisible = 255;
			int index = 0;

			down = label.Height + 10 + label.Top;

			while (index < (int)admisible && pos < files.Length)
			{
					label = new Label(); // declared 
				label.Click += clickHandler;
				label.Text = NameProcessor.getName(files[pos++]);
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
				label.Text = NameProcessor.getName(directories[pos2++]);
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

				label = new Label();
				label.Text = "File\\s: " + files.Length + " Directorie\\s: " + directories.Length;
				label.Font = new Font(ViewAssembly.SECOND, Single.Parse("20"));
				 measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font);
				label.Top = down;
				label.Left = 5;
				label.Width = (int)measure.Width;
				label.Height = (int)measure.Height + 1;

				label.Padding = new Padding(0, 0, 0, 0);
				label.Margin = new Padding(0, 0, 0, 0);
				label.ForeColor = Color.Cyan;
				label.BackColor = Color.Transparent;

				form.Controls.Add(label);
				All.Add(label);

				down = label.Height + 10 + label.Top;
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
					label.Text = NameProcessor.getName(files[index]);
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
					label.Text = NameProcessor.getName(directories[pos2++]);
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
						int count = 0;
						foreach (Label element in All)
						{
							element.Dispose();
							form.Controls.Remove(element);
							if (count < admisible)
								index--;
							count++;
						}
						All.Clear();
						for (byte i = 0; (i < admisible && index > 0); i++)
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

			label = new Label();
			label.Text = "Drive\\s: " + drives.Length;
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("20"));
			 measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font);
			label.Top = down;
			label.Left = 5;
			label.Width = (int)measure.Width;
			label.Height = (int)measure.Height + 1;

			label.Padding = new Padding(0, 0, 0, 0);
			label.Margin = new Padding(0, 0, 0, 0);
			label.ForeColor = Color.Cyan;
			label.BackColor = Color.Transparent;

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
		public static void forSeeReferences (AssemblyName[] Names, string title)
		{
			SeeMore seeMoreReferences;
			seeMoreReferences = new SeeMore(title + ": References", Names);
			seeMoreReferences.viewReferences();
			// the Modal window
			seeMoreReferences.ShowDialog();
			
			seeMoreReferences.Dispose();
		}
		public static void forSeeTypes (Type[] types, string title)
		{
			SeeMore seeMoreTypes;
			seeMoreTypes = new SeeMore(title + ": Types", types);
			seeMoreTypes.viewTypes();
			// // the Modal window
			seeMoreTypes.ShowDialog();
			
			seeMoreTypes.Dispose();
		}
		public static void viewData(AssemblyName inform, ViewAssembly form, int down, AssemblyName[] references, Type[] Tps, ArrayList All)
		{
			// element #1
			Label label = new Label();
			label.Text = "Information";
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("28"), FontStyle.Underline);
			SizeF measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font);
			label.Top = down;
			label.Left = 15;
			label.Width = (int)measure.Width;
			label.Height = (int)measure.Height + 1;

			label.Padding = new Padding(0, 0, 0, 0);
			label.Margin = new Padding(0, 0, 0, 0);
			label.ForeColor = Color.White;
			label.BackColor = Color.Transparent;

			form.Controls.Add(label);
			All.Add(label);
			down = label.Height + 10 + label.Top;

			int separate;
			// element #2
			label = new Label();
			label.Text = "Name:";
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("20"), FontStyle.Bold);
			measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font);
			label.Top = down;
			label.Left = 5;
			label.Width = (int)measure.Width;
			label.Height = (int)measure.Height + 1;

			label.Padding = new Padding(0, 0, 0, 0);
			label.Margin = new Padding(0, 0, 0, 0);
			label.ForeColor = Color.Orange;
			label.BackColor = Color.Transparent;

			separate = label.Left + label.Width;
			form.Controls.Add(label);
			All.Add(label);

			// element #3
			label = new Label();
			label.Text = inform.Name;
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("20"), FontStyle.Italic);
			measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font);
			label.Top = down;
			label.Left = separate;
			label.Width = (int)measure.Width;
			label.Height = (int)measure.Height + 1;

			label.Padding = new Padding(0, 0, 0, 0);
			label.Margin = new Padding(0, 0, 0, 0);
			label.ForeColor = Color.Cyan;
			label.BackColor = Color.Transparent;

			form.Controls.Add(label);
			All.Add(label);

			down = label.Height + 10 + label.Top;

			// element #4
			label = new Label();
			label.Text = "Version:";
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("20"), FontStyle.Bold);
			measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font);
			label.Top = down;
			label.Left = 5;
			label.Width = (int)measure.Width;
			label.Height = (int)measure.Height + 1;

			label.Padding = new Padding(0, 0, 0, 0);
			label.Margin = new Padding(0, 0, 0, 0);
			label.ForeColor = Color.Orange;
			label.BackColor = Color.Transparent;

			separate = label.Left + label.Width;
			form.Controls.Add(label);
			All.Add(label);

			// element #5
			label = new Label();
			label.Text = inform.Version.ToString();
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("20"), FontStyle.Italic);
			measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font);
			label.Top = down;
			label.Left = separate;
			label.Width = (int)measure.Width;
			label.Height = (int)measure.Height + 1;

			label.Padding = new Padding(0, 0, 0, 0);
			label.Margin = new Padding(0, 0, 0, 0);
			label.ForeColor = Color.Cyan;
			label.BackColor = Color.Transparent;

			form.Controls.Add(label);
			All.Add(label);

			down = label.Height + 10 + label.Top;

			// element #6
			label = new Label();
			label.Text = "Version Compatibility:";
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("20"), FontStyle.Bold);
			measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font);
			label.Top = down;
			label.Left = 5;
			label.Width = (int)measure.Width;
			label.Height = (int)measure.Height + 1;

			label.Padding = new Padding(0, 0, 0, 0);
			label.Margin = new Padding(0, 0, 0, 0);
			label.ForeColor = Color.Orange;
			label.BackColor = Color.Transparent;

			separate = label.Left + label.Width;
			form.Controls.Add(label);
			All.Add(label);

			// element #7
			label = new Label();
			label.Text = inform.VersionCompatibility.ToString();
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("20"), FontStyle.Italic);
			measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font);
			label.Top = down;
			label.Left = separate;
			label.Width = (int)measure.Width;
			label.Height = (int)measure.Height + 1;

			label.Padding = new Padding(0, 0, 0, 0);
			label.Margin = new Padding(0, 0, 0, 0);
			label.ForeColor = Color.Cyan;
			label.BackColor = Color.Transparent;

			form.Controls.Add(label);
			All.Add(label);

			down = label.Height + 10 + label.Top;

			// element #8
			label = new Label();
			label.Text = "References";
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("28"), FontStyle.Underline);
			measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font);
			label.Top = down;
			label.Left = 15;
			label.Width = (int)measure.Width;
			label.Height = (int)measure.Height + 1;

			label.Padding = new Padding(0, 0, 0, 0);
			label.Margin = new Padding(0, 0, 0, 0);
			label.ForeColor = Color.White;
			label.BackColor = Color.Transparent;

			form.Controls.Add(label);
			All.Add(label);
			down = label.Height + 10 + label.Top;

			byte admisible = 4;

			int index = 0;

			if (references.Length == 0)
			{
					label = new Label(); // declared 
					label.Text = "Nothing";
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
					down = label.Height + 10 + label.Top;
					form.Controls.Add(label);
					All.Add(label);
			}
			else 
			{
					// x elements
					while (index < (int)admisible && index < references.Length)
					{
							label = new Label(); // declared 
						label.Text = "> " + references[index].Name;
						label.Font = new Font(ViewAssembly.FIRST, Single.Parse("18"));
							measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font); // declared 
						label.Top = down;
						label.Left = 10;
						label.Width = (int)measure.Width;
						label.Height = (int)measure.Height + 1;

						label.Padding = new Padding(0, 0, 0, 0);
						label.Margin = new Padding(0, 0, 0, 0);
						label.ForeColor = Color.Green;
						label.BackColor = Color.Transparent;
						down = label.Height + 10 + label.Top;
						form.Controls.Add(label);
						All.Add(label);
						index++;
					}
			}
			if (references.Length > admisible)
			{
				Button seeMoreButton = new Button(); // declared 
				seeMoreButton.Text = "See more";
				seeMoreButton.Click += new EventHandler(delegate(object origin, EventArgs Argumets)
				{
					forSeeReferences(references, form.Text);
				});
				seeMoreButton.Font = new Font(ViewAssembly.FIRST, Single.Parse("18"));
					measure = form.graphyInterface.MeasureString(seeMoreButton.Text + "W", seeMoreButton.Font); // declared 
				seeMoreButton.Top = down;
				seeMoreButton.Left = 10;
				seeMoreButton.Width = (int)measure.Width;
				seeMoreButton.Height = (int)measure.Height + 1;

				seeMoreButton.Padding = new Padding(0, 0, 0, 0);
				seeMoreButton.Margin = new Padding(0, 0, 0, 0);
				seeMoreButton.ForeColor = Color.White;
				seeMoreButton.BackColor = Color.Blue;
				down = seeMoreButton.Height + 10 + seeMoreButton.Top;
				form.Controls.Add(seeMoreButton);
				All.Add(seeMoreButton);
			}
			else
			{/*Nothing*/}
			
			admisible = 25;

			// element #(x+1)
			label = new Label();
			label.Text = "Types";
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("28"), FontStyle.Underline);
			measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font);
			label.Top = down;
			label.Left = 15;
			label.Width = (int)measure.Width;
			label.Height = (int)measure.Height + 1;

			label.Padding = new Padding(0, 0, 0, 0);
			label.Margin = new Padding(0, 0, 0, 0);
			label.ForeColor = Color.White;
			label.BackColor = Color.Transparent;

			form.Controls.Add(label);
			All.Add(label);
			down = label.Height + 10 + label.Top;

			index = 0;
			if (Tps.Length == 0)
			{
					label = new Label(); // declared 
					label.Text = "Nothing";
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
					down = label.Height + 10 + label.Top;
					form.Controls.Add(label);
					All.Add(label);
			}
			else 
			{
				while (index < (int)admisible && index < Tps.Length)
				{
					Type element = Tps[index];

					string typeName = "Type ->";
					if (element.IsClass)
					{
						if (element.IsAbstract)
							typeName = "Abstract Class ->";
						else 
							typeName = "Class ->";
					}
					else if (element.IsInterface)
							typeName = "Interface ->";

					else if (element.IsEnum)
							typeName = "Enumeration ->";
					label = new Label(); // declared 
					label.Text = typeName;
					label.Font = new Font(ViewAssembly.FIRST, Single.Parse("18"));
						measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font); // declared 
					label.Top = down;
					label.Left = 10;
					label.Width = (int)measure.Width;
					label.Height = (int)measure.Height + 1;
					label.Padding = new Padding(0, 0, 0, 0);
					label.Margin = new Padding(0, 0, 0, 0);
					label.ForeColor = Color.Purple;
					label.BackColor = Color.Transparent;
					separate = label.Left + label.Width;
					form.Controls.Add(label);
					All.Add(label);
					// declaring element.
					label = new Label(); // declared 
					label.Text = element.ToString();
					label.Font = new Font(ViewAssembly.FIRST, Single.Parse("18"));
						measure = form.graphyInterface.MeasureString(label.Text + "W", label.Font); // declared 
					label.Top = down;
					label.Left = separate;
					label.Width = (int)measure.Width;
					label.Height = (int)measure.Height + 1;
					label.Padding = new Padding(0, 0, 0, 0);
					label.Margin = new Padding(0, 0, 0, 0);
					label.ForeColor = Color.Cyan;
					label.BackColor = Color.Transparent;
					down = label.Height + 10 + label.Top;
					index++;
					form.Controls.Add(label);
					All.Add(label);
				}
			}
			if (Tps.Length > admisible)
			{
				Button seeMoreButton = new Button(); // declared 
				seeMoreButton.Click += new EventHandler(delegate (object origin, EventArgs informs)
				{
					forSeeTypes(Tps, form.Text);
				});
				seeMoreButton.Text = "See more";
				seeMoreButton.Font = new Font(ViewAssembly.FIRST, Single.Parse("18"));
					measure = form.graphyInterface.MeasureString(seeMoreButton.Text + "W", seeMoreButton.Font); // declared 
				seeMoreButton.Top = down;
				seeMoreButton.Left = 10;
				seeMoreButton.Width = (int)measure.Width;
				seeMoreButton.Height = (int)measure.Height + 1;

				seeMoreButton.Padding = new Padding(0, 0, 0, 0);
				seeMoreButton.Margin = new Padding(0, 0, 0, 0);
				seeMoreButton.ForeColor = Color.White;
				seeMoreButton.BackColor = Color.Blue;
				down = seeMoreButton.Height + 10 + seeMoreButton.Top;
				form.Controls.Add(seeMoreButton);
				All.Add(seeMoreButton);
			}
			else
			{/*Nothing*/}
		}
	}
}