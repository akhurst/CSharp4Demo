using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp4Demo
{
	public static class Extensions
	{
		public static string MyToString(this int i)
		{
			return "Number " + i;
		}

		public static string NullSafeToString(this string s)
		{
			if (s != null)
			{
				return s.ToString();
			}
			else
			{
				return "String is null";
			}
		}
	}
}
