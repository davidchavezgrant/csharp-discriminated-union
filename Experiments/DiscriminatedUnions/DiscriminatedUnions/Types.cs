using System.Reflection;

// ReSharper disable InconsistentNaming

public class Enumeration<TEnum>: IEquatable<Enumeration<TEnum>> where TEnum: Enumeration<TEnum>
{
	private static readonly Dictionary<int, TEnum> Enumerations = CreateEnumerations();

	protected Enumeration(int value, string name)
	{
		this.Value = value;
		this.Name  = name;
	}

	public int Value { get; protected init; }

	public string Name { get; protected init; } = string.Empty;

	/// <inheritdoc/>
	public bool Equals(Enumeration<TEnum>? other)
	{
		if (other is null)
			return false;

		return this.GetType() == other.GetType() && this.Value == other.Value;
	}

	public bool CanBe(TEnum value) => (this.Value & value.Value) == value.Value;

	private static Dictionary<int, TEnum> CreateEnumerations()
	{
		var enumType = typeof(TEnum);
		var fieldsForType = enumType
							.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
							.Where(fieldInfo => enumType.IsAssignableFrom(fieldInfo.FieldType))
							.Select(fieldInfo => (TEnum)fieldInfo.GetValue(default)!);
		return fieldsForType.ToDictionary(x => x.Value);
	}

	/// <inheritdoc/>
	public override bool Equals(object? obj) => obj is Enumeration<TEnum> other && this.Equals(other);

	public static TEnum? FromName(string name) => Enumerations.Values.SingleOrDefault(e => e.Name == name);

	public static TEnum? FromValue(int value) =>
		Enumerations.TryGetValue(value, out var enumeration)? enumeration : default;

	/// <inheritdoc/>
	public override int GetHashCode() => this.Value.GetHashCode();

	public static TEnum operator &(Enumeration<TEnum> left, Enumeration<TEnum> right)
	{
		var newName  = $"({left.Name}) and ({right.Name})";
		if (left.Value == right.Value) newName = left.Name;
		int newValue = left.Value & right.Value;
		var cons     = typeof(TEnum).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
		var onj = cons[0]
					  .Invoke(new object[]
					  {
						  newValue,
						  newName
					  }) as TEnum;
		return onj;
	}

	public static TEnum operator |(Enumeration<TEnum> left, Enumeration<TEnum> right)
	{
		var newName     = $"({left.Name}) or ({right.Name})";
		int newValue    = left.Value | right.Value;
		var constructor = typeof(TEnum).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
		var newInstance = constructor[0]
							  .Invoke(new object[]
							  {
								  newValue,
								  newName
							  }) as TEnum;
		return newInstance;
	}

	public override string ToString() => this.Name;
}

public class CreditCard: Enumeration<CreditCard>
{
	public static readonly CreditCard STANDARD = new Standard();
	public static readonly CreditCard PREMIUM  = new Premium();
	public static readonly CreditCard PLATINUM = new Platinum();

	/// <inheritdoc/>
	private CreditCard(int value, string name): base(value, name) {}

	public virtual double Discount { get; }

	private sealed class Platinum: CreditCard
	{
		public Platinum(): base(4, nameof(Platinum)) {}

		public override double Discount => 0.10;
	}

	private sealed class Premium: CreditCard
	{
		public Premium(): base(2, nameof(Premium)) {}

		public override double Discount => 0.05;
	}

	private sealed class Standard: CreditCard
	{
		public Standard(): base(1, nameof(Standard)) {}

		public override double Discount => 0.01;
	}
}