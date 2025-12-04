using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WpfBaseApp.Interfaces
{
    public interface INavigationParameters : IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable
    {
        object? GetValue(string key);

        T GetValue<T>(string key);
    }
}
