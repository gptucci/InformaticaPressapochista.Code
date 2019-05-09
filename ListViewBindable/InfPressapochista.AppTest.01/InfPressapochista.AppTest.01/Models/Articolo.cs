using System;

namespace InfPressapochista.AppTest01.Models
{
	public class Articolo
	{
		public Articolo()
		{
			CodArt = string.Empty;
			Descrizione = string.Empty;
		}

		public string CodArt { get; set; }
		public string Descrizione { get; set; }
	}
}

