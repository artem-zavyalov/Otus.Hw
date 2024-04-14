using System.Collections;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Otus.Hw._4.Reflection.Service;

public static class CustomSerializer
{
    private const char ValueSeparator = ',';
    private static StringBuilder _stringBuilder = null!;

    public static string SerializeToCsv(object obj, char separator = ';', bool includeHeaders = true)
    {
        var objType = obj.GetType();
        var properties = objType.GetProperties();
        _stringBuilder = new StringBuilder();

        if (includeHeaders)
        {
            var propertyNames = properties.Select(x => x.Name);
            _stringBuilder.AppendJoin(separator, propertyNames);
        }

        _stringBuilder.AppendLine();

        var propertyValues = properties.Select(x => x.GetValue(obj));
        _stringBuilder.AppendJoin(separator, propertyValues);

        return _stringBuilder.ToString();
    }

    public static string SimpleSerialize(object obj)
    {
        _stringBuilder = new StringBuilder();

        var objType = obj.GetType();
        var properties = objType.GetProperties();

        _stringBuilder.Append('{');

        var firsIteration = true;

        foreach (var property in properties)
        {
            if (!firsIteration)
            {
                _stringBuilder.Append(ValueSeparator);
            }

            firsIteration = false;

            _stringBuilder.Append($"\"{property.Name}\":");

            var value = property.GetValue(obj);

            _stringBuilder.Append(value);
        }

        _stringBuilder.Append('}');

        return _stringBuilder.ToString();
    }

    public static T DeserializeSimpleJson<T>(string obj)
        where T : class, new()
    {
        var objType = typeof(T);
        var properties = objType.GetProperties();

        T result = new();
        obj = Regex.Replace(obj, "\n|\r", String.Empty);

        foreach (var property in properties)
        {
            var name = $"\"{property.Name}\":";
            var nameEndPosition = obj.IndexOf(name, StringComparison.InvariantCultureIgnoreCase) + name.Length;
            var valueString = FindValueString(obj, nameEndPosition);

            var valueInt = Int32.Parse(valueString);
            property.SetValue(result, valueInt);
        }

        return result;
    }

    private static string FindValueString(string s, int startPosition)
    {
        var braceIndex = s.IndexOf('{', startPosition);
        var bracketIndex = s.IndexOf('[', startPosition);
        var comaIndex = s.IndexOf(',', startPosition);

        var isArray = false;
        var isBraceValue = false;
        var startIndex = startPosition;
        var endIndex = s.Length - 1;

        if (bracketIndex < braceIndex && bracketIndex < comaIndex && bracketIndex > 0)
        {
            isArray = true;
            startIndex = bracketIndex;
            endIndex = s.IndexOf(']', bracketIndex);
        }
        else if (braceIndex < comaIndex && braceIndex > 0)
        {
            isBraceValue = true;
            startIndex = braceIndex;
            endIndex = s.IndexOf('}', braceIndex);

            if (endIndex == s.Length)
            {
                endIndex--;
            }
        }
        else if (comaIndex > 0)
        {
            endIndex = comaIndex;
        }

        var result = s.Substring(startIndex, endIndex - startIndex);

        return result;
    }

    public static string SerializeToJson(object obj)
    {
        _stringBuilder = new StringBuilder();
        RecursiveGetProperties(obj);

        return _stringBuilder.ToString();
    }

    private static void RecursiveGetProperties(object obj)
    {
        var objType = obj.GetType();
        var properties = objType.GetProperties();

        _stringBuilder.Append('{');

        var firstIteration = true;

        foreach (var property in properties)
        {
            if (!firstIteration)
            {
                _stringBuilder.Append(ValueSeparator);
            }

            firstIteration = false;
            _stringBuilder.Append($"\"{property.Name}\":");

            var value = property.GetValue(obj);
            var valueTypeName = value?.GetType().Name;

            if (value is IEnumerable values && valueTypeName != "String")
            {
                _stringBuilder.Append('[');

                foreach (var val in values)
                {
                    if (val.GetType().IsClass)
                    {
                        RecursiveGetProperties(val);
                    }
                    else
                    {
                        AppendValue(val);
                        _stringBuilder.Append(ValueSeparator);
                    }
                }

                _stringBuilder.Append(']');
                _stringBuilder.Append(ValueSeparator);
            }
            else
            {
                AppendValue(value!);
            }
        }

        _stringBuilder.Append('}');
    }

    private static void AppendValue(object value)
    {
        if (IsNumeric(value))
        {
            _stringBuilder.Append(ParseAsNumeric(value));
        }
        else if (value is string)
        {
            _stringBuilder.Append($"\"{value}\"");
        }
        else
        {
            _stringBuilder.Append(value);
        }
    }

    private static string ParseAsNumeric(object value)
    {
        return value.GetType().Name switch
        {
            "Double" => ((double) value).ToString(CultureInfo.InvariantCulture),
            "Decimal" => ((decimal) value).ToString(CultureInfo.InvariantCulture),
            "Float" => ((float) value).ToString(CultureInfo.InvariantCulture),
            _ => value.ToString()!
        };
    }

    private static bool IsNumeric(object value)
    {
        return value.GetType().Name is "Double" or "Decimal" or "Float";
    }
}