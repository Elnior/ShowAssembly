namespace Shower.Utils 
{
	public static class NameProccessor
	{
		public static string getName(string direction)
		{
			string reverseName = "", name = "";
			int lastIndex = direction.Length - 1;
			// Necesary conditional..
			if (lastIndex < 0)
				return null;
			else 
			{
				reverseName += new string( new char[]{ direction[lastIndex--] } );
				while (lastIndex > -1)
				{
					char actual = direction[lastIndex--];
					if (actual != '/' && actual != '\\')
						reverseName += new string( new char[]{ actual } );
					else break;
				}
			}
			lastIndex = reverseName.Length - 1;
			while (lastIndex > -1)
				name += new string( new char[]{ reverseName[lastIndex--] } );
			return name;
		}
	}
}