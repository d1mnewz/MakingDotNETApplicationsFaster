using MakingDotNETApplicationsFaster.Infrastructure;

namespace MakingDotNETApplicationsFaster
{
	internal sealed class StructEqualityRunner : IRunner
	{
		public void Run()
		{
			var a = new StructWithNoRefType();
			var b = new StructWithNoRefType();

			var c = new StructWithRefType();
			var d = new StructWithRefType();

			var x = new StructWithRefTypeAndOverridenEquals();
			var y = new StructWithRefTypeAndOverridenEquals();

			new PerformanceTests
			{
				{_ => { CompareStructsWithNoRefTypes(a, b); }, "CompareStructsWithNoRefTypes"},
				{_ => { CompareStructsWithRefTypes(c, d); }, "CompareStructsWithRefTypes"},
				{_ => { CompareStructsWithRefTypesAndOverridenEquals(x, y); }, "CompareStructsWithRefTypesAndOverridenEquals"}
			}.Run(10000000);
		}

		private static bool CompareStructsWithNoRefTypes(StructWithNoRefType a, StructWithNoRefType b)
		{
			return a.Equals(b);
		}

		private static bool CompareStructsWithRefTypes(StructWithRefType c, StructWithRefType d)
		{
			return c.Equals(d);
		}

		private static bool CompareStructsWithRefTypesAndOverridenEquals(StructWithRefTypeAndOverridenEquals x, StructWithRefTypeAndOverridenEquals y)
		{
			return x.Equals(y);
		}
	}
}