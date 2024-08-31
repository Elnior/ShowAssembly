using System;
using System.Drawing;
using Shower.Handlers;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;

namespace Shower.See
{
	public sealed class SeeMore : Form
	{
		public AssemblyName[] Names;
		public Type[] types;
		public Graphics UIface;
		public SeeMore (string title, Type[] types)
		{
			this.UIface = this.CreateGraphics();
			this.Text = title;
			// Styles.
			// BackColor and ForeColor
			this.BackColor = Color.Black;
			this.ForeColor = Color.White;
			this.MinimumSize = new Size(300, 400);
			this.MaximumSize = new Size(1200, 600);

			// States
			this.ShowIcon = false;
			this.AllowTransparency = true;
			this.AutoScroll = true;
			this.AutoSize = false;
			this.ShowInTaskbar = false;
			this.ControlBox = true;
			this.MaximizeBox = false;
			this.TopLevel = true;
			// Box Styles
			this.Margin = new Padding(0, 0, 0, 0);
			this.Padding = new Padding(0, 0, 0, 0);
			// references
			this.Names = new AssemblyName[0];
			this.types = types;
			// Form border style
			this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		}

		public SeeMore (string title, AssemblyName[] references)
		{
			this.UIface = this.CreateGraphics();
			this.Text = title;
			// Styles.
			// BackColor and ForeColor
			this.BackColor = Color.Black;
			this.ForeColor = Color.White;
			this.MinimumSize = new Size(300, 400);
			this.MaximumSize = new Size(1200, 600);

			// States
			this.ShowIcon = false;
			this.AllowTransparency = true;
			this.AutoScroll = true;
			this.AutoSize = false;
			this.ShowInTaskbar = false;
			this.ControlBox = true;
			this.MaximizeBox = false;
			this.TopLevel = true;
			// Box Styles
			this.Margin = new Padding(0, 0, 0, 0);
			this.Padding = new Padding(0, 0, 0, 0);
			// references
			this.Names = references;
			this.types = new Type[0];
			// Form border style
			this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		}
		public void viewReferences ()
		{
			ArrayList All;
			All = new ArrayList();

			int down, defaultTop;

			Label label = new Label();
			label.Text = "References";
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("25"), FontStyle.Underline);
			SizeF measure = this.UIface.MeasureString(label.Text + "W", label.Font);
			label.Top = down = 10;
			label.Left = 5;
			label.Width = (int)measure.Width;
			label.Height = (int)measure.Height + 1;

			label.Padding = new Padding(0, 0, 0, 0);
			label.Margin = new Padding(0, 0, 0, 0);
			label.ForeColor = Color.White;
			label.BackColor = Color.Transparent;

			this.Controls.Add(label);

			defaultTop = down = label.Height + 10 + label.Top;
			
			byte admisible = 150;

			int index = 0;

			while (index < (int)admisible && index < this.Names.Length)
			{
					label = new Label(); // declared 
				label.Text = "> " + this.Names[index].Name;
				label.Font = new Font(ViewAssembly.FIRST, Single.Parse("20"));
					measure = this.UIface.MeasureString(label.Text + "W", label.Font); // declared 
				label.Top = down;
				label.Left = 10;
				label.Width = (int)measure.Width;
				label.Height = (int)measure.Height + 1;

				label.Padding = new Padding(0, 0, 0, 0);
				label.Margin = new Padding(0, 0, 0, 0);
				label.ForeColor = Color.Green;
				label.BackColor = Color.Transparent;
				down = label.Height + 10 + label.Top;
				this.Controls.Add(label);
				All.Add(label);
				index++;
			}

			if (this.Names.Length > admisible)
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
							this.Controls.Remove(element);
							if (count < admisible)
								index--;
							count++;
						}
						All.Clear();
						for (byte i = 0; (i < admisible && index > 0); i++)
							index--;

						down = With.setPrevious(ref index, this, defaultTop, All, previousHandler);

						int calculated = (Names.Length - index);
						if (calculated != 0) 
						{
							label = new Label(); // declared 
							label.Click += nextHandler;
							label.Text = "Next";
							label.Font = new Font(ViewAssembly.SECOND, Single.Parse("18"));
								measure = this.UIface.MeasureString(label.Text + "W", label.Font); // declared 
							label.Top = down;
							label.Left = 10;
							label.Width = (int)measure.Width;
							label.Height = (int)measure.Height + 1;

							label.Padding = new Padding(0, 0, 0, 0);
							label.Margin = new Padding(0, 0, 0, 0);
							label.ForeColor = Color.White;
							label.BackColor = Color.Blue;
							this.Controls.Add(label);
							All.Add(label);
						}
						else {}
					};
					
					nextHandler = delegate (object ORG, EventArgs ARG)
					{
						foreach (Label element in All)
						{
							element.Dispose();
							this.Controls.Remove(element);
						}
						All.Clear();

						down = With.setNext(ref index, this, defaultTop, All, previousHandler);

						int calculated = (this.Names.Length - index);
						if (calculated != 0) 
						{
							label = new Label(); // declared 
							label.Click += nextHandler;
							label.Text = "Next";
							label.Font = new Font(ViewAssembly.SECOND, Single.Parse("18"));
								measure = this.UIface.MeasureString(label.Text + "W", label.Font); // declared 
							label.Top = down;
							label.Left = 10;
							label.Width = (int)measure.Width;
							label.Height = (int)measure.Height + 1;

							label.Padding = new Padding(0, 0, 0, 0);
							label.Margin = new Padding(0, 0, 0, 0);
							label.ForeColor = Color.White;
							label.BackColor = Color.Blue;
							this.Controls.Add(label);
							All.Add(label);
						}
					};

					label = new Label(); // declared 
					label.Click += nextHandler;
					label.Text = "Next";
					label.Font = new Font(ViewAssembly.SECOND, Single.Parse("18"));
						measure = this.UIface.MeasureString(label.Text + "W", label.Font); // declared 
					label.Top = down;
					label.Left = 10;
					label.Width = (int)measure.Width;
					label.Height = (int)measure.Height + 1;

					label.Padding = new Padding(0, 0, 0, 0);
					label.Margin = new Padding(0, 0, 0, 0);
					label.ForeColor = Color.White;
					label.BackColor = Color.Blue;
					this.Controls.Add(label);
					All.Add(label);
			}
		}
		public void viewTypes ()
		{
			ArrayList All;
			All = new ArrayList();

			int down, defaultTop;

			Label label = new Label();
			label.Text = "Types";
			label.Font = new Font(ViewAssembly.SECOND, Single.Parse("25"), FontStyle.Underline);
			SizeF measure = this.UIface.MeasureString(label.Text + "W", label.Font);
			label.Top = down = 10;
			label.Left = 5;
			label.Width = (int)measure.Width;
			label.Height = (int)measure.Height + 1;

			label.Padding = new Padding(0, 0, 0, 0);
			label.Margin = new Padding(0, 0, 0, 0);
			label.ForeColor = Color.White;
			label.BackColor = Color.Transparent;

			this.Controls.Add(label);

			defaultTop = down = label.Height + 10 + label.Top;
			
			byte admisible = 165;

			int index = 0, separate = 0;

			while (index < (int)admisible && index < this.types.Length)
				{
					Type element = this.types[index++];

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
						measure = this.UIface.MeasureString(label.Text + "W", label.Font); // declared 
					label.Top = down;
					label.Left = 10;
					label.Width = (int)measure.Width;
					label.Height = (int)measure.Height + 1;
					label.Padding = new Padding(0, 0, 0, 0);
					label.Margin = new Padding(0, 0, 0, 0);
					label.ForeColor = Color.Purple;
					label.BackColor = Color.Transparent;
					separate = label.Left + label.Width;
					this.Controls.Add(label);
					All.Add(label);
					// declaring element.
					label = new Label(); // declared 
					label.Text = element.ToString();
					label.Font = new Font(ViewAssembly.FIRST, Single.Parse("18"));
						measure = this.UIface.MeasureString(label.Text + "W", label.Font); // declared 
					label.Top = down;
					label.Left = separate;
					label.Width = (int)measure.Width;
					label.Height = (int)measure.Height + 1;
					label.Padding = new Padding(0, 0, 0, 0);
					label.Margin = new Padding(0, 0, 0, 0);
					label.ForeColor = Color.Cyan;
					label.BackColor = Color.Transparent;
					down = label.Height + 10 + label.Top;
					this.Controls.Add(label);
					All.Add(label);
				}

			if (this.types.Length > admisible)
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
							this.Controls.Remove(element);
							if (count < admisible)
								index--;
							count++;
						}
						All.Clear();
						for (byte i = 0; (i < admisible && index > 0); i++)
							index--;

						down = With.setPrevious(previousHandler, ref index, this, defaultTop, All);

						int calculated = (this.types.Length - index);
						if (calculated != 0) 
						{
							label = new Label(); // declared 
							label.Click += nextHandler;
							label.Text = "Next";
							label.Font = new Font(ViewAssembly.SECOND, Single.Parse("18"));
								measure = this.UIface.MeasureString(label.Text + "W", label.Font); // declared 
							label.Top = down;
							label.Left = 10;
							label.Width = (int)measure.Width;
							label.Height = (int)measure.Height + 1;

							label.Padding = new Padding(0, 0, 0, 0);
							label.Margin = new Padding(0, 0, 0, 0);
							label.ForeColor = Color.White;
							label.BackColor = Color.Blue;
							this.Controls.Add(label);
							All.Add(label);
						}
						else {}
					};
					
					nextHandler = delegate (object ORG, EventArgs ARG)
					{
						foreach (Label element in All)
						{
							element.Dispose();
							this.Controls.Remove(element);
						}
						All.Clear();

						down = With.setNext(previousHandler, ref index, this, defaultTop, All);

						int calculated = (this.types.Length - index);
						if (calculated != 0) 
						{
							label = new Label(); // declared 
							label.Click += nextHandler;
							label.Text = "Next";
							label.Font = new Font(ViewAssembly.SECOND, Single.Parse("18"));
								measure = this.UIface.MeasureString(label.Text + "W", label.Font); // declared 
							label.Top = down;
							label.Left = 10;
							label.Width = (int)measure.Width;
							label.Height = (int)measure.Height + 1;

							label.Padding = new Padding(0, 0, 0, 0);
							label.Margin = new Padding(0, 0, 0, 0);
							label.ForeColor = Color.White;
							label.BackColor = Color.Blue;
							this.Controls.Add(label);
							All.Add(label);
						}
					};

					label = new Label(); // declared 
					label.Click += nextHandler;
					label.Text = "Next";
					label.Font = new Font(ViewAssembly.SECOND, Single.Parse("18"));
						measure = this.UIface.MeasureString(label.Text + "W", label.Font); // declared 
					label.Top = down;
					label.Left = 10;
					label.Width = (int)measure.Width;
					label.Height = (int)measure.Height + 1;

					label.Padding = new Padding(0, 0, 0, 0);
					label.Margin = new Padding(0, 0, 0, 0);
					label.ForeColor = Color.White;
					label.BackColor = Color.Blue;
					this.Controls.Add(label);
					All.Add(label);
			}
		}
	}
}