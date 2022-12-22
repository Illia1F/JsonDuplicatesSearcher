using FastColoredTextBoxNS;
using JsonDuplicatesSearcher.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonDuplicatesSearcher.Controls
{
    public partial class JsonTextBox : UserControl
    {
        public JsonTextBox()
        {
            InitializeComponent();
            SetJsonLanguage();
        }

        public JsonElements GetJsonElements()
        {
            return new JsonElements(fctb.TextSource.BuildString());
        }

        public void SetJson(JsonElement[] jsonElements)
        {
            ThrowHelper.ThrowArgumentNullExIfNull(
                argument: jsonElements,
                paramName: nameof(jsonElements),
                message: "Json cannot be Null");

            ThrowHelper.ThrowArgumentExIfEmpty(
                array: jsonElements,
                paramName: nameof(jsonElements),
                message: "Json cannot be empty");

            SetTextSource(jsonElements);
        }

        private void SetJsonLanguage()
        {
            fctb.Language = Language.JSON;
            fctb.SyntaxHighlighter.StringStyle = new TextStyle(Brushes.Brown, null, FontStyle.Regular);
            SyntaxHighlight();
        }

        private void SetTextSource(JsonElement[] jsonElements)
        {
            fctb.TextSource.Clear();
            fctb.TextSource.AddJsonElements(jsonElements);

            SyntaxHighlight();
        }

        private void SyntaxHighlight()
        {
            fctb.OnSyntaxHighlight(new TextChangedEventArgs(fctb.Range));
        }
    }

    public class JsonElements : IEnumerable<JsonElement>
    {
        private List<Dictionary<string, object>> _jsonData;
        private List<JsonElement> _elements;
        private readonly string _originJson;
        public JsonElements(string json) 
        {
            ThrowHelper.ThrowArgumentNullExIfNull(json, nameof(json));

            ThrowHelper.ThrowArgumentExIfEmpty(
                str: json,
                paramName: nameof(_jsonData),
                message: "Json has not been entered");

            _originJson = json;
        }

        public async Task BuildAsync()
        {
            _jsonData = await Task.Run(() => JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(_originJson));

            ThrowHelper.ThrowArgumentNullExIfNull(
                argument: _jsonData,
                paramName: nameof(_jsonData),
                message: "Smth went wrong so that cannot convert entered json");

            _elements = _jsonData
                .Select(e => new JsonElement(e))
                .ToList();
        }

        public JsonElement[] SearchForDuplicates(params string[] comparisonFields)
        {
            var uniqueList = new List<JsonElement>();
            var duplicates = new List<JsonElement>();
            foreach (Dictionary<string, object> values in _jsonData)
            {
                var jsonElement = new JsonElement(values);

                bool duplicateExists = uniqueList.Any(uniqueItem => jsonElement.Equals(uniqueItem, comparisonFields));

                if (duplicateExists)
                {
                    duplicates.Add(jsonElement);
                }
                else
                {
                    uniqueList.Add(jsonElement);
                }
            }

            return duplicates.ToArray();
        }

        public int Count
        {
            get { return _jsonData.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public virtual JsonElement this[int i]
        {
            get { return _elements[i]; }
        }

        public IEnumerator<JsonElement> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (_elements as IEnumerator);
        }
    }

    public class JsonElement : IEquatable<JsonElement>
    {
        private string _elementJson;
        private readonly Dictionary<string, object> _data;
        internal JsonElement(Dictionary<string, object> data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public string Json
        {
            get
            {
                if (string.IsNullOrEmpty(_elementJson))
                    _elementJson = JsonConvert.SerializeObject(_data, Formatting.Indented);

                return _elementJson;
            }
        }

        public IEnumerable<string> Fields => _data.Keys.AsEnumerable();

        public object GetValue(string key)
        {
            return _data[key];
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is not JsonElement element)
                return false;

            return Equals(element);
        }

        public bool Equals(JsonElement other)
        {
            return Equals(other, Fields);
        }

        public bool Equals(JsonElement element, string[] comparisonFields)
        {
            CheckIsFieldsExists(comparisonFields);

            int comparisonFieldsCount = comparisonFields.Length;
            
            int successfulComparisons = comparisonFields.Count(field =>
            {
                object value1 = GetValue(field);
                object value2 = element.GetValue(field);

                return (value1?.Equals(value2)) ?? (value1 == value2);
            });

            return successfulComparisons == comparisonFieldsCount;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_data.Select(d => d.Value).ToString());
        }

        private void CheckIsFieldsExists(string[] fields)
        {
            IEnumerable<string> existingFields = _data.Keys.AsEnumerable();
            for (int i = 0; i < fields.Length; i++)
            {
                string field = fields[i];
                if (!existingFields.Contains(field))
                    throw new ArgumentException($"Wrong comparison fields have been passed \"{field}\"", nameof(fields));
            }
        }
    }
}