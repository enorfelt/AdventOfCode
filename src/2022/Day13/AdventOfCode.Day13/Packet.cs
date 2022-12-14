using System.Text.Json.Nodes;

namespace AdventOfCode.Day13;

public class Packet : IComparable<Packet>
{
	private readonly string packetData;
	private enum CompareResult { None, InOrder, NotInOrder };

	public Packet(string packetData, bool isDivider = false)
	{
		this.packetData = packetData;
		IsDivider = isDivider;
	}

	public JsonNode? PacketData => JsonNode.Parse(packetData ?? "[]");

	public bool IsDivider { get; }

	public int CompareTo(Packet? other)
	{
		var result = Compare(other);
		return result == CompareResult.InOrder ? -1 : 1;
	}

	private CompareResult Compare(Packet? other)
	{
		return Compare(PacketData?.AsArray(), other?.PacketData?.AsArray(), 0);
	}

	private CompareResult Compare(JsonArray? left, JsonArray? right, int i)
	{
		if (left?.Count == i && right?.Count == i)
		{
			return CompareResult.None;
		}

		if (left?.Count == i && right?.Count > i)
		{
			return CompareResult.InOrder;
		}

		if (left?.Count > i && right?.Count == i)
		{
			return CompareResult.NotInOrder;
		}

		if (left[i] is JsonValue && right[i] is JsonValue)
		{
			var leftValue = left[i].GetValue<int>();
			var rightValue = right[i].GetValue<int>();
			if (leftValue < rightValue)
			{
				return CompareResult.InOrder;
			}
			else if (leftValue > rightValue)
			{
				return CompareResult.NotInOrder;
			}
		}
		else if (left[i] is JsonArray && right[i] is JsonArray)
		{
			var result = Compare(left[i].AsArray(), right[i].AsArray(), 0);
			if (result != CompareResult.None)
			{
				return result;
			}
		}
		else if (left[i] is JsonValue && right[i] is JsonArray)
		{
			var array = JsonNode.Parse($"[{left[i].GetValue<int>()}]");
			var result = Compare(array.AsArray(), right[i].AsArray(), 0);
			if (result != CompareResult.None)
			{
				return result;
			}
		}
		else if (left[i] is JsonArray && right[i] is JsonValue)
		{
			var array = JsonNode.Parse($"[{right[i].GetValue<int>()}]");
			var result = Compare(left[i].AsArray(), array.AsArray(), 0);
			if (result != CompareResult.None)
			{
				return result;
			}
		}


		return Compare(left, right, ++i);
	}
}
