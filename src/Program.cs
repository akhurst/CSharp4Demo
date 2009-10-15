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
			// Hello World in C#
			Console.WriteLine("Hello World from C#");

			// Hello World in Ruby
			ScriptEngine ruby = Ruby.CreateEngine();
			ruby.Execute("puts 'Hello World from Ruby'");

			// Execute Ruby Method
			ScriptScope rubyRuntime = Ruby.CreateRuntime().UseFile("..\\..\\RubyFile.rb");
			dynamic rubyObject = rubyRuntime.Engine.Execute("p = RubyClass.new");
			rubyObject.print_message("This string was passed into a Ruby method");

			// Optional and Named Parameters
			var person = new Person();
			person.OldPrintPerson("Allen", "Hurst");
			person.NewPrintPerson("Allen");
			person.NewPrintPerson("Allen", city: "Bryan");

			// Covariance and Contravariance

			// Arrays are unsafely covariant
			string[] stringArray = { "a", "b", "c" };
			Process(stringArray);

			// C# generic collections are historically invariant
			// C# 4 has safe covariance
			IEnumerable<string> stringList = stringArray;
			ProcessEnumerable(stringList);

			// C# 4 safe covariance with delegates
			Func1<Aggie> aggieCreator = () => new Aggie();
			Func1<Person> personCreator = aggieCreator;

			// C# 4 safe contravariance with delegates
			Action1<Person> personPrinter = p => Console.WriteLine(p);
			Action1<Aggie> aggiePrinter = personPrinter;

			Console.ReadLine();
		}

		delegate T Func1<out T>();
		delegate void Action1<in T>(T a);

		static void Process(IList<object> objects)
		{
			objects[0] = "z";
			objects[1] = DateTime.MinValue;
		}

		static void ProcessEnumerable(IEnumerable<object> objects)
		{
			var enumerator = objects.GetEnumerator();
			enumerator.MoveNext();
			//enumerator.Current = "yo";
		}

		public class Aggie : Person
		{
			
		}

		public class Person
		{
			public void NewPrintPerson(string firstName = "", string lastName = "", string city = "", string state = "")
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