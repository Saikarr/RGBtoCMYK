using System.Drawing;
using System.Text.Json;
using System.Windows.Forms;

namespace RGBtoCMYK
{
	public partial class Form1 : Form
	{
		private Point[,] BezierControlPoints = new Point[4, 4];
		private List<Point>[] BezierPoints = new List<Point>[4];
		private int SelectedColor = 0;
		private int SelectedPoint = -1;
		private Color[] Colors = new Color[] { Color.Cyan, Color.Magenta, Color.Yellow, Color.Black };
		private Image image;
		public Form1()
		{
			InitializeComponent();
			for (int i = 0; i < 4; i++)
			{
				BezierControlPoints[i, 0] = new Point(5, bezierPictureBox.Height - 5);
				BezierControlPoints[i, 1] = new Point(bezierPictureBox.Width / 3, 2 * bezierPictureBox.Height / 3);
				BezierControlPoints[i, 2] = new Point(2 * bezierPictureBox.Width / 3, bezierPictureBox.Height / 3);
				BezierControlPoints[i, 3] = new Point(bezierPictureBox.Width - 5, 5);
			}
			for (int i = 0; i < 4; i++)
			{
				CalculateBeziers(i);
			}
		}

		private void bezierPictureBox_Paint(object sender, PaintEventArgs e)
		{
			for (int i = 0; i < 4; i++)
			{
				e.Graphics.DrawEllipse(Pens.Black, BezierControlPoints[SelectedColor, i].X - 6, BezierControlPoints[SelectedColor, i].Y - 6, 12, 12);
			}
			if (allCurvesCheckBox.Checked)
			{
				for (int i = 0; i < 4; i++)
				{
					e.Graphics.DrawBezier(new Pen(Colors[i]), BezierControlPoints[i, 0], BezierControlPoints[i, 1], BezierControlPoints[i, 2], BezierControlPoints[i, 3]);
				}
			}
			else
				e.Graphics.DrawBezier(new Pen(Colors[SelectedColor]), BezierControlPoints[SelectedColor, 0], BezierControlPoints[SelectedColor, 1], BezierControlPoints[SelectedColor, 2], BezierControlPoints[SelectedColor, 3]);
		}

		private void RadioButton_CheckedChanged(object sender, EventArgs e)
		{
			SelectedColor = int.Parse(((RadioButton)sender).Tag.ToString());
			bezierPictureBox.Invalidate();
		}

		private void bezierPictureBox_MouseDown(object sender, MouseEventArgs e)
		{
			for (int i = 0; i < 4; i++)
			{
				if (Math.Abs(e.X - BezierControlPoints[SelectedColor, i].X) < 8 && Math.Abs(e.Y - BezierControlPoints[SelectedColor, i].Y) < 8)
				{
					SelectedPoint = i;
				}
			}
		}

		private void bezierPictureBox_MouseMove(object sender, MouseEventArgs e)
		{
			int x = e.X;
			int y = e.Y;
			if (x < 5) x = 5;
			if (x > bezierPictureBox.Width - 5) x = bezierPictureBox.Width - 5;
			if (y < 5) y = 5;
			if (y > bezierPictureBox.Height - 5) y = bezierPictureBox.Height - 5;
			if (SelectedPoint == 0 || SelectedPoint == 3)
			{
				BezierControlPoints[SelectedColor, SelectedPoint] = new Point(BezierControlPoints[SelectedColor, SelectedPoint].X, y);
				bezierPictureBox.Invalidate();

				CalculateBeziers(SelectedColor);
			}
			else if (SelectedPoint == 1 || SelectedPoint == 2)
			{
				BezierControlPoints[SelectedColor, SelectedPoint] = new Point(x, y);
				bezierPictureBox.Invalidate();

				CalculateBeziers(SelectedColor);
			}
		}

		private void bezierPictureBox_MouseUp(object sender, MouseEventArgs e)
		{
			SelectedPoint = -1;
		}

		private void allCurvesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			bezierPictureBox.Invalidate();
		}

		private void CalculateBeziers(int selcolor)
		{
			BezierPoints[selcolor] = new List<Point>();
			for (double t = 0; t <= 1; t += 0.01)
			{
				double xx = Math.Pow(1 - t, 3) * BezierControlPoints[selcolor, 0].X + 3 * t * Math.Pow(1 - t, 2) * BezierControlPoints[selcolor, 1].X + 3 *
					Math.Pow(t, 2) * (1 - t) * BezierControlPoints[selcolor, 2].X + Math.Pow(t, 3) * BezierControlPoints[selcolor, 3].X;
				double yy = Math.Pow(1 - t, 3) * BezierControlPoints[selcolor, 0].Y + 3 * t * Math.Pow(1 - t, 2) * BezierControlPoints[selcolor, 1].Y + 3 *
					Math.Pow(t, 2) * (1 - t) * BezierControlPoints[selcolor, 2].Y + Math.Pow(t, 3) * BezierControlPoints[selcolor, 3].Y;
				BezierPoints[selcolor].Add(new Point((int)xx, (int)yy));
			}
		}

		private void changePictureButton_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "Image Files |*.jpg;*.png;*.jpeg";
			openFileDialog1.CheckFileExists = true;
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				image = Image.FromFile(openFileDialog1.FileName);
				mainImagePictureBox.Image = image;
				mainImagePictureBox.Invalidate();
			}
		}

		private void allPicturesButton_Click(object sender, EventArgs e)
		{
			if (image == null)
			{
				MessageBox.Show("Please select an image first.");
				return;
			}
			cyanPictureBox.Image = CreateColorImage(0);
			magentaPictureBox.Image = CreateColorImage(1);
			yellowPictureBox.Image = CreateColorImage(2);
			blackPictureBox.Image = CreateColorImage(3);
		}

		private Bitmap CreateColorImage(int color)
		{
			Bitmap bmp = new Bitmap(image.Width, image.Height);
			for (int i = 0; i < image.Width; i++)
			{
				for (int j = 0; j < image.Height; j++)
				{
					Color col = ((Bitmap)image).GetPixel(i, j);
					double r = col.R / 255.0;
					double g = col.G / 255.0;
					double b = col.B / 255.0;
					double c = 1 - r;
					double m = 1 - g;
					double y = 1 - b;
					double k = Math.Min(Math.Min(c, m), y);
					c = c - k;
					m = m - k;
					y = y - k;

					double fc = bezierPictureBox.Height - BezierPoints[0].FirstOrDefault(p => p.X >= k * bezierPictureBox.Width).Y;
					fc = fc / bezierPictureBox.Height;
					double fm = bezierPictureBox.Height - BezierPoints[1].FirstOrDefault(p => p.X >= k * bezierPictureBox.Width).Y;
					fm = fm / bezierPictureBox.Height;
					double fy = bezierPictureBox.Height - BezierPoints[2].FirstOrDefault(p => p.X >= k * bezierPictureBox.Width).Y;
					fy = fy / bezierPictureBox.Height;
					double fk = bezierPictureBox.Height - BezierPoints[3].FirstOrDefault(p => p.X >= k * bezierPictureBox.Width).Y;
					fk = fk / bezierPictureBox.Height;

					c = c + fc > 1 ? 1 : c + fc;
					m = m + fm > 1 ? 1 : m + fm;
					y = y + fy > 1 ? 1 : y + fy;
					k = fk > 1 ? 1 : fk;

					switch (color)
					{
						case 0:
							bmp.SetPixel(i, j, Color.FromArgb(255 - (int)(c * 255), 255, 255));
							break;
						case 1:
							bmp.SetPixel(i, j, Color.FromArgb(255, 255 - (int)(m * 255), 255));
							break;
						case 2:
							bmp.SetPixel(i, j, Color.FromArgb(255, 255, 255 - (int)(y * 255)));
							break;
						case 3:
							bmp.SetPixel(i, j, Color.FromArgb(255 - (int)(k * 255), 255 - (int)(k * 255), 255 - (int)(k * 255)));
							break;
					}

					//double cmyk = 1 - k;
					//double cmy = 1 - cmyk;
					//double c1 = (1 - r - k) / cmy;
					//double m1 = (1 - g - k) / cmy;
					//double y1 = (1 - b - k) / cmy;
					//double c2 = c1 * cmyk + k;
					//double m2 = m1 * cmyk + k;
					//double y2 = y1 * cmyk + k;
					//double c3 = c2 * BezierPoints[color][i].X / 255.0;
					//double m3 = m2 * BezierPoints[color][i].X / 255.0;
					//double y3 = y2 * BezierPoints[color][i].X / 255.0;
					//double r1 = 1 - Math.Min(1, c3 + k);
					//double g1 = 1 - Math.Min(1, m3 + k);
					//double b1 = 1 - Math.Min(1, y3 + k);
					//bmp.SetPixel(i, j, Color.FromArgb((int)(r1 * 255), (int)(g1 * 255), (int)(b1 * 255)));
				}
			}
			return bmp;
		}

		private void savePictureButton_Click(object sender, EventArgs e)
		{
			if (cyanPictureBox.Image == null || magentaPictureBox.Image == null || yellowPictureBox.Image == null || blackPictureBox.Image == null)
			{
				MessageBox.Show("Please generate all pictures first.");
				return;
			}
			saveFileDialog1.Filter = "Image Files |*.jpg|*.png|*.jpeg";
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				cyanPictureBox.Image.Save(saveFileDialog1.FileName + "_cyan.jpg");
				magentaPictureBox.Image.Save(saveFileDialog1.FileName + "_magenta.jpg");
				yellowPictureBox.Image.Save(saveFileDialog1.FileName + "_yellow.jpg");
				blackPictureBox.Image.Save(saveFileDialog1.FileName + "_black.jpg");
			}
		}

		private void saveCurveButton_Click(object sender, EventArgs e)
		{

			saveFileDialog1.Filter = "json |*.json";
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				var points = new Point[4];
				for (int i = 0; i < 4; i++)
				{
					points[i] = BezierControlPoints[SelectedColor, i];
				}
				var json = JsonSerializer.Serialize(points);
				File.WriteAllText(saveFileDialog1.FileName, json);
			}
		}

		private void loadCurveButton_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "json |*.json";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				var json = File.ReadAllText(openFileDialog1.FileName);
				var points = JsonSerializer.Deserialize<Point[]>(json);
				for (int i = 0; i < 4; i++)
				{
					BezierControlPoints[SelectedColor, i] = points[i];
				}
				CalculateBeziers(SelectedColor);
				bezierPictureBox.Invalidate();
			}
		}

		private void blackWhiteButton_Click(object sender, EventArgs e)
		{
			if (image == null)
			{
				MessageBox.Show("Please select an image first.");
				return;
			}
			blackPictureBox.Image = CreateColorImage(3);
		}

		private void noBackButton_Click(object sender, EventArgs e)
		{
			BezierControlPoints[0, 0] = new Point(5, bezierPictureBox.Height - 5);
			BezierControlPoints[0, 1] = new Point(bezierPictureBox.Width / 3, 2 * bezierPictureBox.Height / 3);
			BezierControlPoints[0, 2] = new Point(2 * bezierPictureBox.Width / 3, bezierPictureBox.Height / 3);
			BezierControlPoints[0, 3] = new Point(bezierPictureBox.Width - 5, 5);

			BezierControlPoints[1, 0] = new Point(5, bezierPictureBox.Height - 5);
			BezierControlPoints[1, 1] = new Point(bezierPictureBox.Width / 3, 2 * bezierPictureBox.Height / 3);
			BezierControlPoints[1, 2] = new Point(2 * bezierPictureBox.Width / 3, bezierPictureBox.Height / 3);
			BezierControlPoints[1, 3] = new Point(bezierPictureBox.Width - 5, 5);

			BezierControlPoints[2, 0] = new Point(5, bezierPictureBox.Height - 5);
			BezierControlPoints[2, 1] = new Point(bezierPictureBox.Width / 3, 2 * bezierPictureBox.Height / 3);
			BezierControlPoints[2, 2] = new Point(2 * bezierPictureBox.Width / 3, bezierPictureBox.Height / 3);
			BezierControlPoints[2, 3] = new Point(bezierPictureBox.Width - 5, 5);

			BezierControlPoints[3, 0] = new Point(5, bezierPictureBox.Height - 5);
			BezierControlPoints[3, 1] = new Point(bezierPictureBox.Width / 3, bezierPictureBox.Height - 5);
			BezierControlPoints[3, 2] = new Point(2 * bezierPictureBox.Width / 3, bezierPictureBox.Height - 5);
			BezierControlPoints[3, 3] = new Point(bezierPictureBox.Width - 5, bezierPictureBox.Height - 5);

			for (int i = 0; i < 4; i++)
			{
				CalculateBeziers(i);
			}
			bezierPictureBox.Invalidate();
		}

		private void fullBackButton_Click(object sender, EventArgs e)
		{
			BezierControlPoints[0, 0] = new Point(5, bezierPictureBox.Height - 5);
			BezierControlPoints[0, 1] = new Point(bezierPictureBox.Width / 3, bezierPictureBox.Height - 5);
			BezierControlPoints[0, 2] = new Point(2 * bezierPictureBox.Width / 3, bezierPictureBox.Height - 5);
			BezierControlPoints[0, 3] = new Point(bezierPictureBox.Width - 5, bezierPictureBox.Height - 5);

			BezierControlPoints[1, 0] = new Point(5, bezierPictureBox.Height - 5);
			BezierControlPoints[1, 1] = new Point(bezierPictureBox.Width / 3, bezierPictureBox.Height - 5);
			BezierControlPoints[1, 2] = new Point(2 * bezierPictureBox.Width / 3, bezierPictureBox.Height - 5);
			BezierControlPoints[1, 3] = new Point(bezierPictureBox.Width - 5, bezierPictureBox.Height - 5);

			BezierControlPoints[2, 0] = new Point(5, bezierPictureBox.Height - 5);
			BezierControlPoints[2, 1] = new Point(bezierPictureBox.Width / 3, bezierPictureBox.Height - 5);
			BezierControlPoints[2, 2] = new Point(2 * bezierPictureBox.Width / 3, bezierPictureBox.Height - 5);
			BezierControlPoints[2, 3] = new Point(bezierPictureBox.Width - 5, bezierPictureBox.Height - 5);

			BezierControlPoints[3, 0] = new Point(5, bezierPictureBox.Height - 5);
			BezierControlPoints[3, 1] = new Point(bezierPictureBox.Width / 3, 2 * bezierPictureBox.Height / 3);
			BezierControlPoints[3, 2] = new Point(2 * bezierPictureBox.Width / 3, bezierPictureBox.Height / 3);
			BezierControlPoints[3, 3] = new Point(bezierPictureBox.Width - 5, 5);

			for (int i = 0; i < 4; i++)
			{
				CalculateBeziers(i);
			}
			bezierPictureBox.Invalidate();
		}

		private void ucrButton_Click(object sender, EventArgs e)
		{
			BezierControlPoints[0, 0] = new Point(5, bezierPictureBox.Height - 5);
			BezierControlPoints[0, 1] = new Point(bezierPictureBox.Width / 3, 2 * bezierPictureBox.Height / 3);
			BezierControlPoints[0, 2] = new Point(2 * bezierPictureBox.Width / 3, bezierPictureBox.Height / 3);
			BezierControlPoints[0, 3] = new Point(bezierPictureBox.Width - 5, 5);

			BezierControlPoints[1, 0] = new Point(5, bezierPictureBox.Height - 5);
			BezierControlPoints[1, 1] = new Point(bezierPictureBox.Width / 3, 2 * bezierPictureBox.Height / 3);
			BezierControlPoints[1, 2] = new Point(2 * bezierPictureBox.Width / 3, bezierPictureBox.Height / 3);
			BezierControlPoints[1, 3] = new Point(bezierPictureBox.Width - 5, 5);

			BezierControlPoints[2, 0] = new Point(5, bezierPictureBox.Height - 5);
			BezierControlPoints[2, 1] = new Point(bezierPictureBox.Width / 3, 2 * bezierPictureBox.Height / 3);
			BezierControlPoints[2, 2] = new Point(2 * bezierPictureBox.Width / 3, bezierPictureBox.Height / 3);
			BezierControlPoints[2, 3] = new Point(bezierPictureBox.Width - 5, 5);

			BezierControlPoints[3, 0] = new Point(5, 551);
			BezierControlPoints[3, 1] = new Point(425, 551);
			BezierControlPoints[3, 2] = new Point(522, 551);
			BezierControlPoints[3, 3] = new Point(565, 58);

			for (int i = 0; i < 4; i++)
			{
				CalculateBeziers(i);
			}
			bezierPictureBox.Invalidate();
		}

		private void gcrButton_Click(object sender, EventArgs e)
		{
			BezierControlPoints[0, 0] = new Point(5, bezierPictureBox.Height - 5);
			BezierControlPoints[0, 1] = new Point(bezierPictureBox.Width / 3, 2 * bezierPictureBox.Height / 3);
			BezierControlPoints[0, 2] = new Point(2 * bezierPictureBox.Width / 3, bezierPictureBox.Height / 3);
			BezierControlPoints[0, 3] = new Point(bezierPictureBox.Width - 5, 5);

			BezierControlPoints[1, 0] = new Point(5, bezierPictureBox.Height - 5);
			BezierControlPoints[1, 1] = new Point(bezierPictureBox.Width / 3, 2 * bezierPictureBox.Height / 3);
			BezierControlPoints[1, 2] = new Point(2 * bezierPictureBox.Width / 3, bezierPictureBox.Height / 3);
			BezierControlPoints[1, 3] = new Point(bezierPictureBox.Width - 5, 5);

			BezierControlPoints[2, 0] = new Point(5, bezierPictureBox.Height - 5);
			BezierControlPoints[2, 1] = new Point(bezierPictureBox.Width / 3, 2 * bezierPictureBox.Height / 3);
			BezierControlPoints[2, 2] = new Point(2 * bezierPictureBox.Width / 3, bezierPictureBox.Height / 3);
			BezierControlPoints[2, 3] = new Point(bezierPictureBox.Width - 5, 5);

			BezierControlPoints[3, 0] = new Point(5, 551);
			BezierControlPoints[3, 1] = new Point(371, 551);
			BezierControlPoints[3, 2] = new Point(535, 347);
			BezierControlPoints[3, 3] = new Point(565, 37);

			for (int i = 0; i < 4; i++)
			{
				CalculateBeziers(i);
			}
			bezierPictureBox.Invalidate();
		}
	}
}
