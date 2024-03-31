using System.Text.Json;
using Otus.Hw._4.Reflection.Models;

namespace Otus.Hw._4.Reflection.Service;

public static class TimeTest
{
    public static void Serialization(object testClass, int count, bool needConsole = false)
    {
        var serialiseTypes = new List<SerializeType>
        {
            SerializeType.SerializeCustomSimple, //warmup
            SerializeType.SerializeCustomSimple,
            SerializeType.SerializeCustomRecursive, //warmup
            SerializeType.SerializeCustomRecursive,
            SerializeType.SerializeSystemText, //warmup
            SerializeType.SerializeSystemText
        };

        var durations = new List<double>();

        foreach (var type in serialiseTypes)
        {
            var startTime = DateTimeOffset.Now;

            for (var i = 0; i < count; i++)
            {
                var serializedClassTimed = SerializeSelector(testClass, type);

                if (needConsole)
                {
                    Console.WriteLine(serializedClassTimed);
                }
            }

            var endTime = DateTimeOffset.Now;
            var duration = endTime - startTime;

            durations.Add(duration.TotalMilliseconds);
        }

        for (var index = 0; index < durations.Count; index++)
        {
            var duration = durations[index];
            Console.WriteLine($"{count}, type: {serialiseTypes[index]}, duration: {duration} ms");
        }
    }

    public static async Task Deserialization(string fileName, int count)
    {
        var deserializeTypes = new List<DeserializeType>
        {
            DeserializeType.DeserializeCustom, //warmup
            DeserializeType.DeserializeCustom,
            DeserializeType.DeserializeSystemText, //warmup
            DeserializeType.DeserializeSystemText
        };

        var durations = new List<double>();

        var obj = await File.ReadAllTextAsync(fileName);

        foreach (var type in deserializeTypes)
        {
            var startTime = DateTimeOffset.Now;

            for (var i = 0; i < count; i++)
            {
                var deserializedClassTimed = DeserializeSelector<TestClass>(obj, type);
            }

            var endTime = DateTimeOffset.Now;
            var duration = endTime - startTime;

            durations.Add(duration.TotalMilliseconds);
        }

        for (var index = 0; index < durations.Count; index++)
        {
            var duration = durations[index];
            Console.WriteLine($"{count}, type: {deserializeTypes[index]}, duration: {duration} ms");
        }
    }

    private static string SerializeSelector(object obj, SerializeType type)
    {
        switch (type)
        {
            case SerializeType.SerializeCustomSimple:
                return CustomSerializer.SimpleSerialize(obj);
            case SerializeType.SerializeCustomRecursive:
                return CustomSerializer.SerializeToJson(obj);
            case SerializeType.SerializeSystemText:
                return JsonSerializer.Serialize(obj);
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }

    private static T? DeserializeSelector<T>(string obj, DeserializeType type)
        where T : class, new()
    {
        switch (type)
        {
            case DeserializeType.DeserializeCustom:
                return CustomSerializer.DeserializeSimpleJson<T>(obj);
            case DeserializeType.DeserializeSystemText:
                return JsonSerializer.Deserialize<T>(obj);
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}