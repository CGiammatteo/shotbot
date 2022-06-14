using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shotbot.Misc
{
    internal class ColorStuff
    {
		public static int[] ConvertColor(string coll)
		{
			string[] split = coll.Split(',');
			int[] result = new int[split.Length];
			for (int i = 0; i < split.Length; i++)
			{
				string[] split2 = split[i].Split('=');
				result[i] = int.Parse(split2[1].Replace("]", string.Empty));
			}
			return result;
		}
	}
}
