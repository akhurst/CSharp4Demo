using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IronRuby;
using Microsoft.Scripting.Hosting;

namespace CSharp4Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			// C#

			// 1.0 - .NET Debut
			// 2.0 - adding features
			// 3.0 - LINQ
			// 4.0 - Dynamic

			// Trends
			// Declarative
			// Dynamic
			// Concurrency
			// Polyglot
			// Meta/DSL

			// Hello World in C#
			Console.WriteLine("Hello World in C#");

			// Hello World in Ruby
			Ruby.CreateEngine().Execute("puts 'Hello World in Ruby'");

			// Execute Ruby Method
			var rubyRuntime = Ruby.CreateRuntime().UseFile("..\\..\\RubyFile.rb");
			dynamic rubyObject = rubyRuntime.Engine.Execute("p = RubyClass.new");
			rubyObject.print_message("This was passed to a ruby method");

			// Optional and Named Parameters
			var person = new Person();
			person.NewPrintPerson("Allen", city:"Bryan");

			// Covariance and Contravariance
			string[] stringArray = {"1", "2", "3"};
			IList<string> stringList = stringArray;
			Process(stringList);

			// C# 4 safe covariance with delegates
			Func1<Aggie> aggieCreator = () => new Aggie();
			Func1<Person> personCreator = aggieCreator;

			// C# 4 safe contravariance with delegates
			Action1<Person> personPrinter = delegate(Person p)
			                                	{
			                                		Console.WriteLine(p);
			                                	};

			Action1<Aggie> aggiePrinter = personPrinter;

			

			aggiePrinter(new Aggie());

			// LINQ

			List<Aggie> aggieList = new List<Aggie>();

			for (int i = 0; i < 10;i++ )
			{
				aggieList.Add(new Aggie{Name = "Person "+i});
			}

			var persons2 = from a in aggieList
			               where a.Name == "Person 2"
			               select a;
			Console.WriteLine(persons2.Count());

		// Extension methods

			persons2 = aggieList.FindAll(a => a.Name == "Person 2");

			Console.WriteLine(persons2.Count());

			string s = null;

			Console.WriteLine(s.NullSafeToString());

			Console.WriteLine(1.MyToString());

				Console.ReadLine();
		}

		delegate T Func1<out T>();
		delegate void Action1<in T>(T a);

		public static void Process(IEnumerable<object> objects)
		{
		}

		public class Aggie : Person
		{
			public string Name
			{
				get; set;
			}
		}

		public class Person
		{
			public void NewPrintPerson(string firstName="", string lastName="", string city="", string state="")
			{
				Console.WriteLine(string.Format("{0} {1} {2} {3}", firstName, lastName, city, state));
			}

			public void OldPrintPerson(string firstName)
			{
				OldPrintPerson(firstName, string.Empty, string.Empty, string.Empty);
			}

			public void OldPrintPerson(string firstName, string lastName)
			{
				OldPrintPerson(firstName, lastName, string.Empty, string.Empty);
			}

			public void OldPrintPerson(string firstName, string lastName, string city)
			{
				OldPrintPerson(firstName, lastName, city, string.Empty);
			}

			public void OldPrintPerson(string firstName, string lastName, string city, string state)
			{
				Console.WriteLine(string.Format("{0} {1} {2} {3}", firstName, lastName, city, state));
			}

		}
	}
}